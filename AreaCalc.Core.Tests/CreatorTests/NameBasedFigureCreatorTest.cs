using AreaCalc.Core.Abstract;
using AreaCalc.Core.Creators;

namespace AreaCalc.Core.Tests.CreatorTests
{
    internal class NameBasedFigureCreatortest
    {
        [Theory]
        [TestCase("circle", 1)]
        [TestCase("triangle", 2)]
        [TestCase("triangle", 2, 3)]
        [TestCase("triangle", 2, 3, 4)]
        public void Success_Factory_Exists(string figureName, params double[] parameters)
        {
            var tesNbfc = new NameBasedFigureCreator();
            IFigure? actualFigure = null;

            Assert.DoesNotThrow(() => actualFigure = tesNbfc.CreateFigure(figureName, parameters));

            Assert.NotNull(actualFigure);
        }


        [Theory]
        [TestCase("circlee", 1)]
        [TestCase("triangleFactory", 2)]
        [TestCase("rectangle", 2, 3)]
        public void Exception_Factory_Not_Exists(string figureName, params double[] parameters)
        {
            var tesNbfc = new NameBasedFigureCreator();

            Assert.Throws<ArgumentException>(() => tesNbfc.CreateFigure(figureName, parameters));
        }
    }
}
