# Pinned: the floating 10.0 tag resolves to 10.0.203, whose Razor compiler
# misreads `@section.Title` (a loop variable) as the @section directive.
FROM mcr.microsoft.com/dotnet/sdk:10.0.401 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY GUPBlazor.slnx ./
COPY GUPBlazor/GUPBlazor.csproj GUPBlazor/
COPY GUPBlazorDemo/GUPBlazorDemo.csproj GUPBlazorDemo/
RUN dotnet restore GUPBlazorDemo/GUPBlazorDemo.csproj

COPY . .
RUN dotnet publish GUPBlazorDemo/GUPBlazorDemo.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    -p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080
# Set here too, so `docker run` without compose does not fall back to
# Development and serve the developer exception page.
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DataProtection__KeyRingPath=/keys
RUN mkdir -p /keys && chown $APP_UID:$APP_UID /keys
USER $APP_UID
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GUPBlazorDemo.dll"]
