using DeepSigma.WinUI.Charting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a 2D axis for charts, inheriting from AxisAbstract.
    /// </summary>
    public class Axis2D : AxisAbstract
    {
        /// <summary>
        /// The position of the axis on the chart (e.g., Left, Right, Top, Bottom).
        /// </summary>
        public Chart2DAxisPosition Axis { get; set; }
    }
}
