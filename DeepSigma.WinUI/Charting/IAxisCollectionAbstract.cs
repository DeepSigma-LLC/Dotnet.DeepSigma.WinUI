using System.Collections.Generic;

namespace DeepSigma.WinUI.Charting
{
    /// <summary>
    /// Defines a collection of axes, allowing for adding, retrieving, and removing axes by key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAxisCollectionAbstract<T> where T : IAxis
    {
        /// <summary>
        /// Gets the axis associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T this[string key] { get; }

        /// <summary>
        /// Adds an axis to the collection.
        /// </summary>
        /// <param name="axis"></param>
        void AddAxis(T axis);

        /// <summary>
        /// Returns all axes in the collection.
        /// </summary>
        /// <returns></returns>
        List<T> GetAllAxes();

        /// <summary>
        /// Tries to get the axis associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T? TryToGetAxis(string key);

        /// <summary>
        /// Tries to remove the axis associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool TryToRemoveAxis(string key);
    }
}