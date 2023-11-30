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
            string fileName = $"input_{numberOfDay}.txt";
            string relativePath = Path.Combine("inputs", fileName);
            string text = File.ReadAllText(relativePath);
            return text;
        }
    }
}