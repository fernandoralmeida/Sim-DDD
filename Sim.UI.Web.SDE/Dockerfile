#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Sim.UI.Web.SDE/Sim.UI.Web.SDE.csproj", "Sim.UI.Web.SDE/"]
RUN dotnet restore "Sim.UI.Web.SDE/Sim.UI.Web.SDE.csproj"
COPY . .
WORKDIR "/src/Sim.UI.Web.SDE"
RUN dotnet build "Sim.UI.Web.SDE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sim.UI.Web.SDE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sim.UI.Web.SDE.dll"]