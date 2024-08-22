# Release
dotnet restore
dotnet build -c Release
 
cd src/MyStack.LocalMessage/bin/Release
dotnet nuget push MyStack.LocalMessage.*.nupkg  --api-key $env:NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
cd ../../../../

