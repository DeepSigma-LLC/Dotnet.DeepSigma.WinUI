
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.BadgeNotifications;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Notification;

/// <summary>
/// Provides methods to show notifications in a WinUI application.
/// </summary>
public static class NotificationService
{
    /// <summary>
    /// Represents the options for configuring a notification, including title, message, sound event, timestamp, app logo, and attribution text.
    /// </summary>
    public class NotificationOptions
    {
        /// <summary>
        /// Gets or sets the title of the notification.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the message content of the notification.
        /// </summary>
        public required string Message { get; set; }

        /// <summary>
        /// Gets or sets the sound event for the notification. This determines the sound that will play when the notification is shown.
        /// </summary>
        public AppNotificationSoundEvent SoundEvent { get; set; } = AppNotificationSoundEvent.Default;

        /// <summary>
        /// Gets or sets the timestamp for the notification. This represents the time at which the notification is considered to have occurred.
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the URI of the app logo to be displayed in the notification. This allows for customization of the notification's appearance.
        /// </summary>
        public Uri? AppLogo { get; set; }

        /// <summary>
        /// Gets or sets the crop mode for the app logo in the notification. This determines how the app logo will be displayed (e.g., default, circle, square).
        /// </summary>
        public AppNotificationImageCrop AppLogoCrop { get; set; } = AppNotificationImageCrop.Default;

        /// <summary>
        /// Gets or sets the attribution text for the notification. This text can provide additional context or information about the notification's source or purpose.
        /// </summary>
        public string? AttributionText { get; set; }

        /// <summary>
        /// Gets or sets the URI of the hero image to be displayed in the notification. This allows for customization of the notification's appearance.
        /// </summary>
        public Uri? HeroImageUrl { get; set; }

        /// <summary>
        /// Initializes a new instance of the NotificationOptions class with the specified title, message, sound event, and timestamp.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="soundEvent"></param>
        /// <param name="dateTime"></param>
        [SetsRequiredMembers]
        public NotificationOptions(string title, string message, AppNotificationSoundEvent soundEvent = AppNotificationSoundEvent.Default, DateTime? dateTime = null)
        {
            Title = title;
            Message = message;
            SoundEvent = soundEvent;
            DateTime = dateTime ?? DateTime.Now;
        }
    }
    /// <summary>
    /// Shows a notification with the specified title and message.
    /// </summary>
    /// <param name="options">The options for the notification, including title, message, sound event, and timestamp.</param>
    /// <param name="configure">An optional action to further configure the notification builder.</param>
    /// <remarks>
    /// Example usage:
    /// <code>
    /// NotificationService.ShowNotification(new NotificationService.NotificationOptions("Title", "Message"), builder =>
    /// {
    ///     //Additional configuration for the notification builder. 
    ///     // Shown below is an example of adding a combo box, text box, and button to the notification.
    ///     .AddComboBox(new AppNotificationComboBox("satisfaction")
    ///        .AddItem("1", "Very Bad")
    ///        .AddItem("2", "Bad")
    ///        .AddItem("3", "Neutral")
    ///        .AddItem("4", "Good")
    ///        .AddItem("5", "Excellent")
    ///     .SetSelectedItem("3"))
    /// .AddTextBox("comment", "Leave a comment here...","")
    /// .AddButton(new AppNotificationButton("Submit")
    ///     .AddArgument("action", "submit_survey"))
    /// });
    /// </code>
    /// </remarks>
    public static void ShowNotification(NotificationOptions options, Action<AppNotificationBuilder>? configure = null)
    {
        AppNotificationBuilder builder = new AppNotificationBuilder()
        .AddText(options.Title)
        .AddText(options.Message)
        .SetAudioEvent(options.SoundEvent)
        .SetTimeStamp(options.DateTime);

        if(options.AppLogo != null)
        {
            builder.SetAppLogoOverride(options.AppLogo, options.AppLogoCrop);
        }

        if (options.HeroImageUrl != null)
        {
            builder.SetHeroImage(options.HeroImageUrl);
        }

        if(options.AttributionText != null)
        {
            builder.SetAttributionText(options.AttributionText);
        }

        configure?.Invoke(builder);
        AppNotification notification = builder.BuildNotification();
        AppNotificationManager.Default.Show(notification);
    }

    /// <summary>
    /// Sets the badge glyph on the app's taskbar icon or Start menu tile.
    /// </summary>
    /// <param name="glyph"></param>
    public static void SetBadgeGlyph(BadgeNotificationGlyph glyph)
    {
        BadgeNotificationManager.Current.SetBadgeAsGlyph(glyph);
    }

    /// <summary>
    /// Sets the badge number on the app's taskbar icon or Start menu tile.
    /// </summary>
    /// <param name="number"></param>
    public static void SetBadgeNumber(uint number)
    {
        BadgeNotificationManager.Current.SetBadgeAsCount(number);
    }

    /// <summary>
    /// Clears the badge from the app's taskbar icon or Start menu tile.
    /// </summary>
    public static void ClearBadge()
    {
        BadgeNotificationManager.Current.ClearBadge();
    }


    /// <summary>
    /// Shows a content dialog with the specified content and options.
    /// </summary>
    public class ContentDialogOptions
    {
        /// <summary>
        /// Gets or sets the title of the content dialog.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the text for the primary button of the content dialog.
        /// </summary>
        public string? PrimaryButtonText { get; set; }

        /// <summary>
        /// Gets or sets the text for the close button of the content dialog.
        /// </summary>
        public string? SecondaryButtonText { get; set; }

        /// <summary>
        /// Gets or sets the text for the close button of the content dialog.
        /// </summary>
        public string? CloseButtonText { get; set; }

        /// <summary>
        /// Gets or sets the default button for the content dialog.
        /// </summary>
        public ContentDialogButton DefaultButton { get; set; } = ContentDialogButton.Primary;
    }

    /// <summary>
    /// Shows a content dialog with the specified message. This method is asynchronous and returns a Task that completes when the dialog is closed.
    /// </summary>
    /// <param name="xamlRoot"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static async Task<ContentDialogResult> ShowContentDialog(XamlRoot xamlRoot, string message, ContentDialogOptions? options = null)
    {
        ContentDialog dialog = new();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = xamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = options?.Title;
        dialog.PrimaryButtonText = options?.PrimaryButtonText;
        dialog.CloseButtonText = options?.CloseButtonText;
        dialog.DefaultButton = options?.DefaultButton ?? ContentDialogButton.Primary;
        dialog.Content = message;
        var result = await dialog.ShowAsync();
        return result;
    }

    /// <summary>
    /// Shows a content dialog with the specified message. This method is asynchronous and returns a Task that completes when the dialog is closed.
    /// </summary>
    /// <param name="xamlRoot"></param>
    /// <param name="content"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <remarks>
    /// Example usage:
    /// <code>
    /// 
    /// ContentDialogOptions options = new ContentDialogOptions(){
    ///     Title = "Custom Content Dialog",
    ///     PrimaryButtonText = "OK",
    ///     CloseButtonText = "Cancel",
    /// };
    /// 
    /// StackPanel content = new StackPanel()
    /// {
    ///     Spacing = 12,
    ///     Children =
    ///     new TextBlock() { Text = "This is a custom content dialog." },
    ///     new Button() { Content = "Click Me" }
    /// }
    /// 
    /// await NotificationService.ShowContentDialog(this.XamlRoot, content, options);
    /// </code>
    /// </remarks>
    public static async Task<ContentDialogResult> ShowContentDialog(XamlRoot xamlRoot, object content, ContentDialogOptions? options = null)
    {
        ContentDialog dialog = new();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = xamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = options?.Title;
        dialog.PrimaryButtonText = options?.PrimaryButtonText;
        dialog.SecondaryButtonText = options?.SecondaryButtonText;
        dialog.CloseButtonText = options?.CloseButtonText;
        dialog.DefaultButton = options?.DefaultButton ?? ContentDialogButton.Primary;
        dialog.Content = content;
        var result = await dialog.ShowAsync();
        return result;
    }
}
