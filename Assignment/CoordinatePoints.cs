
using Ardalis.GuardClauses;

namespace Assignment
{
    public class CoordinatePoints
    {
        public readonly int xAxis, yAxis;

        public CoordinatePoints(int x, int y)
        {
            this.xAxis = Guard.Against.NegativeOrZero(x, nameof(x));
            this.yAxis = Guard.Against.NegativeOrZero(y, nameof(y));
        }
    }
}
