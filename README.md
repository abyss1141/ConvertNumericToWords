# ConvertNumericToWords

## Prerequisites

.NET 6

## .NET 6 Installation

Install .NET6 SDK and Runtime
Run the following command in terminal to install the .NET 6 SDK and Runtime

```
winget install Microsoft.DotNet.SDK.6
winget install Microsoft.DotNet.AspNetCore.6
winget install Microsoft.DotNet.Runtime.8
```

## Building and Running the application

Windows:

1. Install and trust the development certificate.
```
dotnet dev-certs https --trust
```
2. Run the app
```
cd ConvertNumericToWords
dotnet watch run
```