# Product Management System

## API (Backend)

- .Net Core


## APP (Frontend)

- Angular
- ReactJS
- VueJS

## .Net Core (Commands)

### Check version
```shell
dotnet --version
```

### List the templates
```shell
dotnet new list
```

### Generate a webapi with the name "api"
```shell
dotnet new webapi -n api
```

### RUN .Net app
```shell
dotnet run
```

## About VSCode X Visual Studio (IDE)

### VSCode
- Frontend APP
- API
- Console
- ...


### Visual Studio 
- Desktop App
- Mobile App
- Windows libraries 
- ...


## Docker 

### APP
```shell
# Build

docker build -t pms-test-nginx .  # you can choose any name
docker run -p 8080:80 pms-test-nginx  # you can choose any port 8080, 8081 .. if the port 8080 is occupied

```

### Docker composer

- Orchestrator 