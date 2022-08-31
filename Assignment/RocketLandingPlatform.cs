
namespace Assignment
{
    public class RocketLandingPlatform
    {
        private RocketPosition? occupiedPosition;
        private const int mandatoryGapBetweenRockets = 1;

        public string CheckIfRequestedCoordinateAvailableForLanding(CoordinatePoints requestedCoordinate)
        {
            if (CheckIfRequestedCoordinateIsOutsideLandingPlatform(requestedCoordinate))
            {
                return ResponseMessage.OutofPlatform;
            }

            if (occupiedPosition is not null)
            {
                if (CheckIfRequestedCoordinateIsInsideLastCheckedPosition(requestedCoordinate))
                {
                    return ResponseMessage.Clash;
                }

                if (CheckIfRequestedCoordinateIsInsideLastCheckedPositionBoundaries(requestedCoordinate))
                {
                    return ResponseMessage.Clash;
                }
            }
            occupiedPosition = new RocketPosition(requestedCoordinate);
            return ResponseMessage.OkForLanding;
        }
        private bool CheckIfRequestedCoordinateIsInsideLastCheckedPosition(CoordinatePoints requestedCoordinate)
        {
            return (occupiedPosition?.TopLeftCoordinate.xAxis == requestedCoordinate.xAxis || occupiedPosition?.TopRightCoordinate.xAxis + 1 == requestedCoordinate.xAxis)
               || (occupiedPosition?.TopLeftCoordinate.yAxis == requestedCoordinate.yAxis || occupiedPosition?.TopLeftCoordinate.yAxis + 1 == requestedCoordinate.yAxis);
        }

        private bool CheckIfRequestedCoordinateIsInsideLastCheckedPositionBoundaries(CoordinatePoints requestedCoordinate)
        {
            return (occupiedPosition?.TopLeftCoordinate.xAxis - mandatoryGapBetweenRockets == requestedCoordinate.xAxis || occupiedPosition?.TopRightCoordinate.xAxis + mandatoryGapBetweenRockets == requestedCoordinate.xAxis
                      || occupiedPosition?.TopLeftCoordinate.yAxis - mandatoryGapBetweenRockets == requestedCoordinate.yAxis || occupiedPosition?.BottomLeftCoordinate.yAxis + mandatoryGapBetweenRockets == requestedCoordinate.yAxis);
        }

        private static bool CheckIfRequestedCoordinateIsOutsideLandingPlatform(CoordinatePoints requestedCoordinate)
        {
            return (Settings.PlatformSize + Settings.startingXcoordinate < requestedCoordinate.xAxis || Settings.PlatformSize + Settings.startingYcoordinate < requestedCoordinate.yAxis
                     || Settings.PlatformStartingPosition.xAxis > requestedCoordinate.xAxis || Settings.PlatformStartingPosition.yAxis > requestedCoordinate.yAxis);
        }
    }
}