#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Sources/OpenLibraryWrapper/OpenLibraryWrapper.csproj", "OpenLibraryWrapper/"]
COPY ["Sources/LibraryDTO/LibraryDTO.csproj", "LibraryDTO/"]
COPY ["Sources/StubbedDTO/StubbedDTO.csproj", "StubbedDTO/"]
COPY ["Sources/JsonReader/JsonReader.csproj", "JsonReader/"]
COPY ["Sources/DtoAbstractLayer/DtoAbstractLayer.csproj", "DtoAbstractLayer/"]
COPY ["Sources/OpenLibraryClient/OpenLibraryClient.csproj", "OpenLibraryClient/"]
COPY ["Sources/MyLibraryManager/MyLibraryManager.csproj", "MyLibraryManager/"]
COPY ["Sources/MyLibraryDB/MyLibraryDB.csproj", "MyLibraryDB/"]
COPY ["Sources/MyLibraryEntities/MyLibraryEntities.csproj", "MyLibraryEntities/"]
COPY ["Sources/StubbedDB/StubbedDB.csproj", "StubbedDB/"]
RUN dotnet restore "OpenLibraryWrapper/OpenLibraryWrapper.csproj"
COPY ["Sources/OpenLibraryWS_Wrapper.sln","OpenLibraryWS_Wrapper.sln"]
WORKDIR "/src/OpenLibraryWrapper"
RUN dotnet build "OpenLibraryWrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenLibraryWrapper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenLibraryWrapper.dll"]
