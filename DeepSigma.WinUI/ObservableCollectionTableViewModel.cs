
using DeepSigma.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepSigma.WinUI;

/// <summary>
/// A generic view model for managing a collection of items.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObservableCollectionTableViewModel<T>() where T : class
{
    public ObservableCollection<T> Items { get; init; } = [];

    public ObservableCollectionTableViewModel(IEnumerable<T> values) : this()
    {
        values.ForEach(v => Items.Add(v)); // Add the items rather than replacing the collection to ensure that the ObservableCollection is properly initialized and can notify any observers of changes.
    }

    /// <summary>
    /// Adds an item to the collection.
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        Items.Add(item);
    }

    /// <summary>
    /// Adds multiple items to the collection.
    /// </summary>
    /// <param name="items"></param>
    public void Add(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    /// <summary>
    /// Removes an item from the collection.
    /// </summary>
    /// <param name="item"></param>
    public void Remove(T item)
    {
        Items.Remove(item);
    }

    /// <summary>
    /// Clears all items from the collection.
    /// </summary>
    public void Clear()
    {
        Items.Clear();
    }

    /// <summary>
    /// Gets the number of items in the collection.
    /// </summary>
    public int Count => Items.Count;

    /// <summary>
    /// Retrieves all items in the collection.
    /// </summary>
    /// <returns></returns>
    public ObservableCollection<T> GetItems() => Items;


    /// <summary>
    /// Filters the items in the collection based on a specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public IEnumerable<T> Where(Func<T, bool> predicate)
    {
        return Items.Where(predicate);
    }

    /// <summary>
    /// Projects each item in the collection into a new form based on a specified selector function.
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    public IEnumerable<T> Select(Func<T, T> selector)
    {
        return Items.Select(selector);
    }
}


