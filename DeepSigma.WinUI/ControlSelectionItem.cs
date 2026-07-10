using System;
using System.Collections.Generic;
using System.Text;

namespace DeepSigma.WinUI;

/// <summary>
/// Represents an item in a control selection, with a display name and a value of type T.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ControlSelectionItem<T> where T : notnull
{
    /// <summary>
    /// Gets or sets the display name of the item.
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the value associated with the item.
    /// </summary>
    public required T Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlSelectionItem{T}"/> class with the specified display name and value.
    /// </summary>
    /// <param name="displayName"></param>
    /// <param name="value"></param>
    public ControlSelectionItem(string displayName, T value)
    {
        DisplayName = displayName;
        Value = value;
    }
}
