FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cognito.Test.API/Cognito.Test.API.csproj", "Cognito.Test.API/"]
RUN dotnet restore "Cognito.Test.API/Cognito.Test.API.csproj"
COPY . .
WORKDIR "/src/Cognito.Test.API"
RUN dotnet build "Cognito.Test.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cognito.Test.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cognito.Test.API.dll"]
