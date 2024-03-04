# Use the official .NET Core SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory
WORKDIR /app

# Copy the .csproj file to the working directory
COPY D:\PatientApplication\PatientApplication\PatientApplication.Web\PatientApplication.Web.csproj .

# Restore dependencies
RUN dotnet restore

# Copy the remaining source code
COPY D:\PatientApplication\PatientApplication\PatientApplication.Data\PatientApplication.Data.csproj .

# Copy the remaining source code
COPY D:\PatientApplication\PatientApplication\PatientApplication.Application\PatientApplication.Application.csproj .

# Build the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory
WORKDIR /app

# Copy the published application from the build environment
COPY --from=build-env /app/out .

# Expose the port the app will run on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "PatientApplication.DataHost.dll"]
