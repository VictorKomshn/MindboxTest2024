using AreaCalc.Core.Abstract;
using AreaCalc.Core.Models.Factories;

namespace AreaCalc.Core.Tests.ModelsTests.FactoriesTests
{
    internal class TriangleFactoryTest
    {
        [Test]
        public void Succes_On_OneNumber_Input_Correct()
        {
            int testTriangleSide = 5;

            var factory = new TriangleFactory();

            Assert.DoesNotThrow(() => factory.Create(testTriangleSide));
        }

        [Test]
        public void Succes_On_TwoNumbers_Input_Correct()
        {
            int testEqualTriangleSide = 5;
            int testUnequalTriangleSide = 5;

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
        public void Exception_On_Input_Incorrect()
        {
            int testTriangleSide_incorrect = -5;

            var factory = new CircleFactory();

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(testTriangleSide_incorrect));
        }

        [Test]
        public void EqualAreas_On_Input_Override()
        {
            int testFirstCircleRadius = 5;
            int testSecondTriangleSide = 6;
            int testThirdTriangleSide = 6;
            int testTriangleSide_override = 6;

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
