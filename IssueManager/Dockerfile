FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IssueManager/IssueManager.csproj", "IssueManager/"]
RUN dotnet restore "IssueManager/IssueManager.csproj"
COPY . .
WORKDIR "/src/IssueManager"
RUN dotnet build "IssueManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IssueManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IssueManager.dll"]
