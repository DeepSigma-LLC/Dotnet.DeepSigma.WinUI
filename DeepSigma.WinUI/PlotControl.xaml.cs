using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepSigma.WinUI
{
    /// <summary>
    /// A user control that hosts an OxyPlot PlotView.
    /// </summary>
    public sealed partial class PlotControl : UserControl
    {
        /// <summary>
        /// Gets the PlotView control.
        /// </summary>
        public PlotView MyPlot => this.MyPlotView;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlotControl"/> class.
        /// </summary>
        public PlotControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the PlotView model to be displayed in the control.
        /// </summary>
        /// <param name="model"></param>
        public void SetPlotModel(PlotView model)
        {
            this.MyPlotView = model;
        }
    }
}
