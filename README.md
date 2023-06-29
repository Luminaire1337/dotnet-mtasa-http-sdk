# MTASA.Http.Sdk
### Unofficial .NET Class Library for interacting with MTA:SA server via the HTTP interface

[![NuGet](https://img.shields.io/nuget/v/MTASA.Http.Sdk.svg)](https://www.nuget.org/packages/MTASA.Http.Sdk/)
[![License](https://img.shields.io/github/license/Luminaire1337/dotnet-mtasa-http-sdk.svg)](https://github.com/Luminaire1337/dotnet-mtasa-http-sdk/blob/main/LICENSE)

## Overview
The `MTASA.Http.Sdk` is a .NET class library that provides a convenient way to interact with an MTA:SA (Multi Theft Auto: San Andreas) server through its HTTP interface. It allows you to perform various operations such as querying player information, executing server-side functions, and more.

## Features
- Connect to an MTA:SA server using the HTTP interface.
- Execute server-side functions remotely.
- Query player information, such as name, score, ping, etc.
- Interact with MTA:SA resources and their functions.

## Installation
The `MTASA.Http.Sdk` library can be easily installed via [NuGet](https://www.nuget.org/packages/MTASA.Http.Sdk/). Use the following command in the NuGet Package Manager Console:

```shell
Install-Package MTASA.Http.Sdk
```

## Code example
```csharp
public async Task<bool> IsAccountNameValid(string userName)
{
    try
    {
        using (Client client = new Client())
        {
            return await client.Call<bool>("webadmin", "isAccountNameValid", userName);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
}
```

## Usage
1. First, ensure that you have installed the `MTASA.Http.Sdk` package from NuGet.

2. Create an instance of the `Client` class:
```csharp
using (Client client = new Client())
{
    // Perform operations with the client
}
```

3. Make calls to the MTA:SA server using the `Call` method:
```csharp
T response = await client.Call<T>(resourceName, functionName, parameters);
```
- `resourceName`: The name of the MTA:SA resource you want to execute the function on.
- `functionName`: The name of the server-side function to execute.
- `parameters` (optional): Any parameters required by the server-side function.\
Note: Make sure to replace `T` with the appropriate return type of the server-side function.

4. Handle the response from the server-side function accordingly.

## Contributing
Contributions to the `MTASA.Http.Sdk` library are welcome! If you find any issues or would like to add new features, please submit a pull request.

## Credits
This library is heavily inspired by [node-mtasa](https://github.com/4O4/node-mtasa).

## License
The `MTASA.Http.Sdk` library is released under the [MIT License](https://github.com/Luminaire1337/dotnet-mtasa-http-sdk/blob/main/LICENSE).
