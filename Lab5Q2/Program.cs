using System;

namespace Lab5Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence1 = "one two three four five";
            string sentence2 = "one two! three four? five, six seven eight nine ten";
            string sentence3 = "one two three four, five six seven";

            Console.WriteLine($"Sentence 1 word count: {sentence1.WordCount()}");
            Console.WriteLine($"Sentence 2 word count: {sentence2.WordCount()}");
            Console.WriteLine($"Sentence 3 word count: {sentence3.WordCount()}");
        }

        
    }

    public static class StringExtensions 
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}