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
> Assume docker installed.
> All commands ran from terminal, assume path configured.
> Feel free to try this fails to start the app on mac. Dotnet entrypoint hangs.  
1. Run `docker build -t sitesweep .`
1. Run `docker run sitesweep`