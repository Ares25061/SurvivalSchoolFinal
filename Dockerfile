FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

EXPOSE 60
ENV ASPNETCORE_URLS=http://+:60
ENV ASPNETCORE_ENVIRONMENT=Development
ENV LANG=C.UTF-8
ENV LC_ALL=C.UTF-8

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /SurvivalSchool

COPY ["SurvivalSchool/SurvivalSchool.csproj", "SurvivalSchool/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "SurvivalSchool/SurvivalSchool.csproj"

COPY . .
FROM build as publish
RUN dotnet publish "SurvivalSchool/SurvivalSchool.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base as final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurvivalSchool.dll"]