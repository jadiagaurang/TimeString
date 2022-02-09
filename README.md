[![NuGet](https://img.shields.io/nuget/dt/libphonenumber-csharp.svg)](https://www.nuget.org/packages/TimeString/)

# TimeString

Parse a human readable time string into a time based value.

## Usage

1. Simple
```csharp
TimeStringUtil objTimeString = new TimeStringUtil(null);
Int64 intTotalSeconds = objTimeString.parseToSeconds("1d 6h 30m 15s");

// intTotalSeconds = 109815
```

2. Complex
```csharp
TimeStringUtil objTimeString = new TimeStringUtil(null);
Int64 intTotalSeconds = objTimeString.parseToSeconds("1y 2mth 4w 7d 12h 30m 15s 1000ms");

// intTotalSeconds = 39886216
```

3. Messy
```csharp
TimeStringUtil objTimeString = new TimeStringUtil(null);
Int64 intTotalSeconds = objTimeString.parseToSeconds("1 d    3HOurS 25              min         1   8s");

// intTotalSeconds = 31557600
```

All other examples are available [here](https://github.com/jadiagaurang/TimeString/blob/main/TimeString.Tests/utTimeStringUtil.cs).

## License

Please see the [license file](https://github.com/jadiagaurang/TimeString/blob/main/LICENSE) for more information.