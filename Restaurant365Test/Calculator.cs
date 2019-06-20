﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Restaurant365Test
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            //int result = c.Add("1\n2,3");
            int result = c.Add("//;\n1,\n2;3");
            Console.Write(result);
        }

        public int Add(string numbers)
        {
            int[] intArray = getIntegersFromString(numbers);
            int sum = 0;
            foreach(int n in intArray)
            {
                sum += n;
            }
            return sum;
        }

        private int[] getIntegersFromString(string myString)
        {
            string[] delimArr = getDelimitersFromString(myString);
            string numString = getNumString(myString);
            if (numString.Contains(",\n"))
            {
                throw new ArgumentException(@"Input containing ,\n is not allowed");
            }
            //NOT SURE WHICH SCENARIO YOU MEANT, SO INCLUDING BOTH
            //if(numString == "1,\n")
            //{
            //    throw new ArgumentException("Input 1,\n is not allowed");
            //}

            //get only the numbers after \n
            string[] strArray = numString.Split(delimArr, StringSplitOptions.None);                     
            List<int> intList = new List<int>();
            foreach(string s in strArray)
            {
                intList.Add(Int32.Parse(s == "" ? "0" : s));
            }
            if(strArray.Length == 0)
            {
                return new int[]{ 0 };
            }
            return intList.ToArray();
        }

        private string[] getDelimitersFromString(string delimString)
        {
            List<string> delimList = new List<string>(new string[] { "\n", "," });
            MatchCollection delimMatches = Regex.Matches(delimString, @"(?<=\/\/)(.*?)(?=[\n])");
            foreach (Match m in delimMatches)
            {
                delimList.Add(m.Value);
            }
            return delimList.ToArray();
        }

        private string getNumString(string rawString)
        {
            if(rawString.Substring(0,2) == "//")
            {
                return rawString.Substring(rawString.IndexOf("\n")+1);
            }
            else
            {
                return rawString;
            }
        }
    }
}
