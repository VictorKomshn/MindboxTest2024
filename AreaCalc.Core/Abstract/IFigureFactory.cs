namespace AreaCalc.Core.Abstract
{
    /// <summary>
    /// Factory interface for managing <see cref="IFigure"/> interface
    /// </summary>
    internal interface IFigureFactory
    {
        /// <summary>
        /// Factory method 
        /// </summary>
        /// <param name="parameters">Parameters, necessary for creating a type of object</param>
        /// <returns></returns>
        public abstract IFigure Create(params double[] parameters);

    }
}
