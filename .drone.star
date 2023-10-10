def Build():
  return {
          "name": "build",
          "image": "mcr.microsoft.com/dotnet/sdk:7.0",
          "commands": [ "cd Sources/" , "dotnet restore OpenLibraryWS_Wrapper.sln" , "dotnet build OpenLibraryWS_Wrapper.sln -c Release --no-restore" ]
        }
  

def Tests():
  return {
          "name": "test",
          "image": "mcr.microsoft.com/dotnet/sdk:7.0",
          "commands": [ "cd Sources/Tests/OpenLibraryWrapper_UT", "dotnet test" ],
          "depends_on": [ "build" ]
        }


def main(ctx):

  listStep = []
  listStep.add(Build())


  return [ 
    "kind": "pipeline",
    "name": "WS",
    "steps": "listStep"
  ]



  
  

