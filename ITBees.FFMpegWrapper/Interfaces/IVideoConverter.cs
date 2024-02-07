﻿using static ITBees.FFMpegWrapper.VideoConverter;

namespace ITBees.FFMpegWrapper.Interfaces;

public interface IVideoConverter
{
    void ConvertWMVtoWebM(string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9);
    void ConvertWMVtoMov(string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20);
    void ConvertMP4toMov(string inputPath, string outputPath);

    void ConvertWebMtoMov(string inputPath, string outputPath,
        AudioBitrate audioBitrate = AudioBitrate.AudioBitrate128k, Crf crf = Crf.Crf20, Codec codec = Codec.vp9);
}