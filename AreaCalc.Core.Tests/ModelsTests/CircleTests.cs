using AreaCalc.Core.Models;

namespace AreaCalc.Core.Tests.ModelsTests
{
    internal class CircleTests
    {

        [Test]
        [TestCase(5)]
        public void Succes_On_Input_Correct(double testCircleRadius)
        {
            Circle? testCircle = null;

            Assert.DoesNotThrow(() => testCircle = new Circle(testCircleRadius));
            Assert.IsNotNull(testCircle);

            double expectedArea = Math.Pow(testCircleRadius, 2) * Math.PI;
            var actualArea = testCircle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) < Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        [TestCase(-1)]
        public void Exception_On_Input_NotCorrect(double testCircleRadius_incorrect)
        {
            Circle? testCircle = null;

            Assert.Throws<ArgumentOutOfRangeException>(() => testCircle = new Circle(testCircleRadius_incorrect));
        }
    }
}
