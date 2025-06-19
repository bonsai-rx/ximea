using OpenCV.Net;
using System;

namespace Bonsai.Ximea
{
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
                default: throw new ArgumentException("ImageFormat type is not supported or implemented.");
            }
        }
    }
}
