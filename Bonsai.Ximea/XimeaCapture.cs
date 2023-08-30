using OpenCV.Net;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using xiApi;
using xiApi.NET;

namespace Bonsai.Ximea
{
    [Description("Acquires a sequence of images from a Ximea camera.")]
    public class XimeaCapture : Source<XimeaDataFrame>
    {
        static readonly object systemLock = new object();

        [TypeConverter(typeof(SerialNumberConverter))]
        [Description("The serial number of the camera from which to acquire images.")]
        public string SerialNumber { get; set; }

        [Description("The timeout duration, in milliseconds, when waiting for new frames to arrive.")]
        public int Timeout { get; set; } = 1000000;

        [Description("Exposure time of each frame, in microseconds.")]
        public int Exposure { get; set; } = 2000;

        [Description("Gain configuration, in dB.")]
        public float Gain { get; set; } = 5;

        [Description("Image format, by default MONO8 mode (0) will be used.")]
        public PixelFormat PixelFormat { get; set; } = PixelFormat.Mono8;

        protected virtual void Configure(xiCam camera)
        {
            camera.SetParam(PRM.EXPOSURE, Exposure);
            camera.SetParam(PRM.GAIN, Gain);
            camera.SetParam(PRM.IMAGE_DATA_FORMAT, (int)PixelFormat);
        }

        public override IObservable<XimeaDataFrame> Generate()
        {
            return Generate(Observable.Return(Unit.Default));
        }

        public IObservable<XimeaDataFrame> Generate<TSource>(IObservable<TSource> start)
        {
            return Observable.Create<XimeaDataFrame>((observer, cancellationToken) =>
            {
                xiCam camera;
                camera = new xiCam();
                ImageConverter.GetImageDepth(PixelFormat, out IplDepth depth, out int channels, out PixelFormat pixelFormat);
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
                        using (var cancellation = cancellationToken.Register(camera.StopAcquisition))
                        {
                            XI_IMG img = new XI_IMG();

                            while (!cancellationToken.IsCancellationRequested)
                            {
                                IplImage output;
                                img.Clear();
                                camera.GetXI_IMG(ref img, Timeout);
                                unsafe
                                {
                                    output = new IplImage(
                                        new Size(img.width, img.height),
                                        depth,
                                        channels,
                                        new IntPtr(img.bp));
                                }
                                observer.OnNext(new XimeaDataFrame(output.Clone(), new Metadata(img)));
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
