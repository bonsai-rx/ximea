using xiApi;

namespace Bonsai.Ximea
{
    /// <summary>
    /// Specifies the image data format of a decoded XIMEA frame.
    /// </summary>
    public enum ImageFormat
    {
        /// <summary>  
        /// 8 bits per pixel. [Intensity]  
        /// </summary>
        Mono8 = XI_IMG_FORMAT.MONO8,

        /// <summary>
        /// 16 bits per pixel. [Intensity LSB] [Intensity MSB]
        /// </summary>  

        Mono16 = XI_IMG_FORMAT.MONO16,

        /// <summary>  
        /// RGB data format. [Blue][Green][Red]
        /// </summary>  
        Rgb24 = XI_IMG_FORMAT.RGB24,

        /// <summary>  
        /// RGBA data format. [Blue][Green][Red][0]
        /// </summary>  
        Rgb32 = XI_IMG_FORMAT.RGB32,

        /// <summary>  
        /// RGB planar data format. [Red][Red]...[Green][Green]...[Blue][Blue]...
        /// </summary>  
        RgbPlanar = XI_IMG_FORMAT.RGBPLANAR,

        /// <summary>  
        /// 8 bits per pixel raw data from sensor. [pixel byte] raw data from transport camera
        /// output
        /// </summary>  
        Raw8 = XI_IMG_FORMAT.RAW8,

        /// <summary>  
        /// 16 bits per pixel raw data from sensor. [pixel byte low] [pixel byte high] 16
        /// bits (depacked) raw data
        /// </summary>  
        Raw16 = XI_IMG_FORMAT.RAW16,

        /// <summary>  
        /// Data from transport layer (e.g. packed). Depends on data on the transport layer
        /// </summary>  
        FrmTransportData = XI_IMG_FORMAT.FRM_TRANSPORT_DATA,

        /// <summary>  
        /// RGB data format. [Blue low byte][Blue high byte][Green low][Green high][Red low][Red
        /// high]
        /// </summary>  
        Rgb48 = XI_IMG_FORMAT.RGB48,

        /// <summary>  
        /// RGBA data format. [Blue low byte][Blue high byte][Green low][Green high][Red
        /// low][Red high][0][0]
        /// </summary>  
        Rgb64 = XI_IMG_FORMAT.RGB64,

        /// <summary>  
        /// RGB16 planar data format
        /// </summary>  
        Rgb16Planar = XI_IMG_FORMAT.RGB16_PLANAR,

        /// <summary>  
        /// 8 bits per pixel raw data from sensor (2 components in a row). [ch1 pixel byte]
        /// [ch2 pixel byte] 8 bits raw data from 2 channels (e.g. high gain and low gain
        /// channels of sCMOS cameras)
        /// </summary>  
        Raw8X2 = XI_IMG_FORMAT.RAW8X2,

        /// <summary>  
        /// 8 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        /// [ch2 pixel byte] [ch3 pixel byte] [ch4 pixel byte] 8 bits raw data from 4 channels
        /// (e.g. sCMOS cameras)
        /// </summary>  
        Raw8X4 = XI_IMG_FORMAT.RAW8X4,

        /// <summary>  
        /// 16 bits per pixel raw data from sensor(2 components in a row). [ch1 pixel byte
        /// low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] 16 bits
        /// (depacked) raw data from 2 channels (e.g. high gain and low gain channels of
        /// sCMOS cameras)
        /// </summary>  
        Raw16X2 = XI_IMG_FORMAT.RAW16X2,

        /// <summary>  
        /// 16 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        /// low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] [ch3 pixel
        /// byte low] [ch3 pixel byte high] [ch4 pixel byte low] [ch4 pixel byte high] 16
        /// bits (depacked) raw data from 4 channels (e.g. sCMOS cameras)
        /// </summary>  
        Raw16X4 = XI_IMG_FORMAT.RAW16X4,

        /// <summary>  
        /// 32 bits per pixel raw data from sensor in integer format (LSB first). 4 bytes
        /// (LSB first) pixel (depacked) raw data
        /// </summary>  
        XiRaw32 = XI_IMG_FORMAT.XI_RAW32,

        /// <summary>  
        /// 32 bits per pixel raw data from sensor in single-precision floating point format.
        /// 4 bytes per pixel (depacked) raw data
        /// </summary>  
        XiFloat32 = XI_IMG_FORMAT.XI_FLOAT32
    }
}
