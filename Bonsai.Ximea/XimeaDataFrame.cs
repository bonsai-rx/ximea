using OpenCV.Net;
using xiApi;

namespace Bonsai.Ximea
{
    public class XimeaDataFrame
    {
        public XimeaDataFrame(IplImage image, XI_IMG xi_img)
        {
            Image = image;
            Metadata = xi_img;
        }

        public IplImage Image { get; private set; }

        public XI_IMG Metadata { get; private set; }
    }
}