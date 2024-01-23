namespace ITBees.FFMpegWrapper;

public partial class VideoConverter
{
    /// <summary>
    /// Codec Choice: VP9 is more efficient than VP8 in terms of compression for similar quality, so it may be a better choice.
    /// </summary>
    public enum Codec
    {
        vp9,
        vp8
    }
}