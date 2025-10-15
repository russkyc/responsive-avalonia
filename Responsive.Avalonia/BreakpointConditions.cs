namespace Responsive.Avalonia;

public static class BreakpointConditions
{
    // Horizontal (width-based) breakpoints
    private static readonly Dictionary<Breakpoint, Func<double, bool>> HorizontalConditions =
        new()
        {
            { Breakpoint.Xs, v => v < 600 },
            { Breakpoint.SmAndDown, v => v < 960 },
            { Breakpoint.Sm, v => v is >= 600 and < 960 },
            { Breakpoint.SmAndUp, v => v >= 600 },
            { Breakpoint.MdAndDown, v => v < 1280 },
            { Breakpoint.Md, v => v is >= 960 and < 1280 },
            { Breakpoint.MdAndUp, v => v >= 960 },
            { Breakpoint.LgAndDown, v => v < 1920 },
            { Breakpoint.Lg, v => v is >= 1280 and < 1920 },
            { Breakpoint.LgAndUp, v => v >= 1280 },
            { Breakpoint.XlAndDown, v => v < 2560 },
            { Breakpoint.Xl, v => v is >= 1920 and < 2560 },
            { Breakpoint.XlAndUp, v => v >= 1920 },
            { Breakpoint.Xxl, v => v >= 2560 }
        };

    // Vertical (height-based) breakpoints
    private static readonly Dictionary<Breakpoint, Func<double, bool>> VerticalConditions =
        new()
        {
            { Breakpoint.Xs, v => v < 480 },
            { Breakpoint.SmAndDown, v => v < 600 },
            { Breakpoint.Sm, v => v is >= 480 and < 600 },
            { Breakpoint.SmAndUp, v => v >= 480 },
            { Breakpoint.MdAndDown, v => v < 800 },
            { Breakpoint.Md, v => v is >= 600 and < 800 },
            { Breakpoint.MdAndUp, v => v >= 600 },
            { Breakpoint.LgAndDown, v => v < 1000 },
            { Breakpoint.Lg, v => v is >= 800 and < 1000 },
            { Breakpoint.LgAndUp, v => v >= 800 },
            { Breakpoint.XlAndDown, v => v < 1200 },
            { Breakpoint.Xl, v => v is >= 1000 and < 1200 },
            { Breakpoint.XlAndUp, v => v >= 1000 },
            { Breakpoint.Xxl, v => v >= 1200 }
        };

    public static bool Evaluate(Breakpoint breakpoint, double value, OrientationMode orientation = OrientationMode.Horizontal)
    {
        var conditions = orientation == OrientationMode.Vertical ? VerticalConditions : HorizontalConditions;
        return conditions.TryGetValue(breakpoint, out var func) && func(value);
    }
}