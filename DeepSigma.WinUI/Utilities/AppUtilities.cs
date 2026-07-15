using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace DeepSigma.WinUI.Utilities;

/// <summary>
/// A utility class for application-related operations, such as checking for updates and retrieving the app version.
/// </summary>
public class AppUtilities
{

    /// <summary>
    /// Asks the App Installer (the .appinstaller channel) whether a newer version
    /// is available. Only meaningful for apps installed via App Installer; otherwise it quietly does nothing.
    /// </summary>
    public static async Task<bool> CheckForUpdatesAsync()
    {
        try
        {
            PackageUpdateAvailabilityResult result = await Package.Current.CheckUpdateAvailabilityAsync();
            if (result.Availability is PackageUpdateAvailability.Available or PackageUpdateAvailability.Required)
            {
                return true;
            }
        }
        catch
        {
            // No package identity, not installed via App Installer, or the update
            // source is unreachable - there is simply nothing to notify about.
        }
        return false;
    }

    /// <summary>
    /// Gets the current application version as a string in the format "vMajor.Minor.Build.Revision".
    /// Reads the version from the installed MSIX package manifest, and falls back to the assembly version when running unpackaged.
    /// </summary>
    /// <returns>The current application version.</returns>
    public static string GetAppVersion()
    {
        try
        {
            var v = Windows.ApplicationModel.Package.Current.Id.Version;
            return $"v{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
        }
        catch
        {
            var asm = DeepSigma.Application.AppUtilities.GetAppVersionFromAssembly();
            return asm is null ? "v0.0.0.0" : $"v{asm.Major}.{asm.Minor}.{asm.Build}.{asm.Revision}";
        }
    }

}
