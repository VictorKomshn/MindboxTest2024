using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Creators
{
    public class NameBasedFigureCreator : IFigureCreator
    {
        public NameBasedFigureCreator()
        {
            var figureFactoryInterface = typeof(IFigureFactory);

            var figureFactoryTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(figureFactoryInterface.IsAssignableFrom).Where(x => !x.IsAbstract);

            _figures = new Dictionary<string, IFigureFactory>();

            foreach (var figureFactoryType in figureFactoryTypes)
            {
                var figureName = figureFactoryType.Name.Substring(0, figureFactoryType.Name.Length - 7).ToLowerInvariant();

                var figureFactory = (IFigureFactory?)Activator.CreateInstance(figureFactoryType);
                if (figureFactory != null)
                {
                    _figures.Add(figureName, figureFactory);
                }
            }

        }

        private readonly Dictionary<string, IFigureFactory> _figures;

        public IFigure CreateFigure(string typeName, params double[] parameters)
        {
            var factoryExists = _figures.TryGetValue(typeName, out var factory);

            if (factoryExists && factory != null)
            {
                return factory.Create(parameters);
            }
            else
            {
                throw new ArgumentException(nameof(typeName), typeName + " figure does not exist");
            }
        }
    }
}
