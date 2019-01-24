FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Gateways/Desktop.Api/Desktop.Api.csproj", "Gateways/Desktop.Api/"]
RUN dotnet restore "Gateways/Desktop.Api/Desktop.Api.csproj"
COPY . .
WORKDIR "/src/Gateways/Desktop.Api"
RUN dotnet build "Desktop.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Desktop.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Desktop.Api.dll"]