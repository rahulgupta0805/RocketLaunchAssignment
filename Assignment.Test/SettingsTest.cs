namespace Assignment.Test
{
    public class SettingsTest
    {
        [Fact]
        public void ShouldSetPlatformSize()
        {
            int platformSize = 15;
            //Act
            Settings.SetPlatformSize(platformSize);

            //Assert
            Assert.Equal(15, platformSize);
        }
    }
}