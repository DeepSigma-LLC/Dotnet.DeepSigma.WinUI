using System;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace DeepSigma.WinUI.Utilities;

/// <summary>
/// Provides a simple text-to-speech utility for Windows applications.
/// </summary>
public class TextToSpeech(MediaPlayer mediaPlayer)
{
    /// <summary>
    /// The media player used for text-to-speech playback.
    /// </summary>
    private MediaPlayer _ttsPlayer = mediaPlayer;

    /// <summary>
    /// Speaks the specified text using Windows text-to-speech functionality.
    /// </summary>
    /// <param name="text">The text to be spoken.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task SpeakAsync(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        try
        {
            // Read the message aloud with Windows text-to-speech.
            using var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream =
                await synth.SynthesizeTextToStreamAsync(text);

            _ttsPlayer ??= new Windows.Media.Playback.MediaPlayer();
            _ttsPlayer.Source = Windows.Media.Core.MediaSource.CreateFromStream(stream, stream.ContentType);
            _ttsPlayer.Play();
        }
        catch
        {
            // Ignore TTS failures (e.g. no voice installed).
        }
    }
}
