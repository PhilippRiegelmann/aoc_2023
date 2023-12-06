namespace aoc_2023
{
    public class CubeGame
    {
        private List<CubeGameSet> CubeGameSets;
        private List<string> ExistingColors = new() { "red", "blue", "green" };
        public int GameNumber;
        public CubeGame(int gameNumber, string[] informationOfAllGameSets)
        {
            GameNumber = gameNumber;
            CubeGameSets = new();
            foreach (string informationOfSet in informationOfAllGameSets)
            {
                CubeGameSets.Add(new CubeGameSet(informationOfSet));
            }
        }
        public bool IsPossible(Dictionary<string, int> valueToCheck)
        {
            foreach (KeyValuePair<string, int> keyValuePair in valueToCheck)
            {
                foreach (CubeGameSet cubeGameSet in CubeGameSets)
                {
                    if (cubeGameSet.GetNumberOfCubesByColor(keyValuePair.Key) > keyValuePair.Value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private int GetMaximumNumberInSets(string color)
        {
            int maximum = 0;
            foreach (CubeGameSet cubeGameSet in CubeGameSets)
            {
                maximum = Math.Max(maximum, cubeGameSet.GetNumberOfCubesByColor(color));
            }
            return maximum;
        }

        public int GetPower()
        {
            int power = 1;
            foreach (string color in ExistingColors)
            {
                power *= GetMaximumNumberInSets(color);
            }
            return power;
        }
    }
}
