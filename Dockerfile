FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /data
COPY data/ ./

WORKDIR /web

# Copy csproj and restore as distinct layers
COPY web/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY web/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /web
COPY --from=build-env /web/out .

# Default env vars in Production
ENV JSWR_Logging__LogLevel__Default="Information"
ENV JSWR_Logging__LogLevel__Microsoft="Warning"
ENV JSWR_Logging__LogLevel__Microsoft.Hosting.Lifetime="Information"
ENV JSWR_AllowedHosts="*"

ENTRYPOINT ["dotnet", "JsonReports.Web.dll"]
