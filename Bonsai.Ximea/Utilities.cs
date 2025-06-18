using OpenCV.Net;
using System;
using xiApi.NET;

namespace Bonsai.Ximea
{

    public enum PixelFormat
    {
        /// <summary>  
        /// 8 bits per pixel. [Intensity] (see Note5,Note6)  
        /// </summary>
        Mono8 = IMG_FORMAT.MONO8,

        /// <summary>
        ///     16 bits per pixel. [Intensity LSB] [Intensity MSB] (see Note5,Note6)
        /// </summary>  

        Mono16 = IMG_FORMAT.MONO16,

        /// <summary>  
        ///     RGB data format. [Blue][Green][Red] (see Note5)
        /// </summary>  
        Rgb24 = IMG_FORMAT.RGB24,

        /// <summary>  
        ///     RGBA data format. [Blue][Green][Red][0] (see Note5)
        /// </summary>  
        Rgb32 = IMG_FORMAT.RGB32,

        /// <summary>  
        ///     RGB planar data format. [Red][Red]...[Green][Green]...[Blue][Blue]... (see Note5)
        /// </summary>  
        RgbPlanar = IMG_FORMAT.RGBPLANAR,

        /// <summary>  
        ///     8 bits per pixel raw data from sensor. [pixel byte] raw data from transport (camera
        ///     output)
        /// </summary>  
        Raw8 = IMG_FORMAT.RAW8,

        /// <summary>  
        ///     16 bits per pixel raw data from sensor. [pixel byte low] [pixel byte high] 16
        ///     bits (depacked) raw data
        /// </summary>  
        Raw16 = IMG_FORMAT.RAW16,

        /// <summary>  
        ///     Data from transport layer (e.g. packed). Depends on data on the transport layer
        ///     (see Note7)
        /// </summary>  
        FrmTransportData = IMG_FORMAT.FRM_TRANSPORT_DATA,

        /// <summary>  
        ///     RGB data format. [Blue low byte][Blue high byte][Green low][Green high][Red low][Red
        ///     high] (see Note5)
        /// </summary>  
        Rgb48 = IMG_FORMAT.RGB48,

        /// <summary>  
        ///     RGBA data format. [Blue low byte][Blue high byte][Green low][Green high][Red
        ///     low][Red high][0][0] (Note5)
        /// </summary>  
        Rgb64 = IMG_FORMAT.RGB64,

        /// <summary>  
        ///     RGB16 planar data format
        /// </summary>  
        Rgb16Planar = IMG_FORMAT.RGB16_PLANAR,

        /// <summary>  
        ///     8 bits per pixel raw data from sensor(2 components in a row). [ch1 pixel byte]
        ///     [ch2 pixel byte] 8 bits raw data from 2 channels (e.g. high gain and low gain
        ///     channels of sCMOS cameras)
        /// </summary>  
        Raw8X2 = IMG_FORMAT.RAW8X2,

        /// <summary>  
        ///     8 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        ///     [ch2 pixel byte] [ch3 pixel byte] [ch4 pixel byte] 8 bits raw data from 4 channels
        ///     (e.g. sCMOS cameras)
        /// </summary>  
        Raw8X4 = IMG_FORMAT.RAW8X4,

        /// <summary>  
        ///     16 bits per pixel raw data from sensor(2 components in a row). [ch1 pixel byte
        ///     low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] 16 bits
        ///     (depacked) raw data from 2 channels (e.g. high gain and low gain channels of
        ///     sCMOS cameras)
        /// </summary>  
        Raw16X2 = IMG_FORMAT.RAW16X2,

        /// <summary>  
        ///     16 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        ///     low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] [ch3 pixel
        ///     byte low] [ch3 pixel byte high] [ch4 pixel byte low] [ch4 pixel byte high] 16
        ///     bits (depacked) raw data from 4 channels (e.g. sCMOS cameras)
        /// </summary>  
        Raw16X4 = IMG_FORMAT.RAW16X4,

        /// <summary>  
        ///     32 bits per pixel raw data from sensor in integer format (LSB first). 4 bytes
        ///     (LSB first) pixel (depacked) raw data
        /// </summary>  
        XiRaw32 = IMG_FORMAT.XI_RAW32,

        /// <summary>  
        ///     32 bits per pixel raw data from sensor in single-precision floating point format.
        ///     4 bytes per pixel (depacked) raw data
        /// </summary>  
        XiFloat32 = IMG_FORMAT.XI_FLOAT32
    }

    internal class ImageConverter
    {
        public static void GetImageDepth(PixelFormat pixelType, out IplDepth depth, out int channels, out PixelFormat outputFormat)
        {
            switch (pixelType)
            {
                case PixelFormat.Mono8:
                    outputFormat = PixelFormat.Mono8;
                    depth = IplDepth.U8;
                    channels = 1;
                    break;
                case PixelFormat.Mono16:
                    outputFormat = PixelFormat.Mono16;
                    depth = IplDepth.U16;
                    channels = 1;
                    break;
                case PixelFormat.Rgb24:
                    outputFormat = PixelFormat.Rgb24;
                    depth = IplDepth.U8;
                    channels = 3;
                    break;
                case PixelFormat.Rgb48:
                    outputFormat = PixelFormat.Rgb48;
                    depth = IplDepth.U16;
                    channels = 3;
                    break;
                default: throw new ArgumentException("Not supported/implemented ImageFormat type.");
            }
        }
    }
}
