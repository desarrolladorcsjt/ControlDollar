FROM mcr.microsoft.com/dotnet/sdk:7.0.102-alpine3.17-amd64 AS build
WORKDIR /src
COPY ./ControlDolarPeru ./
RUN dotnet build
RUN dotnet publish ControlDolarPeruConsole/ControlDolarPeru.Console.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev tzdata
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT="Local"
ENV TZ=America/Lima
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ControlDolarPeru.Console.dll"]