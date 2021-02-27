using System;
using System.Collections.Generic;

namespace Challenges
{
    class Program
    {
        // change to private?
        static Challenges01 _challenges = new Challenges01();
        static List<int> solutionsCount = new List<int>(){1,2,3,4,5};
        
        static void Main(string[] args)
        {
            // Hello world, show current challenge, wait for user input to pick a solution
            Console.WriteLine("Challenges: Hello World!");
            Console.WriteLine();
            _challenges.CurrentChallenge();


            // user input for specific solution (1-5)
            Console.WriteLine($"\"0\" to Quit or Input a number from {solutionsCount[0]} to {solutionsCount[solutionsCount.Count-1]}: ");
            int input = 0;
            do
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // incorrect format (string or space)
                }
               
                _challenges.RunSolution(input);
            } while (input != 0);
        }
    }
}
