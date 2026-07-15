using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

namespace DeepSigma.WinUI.Controls;

/// <summary>
/// A single row of settings UI: icon, header, description, and an edit control.
/// Composes <see cref="Card"/> for the surface.
/// </summary>
[ContentProperty(Name = nameof(SettingsContent))]
public partial class SettingsCard : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsCard"/> class.
    /// </summary>
    public SettingsCard() => InitializeComponent();

    /// <summary>
    /// Gets or sets the header text displayed at the top of the settings card.
    /// </summary>
    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(string), typeof(SettingsCard),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the header text displayed at the top of the settings card.
    /// </summary>
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets the description text displayed below the header in the settings card.
    /// </summary>
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(nameof(Description), typeof(string), typeof(SettingsCard),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the description text displayed below the header in the settings card.
    /// </summary>
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    /// <summary>
    /// Optional leading glyph, e.g. a <see cref="FontIcon"/>.
    /// </summary>
    public static readonly DependencyProperty HeaderIconProperty =
        DependencyProperty.Register(nameof(HeaderIcon), typeof(object), typeof(SettingsCard),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the optional leading glyph (e.g., a <see cref="FontIcon"/>) displayed next to the header in the settings card.
    /// </summary>
    public object HeaderIcon
    {
        get => GetValue(HeaderIconProperty);
        set => SetValue(HeaderIconProperty, value);
    }

    /// <summary>
    /// The edit control (ComboBox, ToggleSwitch, Button…) shown on the right.
    /// </summary>
    public static readonly DependencyProperty SettingsContentProperty =
        DependencyProperty.Register(nameof(SettingsContent), typeof(object), typeof(SettingsCard),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the edit control (e.g., ComboBox, ToggleSwitch, Button) displayed on the right side of the settings card.
    /// </summary>
    public object SettingsContent
    {
        get => GetValue(SettingsContentProperty);
        set => SetValue(SettingsContentProperty, value);
    }

    /// <summary>
    /// Returns <see cref="Visibility.Visible"/> if the provided string is not null or empty; otherwise, returns <see cref="Visibility.Collapsed"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public Visibility HasText(string value) =>
        string.IsNullOrEmpty(value) ? Visibility.Collapsed : Visibility.Visible;

}
