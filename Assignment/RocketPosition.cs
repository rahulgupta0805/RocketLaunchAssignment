using Ardalis.GuardClauses;

namespace Assignment
{
    public class RocketPosition
    {
        public readonly CoordinatePoints TopLeftCoordinate;
        public readonly CoordinatePoints BottomLeftCoordinate;
        public readonly CoordinatePoints TopRightCoordinate;
        public readonly CoordinatePoints BottomRightCoordinate;

        public RocketPosition(CoordinatePoints position)
        {
            Guard.Against.Null(position, nameof(position));   

            TopLeftCoordinate = new CoordinatePoints(position.xAxis, position.yAxis);
            TopRightCoordinate = new CoordinatePoints(position.xAxis + 1, position.yAxis);
            BottomLeftCoordinate = new CoordinatePoints(position.xAxis, position.yAxis + 1);
            BottomRightCoordinate = new CoordinatePoints(position.xAxis + 1, position.yAxis + 1);
        }
    }
}
