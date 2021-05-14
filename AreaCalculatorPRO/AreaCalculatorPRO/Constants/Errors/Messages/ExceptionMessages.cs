namespace AreaCalculatorPRO.Constants.Errors.Messages
{
    /// <summary>
    /// Static class for storing exception messages.
    /// </summary>
    public static class ExceptionMessages
    {
        #region Triangle messages

        public static string TriangleSideCannotBeNegative => "The side of a triangle cannot be negative.";
        public static string TriangleSideMustBeGreaterThanZero => "The side of the triangle must be greater than 0.";
        public static string TriangleWithGivenSidesDoesNotExists => "Triangle with given sides does not exist.";

        #endregion

        #region Circle messages

        public static string CircleRadiusCannotBeNegative => "The radius of a circle cannot be negative.";
        public static string CircleRadiusMustBeGreaterThanZero => "The radius of a circle must be greater than 0.";

        #endregion
    }
}
