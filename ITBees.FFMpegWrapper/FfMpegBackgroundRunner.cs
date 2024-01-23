namespace ITBees.FFMpegWrapper;

using System.Diagnostics;
using System.Threading.Tasks;

public class FfMpegBackgroundRunner
{
    public async Task RunFFmpegAsync(string arguments)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = processStartInfo };

        process.Start();

        await Task.Run(() => process.WaitForExit());

        string output = await process.StandardOutput.ReadToEndAsync();
        string error = await process.StandardError.ReadToEndAsync();

        if (!string.IsNullOrEmpty(output))
        {
            Console.WriteLine(output);
        }

        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine(error);
        }
    }
}
