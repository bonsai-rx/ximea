using xiApi;

namespace Bonsai.Ximea
{
    /// <summary>
    /// Specifies the type of the color filter mosaic placed over the pixel sensors of an image sensor.
    /// </summary>
    public enum ColorFilterArray
    {
        /// <summary>
        /// Image pixels have no filters applied in this format.
        /// </summary>
        None = XI_COLOR_FILTER_ARRAY.CFA_NONE,

        /// <summary>
        /// Regular RGGB Bayer filter.
        /// </summary>
        BayerRGGB = XI_COLOR_FILTER_ARRAY.CFA_BAYER_RGGB,

        /// <summary>
        /// Alternative CMYG Bayer filter used in the AK Sony sensor.
        /// </summary>
        CMYG = XI_COLOR_FILTER_ARRAY.CFA_CMYG,

        /// <summary>
        /// 2R+G Bayer filter readout.
        /// </summary>
        RGR = XI_COLOR_FILTER_ARRAY.CFA_RGR,

        /// <summary>
        /// BGGR Bayer filter readout.
        /// </summary>
        BayerBGGR = XI_COLOR_FILTER_ARRAY.CFA_BAYER_BGGR,

        /// <summary>
        /// GRBG Bayer filter readout.
        /// </summary>
        BayerGRBG = XI_COLOR_FILTER_ARRAY.CFA_BAYER_GRBG,

        /// <summary>
        /// GBRG Bayer filter readout.
        /// </summary>
        BayerGBRG = XI_COLOR_FILTER_ARRAY.CFA_BAYER_GBRG,

        /// <summary>
        /// BGGR polarized 4x4 macropixel Bayer filter.
        /// </summary>
        PolarABayerBGGR = XI_COLOR_FILTER_ARRAY.CFA_POLAR_A_BAYER_BGGR,

        /// <summary>
        /// Polarized 2x2 macropixel Bayer filter.
        /// </summary>
        PolarA = XI_COLOR_FILTER_ARRAY.CFA_POLAR_A,

        /// <summary>
        /// Time-of-flight A and B.
        /// </summary>
        ToFAnB = XI_COLOR_FILTER_ARRAY.CFA_TOF_ANB,

        /// <summary>
        /// Time-of-flight A minus B.
        /// </summary>
        ToFAmB = XI_COLOR_FILTER_ARRAY.CFA_TOF_AMB,

        /// <summary>
        /// Time-of-flight A plus B.
        /// </summary>
        ToFApB = XI_COLOR_FILTER_ARRAY.CFA_TOF_APB,

        /// <summary>
        /// Time-of-flight A only.
        /// </summary>
        ToFA = XI_COLOR_FILTER_ARRAY.CFA_TOF_A,

        /// <summary>
        /// Time-of-flight B only.
        /// </summary>
        ToFB = XI_COLOR_FILTER_ARRAY.CFA_TOF_B
    }
}
