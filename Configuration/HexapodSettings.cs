namespace hexapod_dotnet.Configuration;

public class HexapodSettings
{
    public const string SectionName = "Hexapod";
    
    public required string Host { get; set; }
    public int Port { get; set; } = 5002;
    public string? Protocol { get; set; }
}
