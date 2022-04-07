# Containerize a .Net Core Web API

### Create a new .Net Core Web API
```
dotnet new webapi -o HelloCode.API
```

### Add Run and Debug assets using the c# extention
* Run the web api using the Run and Debug section of VS Code or using "dotnet run" command
* https://localhost:5001/swagger/index.html
* To automatically oprn the swagger page while running the project, add the below JSON to launch.json:
```
"launchBrowser": {
                "enabled": true,
                "args": "${auto-detect-url}/swagger",
                "windows": {
                    "command": "cmd.exe",
                    "args": "/C start ${auto-detect-url}/swagger"
                }
            }
```

### Add Docker support
* Add a Dockerfile using the command palette of VS Code
* Verify launch.json
* Add the following json snippet to open swagger page by default
```
"dockerServerReadyAction": {
                "uriFormat": "%s://localhost:%s/swagger"
```
* Run HelloCode.API using command palette or using the "docker run" command
* Inspect the container image and container using Docker Extention and Docker Desktop


