using System;
using System.Transactions;

namespace aoc_2023
{
    public class PuzzleSolver
    {
        private readonly List<char> numbers;
        private readonly FileProcessor fileProcessor = new();
        public PuzzleSolver()
        {
            numbers = new List<char>();
            numbers.AddRange("0123456789");
        }
        private string CreateAnswer(int numberOfDay, string resultA, string resultB)
        {
            return $"The result of Task 1 on Day {numberOfDay} is: {resultA}.\nThe result of Task 2 on Day {numberOfDay} is: {resultB}.";
        }

        public string DayOne()
        {
            int numberOfDay = 1;
            List<string> lines = fileProcessor.ReturnFileAsListOfLines(numberOfDay);
            int solutionTaskOne = DayOneTaskOne(lines);
            int solutionTaskTwo = DayOneTaskTwo(lines);
            return CreateAnswer(numberOfDay, solutionTaskOne.ToString(), solutionTaskTwo.ToString());
        }

        private int DayOneTaskOne(List<string> lines)
        {
            int sum = 0;
            foreach (string line in lines)
            {
                int firstNumberInLine = FirstDigitInString(line);
                int lastNumberInLine = LastDigitInString(line);
                int searchedNumberInLine = 10 * firstNumberInLine + lastNumberInLine;
                sum += searchedNumberInLine;
            }
            return sum;
        }

        private int DayOneTaskTwo(List<string> lines)
        {
            return 0;
        }

        private bool IsNumber(char entry)
        {
            return numbers.Contains(entry);
        }

        private int FirstDigitInString(string numbersAndLetters)
        {
            foreach (char entry in numbersAndLetters)
            {
                if (IsNumber(entry))
                {
                    return (int)char.GetNumericValue(entry);
                }
            }
            throw new ArgumentException("Provided string contains no numbers!");
        }

        private int LastDigitInString(string numbersAndLetters)
        {
            foreach (char entry in numbersAndLetters.Reverse())
            {
                if (IsNumber(entry))
                {
                    return (int)char.GetNumericValue(entry);
                }
            }
            throw new ArgumentException("Provided string contains no numbers!");
        }

        public string DayTwo()
        {
            int numberOfDay = 2;
            List<string> lines = fileProcessor.ReturnFileAsListOfLines(numberOfDay);
            List<CubeGame> cubeGames = GetListOfCubeGames(lines);
            int solutionTaskOne = DayTwoTaskOne(cubeGames);
            int solutionTaskTwo = DayTwoTaskTwo(cubeGames);
            return CreateAnswer(numberOfDay, solutionTaskOne.ToString(), solutionTaskTwo.ToString());
        }

        private int DayTwoTaskOne(List<CubeGame> cubeGames)
        {
            int sum = 0;
            foreach (CubeGame cubeGame in cubeGames)
            {
                Dictionary<string, int> maximumConfiguration = new(){
                    {"red", 12},
                    {"green", 13},
                    {"blue", 14}};
                if (cubeGame.IsPossible(maximumConfiguration))
                {
                    sum += cubeGame.GameNumber;
                }
            }
            return sum;
        }

        private int DayTwoTaskTwo(List<CubeGame> cubeGames)
        {
            int sum = 0;
            foreach (CubeGame cubeGame in cubeGames)
            {
                sum += cubeGame.GetPower();
            }
            return sum;
        }

        private List<CubeGame> GetListOfCubeGames(List<string> lines)
        {
            List<CubeGame> cubeGames = new();
            foreach (string line in lines)
            {
                int gameNumber = int.Parse(line.Split(":")[0].Split(" ")[1]);
                string[] InformationOfAllGameSetsInGame = line.Split(":")[1].Split(";");
                cubeGames.Add(new(gameNumber, InformationOfAllGameSetsInGame));
            }
            return cubeGames;
        }
    }
}