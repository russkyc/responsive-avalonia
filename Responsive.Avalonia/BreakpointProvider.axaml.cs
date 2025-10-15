using Avalonia;
using Avalonia.Controls;

namespace Responsive.Avalonia
{
    public partial class BreakpointProvider : Grid
    {
        public static readonly StyledProperty<OrientationMode> OrientationProperty =
            AvaloniaProperty.Register<BreakpointProvider, OrientationMode>(nameof(Orientation), OrientationMode.Horizontal);

        public OrientationMode Orientation
        {
            get => GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public static readonly DirectProperty<BreakpointProvider, double> MeasuredLengthProperty =
            AvaloniaProperty.RegisterDirect<BreakpointProvider, double>(nameof(MeasuredLength), o => o.MeasuredLength);

        private double _measuredLength;
        public double MeasuredLength
        {
            get => _measuredLength;
            private set => SetAndRaise(MeasuredLengthProperty, ref _measuredLength, value);
        }

        public BreakpointProvider()
        {
            InitializeComponent();
            AttachedToVisualTree += (_, _) => UpdateMeasuredLength();
            SizeChanged += (_, _) => UpdateMeasuredLength();
        }

        private void UpdateMeasuredLength()
        {
            MeasuredLength = Orientation == OrientationMode.Horizontal ? Bounds.Width : Bounds.Height;
        }
    }
}
