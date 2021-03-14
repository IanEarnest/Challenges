using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
#pragma warning disable CS0219 // Variable is assigned but its value is never used

namespace Challenges
{
    class Challenges01
    {
        List<Action> _listOfFunctions = new List<Action>();

        public Challenges01()
        {
            _listOfFunctions.Add(() => ToString());                             // dummy/ 0 = quit
            _listOfFunctions.Add(() => Solution100Doors());                     // 1 = ... //functions.Add(Solution100Doors);
            _listOfFunctions.Add(() => SolutionMultiplesOf3And5());             // 2 = ... 
            _listOfFunctions.Add(() => SolutionEvenFibonacciNumbers());         // 3 = ... 
            _listOfFunctions.Add(() => SolutionEvenFibonacciNumbers(13, 21));   // 4 = ... 
            _listOfFunctions.Add(() => PrintFibSeq());                          // 5 = shows a fib seq
            _listOfFunctions.Add(() => SolutionLargestPrimeFactor(11, 22));   // 6 = ... 
            // add new functions here //runSolutionArray1();
        }

        // quicker than typing "5" (or latest number)
        public void CurrentChallenge()
        {
            SolutionLargestPrimeFactor();
            Console.WriteLine();
        }

        public int GetFunctionsCount()
        {
            return _listOfFunctions.Count-1;
        }

        public void RunSolution(int solutionNum = 0) // cases for 1, 2, 3
        {
            //List<Action> _listOfFunctions = new List<Action>(); // contains a list of functions
            if (solutionNum <= _listOfFunctions.Count-1) // 0 based index
            {
                _listOfFunctions[solutionNum].Invoke();
            }
            else
            {
                Console.WriteLine($"Solution {solutionNum} not available");
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
            /* Project Euler - Problem 1 - Multiples of 3 and 5
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

        public int SolutionEvenFibonacciNumbers(int _numPastPast = 0, int _numPast = 1)
        {
            #region Even Fibonacci numbers
            /* Project Euler - Problem 2 - Even Fibonacci numbers
            Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
            By starting with 1 and 2, the first 10 terms will be:

            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

            By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
            find the sum of the even-valued terms.
            */

            int limit = 4000000;
            int a = _numPastPast;       // 0 - numPastPast
            int b = _numPast;            // 1 - numPast
            int c = 0;                   // numNext
            int sum = 0;                  // 2 - first num is even

            // calculate numNext, move right/ update past numbers to generate a new next number
            // sum of even numbers, continue if numNext < 4,000,000
            while (c < limit) //while ((numPast + numPastPast) <= maxFib)
            {
                if (b % 2 == 0) //if (numNext % 2 == 0)
                {
                    sum += b;
                    Console.Write($"{sum}, ");
                }
                c = a + b;
                a = b;
                b = c;
            }
            Console.WriteLine($"");
            Console.WriteLine($"Fib - limit: {limit}, a: {_numPastPast}, b: {_numPast}, sum: {sum}"); // 4613732
            // further... every third fib is even, start with 1, 1
            /* no need for if even check ..  1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89,
            c=a+b
                while c<limit
                 sum=sum+c
                 a=b+c
                 b=c+a
                 c=a+b
            */
            // even further ... recursive relation F(n) = F(n-1) + F(n-2)       e.g. 8 = 5 + 3 
            //                                  and F(n) = 4F(n-3) + F(n-6)     e.g. 89 = 84(21x4) + 5
            //                                  and E(n) = 4E(n-1) + E(n-2)     e.g. 144 = 136(34x4) + 8
            // fib seq = 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89,
            // fib seq even =  2, 8, 34, 144
            //
            //            -2 -1 0
            // a b c d e f g h i
            //g = F(n-2)        h = F(n-1)      i = F(n) // F = Fib, n = number
            //
            //     -2    -1    0
            // a b c d e f g h i
            //c = E(n-2)        f = E(n-1)      i = E(n) // E = Even (fib)
            //
            // F(n) = F(n-1) + F(n-2) to prove E(n) = 4E(n-1) + E(n-2)
            //      you can make F(n-1) with F(n-2) + F(n-3)     (f+g=h)
            // F(n) = F(n-1) + F(n-2) =  
            //      (convert n-1)       2F(n-2) + F(n-3) =  
            //      (convert 2x n-2)    3F(n-3) + 2F(n-4) =
            //      (convert n-4)       4F(n-3) + F(n-6)
            // which also means E(n) = 4E(n-1) + E(n-2) 

            /*
            int increment = 0; // numbers in fib seq
            int evenNumA = 0;
            int evenNumB = 0;
            int evenNumC = 0;
            List<int> evenNums = new List<int>();
            while (c < limit && evenNumC < limit) //while ((numPast + numPastPast) <= maxFib)
            {
                
                if (increment > 2)
                {
                    //E(n) = 4E(n-1) + E(n-2)
                    
                    evenNumC = (evenNumB * 4) + evenNumA;
                    if (evenNumC < limit)
                    {
                        evenNums.Add(sum);
                        sum += evenNumC;
                        evenNumA = evenNumB;
                        evenNumB = evenNumC;

                    }
                }
                else
                {
                    if (b % 2 == 0) //if (numNext % 2 == 0)
                    {
                        sum += b;
                        if (increment == 1) evenNumA = b;
                        if (increment == 2) evenNumB = b;
                        increment++;
                    }

                    c = a + b;
                    a = b;
                    b = c;
                }
            }
            Console.WriteLine($"Fib - limit: {limit}, a: {_numPastPast}, b: {_numPast}, sum: {sum}"); // 4613732
            Console.Write($"Evens = ");
            foreach (int evenNum in evenNums)
            {
                Console.Write($"{evenNum}, ");
            }
            */
            #endregion
            return 0;
        }

        public void PrintFibSeq()
        {
            Console.WriteLine("{0}", string.Join(", ", FibSeq()));
        }
        public int[] FibSeq(int _numPastPast = 0, int _numPast = 1, int _rotations = 10)
        {
            // Next number = past number + past past number
            // starting at 0, 1 (then + 10 fib seq)
            //                      fib seq = 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89
            // print starting at 1 and 2
            //                      fib seq = 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233

            int[] fibSeqArray = new int[_rotations];
            int numPastPast = _numPastPast;    // 0 - numPastPast
            int numPast = _numPast;            // 1 - numPast
            int numNext = 0;                   // numNext
            int rotations = _rotations;        // 10 - how many cycles of the fib sequence (includes 2 first numbers)

            //Console.Write($"{numPastPast} {numPast}"); // first two numbers
            fibSeqArray[0] = numPastPast;
            fibSeqArray[1] = numPast;

            // calculate numNext
            for (int i = 0; i < rotations-2; i++) // -2 as first two numbers are already set
            {
                numNext = numPast + numPastPast;
                fibSeqArray[i + 2] = numNext;

                // move right/ update past numbers to generate a new next number
                numPastPast = numPast;
                numPast = numNext;
            }

            return fibSeqArray; //Console.WriteLine("{0}", string.Join(", ", FibSeq()));
        }

        public int SolutionLargestPrimeFactor(int _num1 = 0, int _num2 = 1)
        {
            #region Largest Prime Factor
            /* Project Euler - Problem 3 - Largest prime factor

            The prime factors of 13195 are 5, 7, 13 and 29.
            What is the largest prime factor of the number 600851475143 ?
            */

            //https://www.mathsisfun.com/prime-factorization.html
            // prime number = a whole number greater than 1 that can not be made by multiplying other whole numbers
            // 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31
            //
            // composit number = can make it by multiplying other whole numbers it is a Composite Number
            // Factors = are the numbers you multiply together to get another number
            // 2 x 3 = 6
            //"Prime Factorization" is finding which prime numbers multiply together to make the original number.

            // The prime factors of 13195 are 5, 7, 13 and 29. (5*7*13*29)
            // 13195 / 29 = 445
            // 445 / 13 = 35
            // 35 / 7 = 5



            // calc prime numbers
            int targetPrimeNum = 0; //15000 // 31 = prime
            int primeNumStart = 2;
            List<int> primeNumbers = new List<int>();
            List<int> primeNumbersWorking = new List<int>();
            List<int> primeNumbersUsed = new List<int>();
            int targetPrimeFactorsNum = 13195; // primes = 5, 7, 13 and 29. // 600851475143

            // check all primes of a number ...
            // check if number is not a prime number // prime = num not made by others multiplying
                // start with half of target - go backwards from half (down to 2) and divide
                // find if any numbers can multiply to make target number (if so then number is not prime)

            // already rounds down odd number...? Convert.ToInt32(targetPrimeNum / 2);
            //if (targetPrimeNum % targetPrimeNum / 2 == 0)

            int halfOfTargetPrimeNum = 0;
            bool isPrime = true;

            // find all primes of a number
            for (int i = primeNumStart; i < targetPrimeFactorsNum; i++)
            {
                targetPrimeNum = i;
                halfOfTargetPrimeNum = targetPrimeNum / primeNumStart; // 2

                // check if number is not a prime number
                for (int j = halfOfTargetPrimeNum; j >= primeNumStart; j--) // from half going downwards
                {                    
                    // not prime check + early quit
                    if ((targetPrimeNum % j) == 0) // 30 / 15 = 0, 31 / 15 = 1... // int tmpRemainder = (j % targetPrimeNum);
                    {
                        isPrime = false; // not a prime
                        break;
                    }
                }
                // number is prime if for loop is finished
                if (isPrime)
                {
                    primeNumbers.Add(targetPrimeNum);
                }
                isPrime = true; // reset prime check for next loop
            }
            
            // all primes numbers of target number listed in primeNumbers
            //Console.WriteLine($"Prime Numbers of {targetPrimeFactorsNum}: ");
            //foreach (int primeNum in primeNumbers)
            //{
            //    Console.Write($"{primeNum}, ");
            //}



            // 1. only prime numbers under half of target (100 = 2, 3...43, 47"
            // each prime multiplied by a previous number (count up) "2 x 3 = 6"
                // (start with highest, then bottom up, (47x2=94...47x2x2=188, 47x3=141, 41x2
            //      if < target, multiply by another prime number (count up) "2 x 3(6) x 5(30)"
            //      if num > target, change last, last multiplied prime number
            //      if num = target, save sequence
            // multiply prime numbers (primeNumbers list) to see if they match targetPrimeFactorsNum

            // 2. divide by prime num then another prime num and again to end with a prime num?
            // or /2, /2, /2 (until prime num)

            // 3. targetPrimeFactorsNum = 100; 
            // prime numbers of 100 = 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
            // primeNumbers[primeNumbers.Count-1];// last prime number


            // calc prime factors
            int halfOfTargetPrimeFactorsNum = targetPrimeFactorsNum / 2;






            
            // 1. prime numbers under half of target... "...43, 47" ... 47 x 2 (bottom up), 41 x 2 x 3
            foreach (int primeNum in primeNumbers)
            {
                if (primeNum <= halfOfTargetPrimeFactorsNum)
                {
                    primeNumbersWorking.Add(primeNum);
                }
            }

            // testing
            //Console.WriteLine($"Prime Numbers under half of {targetPrimeFactorsNum}: ");
            //foreach (int primeNum in primeNumbersWorking)
            //{
            //    Console.Write($"{primeNum}, ");
            //}

            // 2. each prime multiplied by a previous number (count up) "2 x 3 = 6"
            //      if < target, multiply by another prime number (count up) "2 x 3(6) x 5(30)"
            //      if num > target, change last, last multiplied prime number
            //      if num = target, save sequence

            // prime nums half target = 2, 3....
            // < target, x prime until too high, remove last, x higher prime
            // 2 x 2 x 2... 2 x 3.... 3 x 2
            //13195 = 5 × 7 × 13 × 29


            // 2, 3, 5, 7, 11, 13, 17, 19, (each of these)
            foreach (int startingPrimeNum in primeNumbersWorking) 
            {
                int tmpTargetNum = startingPrimeNum; // 2....3....
                primeNumbersUsed.Add(startingPrimeNum); // add first number

                // 2 until end?
                for (int i = 0; i < primeNumbersWorking.Count - 1; i++) //.count?
                {
                    int j = i;
                    bool end = false;

                    while (!end)
                    {
                        // 2 + 2 (when first number changes, end/ iterate)
                        while (tmpTargetNum < targetPrimeFactorsNum)
                        {
                            //if < target, multiply by another prime number (count up) "2 x 3(6) x 5(30)"
                            primeNumbersUsed.Add(primeNumbersWorking[j]); // list of multiplied numbers (2, 3)
                            tmpTargetNum *= primeNumbersWorking[j]; // 2 x 2....

                            //Console.WriteLine($"({tmpTargetNum})... "); // testing
                            //foreach (int primeNumU in primeNumbersUsed)
                            //{
                            //    Console.Write($"{primeNumU}, ");
                            //}
                        }// 2 x  = 6... too high 4
                        //

                        // 2 x 2 x 999999 = too high
                        if (tmpTargetNum > targetPrimeFactorsNum)
                        {
                            //if num > target, change last, last multiplied prime number
                            if (primeNumbersUsed.Count < 2) //2? or 3 (2 + 2 + 2 into 2)
                            {
                                end = true; // 2 + 2 (when first number changes, end/ iterate)
                                primeNumbersUsed.Clear();
                                tmpTargetNum = startingPrimeNum;
                            }
                            else // here last....
                            {
                                
                                //tmpNum /= primeNumbersUsed[primeNumbersUsed.Count - 1];
                                primeNumbersUsed.RemoveAt(primeNumbersUsed.Count - 1); // exception, could not remove
                                //tmpNum /= primeNumbersUsed[primeNumbersUsed.Count - 1];
                                primeNumbersUsed.RemoveAt(primeNumbersUsed.Count - 1);
                                tmpTargetNum = startingPrimeNum;
                                foreach (int primeNumUsed in primeNumbersUsed)
                                {
                                    tmpTargetNum *= primeNumUsed;
                                }
                                //primeNumbersUsed.Add(primeNumbersWorking[i + j]); // out of range...
                                //tmpNum *= primeNumbersWorking[i + j];
                                j++;
                                // go back to start of while...
                                //primeNumbersUsed.Clear();

                            }
                        }
                        else if (tmpTargetNum == targetPrimeFactorsNum)
                        {
                            Console.WriteLine($"Used: "); // number found
                            int highest = 0;
                            foreach (int primeNumU in primeNumbersUsed)
                            {

                                Console.Write($"{primeNumU}, ");
                                if (highest < primeNumU)
                                {
                                    highest = primeNumU;
                                }
                            }
                            Console.Write($"Highest prime: {highest}, ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"else?");
                        }
                    }
                }
            }
            // The prime factors of 13195 are 5, 7, 13 and 29. (5*7*13*29)
            // 12 / 2 = 6, 6 / 2 = 3, 
            // can use multiple of the same prime numbers
            // if not whole number, stop
            // 100 = 5 / 5 / 2 / 2
            // 13195 = 5 × 7 × 13 × 29
            // 500851475143 = 17 × 17 × 103 × 1153 × 14593
            #endregion
            return 0;
        }
    }
}
