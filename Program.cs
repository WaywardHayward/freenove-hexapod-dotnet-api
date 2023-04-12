using hexapod_dotnet.Configuration;
using hexapod_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", true).AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",true).AddEnvironmentVariables();

builder.Services.Configure<Hexapod>(builder.Configuration.GetSection(nameof(Hexapod)));
builder.Services.AddTransient<HexapodCommandInvoker>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
