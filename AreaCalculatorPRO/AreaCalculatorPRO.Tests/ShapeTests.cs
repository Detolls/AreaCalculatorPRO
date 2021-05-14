using AreaCalculatorPRO;
using AreaCalculatorPRO.Shapes;
using AreaCalculatorPRO.Shapes.Base;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AreaCalculatorPRO.Tests
{
    public class ShapeTests
    {
        [Theory]
        [InlineData(typeof(Triangle), -1, 1, 1)]
        [InlineData(typeof(Triangle), 1, -1, 1)]
        [InlineData(typeof(Triangle), 1, 1, -1)]
        [InlineData(typeof(Triangle), -1, -1, -1)]
        [InlineData(typeof(Triangle), -5, -13, -7)]

        [InlineData(typeof(Circle), -1)]
        [InlineData(typeof(Circle), -5)]
        [InlineData(typeof(Circle), -15)]
        public void Create_Shape_With_Negative_Values_ThrowsAgrumentOutOfRangeException(Type shapeType, params object[] testShapeData)
        {
            Exception ex = Record.Exception(() => Activator.CreateInstance(shapeType, testShapeData));

            Assert.IsType<ArgumentOutOfRangeException>(ex.InnerException);
        }

        [Theory]
        [InlineData(typeof(Triangle), 0, 0, 0)]
        [InlineData(typeof(Triangle), 1, 0, 0)]
        [InlineData(typeof(Triangle), 0, 1, 0)]
        [InlineData(typeof(Triangle), 0, 0, 1)]
        [InlineData(typeof(Triangle), 1, 0, 1)]

        [InlineData(typeof(Circle), 0)]
        public void Create_Shape_With_Zero_Values_ThrowsArgumentOutOfRangeException(Type shapeType, params object[] testShapeData)
        {
            Exception ex = Record.Exception(() => Activator.CreateInstance(shapeType, testShapeData));

            Assert.IsType<ArgumentOutOfRangeException>(ex.InnerException);
        }

        [Theory]
        [InlineData(typeof(Triangle), 1, 1, 1)]
        [InlineData(typeof(Triangle), 5, 12, 7)]

        [InlineData(typeof(Circle), 1)]
        [InlineData(typeof(Circle), 12)]
        public void Create_Shape_With_Not_Negative_And_Not_Zero_Values_NotThrowsArgumentOutOfRangeException(Type shapeType, params object[] testShapeData)
        {
            Exception ex = Record.Exception(() => Activator.CreateInstance(shapeType, testShapeData));

            Assert.IsNotType<ArgumentOutOfRangeException>(ex);
        }

        [Theory]
        [InlineData(6, 8, 10)]
        [InlineData(8, 10, 6)]
        [InlineData(3, 4, 5)]
        [InlineData(5, 4, 3)]
        public void Create_Triangle_Instance_With_Side_Right_Angled_Values_Is_Right_Angled_Property_ReturnsTrue(params object[] testTriangleData)
        {
            var rightAngledTriangle = Activator.CreateInstance(typeof(Triangle), testTriangleData) as Triangle;

            Assert.True(rightAngledTriangle.IsRightAngled);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 4)]
        public void Create_Triangle_Instance_With_Side_Not_Right_Angled_Values_Is_Right_Angled_Property_ReturnsFalse(params object[] testTriangleData)
        {
            var notRightAngledTriangle = Activator.CreateInstance(typeof(Triangle), testTriangleData) as Triangle;

            Assert.False(notRightAngledTriangle.IsRightAngled);
        }

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(5, 4, 12)]
        public void Create_Triangle_Instance_With_Not_Valid_Side_Values_ThrowsArgumentException(params object[] testTriangleData)
        {
            Exception ex = Record.Exception(() => Activator.CreateInstance(typeof(Triangle), testTriangleData));

            Assert.IsNotType<ArgumentException>(ex);
        }


        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(5, 4, 9)]
        public void Create_Triangle_Instance_With_Valid_Side_Values_NotThrowsArgumentException(params object[] testTriangleData)
        {
            Exception ex = Record.Exception(() => Activator.CreateInstance(typeof(Triangle), testTriangleData));

            Assert.IsNotType<ArgumentException>(ex);
        }

        [Theory]
        [InlineData(6, typeof(Triangle), 3, 4, 5)]
        [InlineData(0.4330127018922193, typeof(Triangle), 1, 1, 1)]
        [InlineData(2.48746859276655, typeof(Triangle), 1, 5, 5)]
        [InlineData(2.48746859276655, typeof(Triangle), 5, 5, 1)]
        [InlineData(2.48746859276655, typeof(Triangle), 5, 1, 5)]
        [InlineData(26.906086671978144, typeof(Triangle), 8, 7, 12)]
        [InlineData(26.906086671978144, typeof(Triangle), 12, 7, 8)]

        [InlineData(3.141592653589793, typeof(Circle), 1)]
        [InlineData(78.53981633974483, typeof(Circle), 5)]
        [InlineData(452.3893421169302, typeof(Circle), 12)]
        public void Calculate_Shape_Area_ReturnsCorrectTriangleArea(double exceptedArea, Type shapeType, params object[] testShapeData)
        {
            var shape = Activator.CreateInstance(shapeType, testShapeData) as Shape;

            double actualArea = shape.GetArea();

            Assert.Equal(exceptedArea, actualArea);
        }

        [Theory]
        [InlineData(6, typeof(Triangle), 3, 4, 5)]
        [InlineData(0.4330127018922193, typeof(Triangle), 1, 1, 1)]
        [InlineData(2.48746859276655, typeof(Triangle), 1, 5, 5)]
        [InlineData(2.48746859276655, typeof(Triangle), 5, 5, 1)]
        [InlineData(2.48746859276655, typeof(Triangle), 5, 1, 5)]
        [InlineData(26.906086671978144, typeof(Triangle), 8, 7, 12)]
        [InlineData(26.906086671978144, typeof(Triangle), 12, 7, 8)]

        [InlineData(3.141592653589793, typeof(Circle), 1)]
        [InlineData(78.53981633974483, typeof(Circle), 5)]
        [InlineData(452.3893421169302, typeof(Circle), 12)]
        public async Task CalculateAsync_Triangle_Area_ReturnsCorrectTriangleArea(double exceptedArea, Type shapeType, params object[] testShapeData)
        {
            var shape = Activator.CreateInstance(shapeType, testShapeData) as Shape;

            double actualArea = await shape.GetAreaAsync();

            Assert.Equal(exceptedArea, actualArea);
        }
    }
}
