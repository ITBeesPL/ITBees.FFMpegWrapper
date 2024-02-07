using System.Diagnostics;
using ITBees.FFMpegWrapper.Interfaces;

namespace ITBees.FFMpegWrapper;

public partial class VideoConverter : IVideoConverter
{
    public void ConvertWMVtoWebM(string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9)
    {
        var args =
            $"-i \"{inputPath}\" -c:v libvpx-{codec} -crf {((int)crf)} -b:v 0 -c:a libvorbis -b:a {(int)audioBitrate}k \"{outputPath}\"";
        var convertProcess = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = args,
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

    public void ConvertWMVtoMov(string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20)
    {
        var args =
            $"-i \"{inputPath}\" -c:v libx264 -crf {((int)crf)} -preset slow -c:a aac -b:a {(int)audioBitrate}k \"{outputPath}\"";
        var convertProcess = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = args,
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
    public void ConvertMP4toMov(string inputPath, string outputPath)
    {
        var args = $"-i \"{inputPath}\" -c copy \"{outputPath}\"";

        var convertProcess = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = args,
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