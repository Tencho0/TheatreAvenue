

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TheatreAvenue.Backend/TheatreAvenue.Backend.csproj", "TheatreAvenue.Backend/"]
RUN dotnet restore "TheatreAvenue.Backend/TheatreAvenue.Backend.csproj"
COPY . .
WORKDIR "/src/TheatreAvenue.Backend"
RUN dotnet build "TheatreAvenue.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheatreAvenue.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheatreAvenue.Backend.dll"]
