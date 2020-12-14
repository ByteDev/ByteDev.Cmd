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

### Logger class

Given optional `LogLevel`, `LoggerColorTheme` and `Output` dependencies provides logger style functionality for writting to the console.

To use reference namespace: `ByteDev.Cmd.Logging`.

Methods include:
- WriteDebug
- WriteInfo
- WriteWarning
- WriteError
- WriteCritical

### Arguments namespace

Handle console arguments using a `CmdArgInfo` class.  Define what arguments are allowed using the `CmdAllowedArg` class.

To use reference namespace: `ByteDev.Cmd.Arguments`.

```csharp
// args is the string array of args from Program.Main

var allowedArgs = new List<CmdAllowedArg>
{
    new CmdAllowedArg('o', false) {LongName = "output", Description = "Output something"},
    new CmdAllowedArg('p', true) {LongName = "path", Description = "Set a path"}
};

var cmdArgInfo = new CmdArgInfo(args, allowedArgs);
```

When creating an instance of `CmdArgInfo` if there was any invalid input a `CmdArgException` will be thrown.

Once you have an instance of `CmdArgInfo` you can use it to determine what operations to perform:

```csharp
if (cmdArgInfo.HasArguments)
{
    foreach (var cmdArg in cmdArgInfo.Arguments)
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
    Console.WriteLine(allowedArgs.HelpText());
}
```

The `ByteDev.Cmd.TestApp` project on GitHub also has a working example of this.
