using AreaCalc.Core.Abstract;
using AreaCalc.Core.Models.Factories;

namespace AreaCalc.Core.Tests.ModelsTests.FactoriesTests
{
    internal class CircleFactoryTest
    {
        [Test]
        public void Succes_On_Input_Correct()
        {
            int testCircleRadius = 5;

            var factory = new CircleFactory();

            Assert.DoesNotThrow(() => factory.Create(testCircleRadius));
        }

        [Test]
        public void Exception_On_Input_Empty()
        {
            var factory = new CircleFactory();

            Assert.Throws<ArgumentException>(() => factory.Create());
        }

        [Test]
        public void Exception_On_Input_Incorrect()
        {
            int testCircleRadius_incorrect = -5;

            var factory = new CircleFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(testCircleRadius_incorrect));
        }

        [Test]
        public void EqualAreas_On_Input_Override()
        {
            int testCircleRadius = 5;
            int testCircleRadiusOverride = 6;

            var factory = new CircleFactory();

            IFigure? firstCircle = null;

            Assert.DoesNotThrow(() => firstCircle = factory.Create(testCircleRadius));

            Assert.NotNull(firstCircle);

            IFigure? secondCircle = null;

            Assert.DoesNotThrow(() => secondCircle = factory.Create(testCircleRadius, testCircleRadiusOverride));

            Assert.NotNull(secondCircle);

            var areasEqual = (firstCircle.GetArea() - secondCircle.GetArea()) < Constants.Precision;

            Assert.That(areasEqual, Is.True);
        }
    }
}
