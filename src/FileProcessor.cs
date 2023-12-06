using System;
using System.IO;

namespace aoc_2023
{
    public class FileProcessor
    {
        public FileProcessor()
        {

        }
        public string ReturnFileAsString(int numberOfDay)
        {
            string text = File.ReadAllText(GetRelativePathToInput(numberOfDay));
            return text;
        }

        public List<string> ReturnFileAsListOfLines(int numberOfDay)
        {
            List<string> lines = File.ReadAllLines(GetRelativePathToInput(numberOfDay)).ToList();
            return lines;
        }

        private string GetRelativePathToInput(int numberOfDay)
        {
            string fileName = $"input_{numberOfDay}.txt";
            string relativePath = Path.Combine("inputs", fileName);
            return relativePath;
        }
    }
}