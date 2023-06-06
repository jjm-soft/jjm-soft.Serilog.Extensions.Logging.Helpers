# jjm.one.Serilog.Extensions.Logging.Helpers

A collection of helper functions for the [Serilog.Extensions.Logging](https://www.nuget.org/packages/Serilog.Extensions.Logging) logging tool.

## Status

|                       |                       |
|----------------------:|-----------------------|
| Nuget Package Version | [![Nuget Version](https://img.shields.io/nuget/v/jjm.one.Serilog.Extensions.Logging.Helpers?style=flat-square)](https://www.nuget.org/packages/jjm.one.Serilog.Extensions.Logging.Helpers/) |
| SonarCloudQuality Gate Status | [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jjm-one_jjm.one.Serilog.Extensions.Logging.Helpers&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=jjm-one_jjm.one.Serilog.Extensions.Logging.Helpers) |

## Table of contents

- [jjm.one.Serilog.Extensions.Logging.Helpers](#jjmoneserilogextensionslogginghelpers)
  - [Status](#status)
  - [Table of contents](#table-of-contents)
  - [Usage](#usage)
    - [Use function logging](#use-function-logging)
    - [Output of function logging](#output-of-function-logging)
  - [Full Documentation](#full-documentation)

## Usage

### Use function logging

```csharp
class MyClass {

    // ...

    void MyFancyFunction() {

        // log the function call
        Log.Logger.LogFctCall(GetType(), MethodBase.GetCurrentMethod(), LogEventLevel.Debug);

        try {
            
            //...
        }
        catch (Exception exc) {

            // Log the exception
            Log.Logger.LogExcInFctCall(exc, GetType(), MethodBase.GetCurrentMethod(), "My custom exception message!", LogEventLevel.Error);
        }
    }

    // ...
}
```

### Output of function logging

```text
Function called: MyClass -> MyFancyFunction
Exception thrown in: MyClass -> MyFancyFunction
My custom exception message!
```

## Full Documentation

The full documentation for this package can be found [here](https://jjm-one.github.io/jjm.one.Serilog.Extensions.Logging.Helpers/main/doc/html/index.html).
