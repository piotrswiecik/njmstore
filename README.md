# NJM Store v2

## Description

Project origin
Comments
Features
tbd

## Running in development

tbd

## Production config

tbd

## Service details

tbd

### DbSeeder service

Standalone CLI service (outside of microservice architecture) used to provide main database with test data. Uses 
Spotify developer API & custom HTTP client to fetch records.

```shell
# get spotify token with client credentials flow
dotnet run --project NjmStore.DbSeeder get-token --client-id id --client-secret secret
```