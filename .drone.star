def main(ctx):
  if ctx.build.branch == "master" :
    return CI()
  else : 
    return none

def CI():
  return {
    "kind": "pipeline",
    "name": "CI",
    "steps": [
        {
          "name": "build",
          "image": "mcr.microsoft.com/dotnet/sdk:7.0",
          "commands": [ "cd Sources/" , "dotnet restore OpenLibraryWS_Wrapper.sln" , "dotnet build OpenLibraryWS_Wrapper.sln -c Release --no-restore" ]
        }
        ,
        {
          "name": "tests",
          "image": "mcr.microsoft.com/dotnet/sdk:7.0",
          "commands": [ "cd Sources/Tests/OpenLibraryWrapper_UT", "dotnet test" ],
          "depends_on": [ "build" ]
        }]
  }


def CD():
  return {
    "kind": "pipeline",
    "name": "CD",
    "steps": [
        {
          "name": "build",
          "image": "mcr.microsoft.com/dotnet/sdk:7.0",
          "commands": [ "cd Sources/" , "dotnet restore OpenLibraryWS_Wrapper.sln" , "dotnet build OpenLibraryWS_Wrapper.sln -c Release --no-restore" ]
        }]
  }
