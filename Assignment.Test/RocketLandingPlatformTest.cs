namespace Assignment.Test
{
    public class RocketLandingPlatformTest
    {
        private readonly RocketLandingPlatform _rocketLandingPlatform;
        public RocketLandingPlatformTest()
        {
            _rocketLandingPlatform = new RocketLandingPlatform();
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(27, 17)]

        public void ShouldReply_OutOfPlatform_WhenLandingPositionIsNotInsideTheLandingPlatform(int xCoordinate, int yCoordinate)
        {
            //Arrange
            CoordinatePoints rocketCoordinates = new CoordinatePoints(xCoordinate, yCoordinate);
            
            //Act
            var result = _rocketLandingPlatform.CheckIfRequestedCoordinateAvailableForLanding(rocketCoordinates);


            //Assert
            Assert.Equal(ResponseMessage.OutofPlatform, result);

        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(8, 9)]
        public void ShouldReply_OKForLanding_WhenLandingPositionIsNotOccupied(int xCoordinate, int yCoordinate)
        {
            //Arrange
            CoordinatePoints rocketCoordinates = new CoordinatePoints(xCoordinate, yCoordinate);

            //Act
            var result = _rocketLandingPlatform.CheckIfRequestedCoordinateAvailableForLanding(rocketCoordinates);


            //Assert
            Assert.Equal(ResponseMessage.OkForLanding, result);
        }

        [Theory]
        [InlineData(6, 6)]
        [InlineData(7, 8)]
        public void ShouldReply_Clash_WhenLandingPositionIsOccupied(int xCoordinate, int yCoordinate)
        {
            //Arrange
            CoordinatePoints firstrocketCoordinates = new CoordinatePoints(xCoordinate, yCoordinate);
            CoordinatePoints secondrocketCoordinates = new CoordinatePoints(xCoordinate, yCoordinate);

            //Act         
            _rocketLandingPlatform.CheckIfRequestedCoordinateAvailableForLanding(firstrocketCoordinates);
            var result = _rocketLandingPlatform.CheckIfRequestedCoordinateAvailableForLanding(secondrocketCoordinates);


            //Assert
            Assert.Equal(ResponseMessage.Clash, result);

        }
    }
}