FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["./SampleWebBasic.csproj", "./"]
RUN dotnet restore "./SampleWebBasic.csproj"
COPY . ./
WORKDIR "/src"
RUN dotnet build "SampleWebBasic.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SampleWebBasic.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SampleWebBasic.dll"]