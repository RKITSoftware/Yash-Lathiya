#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DI_2_Understanding_Lifetime/DI_2_Understanding_Lifetime.csproj", "DI_2_Understanding_Lifetime/"]
RUN dotnet restore "DI_2_Understanding_Lifetime/DI_2_Understanding_Lifetime.csproj"
COPY . .
WORKDIR "/src/DI_2_Understanding_Lifetime"
RUN dotnet build "DI_2_Understanding_Lifetime.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DI_2_Understanding_Lifetime.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DI_2_Understanding_Lifetime.dll"]