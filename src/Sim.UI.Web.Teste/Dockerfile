#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Sim.UI.Web.Teste/Sim.UI.Web.Teste.csproj", "src/Sim.UI.Web.Teste/"]
RUN dotnet restore "src/Sim.UI.Web.Teste/Sim.UI.Web.Teste.csproj"
COPY . .
WORKDIR "/src/src/Sim.UI.Web.Teste"
RUN dotnet build "Sim.UI.Web.Teste.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sim.UI.Web.Teste.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sim.UI.Web.Teste.dll"]