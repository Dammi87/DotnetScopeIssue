# Description
Just a simple repository to show how the exception 
```
System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Microsoft.Extensions.Hosting.IHostedService Lifetime: Singleton ImplementationType: MinimalExample.Services.SomeHostedService': Cannot consume scoped service 'MinimalExample.Services.ISomeScopedService' from singleton 'Microsoft.Extensions.Hosting.IHostedService'.)'
```
is bypassed by manually building and running the project.

# How to replicate the issue

1. Run the code in Visual Studio, the exception above will appear

But now, somehow, magically, it works if we go the manual way about this

1. Open up PowerShell and navigate to this repository
2. `dotnet build "MinimalExample.csproj" -c Release -o ./output`
3. `dotnet .\output\MinimalExample.dll`

And everything will work fine.
