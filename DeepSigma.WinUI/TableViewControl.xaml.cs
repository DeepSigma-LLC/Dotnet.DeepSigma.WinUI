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
        /// Minimum width for columns in the TableView.
        /// </summary>
        public int MinColumnWidth { get; set; } = 100;
        /// <summary>
        /// Initializes a new instance of the <see cref="TableViewControl"/> class.
        /// </summary>
        public TableViewControl()
        {
            InitializeComponent();
            RefreshSettings();
        }

        /// <summary>
        /// Refreshes the TableView settings, applying properties like IsReadOnly and MinColumnWidth.
        /// </summary>
        public void RefreshSettings()
        {
            MyTableView.IsReadOnly = true;
            MyTableView.MinColumnWidth = MinColumnWidth;
        }

        /// <summary>
        /// Automatically adjusts the width of all columns in the TableView to fit their content.
        /// </summary>
        public void AutoFitColumns()
        {
            foreach (var column in MyTableView.Columns)
            {
                column.Width = GridLength.Auto;
            }
        }

        /// <summary>
        /// Binds the provided MainViewModel's items to the TableView's ItemsSource.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view_models"></param>
        public void BindData<T>(MainViewModel<T> view_models) where T : class
        {
            MyTableView.ItemsSource = view_models.GetItems();
        }

        /// <summary>
        /// Removes all items from the TableView's ItemsSource.
        /// </summary>
        public void Clear()
        {
            MyTableView.ItemsSource?.Clear();
        }
    }
}
