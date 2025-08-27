using DeepSigma.WinUI.Charting.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a 3D chart with 3D axes.
    /// </summary>
    public class Chart3D<D> : ChartAbstract<Axis3D, D> where D : IDataModel
    {
        /// <summary>
        /// The collection of axes in the chart.
        /// </summary>
        public override IAxisCollectionAbstract<Axis3D> Axes { get; init; } = new Axis3DCollection();
    }
}
