using System.Diagnostics;
using ITBees.FFMpegWrapper.Interfaces;

namespace ITBees.FFMpegWrapper;

public partial class VideoConverter : IVideoConverter
{
    public void ConvertWMVtoWebM(string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9)
    {
        var convertProcess = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = $"-i {inputPath} -c:v libvpx-{codec} -crf {crf} -b:v 0 -c:a libvorbis -b:a {audioBitrate}k {outputPath}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        using (var process = new Process { StartInfo = convertProcess })
        {
            process.Start();
            process.WaitForExit();
        }
    }
}