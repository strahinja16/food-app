FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY foodApp/foodApp.csproj foodApp/
RUN dotnet restore foodApp/foodApp.csproj
COPY . .
WORKDIR /src/foodApp
#RUN dotnet build foodApp.csproj -c Release -o /app
ENTRYPOINT dotnet watch run --urls=http://+:5000
