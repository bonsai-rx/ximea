using OpenCV.Net;
using xiApi;

namespace Bonsai.Ximea
{
    public class XimeaDataFrame
    {
        public XimeaDataFrame(IplImage image, Metadata xi_img)
        {
            Image = image;
            Metadata = xi_img;
        }

        public IplImage Image { get; private set; }

        public Metadata Metadata { get; private set; }
    }

    public class Metadata
    {

        public Metadata(XI_IMG imgStruct)
        {
            StructSize =            imgStruct.size;
            BufferSize =            imgStruct.bp_size;
            ImageFmt =              (int)imgStruct.frm;
            Width =                 imgStruct.width;
            Height =                imgStruct.height;
            FrameCount =            imgStruct.nframe;
            Seconds =               imgStruct.tsSec;
            MicroSeconds =          imgStruct.tsUSec;
            GpiLevel =              imgStruct.GPI_level;
            BlackLevel =            imgStruct.black_level;
            PaddingX =              imgStruct.padding_x;
            AbsoluleOffsetX =       imgStruct.AbsoluteOffsetX;
            AbsoluleOffsetY =       imgStruct.AbsoluteOffsetY;
            TransportFmr =          imgStruct.transport_frm;
            DownsamplingX =         imgStruct.DownsamplingX;
            DownsamplingY =         imgStruct.DownsamplingY;
            Flags =                 imgStruct.flags;
            ExposureTime =          imgStruct.exposure_time_us;
            GainDb =                imgStruct.gain_db;
            FrameNumber =           imgStruct.acq_nframe;
            WhiteBalanceRedCh =     imgStruct.wb_red;
            WhiteBalanceGreenCh =   imgStruct.wb_green;
            WhiteBalanceBlueCh =    imgStruct.wb_blue;
            BlackLevelHighGain =    imgStruct.hg_black_level;
            BlackLevelLowGain =     imgStruct.lg_black_level;
            RangeHighGain =         imgStruct.hg_range;
            RangeLowGain =          imgStruct.lg_range;
            RangeGainRatio =        imgStruct.gain_ratio;
            FDownsamplingX =        imgStruct.fDownsamplingX;
            FDownsamplingY =        imgStruct.fDownsamplingY;
            UserData =              imgStruct.image_user_data;
        }

        public int StructSize               { get; private set; }
        public int BufferSize               { get; private set; }
        public int ImageFmt                 { get; private set; }
        public int Width                    { get; private set; }
        public int Height                   { get; private set; }
        public int FrameCount               { get; private set; }
        public int Seconds                  { get; private set; }
        public int MicroSeconds             { get; private set; }
        public int GpiLevel                 { get; private set; }
        public int BlackLevel               { get; private set; }
        public int PaddingX                 { get; private set; }
        public int AbsoluleOffsetX          { get; private set; }
        public int AbsoluleOffsetY          { get; private set; }
        public int TransportFmr             { get; private set; }
        public int DownsamplingX            { get; private set; }
        public int DownsamplingY            { get; private set; }
        public int Flags                    { get; private set; }
        public int ExposureTime             { get; private set; }
        public float GainDb                 { get; private set; }
        public int FrameNumber              { get; private set; }
        public float WhiteBalanceRedCh      { get; private set; }
        public float WhiteBalanceGreenCh    { get; private set; }
        public float WhiteBalanceBlueCh     { get; private set; }
        public int BlackLevelHighGain       { get; private set; }
        public int BlackLevelLowGain        { get; private set; }
        public int RangeHighGain            { get; private set; }
        public int RangeLowGain             { get; private set; }
        public float RangeGainRatio         { get; private set; }
        public float FDownsamplingX         { get; private set; }
        public float FDownsamplingY         { get; private set; }
        public int UserData                 { get; private set; } 
    }
}
