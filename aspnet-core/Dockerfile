FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/myTestProject.Web.Host/myTestProject.Web.Host.csproj", "src/myTestProject.Web.Host/"]
COPY ["src/myTestProject.Web.Core/myTestProject.Web.Core.csproj", "src/myTestProject.Web.Core/"]
COPY ["src/myTestProject.Application/myTestProject.Application.csproj", "src/myTestProject.Application/"]
COPY ["src/myTestProject.Core/myTestProject.Core.csproj", "src/myTestProject.Core/"]
COPY ["src/myTestProject.EntityFrameworkCore/myTestProject.EntityFrameworkCore.csproj", "src/myTestProject.EntityFrameworkCore/"]
WORKDIR "/src/src/myTestProject.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/myTestProject.Web.Host", "src/myTestProject.Web.Host"]
COPY ["src/myTestProject.Web.Core", "src/myTestProject.Web.Core"]
COPY ["src/myTestProject.Application", "src/myTestProject.Application"]
COPY ["src/myTestProject.Core", "src/myTestProject.Core"]
COPY ["src/myTestProject.EntityFrameworkCore", "src/myTestProject.EntityFrameworkCore"]
WORKDIR "/src/src/myTestProject.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "myTestProject.Web.Host.dll"]
