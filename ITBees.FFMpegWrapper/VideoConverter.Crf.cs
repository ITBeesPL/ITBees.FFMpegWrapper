namespace ITBees.FFMpegWrapper;

public partial class VideoConverter
{
    /// <summary>
    /// CRF (Constant Rate Factor) setting: CRF values in the range of 15-35 provide a good balance between quality and file size. Values closer to 15 will have higher quality (and larger file size), while values closer to 35 will have smaller file size but lower quality.
    /// </summary>
    public enum Crf
    {
        Crf4 = 4,
        Crf5 = 5,
        Crf6 = 6,
        Crf7 = 7,
        Crf8 = 8,
        Crf9 = 9,
        Crf10 = 10,
        Crf11 = 11,
        Crf12 = 12,
        Crf13 = 13,
        Crf14 = 14,
        Crf15 = 15,
        Crf16 = 16,
        Crf17 = 17,
        Crf18 = 18,
        Crf19 = 19,
        Crf20 = 20,
        Crf21 = 21,
        Crf22 = 22,
        Crf23 = 23,
        Crf24 = 24,
        Crf25 = 25,
        Crf26 = 26,
        Crf27 = 27,
        Crf28 = 28,
        Crf29 = 29,
        Crf30 = 30,
        Crf31 = 31,
        Crf32 = 32,
        Crf33 = 33,
        Crf34 = 34,
        Crf35 = 35,

    }
}