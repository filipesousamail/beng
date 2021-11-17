FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["beng.user.service.API.csproj", "User.Service.API/"]
RUN dotnet restore "beng.user.service.API.csproj"
COPY . .
WORKDIR "/src/User.Service.API"
RUN dotnet build "beng.user.service.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "beng.user.service.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "beng.user.service.API.dll"]
