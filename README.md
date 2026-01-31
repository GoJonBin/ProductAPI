# ProductAPI

A sample ASP.NET Core Web API demonstrating Clean Architecture, JWT authentication, CRUD operations, and unit tests.

## Features

- Clean Architecture (API, Application, Domain, Infrastructure)
- JWT authentication
- Products CRUD API
- Soft delete with audit fields
- Unit tests with xUnit, Moq, FluentAssertions

## Setup (Local Development)

1. Copy sample config:

   ```bash
   cp appsettings.Sample.json appsettings.json
   ```
2. Update connection string and JWT secret in appsettings.json.

3. Run migrations and start API:

   ```bash
   dotnet ef database update
   dotnet run
   ```

4. Run tests:

   ```bash
   dotnet test
   ```

## Setup with Docker

You can run ProductAPI in a Docker container without installing .NET locally.

1. Build the Docker image:

   ```bash
   docker build -t productapi .
   ```

2. Run the container (detached mode):

   ```bash
   docker run -d -p 5000:8080 productapi
   ```

   ```bash
   -p 5000:8080 maps the container port 8080 to your local port 5000
   ```

   ```bash
   -d runs the container in the background
   ```

3. Access the API via Swagger:

   Open your browser:

   http://localhost:5000/swagger


4. Stop the container when done (optional):

   ```bash
   docker ps           # find your container ID
   ```

   ```bash
   docker stop <container-id>
   ```

   ```bash
   docker rm <container-id>
   ```


Notes

For production, configure proper secrets and database connection strings via environment variables instead of committing them to Git.

Docker ensures your API runs consistently across machines.