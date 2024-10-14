using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Models.Factories
{
    public class CircleFactory : FigureFactoryBase
    {
        public override IFigure Create(params double[] parameters)
        {
            if (parameters.Length >= 1)
            {
                return new Circle(parameters[0]);
            }
            else
            {
                throw new ArgumentException(nameof(parameters), "Connot create circle without any parameters");
            }
        }
    }
}
