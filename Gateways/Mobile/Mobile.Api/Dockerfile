FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Gateways/Mobile/Mobile.Api/Mobile.Api.csproj", "Gateways/Mobile/Mobile.Api/"]
RUN dotnet restore "Gateways/Mobile/Mobile.Api/Mobile.Api.csproj"
COPY . .
WORKDIR "/src/Gateways/Mobile/Mobile.Api"
RUN dotnet build "Mobile.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Mobile.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mobile.Api.dll"]