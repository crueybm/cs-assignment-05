/*
 * Name: Brandon Cruey 
 * email: crueybm@mail.uc.edu
 * Class: Contemporary Programming
 * Date: 09/28/2017
 * Assignment: 005
 * Description: This program takes two arrays of binary numbers, then verifies that they only contain 0 and 1 and are the same length.
 * The binary numbers are then converted to strings, and added using base 2.  
 * The resulting sum is then converted back into an int array, checked for length, and returned to the main.
 * This file constructs the test cases for the main to use.
 * Citations: N/A
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment05Fall2017 {
    /// <summary>
    /// A test case for testing the AddBinary method in the Assignment05 class
    /// </summary>
    class TestCase {
        private int[] mOperand1;
        private int[] mOperand2;
        private int[] mExpectedResult;
        private bool mShouldThrowException;

        public TestCase(int[] operand1, int[] operand2, int[] expectedResult, bool shouldThrowException) {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.expectedResult = expectedResult;
            this.shouldThrowException = shouldThrowException;
        }
        public int[] operand1 {
            get { return mOperand1; }
            set { mOperand1 = (int[])value.Clone(); }
        }
        public int[] operand2 {
            get { return mOperand2; }
            set { mOperand2 = (int[])value.Clone(); }
        }
        public int[] expectedResult {
            get { return mExpectedResult; }
            set { mExpectedResult = (int[])value.Clone(); }
        }
        public bool shouldThrowException {
            get { return mShouldThrowException; }
            set { mShouldThrowException = value; }
        }

    }
}
