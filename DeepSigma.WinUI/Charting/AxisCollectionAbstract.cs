using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a collection of axes for a chart.
    /// </summary>
    public abstract class AxisCollectionAbstract<T> : IAxisCollectionAbstract<T> where T : IAxis
    {
        private Dictionary<string, T> axes { get; init; } = [];

        /// <summary>
        /// Gets all axes in the collection.
        /// </summary>
        /// <param name="axis"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddAxis(T axis)
        {
            if (axes.ContainsKey(axis.Key))
            {
                throw new ArgumentException($"An axis with the key '{axis.Key}' already exists.");
            }
            axes[axis.Key] = axis;
        }

        /// <summary>
        /// Tries to remove an axis by its key. Returns true if removed, false if not found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool TryToRemoveAxis(string key)
        {
            return axes.Remove(key);
        }

        /// <summary>
        /// Tries to get an axis by its key. Returns null if not found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T? TryToGetAxis(string key)
        {
            if (axes.TryGetValue(key, out var axis))
            {
                return axis;
            }
            return default;
        }

        /// <summary>
        /// Gets the axis by its key. Throws an exception if not found.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T this[string key] => axes[key];

        /// <summary>
        /// Gets all axes in the collection as a list.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllAxes() => axes.Values.ToList();

    }
}
