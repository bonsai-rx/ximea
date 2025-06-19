using OpenCV.Net;

namespace Bonsai.Ximea
{
    /// <summary>
    /// Represents a data object containing a decoded image frame and the metadata object
    /// which contains additional information about the image.
    /// </summary>
    public class XimeaDataFrame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XimeaDataFrame"/> class
        /// with the decoded image frame and metadata object.
        /// </summary>
        /// <param name="image">The decoded image frame.</param>
        /// <param name="metadata">
        /// The managed chunk data which contains additional information about the image.
        /// </param>
        public XimeaDataFrame(IplImage image, ImageMetadata metadata)
        {
            Image = image;
            Metadata = metadata;
        }

        /// <summary>
        /// Gets the decoded image frame.
        /// </summary>
        public IplImage Image { get; }

        /// <summary>
        /// Gets the metadata object which contains additional information about the image.
        /// </summary>
        public ImageMetadata Metadata { get; }
    }
}
