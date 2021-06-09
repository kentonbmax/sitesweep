# sitesweep
> Note: url "http://www.infotrack.com" not found. instead try https. 
## Build
> Ensure net5 sdk installed. 
1. run the following from terminal `dotnet build sitesweep.csproj`

## Debug
> [Swagger page](http://localhost:5000/swagger/index.html)
1. Run the Launch Site Sweep configuration through VSC debugger. 

## Running the Api
> All commands ran from terminal, assume path configured.
### Terminal
> Ensure current dir = app working dir
1. See Build section above
1. Run `dotnet run` 
1. Note the port.
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