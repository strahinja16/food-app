FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY App/FoodApp.csproj FoodApp/
RUN dotnet restore FoodApp/FoodApp.csproj
COPY . .
WORKDIR /src/FoodApp
ENTRYPOINT dotnet watch run --urls=http://+:5000
