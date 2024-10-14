using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Models.Factories
{
    public class TriangleFactory : IFigureFactory
    {
        public IFigure Create(params double[] parameters)
        {
            if (parameters.Length >= 3)
            {
                return new Triangle(parameters[0], parameters[1], parameters[2]);
            }
            else if (parameters.Length == 2)
            {
                return new Triangle(parameters[0], parameters[1]);
            }
            else if (parameters.Length == 1)
            {
                return new Triangle(parameters[0]);
            }
            else
            {
                throw new ArgumentException(nameof(parameters), "Connot create triangle without any parameters");
            }
        }
    }
}
