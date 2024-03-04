# Use the official SQL Server 2019 image from Microsoft
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables
ENV SA_PASSWORD=sql_user
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express
ENV MSSQL_DATABASE=PatientApplication

# Create a directory for SQL Server data
RUN mkdir -p /var/opt/mssql/data

# Grant permissions to the SQL Server data directory
RUN chmod -R 777 /var/opt/mssql/data

# Expose SQL Server port
EXPOSE 1433

# Start SQL Server
CMD ["sqlservr"]