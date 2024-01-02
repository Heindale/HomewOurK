#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HomewOurK.WebAPI/HomewOurK.WebAPI.csproj", "HomewOurK.WebAPI/"]
RUN dotnet restore "HomewOurK.WebAPI/HomewOurK.WebAPI.csproj"
COPY . .
WORKDIR "/src/HomewOurK.WebAPI"
RUN dotnet build "HomewOurK.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomewOurK.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomewOurK.WebAPI.dll"]