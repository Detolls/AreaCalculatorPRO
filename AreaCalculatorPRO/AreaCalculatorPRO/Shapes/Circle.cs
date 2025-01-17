﻿using AreaCalculatorPRO.Constants.Errors.Messages;
using AreaCalculatorPRO.Shapes.Base;
using Dawn;
using System;
using System.Threading.Tasks;

namespace AreaCalculatorPRO.Shapes
{
    /// <summary>
    /// Circle.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Radius.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <exception cref="ArgumentOutOfRangeException">Circle radius value is less than or equal to 0.</exception>
        public Circle(double radius)
        {
            Guard.Argument(radius, nameof(radius)).NotNegative(message: radius => ExceptionMessages.CircleRadiusCannotBeNegative)
                .GreaterThan(0, message: (radius, x) => ExceptionMessages.CircleRadiusMustBeGreaterThanZero);

            Radius = radius;
        }

        /// <inheritdoc cref="Shape.GetArea"/>
        public override double GetArea()
        {
            return Math.PI * (Radius * Radius);
        }

        /// <inheritdoc cref="Shape.GetAreaAsync"/>
        public override async Task<double> GetAreaAsync()
        {
            return await Task.Factory.StartNew(() => GetArea());
        }
    }
}
