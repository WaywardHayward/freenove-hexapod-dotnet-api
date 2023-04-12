# Freenove Hexapod dotnet Api

This is a dotnet rest api for the Freenove Hexapod.

## Getting Started

To run the api, you need to have dotnet core 7 installed and a Freenove Hexapod.

if you debug the application in vscode it should automatically start the api and open the swagger page.

However you can also run the following command to start the api:

```bash
dotnet run
```

You can then access the api at http://localhost:5000/Swagger

## Configuration

The api can be configured using one of the files or environment variables.

- appsettings.json
- appsettings.Development.json
- appsettings.{Environment Name Name}.json

### Environment Variables and Settings

The following settings can be configured using environment variables or the appsettings.json file.

| Setting | Environment Variable | Description |
| ------- | -------------------- | ----------- |
| Hexapod.Host | Hexapod__Host | The hostname of the hexapod (can be ip or hostname) |
| Hexapod.Port | Hexapod__Port | The port which the hexapod api is running on, defaults to 5002 |


