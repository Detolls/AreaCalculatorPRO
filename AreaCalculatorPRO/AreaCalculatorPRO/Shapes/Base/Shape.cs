using System.Threading.Tasks;

namespace AreaCalculatorPRO.Shapes.Base
{
    /// <summary>
    /// Base shape.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Get shape area.
        /// </summary>
        /// <returns>Shape area value.</returns>
        public abstract double GetArea();

        /// <summary>
        /// Get shape area async.
        /// </summary>
        /// <returns>Shape area value.</returns>
        public abstract Task<double> GetAreaAsync();
    }
}
