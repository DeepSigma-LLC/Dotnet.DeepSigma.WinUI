
using Microsoft.UI.Xaml.Controls;
using OxyPlot;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DeepSigma.WinUI;

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
    public void SetPlotModel(PlotModel model)
    {
        this.MyPlotView.Model = model;
    }
}
