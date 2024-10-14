using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Models
{
    /// <summary>
    /// Circle representation
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Create circle object
        /// </summary>
        /// <param name="radius"> Circle radius </param>
        /// <exception cref="ArgumentOutOfRangeException">If radius is less then zero</exception>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Non-negative number requeired");
            }
            Radius = radius;
        }

        public double Radius { get; private set; }

        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
