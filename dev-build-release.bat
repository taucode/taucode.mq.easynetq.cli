dotnet restore

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\tests\TauCode.Mq.EasyNetQ.Cli.Tests\TauCode.Mq.EasyNetQ.Cli.Tests.csproj
dotnet test -c Release .\tests\TauCode.Mq.EasyNetQ.Cli.Tests\TauCode.Mq.EasyNetQ.Cli.Tests.csproj

nuget pack nuget\TauCode.Mq.EasyNetQ.Cli.nuspec
