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


## Add support for NGINX ingress controller

* Install using Helm
```
$Namespace = 'ingress-basic'

helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx
helm repo update

helm install ingress-nginx ingress-nginx/ingress-nginx --create-namespace --namespace $Namespace
```
* Verify external IP
```
kubectl --namespace ingress-basic get services -o wide -w ingress-nginx-controller
```

* Add ingress.yml 
```
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: hellocode-ingress
  annotations:
    kubernetes.io/ingress.class: nginx
    nginx.ingress.kubernetes.io/backend-protocol: "HTTP"
    nginx.ingress.kubernetes.io/use-regex: "true"
    nginx.ingress.kubernetes.io/cors-allow-methods: '*'
    nginx.ingress.kubernetes.io/cors-allow-origin: '*'
    nginx.ingress.kubernetes.io/cors-allow-headers: access-token,Authorization,Content-Type,Postman-Token,cache-control
spec:
  rules:
    - http:
        paths:
            - pathType: Prefix
              backend:
                service:
                  name: hellocode-svc
                  port:
                    number: 80
              path: /WeatherForecast/

```