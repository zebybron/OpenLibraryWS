def main(ctx):
  return {
    "kind": "pipeline",
    "name": "build-WS",
    "steps": [
        {
                "name": "build",
                "image": "mcr.microsoft.com/dotnet/sdk:7.0",
                "commands": [ "cd Sources/" , "dotnet restore OpenLibraryWS_Wrapper.sln" , "dotnet build OpenLibraryWS_Wrapper.sln -c Release --no-restore" ]}
            ]
  }


