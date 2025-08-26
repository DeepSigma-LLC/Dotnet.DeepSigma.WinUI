using DeepSigma.WinUI.Charting;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.OxyPlotCharting.Builders
{
    internal abstract class BaseChartBuilder
    {
        public PlotModel Build(Chart chart)
        {
            PlotModel plot = OxyPlotUtilities.CreatePlot(chart);
            OxyPlotUtilities.AddAxesToPlot(plot, chart);
            AddSeries(plot, chart);
            return plot;
        }

        protected abstract void AddSeries(PlotModel plot, Chart chart);
    }
}
