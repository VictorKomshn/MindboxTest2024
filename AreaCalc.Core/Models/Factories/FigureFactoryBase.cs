using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Models.Factories
{
    /// <summary>
    /// Base factory for managing <see cref="IFigure"/> interface
    /// </summary>
    public abstract class FigureFactoryBase
    {
        /// <summary>
        /// Factory method 
        /// </summary>
        /// <param name="parameters">Parameters, necessary for creating a type of object</param>
        /// <returns></returns>
        public abstract IFigure Create(params double[] parameters);
    }
}
