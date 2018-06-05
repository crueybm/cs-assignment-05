/*
 * Name: Brandon Cruey 
 * email: crueybm@mail.uc.edu
 * Class: Contemporary Programming
 * Date: 09/28/2017
 * Assignment: 005
 * Description: This program takes two arrays of binary numbers, then verifies that they only contain 0 and 1 and are the same length.
 * The binary numbers are then converted to strings, and added using base 2.  
 * The resulting sum is then converted back into an int array, checked for length, and returned to the main.
 * Citations: https://stackoverflow.com/questions/5074575/what-is-the-best-way-in-c-sharp-to-convert-string-into-int
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment05Fall2017 {
    class Assignment05 {
        /// <summary>
        /// Test the AddBinary method in this class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // Define an array of objects for the test cases
            TestCase[] testCases = {
                                    new TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 0, 0, 0, 0, 0 }, true),      // Should cause overflow and throw an exception
                                    new TestCase(new int[] { 0 },             new int[] { 1 },             new int[] { 1 },             false),
                                    new TestCase(new int[] { 0, 1 },          new int[] { 0, 1 },          new int[] { 1, 0 },          false),
                                    new TestCase(new int[] { 0, 0 },          new int[] { 0, 0 },          new int[] { 0, 0 },          false),
                                    new TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 2 },             new int[] { 1 },             new int[] { 1 },             true),         // should detect an invalid char and throw an exception
                                    new TestCase(new int[] { 2, 2, 2, 2, 2 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, true),         // should detect an invalid char and throw an exception
                                    new TestCase(new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 0, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 0, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 0, 1, 0, 1, 0 }, new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 1 }, false),
                                    new TestCase(new int[] { 1 },             new int[] { 1 },             new int[] { 1 },             true),          // Should cause overlow and throw an exception
                                    new TestCase(new int[] { 1 },             new int[] { 2 },             new int[] { 1 },             true),          // should detect an invalid char and throw an exception
                                    new TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }, false),
            };
            int totalTests = 0, testsPassed = 0;
            // Process all the test cases
            foreach (TestCase testCase in testCases) {
                bool threwException, testFailed;
                threwException = false;
                testFailed = false;
                totalTests++;
                int[] actualResult = null;
                try {
                    Console.WriteLine("Test Case #" + totalTests + "...");
                    actualResult = AddBinary(testCase.operand1, testCase.operand2);     // Here is the actual test. 

                } catch (Exception ex) {
                    threwException = true;                                              // Sometimes the test case should throw an exception, sometimes not
                }
                if (threwException == true && testCase.shouldThrowException == false) {
                    Console.WriteLine("Exception thrown but it shouldn't have");
                    testFailed = true;
                } else {
                    if (threwException == false && testCase.shouldThrowException == true) {
                        Console.WriteLine("Exception not thrown but it should have been");
                        testFailed = true;
                    } else {
                        if (threwException == true && testCase.shouldThrowException == true) {
                            // The test passed because it threw an exception and it should have. All is well. 
                            //Console.WriteLine("Exception not thrown as expected.");
                        } else {
                            if (actualResult.Length != testCase.expectedResult.Length) {
                                Console.WriteLine("Length of actual result is not the same as length of the expected result");
                                testFailed = true;
                            } else {
                                bool resultIsCorrect;
                                resultIsCorrect = true;      // Hope for the best
                                for (int i = 0; i < actualResult.Length; i++) {
                                    if (actualResult[i] != testCase.expectedResult[i]) {
                                        resultIsCorrect = false;
                                    }
                                }
                                if (resultIsCorrect != true) {
                                    Console.WriteLine("Actual result != expected result. Test failed");
                                    testFailed = true;
                                }
                            }
                        }
                    }
                }
                // OK, after all this, did the test pass or not?
                if (testFailed == true) {
                    Console.WriteLine("TEST FAILED");
                } else {
                    testsPassed++;
                }
            }
            // Print a summary of the testing. This is really what matters. All tests should have passed.
            Console.WriteLine(totalTests + " tests were run, " + testsPassed + " passed.");
            if (totalTests == testsPassed) {
                Console.WriteLine("ALL tests PASSED");
            } else {
                Console.WriteLine("*************** SOME tests FAILED ****************");
            }
        }
        /// <summary>
        /// Add two binary numbers stored in int arrays: op1 + op2
        /// </summary>
        /// <param name="op1">Operand #1</param>
        /// <param name="op2">Operand #2</param>
        /// <returns>the sum of op1 and op2</returns>
        public static int[] AddBinary(int[] op1, int[] op2) {
            int[] result;                               //Declares result array.
            for (int i = op1.Length - 1; i < op1.Length; i--)   //Begins a for loop to check array consistency.
            {
                if (op1[i] > 1 || op2[i] > 1)           //Verifies that the numbers in the binary arrays are no greater than 0 or 1
                {
                    throw new Exception("Number greater than 1 detected");          //Throws the resulting exception.
                } else if (op1.Length != op2.Length)    //Verifies that the two binary arrays are the same length.
                {
                    throw new Exception("Binary numbers are not the same length");  //Throws the resulting exception.
                }
                break;
            }
            string tmp1 = string.Join("", op1);         //Converts the int op1 array into a string.
            string tmp2 = string.Join("", op2);         //Converts the int op2 array into a string.
            int tmp11 = Convert.ToInt32(tmp1, 2);       //Converts the tmp1 string into a base 2 integer.
            int tmp22 = Convert.ToInt32(tmp2, 2);       //Converts the tmp2 string into a base 2 integer.
            string res = Convert.ToString(tmp11 + tmp22, 2).PadLeft(op1.Length, '0');   
            //Adds the tmp1 and tmp2 binary integers, converts the sum into a string, and then pads the left of the string with 0.
            string res1 = string.Join<char>(",", res);  //Inserts commas into the res string for the next step.
            result = res1.Split(',').Select(int.Parse).ToArray();
            //Changes the binary sum into an int array.
            if (result.Length != op1.Length)            //Checks the result array against the original array to verify length.
            {
                throw new Exception("Result Length does not match Operand Length");     //Throws the resulting exception
            }
            return result;   //Returns the resulting array to the main      // Obviously incorrect. 
        }
    }
}
