using System.Text.Json.Serialization;
using NAudio.Wave;
using System.Reflection;

public class PlaySound :  Request
{
    [JsonIgnore]
    private const string _soundsDir = "sounds";
    public string sound {get; set;}

    public const string RequestName = "play-sound";     // static access
    public override string Type => RequestName; // instance access

    public override string HandleRequest()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream($"FinalProject.{_soundsDir}.{sound}");
        if (stream == null) return "Sound not found!";

        using WaveStream reader =
            sound.EndsWith(".wav") ? new WaveFileReader(stream) :
            sound.EndsWith(".mp3") ? new Mp3FileReader(stream) :
            throw new NotSupportedException();

        using var output = new WaveOutEvent();

        output.Init(reader);
        output.Play();
        while (output.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(100);
        }
        
        return $"Played {sound}";
    }
}
