using AreaCalc.Core.Models;

namespace AreaCalc.Core.Tests.ModelsTests
{
    internal class CircleTests
    {

        [Test]
        public void Succes_On_Input_Correct()
        {
            int testCircleRadius = 5;

            Circle? testCircle = null;

            Assert.DoesNotThrow(() => testCircle = new Circle(testCircleRadius));
            Assert.IsNotNull(testCircle);

            double expectedArea = Math.Pow(testCircleRadius, 2) * Math.PI;
            var actualArea = testCircle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) < Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        public void Exception_On_Input_NotCorrect()
        {
            int testCircleRadius_incorrect = -1;

            Circle? testCircle = null;

            Assert.Throws<ArgumentOutOfRangeException>(() => testCircle = new Circle(testCircleRadius_incorrect));
        }
    }
}
