# Description
Just a simple repository to show how the exception 
```
System.AggregateException: 'Some services are not able to be constructed (Error while validating the 
service descriptor 'ServiceType: Microsoft.Extensions.Hosting.IHostedService Lifetime: Singleton 
ImplementationType: MinimalExample.Services.SendOrderCompletedService': Cannot consume scoped service 
'MassTransit.IPublishEndpoint' from singleton 'Microsoft.Extensions.Hosting.IHostedService'.)'
```
is bypassed by manually building and running the project.

## Requirements
You need docker installed as the project assume a running rabbitmq client in localhost with guest / guest authorization. Alternatively you can run your own client locally if you so choose.

# How to replicate the issue

1. Start by starting up an instance of rabbitmq in docker. `docker run -d -p 5672:5672 rabbitmq:3-management`
2. Run the code in Visual Studio, the exception above will appear

But now, somehow, magically, it works if we go the manual way about this

1. Open up PowerShell and navigate to this repository
2. `dotnet build "MinimalExample.csproj" -c Release -o ./output`
3. `dotnet .\output\MinimalExample.dll`

And everything will work fine.
