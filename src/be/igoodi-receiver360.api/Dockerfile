FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch
WORKDIR /app
COPY /app .
ENTRYPOINT ["dotnet", "./adme360-cms.api.dll"]