
using System.ComponentModel;

namespace DeepSigma.WinUI;

/// <summary>
/// Represents an item with properties for display in a table view.
/// </summary>
public class Item : INotifyPropertyChanged
{
    private string? _name;
    private double _price;
    private int _quantity;
    /// <summary>
    /// Event fires when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// The name of the item.
    /// </summary>
    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    /// <summary>
    /// The price of the item.
    /// </summary>
    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }
    /// <summary>
    /// The quantity of the item.
    /// </summary>
    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
