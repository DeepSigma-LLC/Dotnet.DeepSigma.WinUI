using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;

namespace DeepSigma.WinUI.Utilities;

/// <summary>
/// A utility class for interacting with the system clipboard, providing methods to copy and retrieve text and images.
/// </summary>
public static class ClipboardUtility
{
    /// <summary>
    /// Copies the specified text to the system clipboard.
    /// </summary>
    /// <param name="text"></param>
    public static void CopyToClipboard(string text)
    {
        var dataPackage = new DataPackage();
        dataPackage.SetText(text);
        Clipboard.SetContent(dataPackage);
    }

    /// <summary>
    /// Asynchronously retrieves text from the system clipboard, if available.
    /// </summary>
    /// <returns></returns>
    public static async Task<string?> GetTextFromClipboard()
    {
        var package = Clipboard.GetContent();
        if (package.Contains(StandardDataFormats.Text))
        {
            var text = await package.GetTextAsync();
            return text;
        }
        return null;
    }

    /// <summary>
    /// Clears the contents of the system clipboard.
    /// </summary>
    public static void Clear()
    {
        Clipboard.Clear();
    }

    /// <summary>
    /// Asynchronously copies an image from the application's assets to the system clipboard.
    /// </summary>
    /// <returns></returns>
    public static async Task CopyImageToClipboard()
    {
        var package = new DataPackage();
        var imageUri = new Uri("ms-appx:///Assets/SampleMedia/rainier.jpg");
        package.SetBitmap(RandomAccessStreamReference.CreateFromUri(imageUri));
        Clipboard.SetContent(package);
    }

    /// <summary>
    /// Asynchronously retrieves an image from the system clipboard, if available, and returns it as a BitmapImage.
    /// </summary>
    /// <returns></returns>
    public static async Task<BitmapImage?> PasteImage()
    {
        var package = Clipboard.GetContent();
        if (package.Contains(StandardDataFormats.Bitmap))
        {
            var imageReference = await package.GetBitmapAsync();
            using (var imageStream = await imageReference.OpenReadAsync())
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(imageStream);
                return bitmapImage;
            }
        }
        return null;
    }

    /// <summary>
    /// Copies the specified text to the system clipboard and allows it to be stored in the clipboard history and roam across devices.
    /// </summary>
    /// <param name="text"></param>
    public static void CopyIntoHistory(string text)
    {
        var options = new ClipboardContentOptions()
        {
            IsAllowedInHistory = true, // Allow the content to be stored in clipboard history
            IsRoamable = true, // Allow the content to roam across devices
        };

        var dataPackage = new DataPackage();
        dataPackage.SetText(text);
        Clipboard.SetContentWithOptions(dataPackage, options);
    }
}
