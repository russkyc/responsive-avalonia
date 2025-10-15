using System.Globalization;
using Avalonia.Data.Converters;

namespace Responsive.Avalonia;

public class LengthToVisibilityConverter : IMultiValueConverter
{
    public static LengthToVisibilityConverter Instance => new();
    
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is not double length) return true;
        if (values[1] is not Breakpoint breakpoint) return true;
        if (values[3] is not bool invert) return true;
        if (values[4] is not OrientationMode orientationMode) return true;
        if (values[2] is Func<double, bool> customCondition)
        {
            return customCondition(length) ^ invert;
        }
        var isVisible = BreakpointConditions.Evaluate(breakpoint, length, orientationMode) ^ invert;
        return isVisible;
    }
}