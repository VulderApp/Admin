# Admin

[![Test](https://github.com/VulderApp/Admin/actions/workflows/test.yml/badge.svg)](https://github.com/VulderApp/Admin/actions/workflows/test.yml)
[![codecov](https://codecov.io/gh/VulderApp/Admin/branch/dev/graph/badge.svg?token=C9055U7JUH)](https://codecov.io/gh/VulderApp/Admin)

Microservice to manage vulder app database

## Run development server
```bash
$ docker-compose -f docker-compose.dev.yml up -d
$ dotnet restore
$ dotnet watch --project ./src/Vulder.Admin.Api
```

## Build a release
```bash
$ dotnet restore
$ dotnet build
$ dotnet publish ./src/Vulder.Admin.Api -c Release
```

## Build a docker image
```bash
$ docker build -t vulderapp/admin:release .
```

## Run migrations
```bash
export POSTGRES_CONNECTION_STRING=connection_string
$ dotnet ef database update --project ./src/Vulder.Admin.Infrastructure
```