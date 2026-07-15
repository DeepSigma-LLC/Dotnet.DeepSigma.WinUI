using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

namespace DeepSigma.WinUI.Controls;

/// <summary>
/// Represents a reusable container that displays content inside a bordered,
/// rounded card surface.
/// </summary>
/// <remarks>
/// Example usage in XAML (add the namespace to the page first):
/// <code>
/// xmlns:controls="using:DeepSigma.WinUI.Controls"
/// ...
/// &lt;controls:Card Title="Encryption Settings"&gt;
///     &lt;StackPanel Spacing="8"&gt;
///         &lt;TextBox Header="Key file:"/&gt;
///         &lt;Button&gt;Load&lt;/Button&gt;
///     &lt;/StackPanel&gt;
/// &lt;/controls:Card&gt;
/// </code>
/// </remarks>
[ContentProperty(Name = nameof(CardContent))]
public partial class Card : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class.
    /// </summary>
    public Card()
    {
        InitializeComponent();
    }

    /// <summary>
    /// The "slot" for arbitrary inner content.
    /// </summary>
    public static readonly DependencyProperty CardContentProperty =
        DependencyProperty.Register(
            nameof(CardContent),
            typeof(object),
            typeof(Card),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the content to be displayed inside the card.
    /// </summary>
    public object CardContent
    {
        get => GetValue(CardContentProperty);
        set => SetValue(CardContentProperty, value);
    }

    /// <summary>
    /// Gets or sets the title of the card.
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(Card),
            new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets the title of the card, which is displayed at the top of the card.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Function binding: re-evaluates whenever Title changes, no converter needed.
    /// </summary>
    /// <param name="title">The title of the card.</param>
    /// <returns>A <see cref="Visibility"/> value indicating whether the title should be visible.</returns>
    public Visibility TitleToVisibility(string title) =>
        string.IsNullOrEmpty(title) ? Visibility.Collapsed : Visibility.Visible;

    public static readonly DependencyProperty CardPaddingProperty =
    DependencyProperty.Register(
        nameof(CardPadding),
        typeof(Thickness),
        typeof(Card),
        new PropertyMetadata(new Thickness(16)));

    /// <summary>
    /// Gets or sets the padding inside the card.
    /// </summary>
    public Thickness CardPadding
    {
        get => (Thickness)GetValue(CardPaddingProperty);
        set => SetValue(CardPaddingProperty, value);
    }
}