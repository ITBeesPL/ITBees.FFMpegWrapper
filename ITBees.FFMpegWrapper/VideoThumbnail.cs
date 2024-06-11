using FFMediaToolkit;
using FFmpeg.AutoGen;

public class VideoThumbnailGenerator
{
    public static void GenerateThumbnail(string videoPath, string thumbnailPath, int width, int height)
    {
        FFmpegLoader.FFmpegPath = @"path_to_ffmpeg";
        unsafe
        {
            AVFormatContext* formatContext = null;
            if (ffmpeg.avformat_open_input(&formatContext, videoPath, null, null) < 0)
            {
                throw new ApplicationException("Opening video file has failed.");
            }

            // todo rest code method implementation
        }
    }
}