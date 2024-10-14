namespace AreaCalc.Core.Abstract
{
    public interface IFigureCreator
    {
        public IFigure CreateFigure(string typeName, params double[] parameters);
    }
}
