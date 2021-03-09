using System;
using System.Collections.Generic;

namespace Challenges
{
    class Program
    {
        // change to private?
        static Challenges01 _challenges = new Challenges01();
        
        static void Main(string[] args)
        {
            // Hello world, show current challenge, wait for user input to pick a solution
            Console.WriteLine("Challenges: Hello World!");
            Console.WriteLine();
            _challenges.CurrentChallenge();


            // user input for specific solution (1-5)
            int input = 0;
            do
            {
                Console.WriteLine($"\"0\" to Quit or Input a number from 1 to {_challenges.GetFunctionsCount()}: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); // incorrect format (string or space)
                }
               
                _challenges.RunSolution(input);
                Console.WriteLine(); // space after solutions run
            } while (input != 0);
        }
    }
}
