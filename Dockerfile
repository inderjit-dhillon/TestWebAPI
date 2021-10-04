#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TestWebAPI/TestWebAPI.csproj", "TestWebAPI/"]
COPY ["TestWebAPI.Repository/TestWebAPI.Repository.csproj", "TestWebAPI.Repository/"]
COPY ["TestWebAPI.Utility/TestWebAPI.Utility.csproj", "TestWebAPI.Utility/"]
COPY ["TestWebAPI.Service/TestWebAPI.Service.csproj", "TestWebAPI.Service/"]
COPY ["TestWebAPI.Domain/TestWebAPI.Domain.csproj", "TestWebAPI.Domain/"]
RUN dotnet restore "TestWebAPI/TestWebAPI.csproj"
COPY . .
WORKDIR "/src/TestWebAPI"
RUN dotnet build "TestWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebAPI.dll"]