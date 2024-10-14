using AreaCalc.Core.Abstract;

namespace AreaCalc.Core.Models
{
    public class Triangle : IFigure, IRightFigure
    {
        #region Constructors

        /// <summary>
        /// Creates equilateral triangle
        /// </summary>
        /// <param name="sideLength">Equeal sides length</param>
        /// <exception cref="ArgumentOutOfRangeException">If side is less then zero</exception>
        public Triangle(double sideLength)
        {
            if (sideLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sideLength), "Triangle side can not be less then 0");
            }

            FirstSide = sideLength;
            SecondSide = sideLength;
            ThirdSide = sideLength;
        }

        /// <summary>
        /// Creates isosceles triangle
        /// </summary>
        /// <param name="equalsidesLength">Equal sides length</param>
        /// <param name="unequalSideLength">Unequal sides lenth</param>
        /// <exception cref="ArgumentOutOfRangeException">If any side is less then zero</exception>
        /// <exception cref="ArgumentException">If unequal side is greater then sum of equeal</exception>
        public Triangle(double equalsidesLength, double unequalSideLength)
        {
            if (equalsidesLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(equalsidesLength), "Triangle side can not be less then 0");
            }
            else if (unequalSideLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unequalSideLength), "Triangle side can not be less then 0");
            }

            if (unequalSideLength > equalsidesLength * 2)
            {
                throw new ArgumentException(nameof(unequalSideLength), "Triangle side can not be greater then sum of two others");
            }

            FirstSide = equalsidesLength;
            SecondSide = equalsidesLength;
            ThirdSide = unequalSideLength;

            IsRight = CheckIsRight();
        }

        /// <summary>
        /// Creates regular triangle 
        /// </summary>
        /// <param name="firstSide">first side length</param>
        /// <param name="secondSide">second side length</param>
        /// <param name="thirdSide">third side length</param>
        /// <exception cref="ArgumentOutOfRangeException">If any side is less then zero</exception>
        /// <exception cref="ArgumentException">If unequal side is greater then sum of equeal</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(firstSide), "Triangle side can not be less then 0");
            }
            else if (secondSide < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(secondSide), "Triangle side can not be less then 0");
            }
            else if (thirdSide < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(thirdSide), "Triangle side can not be less then 0");
            }

            var biggestSide = Math.Max(firstSide, Math.Max(secondSide, thirdSide));
            var sumOfSmallestSides = firstSide + secondSide + thirdSide - biggestSide;
            if (sumOfSmallestSides < biggestSide)
            {
                throw new ArgumentException(nameof(biggestSide), "Triangle side can not be greater then sum of two others");
            }

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            IsRight = CheckIsRight();
        }

        #endregion

        #region Public fields

        public double FirstSide { get; }

        public double SecondSide { get; }

        public double ThirdSide { get; }

        public bool IsRight { get; }

        #endregion

        #region Public methods

        public double GetArea()
        {
            var halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2d;

            var result = Math.Sqrt(halfPerimeter *
                                  (halfPerimeter - FirstSide) *
                                  (halfPerimeter - SecondSide) *
                                  (halfPerimeter - ThirdSide));

            return result;

        }

        #endregion

        #region Private methods

        public bool CheckIsRight()
        {
            double biggestSide = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));

            double biggestSideSquare = Math.Pow(biggestSide, 2);

            double allSidesSum = Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2) + Math.Pow(ThirdSide, 2);

            bool isRight = Math.Abs(biggestSideSquare * 2 - allSidesSum) < Constants.Precision;

            return isRight;
        }

        #endregion
    }
}
