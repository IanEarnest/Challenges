using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace Challenges
{
    class Challenges01
    {
        public Challenges01()
        {
            // need this? maybe?
        }

        public void CurrentChallenge()
        {
            //runSolutionArray1();
            //Solution100Doors();
            SolutionMultiplesOf3And5();
            Console.WriteLine();
        }
        public void RunSolution(int solutionNum = 0) // cases for 1, 2, 3
        {
            switch (solutionNum)
            {
                case 1:
                    SolutionArray1();
                    break;
                case 2:
                    Solution100Doors();
                    break;
                case 3:
                    SolutionMultiplesOf3And5();
                    break;
                default:
                    ;
                    break;
            }
        }






        #region Array1
        void SolutionsArray1() // run solution array 1
        {
            int[] AArray = new int []{
                1, 3, 6, 4, 1, 2
            };


            int[] BArray = new int []{
                1,2,3
            };

            int[] CArray = new int []{
                -1,-3
            };
            Console.WriteLine(SolutionArray1(AArray));
            Console.WriteLine();
            Console.WriteLine(SolutionArray1(BArray));
            Console.WriteLine();
            Console.WriteLine(SolutionArray1(CArray));
        }

        public int SolutionArray1()
        {
            int[] AArray = new int[]{
                    1, 3, 6, 4, 1, 2
                };
            return SolutionArray1(AArray);
        }
        public int SolutionArray1(int[] AArray)
        {
            if (AArray.Length == 0)
            {
                AArray = new int[]{
                    1, 3, 6, 4, 1, 2
                };
            }

            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Console.WriteLine("this is a debug message");
            Array.Sort(AArray);
            Console.WriteLine("[{0}]", string.Join(", ", AArray));
            //[1, 3, 6, 4, 1, 2]
            //[1, 2, 3]
            //[-1, -3]
            //[3, 4, 5, 6, 7]
            int lowestInt = 1;
            int firstNum = 0;
            int firstElement = 0;
            firstNum = AArray[firstElement];

            // check first - all negative numbers then positive? -2 -1 1 2 3
            //if(AArray.Length-1 > 0)
            // extreme single           expected 3 got 1
            // extreme min max value    expected 1 got 6
            // positive from 0 only     expected 101 got 1

            if (firstNum > 0) // if positive number
            {
                //lowestInt = firstNum - 1;
                for (int i = 0; i < AArray.Length; i++)
                {
                    if (i == AArray.Length - 1) // return last element + 1
                    {
                        return AArray[AArray.Length - 1] + 1;
                    }
                    else if (AArray[i] < AArray[i + 1]) // check next number is higher
                    {
                        if (AArray[i + 1] - AArray[i] > 1) // higher by more than 1
                        {
                            return AArray[i] + 1; // in between number found 1, 2, (3) 4, 5,
                        }
                    }
                    // if not greater then is same, so continue
                    //1, 1, 3, 4
                }
            }
            return lowestInt;
        }


        //if (firstNum > 0) // if positive number
        //{
        //    //lowestInt = firstNum - 1;


        //    for (int i = 0; i < AArray.Length; i++)
        //    {
        //        int j = 1;
        //        if (AArray[i] != j && AArray[i] > j)
        //        {
        //            //lowestInt = AArray[i];
        //            return AArray[i];
        //        }
        //        //1 1 3 4
        //    }
        //}
        //else
        //{
        //    //lowestInt = 1;
        //}
        #endregion

        public int Solution100Doors(int doors = 100)
        {
            #region 100 doors closed
            // 100 doors = closed
            int doorsCount = doors; // 100
            int passes = doorsCount;
            bool[] doorsArray = new bool[doorsCount]; // open, closed, closed, open?
                                                      // 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 ... 
                                                      // 100 passes

            // each pass toggle open/ closed
            int j = 0;
            int i = 1;
            for (; i <= passes; i++) // 100 passes?// 1, 2, 3...
            {
                j = 0;
                //int _jMultiply = 1;
                for (; j < passes;) // ? passes per 100// 2 = 50 passes...
                {
                    j = j + i;
                    if (j < passes)
                    {
                        doorsArray[j - 1] = !doorsArray[j - 1]; //0 = true...                        
                    }
                    // failsafe
                    //_jMultiply++;
                    //j = j + _jMultiply; // 3 = 3 x 2 (6),  3 = 3 x 3 (9)...
                }
                if (j <= 100)
                {
                    j++; // j = 2
                }
                else
                {
                    j = 0; // to include first number
                }
            }


            // Print 100 doors + value "Door 1 = true ...."
            int _doorNum = 1;
            int _openDoors = 0;
            int _closedDoors = 0;
            //int[] doorsOpenArray = new int[doorsCount];
            //int[] doorsClosedArray = new int[doorsCount];
            List<int> doorsOpenArray = new List<int>();
            List<int> doorsClosedArray = new List<int>();
            foreach (bool doorValue in doorsArray)
            {
                int doorsOpenArrayPos = 0;
                int doorsClosedArrayPos = 0;

                //100 lines is too much
                //Console.WriteLine($"Door {_doorNum} = {doorValue}");
                if (_doorNum % 10 == 0)
                {
                    Console.WriteLine("");
                }
                if (_doorNum < 10)
                {
                    Console.Write($"Door 0{_doorNum} = {doorValue}, ");
                }
                else
                {
                    Console.Write($"Door {_doorNum} = {doorValue}, ");
                }
                if (doorValue == true)
                {
                    _openDoors++;
                    doorsOpenArray.Add(_doorNum);
                    //doorsOpenArray[doorsOpenArrayPos] = _doorNum;
                    //doorsOpenArrayPos++;
                }
                else
                {
                    _closedDoors++;
                    doorsClosedArray.Add(_doorNum);
                    //doorsClosedArray[doorsClosedArrayPos] = _doorNum;
                    //doorsClosedArrayPos++;
                }
                _doorNum++;
            }
            Console.WriteLine();
            Console.WriteLine($"Closed doors =  {_closedDoors}, Open doors = {_openDoors}");
            Console.WriteLine("Closed doors: ");
            foreach (int item in doorsClosedArray)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("Open doors: ");
            foreach (int item in doorsOpenArray)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            // door num to toggle = pass + passStart (2, 4, 6... or 3, 6, 9...)



            // list which doors open/ closed once on pass 100





            /*
                100 doors in a row are all initially closed. You make 100 passes by the doors. The first time through, you visit every door and toggle the door (if the door is closed, you open it; if it is open, you close it).
                The second time you only visit every 2nd door (door #2, #4, #6, ...).
                The third time, every 3rd door (door #3, #6, #9, ...), etc, until you only visit the 100th door.

                Question: What state are the doors in after the last pass? Which are open, which are closed?
            */
            #endregion
            return 0;
        }

        public int SolutionMultiplesOf3And5(int targetNum = 1000)
        {
            #region Multiples of 3 and 5
            /*
            Multiples of 3 and 5 - 15 mins
                If we list all the natural numbers below 10 that are multiples of 3 or 5, 
            we get 3, 5, 6 and 9. The sum of these multiples is 23.
                Find the sum of all the multiples of 3 or 5 below 1000.

            */

            // 23 is sum of 10 = x 3 and x 5 = 3, 5, 6, 9 (added together = 23)
            // sum of 1000 (3 and 5 multiples)

            //if (_doorNum % 10 == 0)

            int firstMultiplier = 3;
            int secondMultiplier = 5;
            int targetNumber = targetNum;
            int targetNumberV0 = 10;
            int targetNumberV1 = 100;
            int targetNumberV2 = 1000;
            List<int> multiples = new List<int>();
            int sum = 0;

            Console.WriteLine($"Multiples of 3 and 5");
            // user input, 0, 1, 2

            // num
            //targetNumber = targetNumberV2; // override target number (DEBUG) - V0 = 10, V1 = 100, V2 = 1000
            for (int i = 1; i < targetNumber; i++)
            {
                if (i % firstMultiplier == 0 || i % secondMultiplier == 0) // 3, 5
                {
                    multiples.Add(i);
                    sum += i;
                }
            }


            foreach (int item in multiples)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine($"");
            Console.WriteLine($"Multiples of 3 and 5 of {targetNumber}, Sum: {sum}");
            //10 = 23, 100 = 2318, 1000 = 233168


            #region Tests
            /*   
            using NUnit.Framework;

            [TestFixture]
            public class HikerTest
            {
                [Test]
                public void life_the_universe_and_everything()
                {
                    // a simple example to start you off
                    Assert.AreEqual(42, Hiker.Answer());
                }
            }
            */
            #endregion
            #endregion // Multiples of 3 and 5
            return 0;
        }
    }
}
