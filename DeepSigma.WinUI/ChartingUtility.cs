using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI
{
    internal class ChartingUtility
    {
        public void Plot(PlotView plot_view, string title)
        {
            var plotModel = new PlotModel { Title = title };

            var series = new LineSeries
            {
                Title = "y = x²",
                MarkerType = MarkerType.Circle
            };

            for (int x = -5; x <= 5; x++)
            {
                series.Points.Add(new DataPoint(x, x * x));
            }

            plotModel.Series.Add(series);

            plot_view.Model = plotModel;
        }
    }
}
