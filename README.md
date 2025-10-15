<h2 align="center">Responsive.Avalonia - Use Breakpoints in AvaloniaUI</h2>

<p align="center">
    <img src="https://img.shields.io/nuget/v/Responsive.Avalonia?color=1f72de" alt="Nuget">
    <img src="https://img.shields.io/badge/-.NET%20Standard%202.0-blueviolet?color=1f72de&label=NET" alt="">
    <img src="https://img.shields.io/github/license/russkyc/responsive-avalonia">
    <img src="https://img.shields.io/github/issues/russkyc/responsive-avalonia">
    <img src="https://img.shields.io/nuget/dt/Responsive.Avalonia">
</p>

## Overview

Responsive.Avalonia is a library that provides responsive breakpoints for AvaloniaUI applications. It allows developers
to create responsive layouts that adapt to different screen sizes using predefined breakpoints.

## Features

> [!NOTE]
> Custom conditions can now be added by using the `Condition` property of the `Show` control. Read more in this section: [Custom Conditions](#custom-conditions).

- **Predefined Breakpoints**: Use predefined breakpoints such as `Xs`, `Sm`, `Md`, `Lg`, `Xl`, and `Xxl`.
- **Customizable Visibility**: Control the visibility of UI elements based on the current screen width or height.
- **Orientation Mode**: Toggle between horizontal (width-based) and vertical (height-based) breakpoints using the `Orientation` property on `BreakpointProvider`.
- **Easy Integration**: Simple to integrate into existing AvaloniaUI projects.

## Installation

You can install the library via NuGet Package Manager:

```sh
dotnet add package Responsive.Avalonia
```

## Usage

Add Namespace

```xaml
xmlns:rc="using:Responsive.Avalonia"
```

There are two controls needed to be used. The `BreakpointProvider` is the root that detects
the size changes, and the `Show` control contains the elements that will be shown when the measured length
(width or height, depending on orientation) is within the breakpoint.

### Orientation Mode

By default, breakpoints are based on width (horizontal mode). To use height (vertical mode), set the `Orientation` property on `BreakpointProvider`:

```xml
<rc:BreakpointProvider Orientation="Vertical">
    <!-- Responsive content here -->
</rc:BreakpointProvider>
```

Or in code:

```csharp
breakpointProvider.Orientation = ResponsiveOrientationMode.Vertical;
```

## Example

```xml
<rc:BreakpointProvider Orientation="Horizontal"> <!-- or "Vertical" -->
    <rc:Show Breakpoint="Xs">
        <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="White"
                   FontWeight="Medium" FontSize="14" Text="Visible on Small Screens"/>
    </rc:Show>
    <rc:Show Breakpoint="Sm">
        <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="White"
                   FontWeight="Medium" FontSize="24" Text="Visible on Medium Screens"/>
    </rc:Show>
    <rc:Show Breakpoint="MdAndUp">
        <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Foreground="White"
                   FontWeight="Medium" FontSize="38" Text="Visible on Large Screens"/>
    </rc:Show>
</rc:BreakpointProvider>
```

## Show Control Properties

**Breakpoint** - Specifies the breakpoint at which the content should be visible. It is of type `Breakpoint`.

| Breakpoint           | Pixel Equivalent         |
|----------------------|--------------------------|
| Breakpoint.Xs        | length < 600px           |
| Breakpoint.SmAndDown | length < 960px           |
| Breakpoint.Sm        | 600px <= length < 960px  |
| Breakpoint.SmAndUp   | length >= 600px          |
| Breakpoint.MdAndDown | length < 1280px          |
| Breakpoint.Md        | 960px <= length < 1280px |
| Breakpoint.MdAndUp   | length >= 960px          |
| Breakpoint.LgAndDown | length < 1920px          |
| Breakpoint.Lg        | 1280px <= length < 1920px|
| Breakpoint.LgAndUp   | length >= 1280px         |
| Breakpoint.XlAndDown | length < 2560px          |
| Breakpoint.Xl        | 1920px <= length < 2560px|
| Breakpoint.XlAndUp   | length >= 1920px         |
| Breakpoint.Xxl       | length >= 2560px         |

> **Note:** The `length` refers to width in horizontal mode and height in vertical mode, depending on the `Orientation` property of the nearest `BreakpointProvider`.

**Condition** - A custom condition that can be used to determine the visibility of the content. It is a `Func<double,bool>` delegate
that returns true if the content should be visible. See the [Custom Conditions](#custom-conditions) section for more details.

**Invert** - A boolean property that inverts the visibility condition. If set to true, the content will be hidden at the
  specified breakpoint. This property is also respected when using the `Condition` property.

## Custom Conditions
For more granular control, custom conditions can be used instead of the standard breakpoints. The condition receives the measured length (width or height, depending on orientation) of the breakpoint provider. For example, to show the element if the length is between 600 and 700 pixels:
```csharp
using System;

namespace SampleApp;

public static class CustomBreakpoints
{
    // Example implementation of a custom breakpoint for demonstration purposes.
    public static Func<double,bool> Length600To700Condition => length => length is >= 600 and < 700;
}
```

To use this, set the `Condition` property of the `Show` control:

```xaml
<rc:Show Condition="{x:Static sampleApp:CustomBreakpoints.Length600To700Condition}">
   <TextBlock Text="Visible if length is between 600px and 700px" />
</rc:Show>
```
> [!IMPORTANT]
> When using custom conditions, the `Breakpoint` property will be ignored.
> The value passed to the condition is the measured width or height, depending on the orientation.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
