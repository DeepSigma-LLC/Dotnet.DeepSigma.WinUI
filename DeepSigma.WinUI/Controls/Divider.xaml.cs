using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace DeepSigma.WinUI.Controls;

/// <summary>
/// A simple divider control that can be used to separate content in a UI. It allows customization of the line thickness and brush color.
/// </summary>
public sealed partial class Divider : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Divider"/> class. It sets the default line brush to a resource-defined brush if not already set.
    /// </summary>
    public Divider()
    {
        InitializeComponent();
        LineBrush ??= Microsoft.UI.Xaml.Application.Current.Resources["DividerStrokeColorDefaultBrush"] as Brush;
    }

    /// <summary>
    /// Gets or sets the thickness of the divider line. The default value is 1.0.
    /// </summary>
    public double LineThickness
    {
        get => (double)GetValue(LineThicknessProperty);
        set => SetValue(LineThicknessProperty, value);
    }

    /// <summary>
    /// Gets or sets the thickness of the divider line. The default value is 1.0.
    /// </summary>
    public static readonly DependencyProperty LineThicknessProperty =
        DependencyProperty.Register(
            nameof(LineThickness),
            typeof(double),
            typeof(Divider),
            new PropertyMetadata(1d));

    /// <summary>
    /// Gets or sets the brush used to draw the divider line. If not set, it defaults to a resource-defined brush.
    /// </summary>
    public Brush? LineBrush
    {
        get => (Brush?)GetValue(LineBrushProperty);
        set => SetValue(LineBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the brush used to draw the divider line. If not set, it defaults to a resource-defined brush.
    /// </summary>
    public static readonly DependencyProperty LineBrushProperty =
        DependencyProperty.Register(
            nameof(LineBrush),
            typeof(Brush),
            typeof(Divider),
            new PropertyMetadata(null));
}
