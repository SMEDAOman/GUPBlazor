# Pinned: the floating 10.0 tag resolves to 10.0.203, whose Razor compiler
# misreads `@section.Title` (a loop variable) as the @section directive.
FROM mcr.microsoft.com/dotnet/sdk:10.0.401 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY GUPBlazor.slnx ./
COPY GUPBlazor/GUPBlazor.csproj GUPBlazor/
COPY GUPBlazorDemo/GUPBlazorDemo.csproj GUPBlazorDemo/
COPY tools/AiDocsGen/AiDocsGen.csproj tools/AiDocsGen/
RUN dotnet restore GUPBlazorDemo/GUPBlazorDemo.csproj \
 && dotnet restore tools/AiDocsGen/AiDocsGen.csproj

COPY . .

# Regenerate the AI reference so /llms.txt and /ai/** always match the components
# in this image. The library is built first because the generator reads its XML
# docs for the enum and type summaries. Links stay relative, so the same files
# serve correctly from whatever host runs the container.
RUN dotnet build GUPBlazor/GUPBlazor.csproj -c Release --no-restore \
 && dotnet run --project tools/AiDocsGen/AiDocsGen.csproj -c Release -- \
    --repo /src --out /src/docs/ai

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
# The generated reference, served by /llms.txt and /ai/**.
COPY --from=build /src/docs ./docs
ENTRYPOINT ["dotnet", "GUPBlazorDemo.dll"]
