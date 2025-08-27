using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a 2D chart with axes.
    /// </summary>
    public class Chart2D : ChartAbstract<Axis2D>
    {
        /// <summary>
        /// The collection of axes in the chart.
        /// </summary>
        public override IAxisCollectionAbstract<Axis2D> Axes { get; init; } = new Axis2DCollection();
    }
}
