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
                                    new TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 }, false),
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

                }
                catch (Exception ex) {
                    threwException = true;                                              // Sometimes the test case should throw an exception, sometimes not
                }
                if (threwException == true && testCase.shouldThrowException == false) {
                    Console.WriteLine("Exception thrown but it shouldn't have");
                    testFailed = true;
                }
                else {
                    if (threwException == false && testCase.shouldThrowException == true) {
                        Console.WriteLine("Exception not thrown but it should have been");
                        testFailed = true;
                    }
                    else {
                        if (threwException == true && testCase.shouldThrowException == true) {
                            // The test passed because it threw an exception and it should have. All is well. 
                            //Console.WriteLine("Exception not thrown as expected.");
                        }
                        else {
                            if (actualResult.Length != testCase.expectedResult.Length) {
                                Console.WriteLine("Length of actual result is not the same as length of the expected result");
                                testFailed = true;
                            }
                            else {
                                bool resultIsCorrect;
                                resultIsCorrect = true;      // Hope for the best
                                // Compare the actual result with the expected result
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
                }
                else {
                    testsPassed++;
                }
            }
            // Print a summary of the testing. This is really what matters. All tests should have passed.
            Console.WriteLine(totalTests + " tests were run, " + testsPassed + " passed.");
            if (totalTests == testsPassed) {
                Console.WriteLine("ALL tests PASSED");
            }
            else {
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
            return op2;     // Obviously incorrect. 
        }
    }
}
