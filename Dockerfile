# Docker build File for dotnet Core 6.0 web API apps
#
# version 0.0.1 3/12/2022 Steven Stier - Initial Release
#
# start with DotNet sdk debian based bullseye slim image-everything we need to develop and build
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
# Copy the .csproj and restore the project dependancies
COPY *.csproj ./
RUN dotnet restore
#copy Everything else
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# build the runtime image using a plain vinella dotnet aspnet image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim
WORKDIR /app
# copy the stuff from publish 
COPY --from=build /app/publish .
# copy the certs to the proper directory in the image 
COPY "/https" /root/.aspnet/https/
# copy the user secrets to the proper directory in the image
# COPY "/usersecrets/." /root/.microsoft/usersecrets/.
# setup the entry point for the container.
ENTRYPOINT ["dotnet", "WeatherAPI.dll"]
