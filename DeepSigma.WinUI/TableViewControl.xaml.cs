using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUI.TableView;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepSigma.WinUI
{
    /// <summary>
    /// A user control that hosts a TableView.
    /// </summary>
    public sealed partial class TableViewControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableViewControl"/> class.
        /// </summary>
        public TableViewControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds an item to the TableView's ItemsSource.
        /// </summary>
        /// <param name="item"></param>
        public void Add(object item)
        {
            MyTableView?.ItemsSource?.Add(item);
        }

        /// <summary>
        /// Adds multiple items to the TableView's ItemsSource.
        /// </summary>
        /// <param name="items"></param>
        public void Add(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                MyTableView?.ItemsSource?.Add(item);
            }
        }

        /// <summary>
        /// Removes all items from the TableView's ItemsSource.
        /// </summary>
        public void Clear()
        {
            MyTableView?.ItemsSource?.Clear();
        }
    }
}
