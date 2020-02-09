# netcorever
A utility that walks down a directory tree and reports the .NET Core project versions found.

## This is a Minimal Viable Product (MVP).
That is, it works with limitations and restrictions and is extremely opinionated and not-configurable.

## Want to help?
Pick an issue and contribute!

## Overview
netcorver runs in a directory and returns results for that directory and every child directory. Run it in your root directory and it'll take a long time but catch all your C# projects.

Here's an example:

<code>
➜  donschenck dotnet run -p /Users/dschenck/src/github/donschenck/netcorever
donschenck.csproj,netcoreapp3.1
netcorever.csproj,netcoreapp3.1
helloworld.csproj,netcoreapp2.1
mylocation.csproj,netcoreapp2.1
getOneCustomer.csproj,netcoreapp2.2
web.csproj,netcoreapp2.1
rest.csproj,netcoreapp2.1
foo.csproj,netcoreapp3.1
devfile-tutorial.csproj,netcoreapp3.0
webapi.csproj,netcoreapp3.0
locationms.csproj,netcoreapp2.0
MusicStore.Test.csproj,netcoreapp1.0;net451
E2ETests.csproj,netcoreapp1.0
MusicStore.csproj,netcoreapp1.0
MusicStore.Standalone.csproj,netcoreapp1.0
MusicStore.Test.csproj,netcoreapp1.0;net451
E2ETests.csproj,netcoreapp1.0
MusicStore.csproj,netcoreapp1.0
MusicStore.Standalone.csproj,netcoreapp1.0
HelloMvcApi.csproj,netcoreapp2.0
HelloWorld.csproj,netcoreapp2.0
HelloWeb.csproj,netcoreapp2.0
HelloWebStandalone.csproj,netcoreapp2.0
webapi.csproj,netcoreapp2.0
24 project(s) found.
22 .NET Core project(s) found
0 .NET Framework project(s) found
2 .NET Multi-framework project(s) found
</code>

## What's missing/What's wrong?
* It only looks for C# projects
* The starting path should be an optional command-line parameter
* The output is only a comma-delimited stream
* Version totals could be a nice chart or table

... and probably much more.