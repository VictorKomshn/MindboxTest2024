namespace AreaCalc.Core.Abstract
{
    /// <summary>
    /// Interface, which represents figures, that are possible to be right
    /// </summary>
    public interface IRightFigure
    {
        /// <summary>
        /// checks, if the current figure is right
        /// </summary>
        /// <returns></returns>
        public bool CheckIsRight();
    }
}
