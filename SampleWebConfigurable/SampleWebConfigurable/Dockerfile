FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["./SampleWebConfigurable.csproj", "./"]
RUN dotnet restore "./SampleWebConfigurable.csproj"
COPY . ./
WORKDIR "/src"
RUN dotnet build "SampleWebConfigurable.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SampleWebConfigurable.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SampleWebConfigurable.dll"]