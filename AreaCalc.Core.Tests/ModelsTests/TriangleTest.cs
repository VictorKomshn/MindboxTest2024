using AreaCalc.Core.Models;

namespace AreaCalc.Core.Tests.ModelsTests
{
    internal class TriangleTest
    {
        #region One number

        [Test]
        public void Succes_On_OneNumber_Correct()
        {
            int testSideLength = 5;

            Triangle? testTriangle = null;

            Assert.DoesNotThrow(() => testTriangle = new Triangle(testSideLength));

            Assert.NotNull(testTriangle);

            Assert.That(testTriangle.FirstSide == testTriangle.SecondSide);
            Assert.That(testTriangle.SecondSide == testTriangle.ThirdSide);

            Assert.That(testTriangle.IsRight, Is.False);

            var expectedHalfPerimeter = testSideLength * 3 / 2;
            var expectedArea = Math.Sqrt(expectedHalfPerimeter * Math.Pow(expectedHalfPerimeter - testSideLength, 3));

            var actualArea = testTriangle.GetArea();

            var areaCorrect = Math.Abs(expectedArea - actualArea) > Constants.Precision;
            Assert.IsTrue(areaCorrect);
        }

        [Test]
        public void Exception_On_OneNumber_OutOfRange()
        {
            int testSideLength_incorrect = -1;

            Triangle? testTriangle = null;

            Assert.Throws<ArgumentOutOfRangeException>(() => testTriangle = new Triangle(testSideLength_incorrect));
        }

        #endregion

        #region TwoNumbers

        [Test]
        public void Succes_On_TwoNumber_Correct()
        {
            int testEqualSidesLength = 5;
            int testUnequalSideLength = 7;


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
        public void Exception_On_TwoNumber_OutOfRange()
        {
            int testEqualSidesLength = 1;
            int testUnequalSideLength = -2;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength));

            testEqualSidesLength = -1;
            testUnequalSideLength = -2;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength));

            testEqualSidesLength = -1;
            testUnequalSideLength = 2;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength));
        }

        [Test]
        public void Exception_On_TwoNumber_ExceedTriangleSideLengthLimit()
        {
            int testEqualSidesLength = 2;
            int testUnequalSideLength_incorrect = 10;

            Assert.Throws<ArgumentException>(() => new Triangle(testEqualSidesLength, testUnequalSideLength_incorrect));
        }

        [Test]
        public void IsRight_On_TwoNumber()
        {
            int testEqualSidesLength = 1;
            double testUnequalSideLength = Math.Sqrt(2);

            Triangle? testTriangle = new Triangle(testEqualSidesLength, testUnequalSideLength);

            Assert.That(testTriangle.IsRight, Is.True);
        }

        [Test]
        public void IsNotRight_On_TwoNumber()
        {
            int testEqualSidesLength = 3;
            double testUnequalSideLength = 4;

            Triangle? testTriangle = new Triangle(testEqualSidesLength, testUnequalSideLength);

            Assert.That(testTriangle.IsRight, Is.False);
        }

        #endregion

        #region Three numbers

        [Test]
        public void Succes_On_ThreeNumber_Correct()
        {
            int testFirstSidesLength = 5;
            int testSecondSideLength = 7;
            int testThirdSideLength = 10;


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
        public void Exception_On_ThreeNumber_OutOfRange()
        {
            int testFirstSidesLength = -5;
            int testSecondSideLength = 7;
            int testThirdSideLength = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));

            testFirstSidesLength = 5;
            testSecondSideLength = -7;
            testThirdSideLength = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));

            testFirstSidesLength = 5;
            testSecondSideLength = 7;
            testThirdSideLength = -10;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));
        }

        [Test]
        public void Exception_On_ThreeNumber_ExceedTriangleSideLengthLimit()
        {
            int testFirstSidesLength = 1;
            int testSecondSideLength = 3;
            int testThirdSideLength = 7;

            Assert.Throws<ArgumentException>(() => new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength));
        }

        [Test]
        public void IsRight_On_ThreeNumber()
        {
            int testFirstSidesLength = 3;
            int testSecondSideLength = 4;
            int testThirdSideLength = 5;

            Triangle? testTriangle = new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength);

            Assert.That(testTriangle.IsRight, Is.True);
        }

        [Test]
        public void IsNotRight_On_ThreeNumber()
        {
            int testFirstSidesLength = 3;
            int testSecondSideLength = 4;
            int testThirdSideLength = 6;

            Triangle? testTriangle = new Triangle(testFirstSidesLength, testSecondSideLength, testThirdSideLength);

            Assert.That(testTriangle.IsRight, Is.False);
        }

        #endregion

    }
}
