FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY FoodApp/FoodApp.csproj FoodApp/
RUN dotnet restore FoodApp/FoodApp.csproj
COPY . .
WORKDIR /src/FoodApp
#RUN dotnet build FoodApp.csproj -c Release -o /app
ENTRYPOINT dotnet watch run --urls=http://+:5000