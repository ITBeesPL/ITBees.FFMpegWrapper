using System.Diagnostics;
using ITBees.FFMpegWrapper.Interfaces;

namespace ITBees.FFMpegWrapper;

public partial class VideoConverter : IVideoConverter
{
    public void ConvertWMVtoWebM(bool overwriteTargetFileIfExist, string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9)
    {
        var overwriteParameter = GetOverwriteParameter(overwriteTargetFileIfExist);

        var args =
            $"{overwriteParameter} -i \"{inputPath}\" -c:v libvpx-{codec} -crf {((int)crf)} -b:v 0 -c:a libvorbis -b:a {(int)audioBitrate}k \"{outputPath}\"";
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

    public void ConvertWMVtoMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20)
    {
        var overwriteParameter = GetOverwriteParameter(overwriteTargetFileIfExist);

        var args =
            $"{overwriteParameter} -i \"{inputPath}\" -c:v libx264 -crf {((int)crf)} -preset slow -c:a aac -b:a {(int)audioBitrate}k \"{outputPath}\"";
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
    public void ConvertMP4toMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath)
    {
        var overwriteParameter = GetOverwriteParameter(overwriteTargetFileIfExist);

        var args = $"{overwriteParameter} -i \"{inputPath}\" -c copy \"{outputPath}\"";

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

    private static string GetOverwriteParameter(bool overwriteTargetFileIfExist)
    {
        var overwriteParameter = string.Empty;
        if (overwriteTargetFileIfExist)
            overwriteParameter = "-y";
        return overwriteParameter;
    }

    public void ConvertWebMtoMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath, AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9)
    {
        var overwriteParameter = GetOverwriteParameter(overwriteTargetFileIfExist);

        var args =
            $"{overwriteParameter} -i \"{inputPath}\" -c:v libx264 -crf {((int)crf)} -preset slow -c:a aac -b:a {(int)audioBitrate}k \"{outputPath}\"";
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