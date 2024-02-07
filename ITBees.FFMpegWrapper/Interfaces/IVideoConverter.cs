using static ITBees.FFMpegWrapper.VideoConverter;

namespace ITBees.FFMpegWrapper.Interfaces;

public interface IVideoConverter
{
    void ConvertWMVtoWebM(bool overwriteTargetFileIfExist, string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9);
    void ConvertWMVtoMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20);
    void ConvertMP4toMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath);

    void ConvertWebMtoMov(bool overwriteTargetFileIfExist, string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9);
}