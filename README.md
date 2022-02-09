[![NuGet](https://img.shields.io/nuget/dt/TimeString.svg)](https://www.nuget.org/packages/TimeString/)

# TimeString

Parse a human readable time string into a time based value.

## Usage

1. Simple
```csharp
TimeStringUtil objTimeString = new TimeStringUtil();
Int64 intTotalSeconds = objTimeString.Parse("1d 6h 30m 15s");

// intTotalSeconds = 109815
```

2. Complex
```csharp
TimeStringUtil objTimeString = new TimeStringUtil();
Int64 intTotalSeconds = objTimeString.Parse("1y 2mth 4w 7d 12h 30m 15s 1000ms");

// intTotalSeconds = 39886216
```

3. Messy
```csharp
TimeStringUtil objTimeString = new TimeStringUtil();
Int64 intTotalSeconds = objTimeString.Parse("9 d  18hrs   27    mIn     3      6seC       1000        milli         ");

// intTotalSeconds = 844057
```

4. Parse to TimeSpan
```csharp
TimeStringUtil objTimeString = new TimeStringUtil();
TimeSpan tsNineDays = objTimeString.ParseToTimeSpan("9d");

// tsNineDays = new TimeSpan(9, 0, 0, 0)
```

5. Parse to DateTime
```csharp
TimeStringUtil objTimeString = new TimeStringUtil();
DateTime dtEighteenDays = objTimeString.ParseToDateTime("18d");

// dtEighteenDays.DayOfWeek = DateTime.Now.AddDays(18).DayOfWeek
```

5. Custom Args
```csharp
DEFAULT_OPTS objArgs = new DEFAULT_OPTS() {
	hoursPerDay = 24,
	daysPerWeek = 7,
	weeksPerMonth = 4,
	monthsPerYear = 12,
	daysPerYear = 365.25,
};

TimeStringUtil objTimeString = new TimeStringUtil(objArgs);

Int64 intTotalSeconds = objTimeString.Parse("1y");

// intTotalSeconds = 31557600
```

All other examples are available [here](https://github.com/jadiagaurang/TimeString/blob/main/TimeString.Tests/utTimeStringUtil.cs).

## License

Please see the [license file](https://github.com/jadiagaurang/TimeString/blob/main/LICENSE) for more information.

## Credit

* This repo is a .Net Port of [timestring](https://github.com/mike182uk/timestring)