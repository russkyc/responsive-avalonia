namespace Responsive.Avalonia;

public static class BreakpointConditions
{
    public static readonly Dictionary<Breakpoint, Func<double, bool>> Conditions =
        new()
        {
            { Breakpoint.Xs, width => width < 600 },
            { Breakpoint.SmAndDown, width => width < 960 },
            { Breakpoint.Sm, width => width >= 600 && width < 960 },
            { Breakpoint.SmAndUp, width => width >= 600 },
            { Breakpoint.MdAndDown, width => width < 1280 },
            { Breakpoint.Md, width => width >= 960 && width < 1280 },
            { Breakpoint.MdAndUp, width => width >= 960 },
            { Breakpoint.LgAndDown, width => width < 1920 },
            { Breakpoint.Lg, width => width >= 1280 && width < 1920 },
            { Breakpoint.LgAndUp, width => width >= 1280 },
            { Breakpoint.XlAndDown, width => width < 2560 },
            { Breakpoint.Xl, width => width >= 1920 && width < 2560 },
            { Breakpoint.XlAndUp, width => width >= 1920 },
            { Breakpoint.Xxl, width => width >= 2560 }
        };
}