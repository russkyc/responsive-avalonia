using Avalonia;
using Avalonia.Controls;

namespace Responsive.Avalonia;

public partial class Show : Grid
{
    public static readonly StyledProperty<Breakpoint> BreakpointProperty =
        AvaloniaProperty.Register<BreakpointProvider, Breakpoint>(
            nameof(Breakpoint));

    public Breakpoint Breakpoint
    {
        get => GetValue(BreakpointProperty);
        set => SetValue(BreakpointProperty, value);
    }

    public static readonly StyledProperty<Func<double, bool>> ConditionProperty =
        AvaloniaProperty.Register<BreakpointProvider, Func<double, bool>>(
            nameof(Condition));

    public Func<double, bool> Condition
    {
        get => GetValue(ConditionProperty);
        set => SetValue(ConditionProperty, value);
    }

    public static readonly StyledProperty<bool> InvertProperty = AvaloniaProperty.Register<BreakpointProvider, bool>(
        nameof(Invert));

    public bool Invert
    {
        get => GetValue(InvertProperty);
        set => SetValue(InvertProperty, value);
    }

    public Show()
    {
        InitializeComponent();
    }
}