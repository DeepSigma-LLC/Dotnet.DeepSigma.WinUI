using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.Storage.Pickers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeepSigma.Core.Extensions;

namespace DeepSigma.WinUI.Utilities;

/// <summary>
/// A utility class for picking files using the Windows file picker.
/// </summary>
public static class StoragePicker
{
    /// <summary>
    /// Options for configuring the file picker behavior.
    /// </summary>
    public sealed class StoragePickerOptions()
    {
        /// <summary>
        /// The title of the file picker dialog.
        /// </summary>
        public string? Title { get; init; }
        /// <summary>
        /// The view mode of the file picker (e.g., list or thumbnail).
        /// </summary>
        public PickerViewMode? ViewMode { get; init; } = PickerViewMode.List;
        /// <summary>
        /// The text displayed on the commit button of the file picker dialog.
        /// </summary>
        public string? CommitButtonText { get; init; }

        /// <summary>
        /// The suggested start location for the file picker (e.g., DocumentsLibrary, Desktop, etc.).
        /// </summary>
        public PickerLocationId? SuggestedStartLocation { get; init; } = PickerLocationId.DocumentsLibrary;

        /// <summary>
        /// The list of file types to filter in the file picker dialog. Defaults to all file types ("*").
        /// </summary>
        public List<string> FileTypeFilter { get; init; } = ["*"];
    }


    /// <summary>
    /// Picks a file using the Windows file picker.
    /// </summary>
    /// <param name="sender">The UI element that triggered the file picker.</param>
    /// <param name="options">Options for configuring the file picker behavior.</param>
    /// <returns>The result of the file picker operation.</returns>
    public static async Task<PickFileResult?> PickSingleFileAsync(Control sender, StoragePickerOptions? options = null)
    {
        options = options ?? new StoragePickerOptions();
        sender.IsEnabled = false;

        FileOpenPicker picker = new(sender.XamlRoot.ContentIslandEnvironment.AppWindowId)
        {
            CommitButtonText = options.CommitButtonText ?? "Pick File",
            SuggestedStartLocation = options.SuggestedStartLocation ?? PickerLocationId.DocumentsLibrary,
            ViewMode = options.ViewMode ?? PickerViewMode.List,
            Title = options.Title ?? string.Empty
        };
        options.FileTypeFilter.ForEach(fileType => picker.FileTypeFilter.Add(fileType));

        PickFileResult result = await picker.PickSingleFileAsync();

        //reenable the button after the file picker is closed
        sender.IsEnabled = true;
        return result;
    }

    /// <summary>
    /// Picks a file using the Windows file picker.
    /// </summary>
    /// <param name="sender">The UI element that triggered the file picker.</param>
    /// <param name="options">Options for configuring the file picker behavior.</param>
    /// <returns>The result of the file picker operation.</returns>
    public static async Task<IReadOnlyList<PickFileResult>?> PickMultipleFilesAsync(Control sender, StoragePickerOptions? options = null)
    {
        options = options ?? new StoragePickerOptions();
        sender.IsEnabled = false;

        FileOpenPicker picker = new(sender.XamlRoot.ContentIslandEnvironment.AppWindowId)
        {
            CommitButtonText = options.CommitButtonText ?? "Pick File",
            SuggestedStartLocation = options.SuggestedStartLocation ?? PickerLocationId.DocumentsLibrary,
            ViewMode = options.ViewMode ?? PickerViewMode.List,
            Title = options.Title ?? string.Empty
        };
        options.FileTypeFilter.ForEach(fileType => picker.FileTypeFilter.Add(fileType));

        IReadOnlyList<PickFileResult> result = await picker.PickMultipleFilesAsync();

        //reenable the button after the file picker is closed
        sender.IsEnabled = true;
        return result;
    }


    /// <summary>
    /// Picks a folder using the Windows folder picker.
    /// </summary>
    /// <param name="sender">The UI element that triggered the folder picker.</param>
    /// <param name="options">Options for configuring the folder picker behavior.</param>
    /// <returns>The result of the folder picker operation.</returns>
    public static async Task<PickFolderResult?> PickFolderAsync(Control sender, StoragePickerOptions? options = null)
    {
        options = options ?? new StoragePickerOptions();
        sender.IsEnabled = false;

        FolderPicker picker = new(sender.XamlRoot.ContentIslandEnvironment.AppWindowId)
        {
            CommitButtonText = options.CommitButtonText ?? "Pick Folder",
            SuggestedStartLocation = options.SuggestedStartLocation ?? PickerLocationId.DocumentsLibrary,
            ViewMode = options.ViewMode ?? PickerViewMode.List,
            Title = options.Title ?? string.Empty
        };
        PickFolderResult result = await picker.PickSingleFolderAsync();

        //reenable the button after the folder picker is closed
        sender.IsEnabled = true;
        return result;
    }
}
