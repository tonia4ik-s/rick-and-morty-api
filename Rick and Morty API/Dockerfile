FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Rick and Morty API/Rick and Morty API.csproj", "Rick and Morty API/"]
RUN dotnet restore "Rick and Morty API/Rick and Morty API.csproj"
COPY . .
WORKDIR "/src/Rick and Morty API"
RUN dotnet build "Rick and Morty API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rick and Morty API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rick and Morty API.dll"]
