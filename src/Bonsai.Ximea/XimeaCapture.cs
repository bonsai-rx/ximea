using OpenCV.Net;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using xiApi;
using xiApi.NET;

namespace Bonsai.Ximea
{
    /// <summary>
    /// Represents an operator that generates a sequence of images acquired from
    /// the specified XIMEA camera.
    /// </summary>
    [XmlType(Namespace = Constants.XmlNamespace)]
    [Description("Acquires a sequence of images from a XIMEA camera.")]
    public class XimeaCapture : Source<XimeaDataFrame>
    {
        static readonly object systemLock = new();

        /// <summary>
        /// Gets or sets the serial number of the camera from which to acquire images.
        /// </summary>
        [TypeConverter(typeof(SerialNumberConverter))]
        [Description("The serial number of the camera from which to acquire images.")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the maximum time interval to use when waiting for new frames to
        /// arrive, in milliseconds.
        /// </summary>
        [Description("The maximum time interval to use when waiting for new frames to arrive, in milliseconds.")]
        public int Timeout { get; set; } = 1000000;

        /// <summary>
        /// Gets or sets the exposure time of each frame, in microseconds. If value is within range, the
        /// closest settable value is used.
        /// </summary>
        [Description("The exposure time of each frame, in microseconds.")]
        public int Exposure { get; set; } = 2000;

        /// <summary>
        /// Gets or sets the sensor analog gain, in dB. If value is within range, the closest settable value
        /// is used.
        /// </summary>
        [Description("The sensor analog gain, in dB.")]
        public float Gain { get; set; } = 5;

        /// <summary>
        /// Gets or sets a value specifying the image data format to use for acquisition.
        /// </summary>
        [Description("Specifies the image data format to use for acquisition.")]
        public ImageFormat ImageFormat { get; set; } = ImageFormat.Mono8;

        /// <summary>
        /// Configures the acquisition mode on the selected camera.
        /// </summary>
        /// <param name="camera">The camera to configure.</param>
        protected virtual void Configure(xiCam camera)
        {
            camera.SetParam(PRM.EXPOSURE, Exposure);
            camera.SetParam(PRM.GAIN, Gain);
            camera.SetParam(PRM.IMAGE_DATA_FORMAT, (int)ImageFormat);
        }

        /// <summary>
        /// Generates an observable sequence of images acquired from the specified XIMEA camera.
        /// </summary>
        /// <returns>
        /// A sequence of <see cref="XimeaDataFrame"/> objects representing each frame
        /// decoded from the camera and the metadata object containing additional
        /// information about the image.
        /// </returns>
        public override IObservable<XimeaDataFrame> Generate()
        {
            return Generate(Observable.Return(Unit.Default));
        }

        /// <summary>
        /// Generates an observable sequence of images acquired from the specified XIMEA
        /// camera, where the start of acquisition is controlled by the input sequence.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="start"/> sequence.
        /// </typeparam>
        /// <param name="start">
        /// The sequence containing the notification used to start reading images
        /// from the Spinnaker camera.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="XimeaDataFrame"/> objects representing each frame
        /// decoded from the camera and the metadata object containing additional
        /// information about the image.
        /// </returns>
        public IObservable<XimeaDataFrame> Generate<TSource>(IObservable<TSource> start)
        {
            return Observable.Create<XimeaDataFrame>((observer, cancellationToken) =>
            {
                if (string.IsNullOrEmpty(SerialNumber))
                {
                    throw new InvalidOperationException("The serial number of the camera must be specified.");
                }

                xiCam camera;
                camera = new xiCam();
                ImageConverter.GetImageDepth(ImageFormat, out IplDepth depth, out int channels, out ImageFormat pixelFormat);
                return Task.Factory.StartNew(async () =>
                {
                    lock (systemLock)
                    {
                        camera.OpenDeviceBy(OPEN_BY.OPEN_BY_SN, SerialNumber);
                        Configure(camera);
                        camera.SetParam(PRM.BUFFER_POLICY, BUFF_POLICY.UNSAFE);
                        camera.StartAcquisition();
                    }
                    try
                    {
                        await start;
                        using var cancellation = cancellationToken.Register(camera.StopAcquisition);

                        XI_IMG img = new();
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            img.Clear();
                            camera.GetXI_IMG(ref img, Timeout);
                            unsafe
                            {
                                using var output = new IplImage(new(img.width, img.height), depth, channels, (IntPtr)img.bp);
                                observer.OnNext(new XimeaDataFrame(output.Clone(), new ImageMetadata(ref img)));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                        throw;
                    }
                    finally
                    {
                        camera.StopAcquisition();
                        camera.CloseDevice();
                    }
                });
            });
        }
    }
}
