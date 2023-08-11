using OpenCV.Net;
using System;
using xiApi.NET;

namespace Bonsai.Ximea
{

    public enum ImageFormat
    {
        //     8 bits per pixel. [Intensity] (see Note5,Note6)
        Mono8 = IMG_FORMAT.MONO8,

        //     16 bits per pixel. [Intensity LSB] [Intensity MSB] (see Note5,Note6)
        Mono16 = IMG_FORMAT.MONO16,

        //     RGB data format. [Blue][Green][Red] (see Note5)
        Rgb24 = IMG_FORMAT.RGB24,

        //     RGBA data format. [Blue][Green][Red][0] (see Note5)
        Rgb32 = IMG_FORMAT.RGB32,

        //     RGB planar data format. [Red][Red]...[Green][Green]...[Blue][Blue]... (see Note5)
        RgbPlanar = IMG_FORMAT.RGBPLANAR,

        //     8 bits per pixel raw data from sensor. [pixel byte] raw data from transport (camera
        //     output)
        Raw8 = IMG_FORMAT.RAW8,

        //     16 bits per pixel raw data from sensor. [pixel byte low] [pixel byte high] 16
        //     bits (depacked) raw data
        Raw16 = IMG_FORMAT.RAW16,

        //     Data from transport layer (e.g. packed). Depends on data on the transport layer
        //     (see Note7)
        FrmTransportData = IMG_FORMAT.FRM_TRANSPORT_DATA,

        //     RGB data format. [Blue low byte][Blue high byte][Green low][Green high][Red low][Red
        //     high] (see Note5)
        Rgb48 = IMG_FORMAT.RGB48,

        //     RGBA data format. [Blue low byte][Blue high byte][Green low][Green high][Red
        //     low][Red high][0][0] (Note5)
        Rgb64 = IMG_FORMAT.RGB64,

        //     RGB16 planar data format
        Rgb16Planar = IMG_FORMAT.RGB16_PLANAR,

        //     8 bits per pixel raw data from sensor(2 components in a row). [ch1 pixel byte]
        //     [ch2 pixel byte] 8 bits raw data from 2 channels (e.g. high gain and low gain
        //     channels of sCMOS cameras)
        Raw8X2 = IMG_FORMAT.RAW8X2,

        //     8 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        //     [ch2 pixel byte] [ch3 pixel byte] [ch4 pixel byte] 8 bits raw data from 4 channels
        //     (e.g. sCMOS cameras)
        Raw8X4 = IMG_FORMAT.RAW8X4,

        //     16 bits per pixel raw data from sensor(2 components in a row). [ch1 pixel byte
        //     low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] 16 bits
        //     (depacked) raw data from 2 channels (e.g. high gain and low gain channels of
        //     sCMOS cameras)
        Raw16X2 = IMG_FORMAT.RAW16X2,

        //     16 bits per pixel raw data from sensor(4 components in a row). [ch1 pixel byte
        //     low] [ch1 pixel byte high] [ch2 pixel byte low] [ch2 pixel byte high] [ch3 pixel
        //     byte low] [ch3 pixel byte high] [ch4 pixel byte low] [ch4 pixel byte high] 16
        //     bits (depacked) raw data from 4 channels (e.g. sCMOS cameras)
        Raw16X4 = IMG_FORMAT.RAW16X4,

        //     32 bits per pixel raw data from sensor in integer format (LSB first). 4 bytes
        //     (LSB first) pixel (depacked) raw data
        XiRaw32 = IMG_FORMAT.XI_RAW32,

        //     32 bits per pixel raw data from sensor in single-precision floating point format.
        //     4 bytes per pixel (depacked) raw data
        XiFloat32 = IMG_FORMAT.XI_FLOAT32
    }

    internal class ImageConverter
    {
        public static void GetImageDepth(ImageFormat pixelType, out IplDepth depth, out int channels, out ImageFormat outputFormat)
        {
            switch (pixelType)
            {
                case ImageFormat.Mono8:
                    outputFormat = ImageFormat.Mono8;
                    depth = IplDepth.U8;
                    channels = 1;
                    break;
                case ImageFormat.Mono16:
                    outputFormat = ImageFormat.Mono16;
                    depth = IplDepth.U16;
                    channels = 1;
                    break;
                case ImageFormat.Rgb24:
                    outputFormat = ImageFormat.Rgb24;
                    depth = IplDepth.U8;
                    channels = 3;
                    break;
                case ImageFormat.Rgb48:
                    outputFormat = ImageFormat.Rgb48;
                    depth = IplDepth.U16;
                    channels = 3;
                    break;
                default: throw new ArgumentException("Not supported/implemented ImageFormat type.");
            }
        }
    }
}
