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
    public class MainViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>
        {
            new Item { Name = "Item 1", Price = 10.0, Quantity = 1 },
            new Item { Name = "Item 2", Price = 15.0, Quantity = 2 },
            new Item { Name = "Item 3", Price = 20.0, Quantity = 3 },
            // Add more items here
        };
        }
    }

    
}
