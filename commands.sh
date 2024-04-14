# Create Project
dotnet new sln
dotnet new gitignore

dotnet new webapi -n WebApi
dotnet sln add WebApi

dotnet new classlib -n Application
dotnet sln add Application
dotnet add WebApi reference Application

dotnet new classlib -n Persistence
dotnet sln add Persistence
dotnet add Application reference Persistence

# Dependencies 
dotnet add Persistence package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.2
dotnet add Persistence package Microsoft.EntityFrameworkCore.Design --version 8.0.4
dotnet add Application package AutoMapper --version 13.0.1
dotnet add Application package AutoMapper.EF6 --version 3.0.0
dotnet add Application package Dumpify --version 0.6.5
dotnet add Application package System.Linq.Dynamic.Core --version 1.3.10
dotnet add Application package Newtonsoft.Json --version 13.0.3
dotnet add Application package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.4
dotnet add Application package Quartz.AspNetCore --version 3.8.1

# Scaffolding
dotnet ef dbcontext scaffold \
    "Name=ConnectionStrings:PostgresDatabase" \
    Npgsql.EntityFrameworkCore.PostgreSQL \
    -c OutboxDbContext \
    --context-dir ./ \
    -o ./Models -f \
    -p Persistence \
    -s WebApi \
    -v --no-onconfiguring