using System;

namespace aoc_2023
{
    public class PuzzleSolver
    {
        FileProcessor fileProcessor = new FileProcessor();
        public PuzzleSolver()
        {

        }
        public string Hello()
        {
            return fileProcessor.ReturnFileAsString(1);
        }
    }
}