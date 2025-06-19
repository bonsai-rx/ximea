using xiApi;

namespace Bonsai.Ximea
{
    /// <summary>
    /// Represents additional information about an image decoded from a XIMEA camera.
    /// </summary>
    public class ImageMetadata
    {
        internal ImageMetadata(ref XI_IMG img)
        {
            ImageFormat = (ImageFormat)img.frm;
            FrameCount = img.nframe;
            Seconds = img.tsSec;
            MicroSeconds = img.tsUSec;
            GpioLevel = img.GPI_level;
            BlackLevel = img.black_level;
            AbsoluteOffsetX = img.AbsoluteOffsetX;
            AbsoluteOffsetY = img.AbsoluteOffsetY;
            DownsamplingX = img.DownsamplingX;
            DownsamplingY = img.DownsamplingY;
            ExposureTime = img.exposure_time_us;
            Gain = img.gain_db;
            AcquisitionFrameCount = img.acq_nframe;
            WhiteBalanceRed = img.wb_red;
            WhiteBalanceGreen = img.wb_green;
            WhiteBalanceBlue = img.wb_blue;
            HighGainBlackLevel = img.hg_black_level;
            LowGainBlackLevel = img.lg_black_level;
            HighGainRange = img.hg_range;
            LowGainRange = img.lg_range;
            GainRatio = img.gain_ratio;
            FloatDownsamplingX = img.fDownsamplingX;
            FloatDownsamplingY = img.fDownsamplingY;
            ColorFilterArray = (ColorFilterArray)img.color_filter_array;
        }

        /// <summary>
        /// Gets a value specifying the image data format.
        /// </summary>
        public ImageFormat ImageFormat { get; }

        /// <summary>
        /// Gets the internal frame counter. In some cameras it is reset by changes in exposure,
        /// gain, downsampling, or auto exposure.
        /// </summary>
        public int FrameCount { get; }

        /// <summary>
        /// Gets the seconds component of the image timestamp.
        /// </summary>
        public int Seconds { get; }

        /// <summary>
        /// Gets the microseconds component of the image timestamp.
        /// </summary>
        public int MicroSeconds { get; }

        /// <summary>
        /// Gets the state of the digital inputs and outputs of the camera at the time of
        /// exposure. Exact sample time and word bits are specific for each camera model.
        /// </summary>
        public int GpioLevel { get; }

        /// <summary>
        /// Gets the black level of the image. Only used for MONO and RAW formats.
        /// </summary>
        public int BlackLevel { get; }

        /// <summary>
        /// Gets the horizontal offset between the sensor origin and the first image pixel.
        /// </summary>
        public int AbsoluteOffsetX { get; }

        /// <summary>
        /// Gets the vertical offset between the sensor origin and the first image pixel.
        /// </summary>
        public int AbsoluteOffsetY { get; }

        /// <summary>
        /// Gets the horizontal downsampling factor.
        /// </summary>
        public int DownsamplingX { get; }

        /// <summary>
        /// Gets the vertical downsampling factor.
        /// </summary>
        public int DownsamplingY { get; }

        /// <summary>
        /// Gets the exposure time of the image, in microseconds.
        /// </summary>
        public int ExposureTime { get; }

        /// <summary>
        /// Gets the analog gain value for this image, in dB.
        /// </summary>
        public float Gain { get; }

        /// <summary>
        /// Gets the acquisition frame counter. This counter is reset only at the start of acquisition.
        /// </summary>
        public int AcquisitionFrameCount { get; }

        /// <summary>
        /// Gets the red coefficient of the white balance.
        /// </summary>
        public float WhiteBalanceRed { get; }

        /// <summary>
        /// Gets the green coefficient of the white balance.
        /// </summary>
        public float WhiteBalanceGreen { get; }

        /// <summary>
        /// Gets the blue coefficient of the white balance.
        /// </summary>
        public float WhiteBalanceBlue { get; }

        /// <summary>
        /// Gets the black level of the high gain channel. Used only in case of multi gain channel readout.
        /// </summary>
        public int HighGainBlackLevel { get; }

        /// <summary>
        /// Gets the black level of the low gain channel. Used only in case of multi gain channel readout.
        /// </summary>
        public int LowGainBlackLevel { get; }

        /// <summary>
        /// Gets the valid range of the high gain channel. Used only in case of multi gain channel readout.
        /// </summary>
        public int HighGainRange { get; }

        /// <summary>
        /// Gets the valid range of the low gain channel. Used only in case of multi gain channel readout.
        /// </summary>
        public int LowGainRange { get; }

        /// <summary>
        /// Gets the gain ratio for multi gain channel readout.
        /// </summary>
        public float GainRatio { get; }

        /// <summary>
        /// Gets the floating-point horizontal downsampling factor.
        /// </summary>
        public float FloatDownsamplingX { get; }

        /// <summary>
        /// Gets the floating-point horizontal downsampling factor.
        /// </summary>
        public float FloatDownsamplingY { get; }

        /// <summary>
        /// Gets the type of the color filter array applied to RAW data.
        /// </summary>
        public ColorFilterArray ColorFilterArray { get; }
    }
}
