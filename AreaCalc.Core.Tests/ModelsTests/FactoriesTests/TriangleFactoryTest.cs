using AreaCalc.Core.Abstract;
using AreaCalc.Core.Models.Factories;

namespace AreaCalc.Core.Tests.ModelsTests.FactoriesTests
{
    internal class TriangleFactoryTest
    {
        [Test]
        [TestCase(5)]
        public void Succes_On_OneNumber_Input_Correct(double testTriangleSide)
        {
            var factory = new TriangleFactory();

            Assert.DoesNotThrow(() => factory.Create(testTriangleSide));
        }

        [Test]
        [TestCase(5, 5)]
        public void Succes_On_TwoNumbers_Input_Correct(double testEqualTriangleSide, double testUnequalTriangleSide)
        {
            var factory = new TriangleFactory();

            Assert.DoesNotThrow(() => factory.Create(testEqualTriangleSide, testUnequalTriangleSide));
        }

        [Test]
        public void Exception_On_Input_Empty()
        {
            var factory = new TriangleFactory();

            Assert.Throws<ArgumentException>(() => factory.Create());
        }

        [Test]
        [TestCase(-5)]
        public void Exception_On_Input_Incorrect(double testTriangleSide_incorrect)
        {
            var factory = new CircleFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(testTriangleSide_incorrect));
        }

        [Test]
        [TestCase(5, 6, 6, 6)]
        public void EqualAreas_On_Input_Override(double testFirstCircleRadius,
                                                 double testSecondTriangleSide,
                                                 double testThirdTriangleSide,
                                                 double testTriangleSide_override)
        {
            var factory = new CircleFactory();

            IFigure? firstCircle = null;

            Assert.DoesNotThrow(() => firstCircle = factory.Create(testFirstCircleRadius, testSecondTriangleSide, testThirdTriangleSide));

            Assert.NotNull(firstCircle);

            IFigure? secondCircle = null;

            Assert.DoesNotThrow(() => secondCircle = factory.Create(testFirstCircleRadius, testSecondTriangleSide, testThirdTriangleSide, testTriangleSide_override));

            Assert.NotNull(secondCircle);

            var areasEqual = (firstCircle.GetArea() - secondCircle.GetArea()) < Constants.Precision;

            Assert.That(areasEqual, Is.True);
        }
    }
}
