# Use Linux-based .NET 8 SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CoreAppPractice/CoreAppPractice.csproj", "CoreAppPractice/"]
RUN dotnet restore "CoreAppPractice.csproj"
COPY . .
RUN dotnet publish "CoreAppPractice.csproj" -c Release -o /app/publish

# Use lightweight Linux runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CoreAppPractice.dll"]