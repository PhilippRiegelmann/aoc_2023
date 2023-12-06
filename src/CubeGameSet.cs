namespace aoc_2023
{
    public class CubeGameSet
    {
        private Dictionary<string, int> CubeEntries;
        public CubeGameSet(string informationOfSet)
        {
            CubeEntries = GetCubeEntries(informationOfSet);
        }
        public int GetNumberOfCubesByColor(string color)
        {
            if (CubeEntries.ContainsKey(color))
            {
                return CubeEntries[color];
            }
            return 0;
        }

        private Dictionary<string, int> GetCubeEntries(string informationOfSet)
        {
            Dictionary<string, int> cubeEntries = new();
            string[] cubeInformation = informationOfSet.Split(",");
            foreach (string singleCubeInformation in cubeInformation)
            {
                string[] colorAndAmount = (singleCubeInformation.Trim()).Split(" ");
                cubeEntries.Add(colorAndAmount[1], int.Parse(colorAndAmount[0]));
            }
            return cubeEntries;
        }
    }
}
