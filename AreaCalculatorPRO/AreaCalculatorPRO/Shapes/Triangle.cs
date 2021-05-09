using AreaCalculatorPRO.Constants.Errors.Messages;
using AreaCalculatorPRO.Shapes.Base;
using Dawn;
using System;
using System.Linq;

namespace AreaCalculatorPRO.Shapes
{
    /// <summary>
    /// Triangle.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// First side.
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Second side.
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Third side.
        /// </summary>
        public double C { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="a">First triangle side.</param>
        /// <param name="b">Second triangle side.</param>
        /// <param name="c">Third triangle side.</param>
        /// <exception cref="ArgumentOutOfRangeException">Triangle side value is less than or equal to 0.</exception>
        /// <exception cref="ArgumentException">Invalid triangle side values.</exception>
        public Triangle(double a, double b, double c)
        {
            Guard.Argument(a, nameof(a)).NotNegative(message: a => ExceptionMessages.TriangleSideCannotBeNegative)
                .GreaterThan(0, message: (a, x) => ExceptionMessages.TriangleSideMustBeGreaterThanZero);

            Guard.Argument(b, nameof(b)).NotNegative(m => ExceptionMessages.TriangleSideCannotBeNegative)
                .GreaterThan(0, message: (b, x) => ExceptionMessages.TriangleSideMustBeGreaterThanZero);

            Guard.Argument(c, nameof(c)).NotNegative(m => ExceptionMessages.TriangleSideCannotBeNegative)
                .GreaterThan(0, message: (c, x) => ExceptionMessages.TriangleSideMustBeGreaterThanZero);

            if (!(a + b > c && a + c > b && b + c > a))
                throw new ArgumentException(ExceptionMessages.TriangleWithGivenSidesDoesNotExists);

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Check triangle is right angled.
        /// </summary>
        public bool IsRightAngled => CheckIsRightAngled();

        private bool CheckIsRightAngled()
        {
            double maxSide = GetMaxSide();
            double maxSideSqr = maxSide * maxSide;

            return maxSideSqr + maxSideSqr == A * A + B * B + C * C;
        }

        private double GetMaxSide()
            => new[] { A, B, C }.Max();
    }
}
