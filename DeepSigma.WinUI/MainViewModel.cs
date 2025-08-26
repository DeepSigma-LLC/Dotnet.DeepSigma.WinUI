using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepSigma.WinUI
{
    /// <summary>
    /// A generic view model for managing a collection of items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MainViewModel<T> where T : class
    {
        private ObservableCollection<T> Items { get; set; } = [];

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
        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        /// <summary>
        /// Clears all items from the collection.
        /// </summary>
        public void ClearItems()
        {
            Items.Clear();
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int ItemCount => Items.Count;
    }

    
}
