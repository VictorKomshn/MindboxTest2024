using AreaCalc.Core.Models;

namespace AreaCalc.Core.Tests.ModelsTests
{
    internal class TriangleTest
    {
        #region One number

        [Test]
        [TestCase(5)]
        public void Succes_On_OneNumber_Correct(double testSideLength)
        {
            Triangle? testTriangle = null;

            Assert.DoesNotThrow(() => testTriangle = new Triangle(testSideLength));

            Assert.NotNull(testTriangle);

            Assert.That(testTriangle.FirstSide == testTriangle.SecondSide);
            Assert.That(testTriangle.SecondSide == testTriangle.ThirdSide);

            Assert.That(testTriangle.IsRight, Is.False);

            var expectedHalfPerimeter = testSideLength * 3 / 2;
            var expectedArea = Math.Sqrt(expectedHalfPerimeter * Math.Pow(expectedHalfPerimeter - testSideLength, 3));

            var actualArea = testTriangle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) < Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        [TestCase(-1)]
        public void Exception_On_OneNumber_OutOfRange(double testSideLength_incorrect)
        {
            Triangle? testTriangle = null;

            Assert.Throws<ArgumentOutOfRangeException>(() => testTriangle = new Triangle(testSideLength_incorrect));
        }

        #endregion

        #region TwoNumbers

        [Test]
        [TestCase(5, 7)]
        public void Succes_On_TwoNumber_Correct(double testEqualSidesLength, double testUnequalSideLength)
        {
            Triangle? testTriangle = null;

            Assert.DoesNotThrow(() => testTriangle = new Triangle(testEqualSidesLength, testUnequalSideLength));

            Assert.NotNull(testTriangle);

            Assert.That(testTriangle.FirstSide == testTriangle.SecondSide);
            Assert.That(testTriangle.SecondSide != testTriangle.ThirdSide);

            Assert.That(testTriangle.IsRight, Is.False);

            double expectedHalfPerimeter = (testEqualSidesLength * 2 + testUnequalSideLength) / 2d;

            var expectedArea = Math.Sqrt(expectedHalfPerimeter *
                                         Math.Pow(expectedHalfPerimeter - testEqualSidesLength, 2) *
                                         (expectedHalfPerimeter - testUnequalSideLength));

            var actualArea = testTriangle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) < Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        [TestCase(1, -2)]
        [TestCase(-1, -2)]
        [TestCase(-1, 2)]
        public void Exception_On_TwoNumber_OutOfRange(double testEqualSidesLength, double testUnequalSideLength)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength));
        }

        [Test]
        [TestCase(2, 10)]
        public void Exception_On_TwoNumber_ExceedTriangleSideLengthLimit(double testEqualSidesLength, double testUnequalSideLength_incorrect)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength_incorrect));
        }

        [Test]
        [TestCase(1, 1.41421356)]
        public void IsRight_On_TwoNumber(double testEqualSidesLength, double testUnequalSideLength)
        {
            Triangle? testTriangle = new Triangle(testEqualSidesLength, testUnequalSideLength);

            Assert.That(testTriangle.IsRight, Is.True);
        }

        [Test]
        [TestCase(3, 4)]
        public void IsNotRight_On_TwoNumber(double testEqualSidesLength, double testUnequalSideLength)
        {
            Triangle? testTriangle = new Triangle(testEqualSidesLength, testUnequalSideLength);

            Assert.That(testTriangle.IsRight, Is.False);
        }

        #endregion

        #region Three numbers

        [Test]
        [TestCase(5, 7, 10)]
        public void Succes_On_ThreeNumber_Correct(double testFirstSidesLength,
                                                  double testSecondSideLength,
                                                  double testThirdSideLength)
        {
            Triangle? testTriangle = null;

            Assert.DoesNotThrow(() => testTriangle = new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));

            Assert.NotNull(testTriangle);

            var expectedhalfPerimeter = (testFirstSidesLength + testSecondSideLength + testThirdSideLength) / 2;

            var expectedArea = Math.Sqrt(expectedhalfPerimeter *
                                  (expectedhalfPerimeter - testFirstSidesLength) *
                                  (expectedhalfPerimeter - testSecondSideLength) *
                                  (expectedhalfPerimeter - testThirdSideLength));

            var actualArea = testTriangle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) < Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        [TestCase(-5, 7, 10)]
        [TestCase(5, -7, 10)]
        [TestCase(5, 7, -10)]
        public void Exception_On_ThreeNumber_OutOfRange(double testFirstSidesLength,
                                                        double testSecondSideLength,
                                                        double testThirdSideLength)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));
        }

        [Test]
        [TestCase(1, 3, 7)]

        public void Exception_On_ThreeNumber_ExceedTriangleSideLengthLimit(double testFirstSidesLength,
                                                                           double testSecondSideLength,
                                                                           double testThirdSideLength)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));
        }

        [Test]
        [TestCase(3, 4, 5)]

        public void IsRight_On_ThreeNumber(double testFirstSidesLength,
                                           double testSecondSideLength,
                                           double testThirdSideLength)
        {
            Triangle? testTriangle = new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength);

            Assert.That(testTriangle.IsRight, Is.True);
        }

        [Test]
        [TestCase(3, 4, 6)]

        public void IsNotRight_On_ThreeNumber(double testFirstSidesLength,
                                              double testSecondSideLength,
                                              double testThirdSideLength)
        {
            Triangle? testTriangle = new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength);

            Assert.That(testTriangle.IsRight, Is.False);
        }

        #endregion

    }
}
