namespace hexapod_dotnet.Model.Api;

public record PowerResponse(string Battery1, string Battery2);

public record UltrasonicResponse(string? Distance);
