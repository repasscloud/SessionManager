# SessionManager

SessionManager is a utility to log off disconnected user sessions on a Windows system using .NET.

## Features

- Log off disconnected user sessions.
- Check for .NET 6 runtime or higher before execution.

## Requirements

- .NET 6 SDK or higher

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/SessionManager.git
    cd SessionManager
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

## Usage

### Command Line

To run the utility, use the following command:

```bash
dotnet run --project SessionManager/SessionManager.csproj
```

### Building and Publishing

You can publish the application for specific runtimes:

#### Publish for win-x86

```bash
dotnet publish -c Release -r win-x86 --self-contained false -p:PublishSingleFile=true
```

#### Publish for win-x64

```bash
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true
```
