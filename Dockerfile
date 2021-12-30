FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.13 AS build

WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish src/Vulder.Admin.Api -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.13

WORKDIR /app

COPY --from=build /app .

EXPOSE 80
EXPOSE 433

ENTRYPOINT [ "dotnet", "Vulder.Admin.Api.dll" ]