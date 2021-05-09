using AreaCalculatorPRO.Constants.Errors.Messages;
using AreaCalculatorPRO.Shapes;
using AreaCalculatorPRO.Shapes.Base;
using System;
using System.Threading.Tasks;

namespace AreaCalculatorPRO
{
    /// <summary>
    /// Static class for calculating the area of ​​shapes.
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// Static method for calculating the area of ​​a figure.
        /// </summary>
        /// <param name="shape">Shape.</param>
        /// <returns>Calculated shape area.</returns>
        /// <exception cref="ArgumentNullException">Shape value is null.</exception>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateArea(Shape shape) =>
            shape switch
            {
                Triangle triangle => CalculateTriangleArea(triangle),
                Circle circle => CalculateCircleArea(circle),

                null => throw new ArgumentNullException(nameof(shape), ExceptionMessages.ShapeMustNotBeNull),
                _ => throw new ArgumentException(nameof(shape), ExceptionMessages.ShapeIsNotRecognized)
            };

        /// <summary>
        /// Static async method for calculating the area of ​​a figure.
        /// </summary>
        /// <param name="shape">Shape.</param>
        /// <returns>Calculated shape area.</returns>
        /// <exception cref="ArgumentNullException">Shape value is null.</exception>
        /// <exception cref="ArgumentException"></exception>
        public async static Task<double> CalculateAreaAsync(Shape shape) =>
            await Task.Factory.StartNew(() => CalculateArea(shape));

        private static double CalculateTriangleArea(Triangle triangle)
        {
            double semiPerimeter = (triangle.A + triangle.B + triangle.C) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.A) * (semiPerimeter - triangle.B)
                * (semiPerimeter - triangle.C));
        }

        private static double CalculateCircleArea(Circle circle)
        {
            return Math.PI * (circle.Radius * circle.Radius);
        }
    }
}
