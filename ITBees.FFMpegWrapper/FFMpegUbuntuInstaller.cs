using System.Diagnostics;
using ITBees.FFMpegWrapper.Interfaces;

namespace ITBees.FFMpegWrapper;

public class FFMpegUbuntuInstaller : IFFMpegInstaller
{
    public bool Install()
    {
        try
        {
            // Instalacja FFmpeg
            var updateAptPackages = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"apt-get update\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var installProcess = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"apt-get install -y ffmpeg\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = updateAptPackages })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Updated apt packages with success.");
                    
                }
                else
                {
                    Console.WriteLine("Update apt packages failed..");
                    return false;
                }
            }

            using (var process = new Process { StartInfo = installProcess })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine("FFmpeg installed with success.");
                    return CheckIfFFmpegIsInstalled();
                }
                else
                {
                    Console.WriteLine("There was an error during FFmpeg installation process");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            // Obsługa wyjątków
            Console.WriteLine($"There was an error: {ex.Message}");
            return false;
        }
    }

    private static bool CheckIfFFmpegIsInstalled()
    {
        try
        {
            var checkProcess = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = "-version",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = checkProcess })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                
                if (output.ToLower().Contains("ffmpeg"))
                {
                    Console.WriteLine("FFmpeg is correctly installed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("FFmpeg was not found.");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There was an exception in FFmpeg: {ex.Message}");
            return false;
        }
    }

}