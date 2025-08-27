using DeepSigma.WinUI.Charting.DataModels;
using DeepSigma.WinUI.Charting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Represents a series of data points.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataSeries<T> where T : IDataModel
    {
        private List<IDataModel> Data = [];

        /// <summary>
        /// Adds a data point to the series.
        /// </summary>
        /// <param name="dataPoint"></param>
        public void Add(T dataPoint)
        {
            Data.Add(dataPoint);
        }

        /// <summary>
        /// Retrieves all data points in the series.
        /// </summary>
        /// <returns></returns>
        public List<IDataModel> GetAllDataPoints()
        {
            return Data;
        }

        /// <summary>
        /// Clears all data points from the series.
        /// </summary>
        public void ClearData()
        {
            Data.Clear();
        }

        /// <summary>
        /// Gets the number of data points in the series.
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// Gets the data point at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IDataModel this[int index] => Data[index];

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<IDataModel> Where(Func<IDataModel, bool> predicate)
        {
            return Data.Where(predicate);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IEnumerable<TResult> Select<TResult>(Func<IDataModel, TResult> selector)
        {
            return Data.Select(selector);
        }

        /// <summary>
        /// Adds a range of data points to the series.
        /// </summary>
        /// <param name="dataPoints"></param>
        public void AddRange(IEnumerable<IDataModel> dataPoints)
        {
            Data.AddRange(dataPoints);
        }

    }
}
