using System.Globalization;
using Avalonia.Data.Converters;

namespace Responsive.Avalonia;

public class WidthToVisibilityConverter : IMultiValueConverter
{
    public static WidthToVisibilityConverter Instance => new();
    
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is not double width) return true;
        if (values[1] is not Breakpoint breakpoint) return true;
        if (values[2] is not bool invert) return true;
        var isVisible = BreakpointConditions.Conditions.TryGetValue(breakpoint, out var condition) &&
                        condition(width);
        return invert ? !isVisible : isVisible;
    }
}