using Ardalis.GuardClauses;

namespace Assignment
{
    public static class Settings
    {
        internal static int PlatformSize = 10;
        internal static int startingXcoordinate = 5;
        internal static int startingYcoordinate = 5;
        internal static CoordinatePoints PlatformStartingPosition = new(startingXcoordinate, startingYcoordinate);

        public static void SetPlatformSize(int platformSize)
        {
            Guard.Against.NegativeOrZero(platformSize, nameof(platformSize));
            if (platformSize <= 0 || platformSize > 100)
            {
                throw new ArgumentOutOfRangeException($"{nameof(platformSize)} is not a valid platform size.The size should be between 1 and 100");
            }
            PlatformSize = platformSize;
        }
    }
}
