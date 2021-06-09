# sitesweep
> Note: url "http://www.infotrack.com not found. instead try https. 
## Build
> Ensure net5 sdk installed. 
1. run the following from terminal `dotnet build sitesweep.csproj`

## Debug
> launch.json included. Assume VSCode 
> [Swagger page](http://localhost:5000/swagger/index.html)
1. Run the launch site sweep configuration. 

## Running the Api
> All commands ran from terminal, assume path configured.
### Terminal
> Ensure current dir = app working dir
> not working requires env for Environment. Check docker.
1. See Build section above
1. Run `dotnet ./bin/debug/net5.0/sitesweep.dll`
### Docker
> Tested on Mac only
1. Run `docker build -t sitesweep .`
1. Run `docker run -p 8080:80 sitesweep`
1. In browser nav to `http://localhost:8080/swagger`
1. Click on search Route and then Try It out.

ToDo:
1. Purchase Graphics card at fair price. 
    1. Run on windows. 
        1. Add unit tests. 