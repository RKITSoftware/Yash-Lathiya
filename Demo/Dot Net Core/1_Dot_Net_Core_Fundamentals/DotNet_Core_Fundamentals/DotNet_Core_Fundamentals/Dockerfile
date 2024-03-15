#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotNet_Core_Fundamentals/DotNet_Core_Fundamentals.csproj", "DotNet_Core_Fundamentals/"]
RUN dotnet restore "DotNet_Core_Fundamentals/DotNet_Core_Fundamentals.csproj"
COPY . .
WORKDIR "/src/DotNet_Core_Fundamentals"
RUN dotnet build "DotNet_Core_Fundamentals.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet_Core_Fundamentals.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet_Core_Fundamentals.dll"]