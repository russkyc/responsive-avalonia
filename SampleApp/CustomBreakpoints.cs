using System;

namespace SampleApp;

public static class CustomBreakpoints
{
    // Example implementation of a custom breakpoint for demonstration purposes.
    public static Func<double,bool> Width600To700Condition => width => width is >= 600 and < 700;
}