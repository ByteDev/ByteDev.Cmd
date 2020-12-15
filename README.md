[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Cmd?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Cmd/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Cmd.svg)](https://www.nuget.org/packages/ByteDev.Cmd)

# ByteDev.Cmd

Library providing functionality to help when creating .NET Console applications.

## Installation

ByteDev.Cmd has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Cmd is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Cmd`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Cmd/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Cmd/blob/master/docs/RELEASE-NOTES.md).

## Usage

### Output class

Provides wrapper functionality around the `System.Console` class to make writing out output easier.

To use reference namespace: `ByteDev.Cmd`.

Methods include:
- Write
- WriteLine
- WriteRainbowLine
- WriteAlignLeft
- WriteAlignRight
- WriteAlignCenter
- WriteAlignToSides
- WriteHorizontalLine
- WriteBlankLines
- WriteWrap

---

### Logger class

The `Logger` class provides a convenient way to write log style messages to the console based on a given `LogLevel`.

To use reference namespace: `ByteDev.Cmd.Logging`.

Methods include:
- WriteDebug
- WriteInfo
- WriteWarning
- WriteError
- WriteCritical

```csharp
// Example: at LogLevel.Error only Error and Critical messages will be written

var logger = new Logger(LogLevel.Error);

logger.WriteDebug("Debug message");
logger.WriteInfo("Info message");
logger.WriteWarning("Warning message");
logger.WriteError("Error message");
logger.WriteCritical("Critical message");
```

---

### Arguments namespace

To use reference namespace: `ByteDev.Cmd.Arguments`.

The namespace defines a number of types:
- `CmdAllowedArg` - represents an allowed argument.
- `CmdArgInfo` - represents `string[] args` from the console app and a collection of `CmdAllowedArg`.
- `CmdArg` - represents an input command line argument.

```csharp
// Define what arguments are allowed using the CmdAllowedArg class

var cmdAllowedArgs = new List<CmdAllowedArg>
{
    new CmdAllowedArg('o', false) 
    {
        LongName = "output", 
        Description = "Output something"
    },
    new CmdAllowedArg('p', true) 
    {
        LongName = "path", 
        Description = "Set a path", 
        IsRequired = true
    }
};

try
{
    // Handle console arguments using the CmdArgInfo class
    // args is the string array of args from Program.Main

    var cmdArgInfo = new CmdArgInfo(args, cmdAllowedArgs);

    // Use CmdArgInfo instance to determine what operations to perform

    if (cmdArgInfo.HasArguments)
    {
        foreach (CmdArg cmdArg in cmdArgInfo.Arguments)
        {
            switch (cmdArg.ShortName)
            {
                case 'o':
                    DoSomeOutput();
                    break;

                case 'p':
                    SetPath(cmdArg.Value);
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine(cmdAllowedArgs.HelpText());
    }
}
catch (CmdArgException ex)
{
    // When creating CmdArgInfo if any invalid input a CmdArgException will be thrown
    Console.WriteLine(ex.Message);
    Console.WriteLine(cmdAllowedArgs.HelpText());
}
```

The `ByteDev.Cmd.TestApp` project on GitHub also has a working example of this.
