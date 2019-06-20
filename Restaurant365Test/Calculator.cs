using System;
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
            int result = c.Add("//;\n1;2;3");
            Console.Write(result);
        }

        public int Add(string numbers)
        {
            int[] intArray = getIntegersFromString(numbers);
            int sum = 0;
            if (intArray.Length > 3)
            {
                throw new ArgumentException("Too many numbers supplied");
            }
            foreach(int n in intArray)
            {
                sum += n;
            }
            return sum;
        }

        private int[] getIntegersFromString(string myString)
        {

            //string[] delimArr = getDelimitersFromString(myString.Substring(0, myString.IndexOf("\n")));
            string[] delimArr = getDelimitersFromString(myString);
            string numString = getNumString(myString);
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
            //if nothing supplied, default to \n and ,
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
