using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {

        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            /* We have two children, a and b, and the parameters aSmile 
             * and bSmile indicate if each is smiling. We are in trouble
             * if they are both smiling or if neither of them is smiling.
             * Return true if we are in trouble. 
             * 
             * AreWeInTrouble(true, true) -> true
             * AreWeInTrouble(false, false) -> true
             * AreWeInTrouble(true, false) -> false
            */

            return (aSmile == bSmile);

        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {

            /*  The parameter weekday is true if it is a weekday, and the parameter vacation 
             *  is true if we are on vacation. We sleep in if it is not a weekday or we're on
             *  vacation. Return true if we sleep in. 

                sleepIn(false, false) -> true
                sleepIn(true, false) -> false
                sleepIn(false, true) -> true
             * 
             */

            return ((isWeekday == isVacation) || (isVacation == true));

        }

        public int SumDouble(int a, int b)
        {
            /*
             *  Given two int values, return their sum. However, if the two values are the same,
             *  then return double their sum. 

                SumDouble(1, 2) -> 3
                SumDouble(3, 2) -> 5
                SumDouble(2, 2) -> 8
            */

            int result = a + b;
            if (a == b)
            {
                result *= 2;
            }

            return result;

        }

        public int Diff21(int n)
        {
            /*
             *  Given an int n, return the absolute value of the difference between n and 21,
             *  except return double the absolute value of the difference if n is over 21. 

                Diff21(23) -> 4
                Diff21(10) -> 11
                Diff21(21) -> 0
             * 
             */


            int result = 0;
            if (n <= 21)
            {
                result = 21 - n;
            }
            else
            {
                result = 2 * (n - 21);
            }

            return result;
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            // We have a loud talking parrot. The "hour" parameter is the current hour time 
            // in the range 0..23.We are in trouble if the parrot is talking and the hour 
            // is before 7 or after 20.Return true if we are in trouble.

            // ParrotTrouble(true, 6)-> true
            // ParrotTrouble(true, 7)-> false
            // ParrotTrouble(false, 6)-> false


            bool result = false;
            if (isTalking && (hour < 7 || hour > 20))
            {
                result = true;
            }

            return result;
        }

        public bool Makes10(int a, int b)
        {
            //Given two ints, a and b, return true if one if them is 10 or if their sum 
            //is 10.

            //Makes10(9, 10)-> true
            //Makes10(9, 9)-> false
            //Makes10(1, 9)-> true

            bool result = false;
            if ((a == 10) || (b == 10) || (a + b) == 10)
                result = true;

            return result;
        }

        public bool NearHundred(int n)
        {
            // Given an int n, return true if it is within 10 of 100 or 200.
            // Hint: Check out the C# Math class for absolute value

            // NearHundred(103)-> true
            // NearHundred(90)-> true
            // NearHundred(89)-> false


            bool result = false;
            if ((Math.Abs(n - 100) <= 10) || (Math.Abs(n - 200) <= 10))
            {
                result = true;
            }

            return result;

        }

        public bool PosNeg(int a, int b, bool negative)
        {

            // Given two int values, return true if one is negative and one is positive.Except 
            // if the parameter "negative" is true, then return true only if both are negative. 

            // PosNeg(1, -1, false)-> true
            // PosNeg(-1, 1, false)-> true
            // PosNeg(-4, -5, true)-> true

            bool result = false;
            if (((Math.Abs(a + b) < a) || Math.Abs(a + b) < b)) result = true;
            if ((a < 0 && b < 0) && (negative == true)) result = true;

            return result;

        }

        public string NotString(string s)
        {

            // Given a string, return a new string where "not " has been added
            // to the front. However, if the string already begins with "not",
            // return the string unchanged.

            //Hint: Look up how to use "SubString" in c#

            //NotString("candy")-> "not candy"
            //NotString("x")-> "not x"
            //NotString("not bad")-> "not bad"

            string pattern = "not ";
            if (s.Length < pattern.Length)
            {

                s = pattern + s;

            }
            else
            {
                int matchChar = 0;
                for (int counter = 0; counter < pattern.Length; counter++)
                {
                    if (s[counter] == pattern[counter]) matchChar++;

                }

                if (matchChar != pattern.Length) s = pattern + s;
            }

            return s;
        }

        public string MissingChar(string str, int n)
        {

            //Given a non - empty string and an int n, return a new string where 
            //the char at index n has been removed.The value of n will be a valid
            //index of a char in the original string(Don't check for bad index). 


            // MissingChar("kitten", 1)-> "ktten"
            // MissingChar("kitten", 0)-> "itten"
            // MissingChar("kitten", 4)-> "kittn"


            string result = "";
            for (int index = 0; index < str.Length; index++)
            {
                if (index == n) index++;
                result += str[index];
            }

            return result;
        }

        public string FrontBack(string str)
        {
            // Given a string, return a new string where the first and last chars have been exchanged.

            // FrontBack("code")-> "eodc"
            // FrontBack("a")-> "a"
            // FrontBack("ab")-> "ba"

            string output = "";
            if (str.Length > 1)
            {
                output += str[str.Length - 1];
                for (int index = 1; index < str.Length - 1; index++)
                {
                    output += str[index];
                }
                output += str[0];
            }
            else
            {
                output = str;

            }

            return output;
        }

        public string Front3(string str)
        {
            // Given a string, we'll say that the front is the first 3 chars of the string. 
            // If the string length is less than 3, the front is whatever is there. Return 
            // a new string which is 3 copies of the front. 

            // Front3("Microsoft")-> "MicMicMic"
            // Front3("Chocolate")-> "ChoChoCho"
            // Front3("at")-> "atatat"

            string output;

            if (str.Length < 3)
            {
                output = str;
            }
            else
            {
                output = str.Substring(0, 3);

            }

            output = output + output + output;

            return output;
        }

        public string BackAround(string str)
        {
            // Given a string, take the last char and return a new string with 
            // the last char added at the front and back, so "cat" yields "tcatt".
            // The original string will be length 1 or more. 

            // BackAround("cat")-> "tcatt"
            // BackAround("Hello")-> "oHelloo"
            // BackAround("a")-> "aaa"


            return str[str.Length - 1] + str + str[str.Length - 1];


        }

        public bool Multiple3or5(int number)
        {
            // Return true if the given non-negative number is a multiple of 3 or a 
            // multiple of 5.Use the % "mod" operator

            // Multiple3or5(3)-> true
            // Multiple3or5(10)-> true
            // Multiple3or5(8)-> false

            bool result = false;

            if ((number % 5 == 0) || (number % 3 == 0))
            {
                result = true;
            }

            return result;
        }
        
        public bool StartHi(string str)
        {
            // Given a string, return true if the string starts with "hi" and 
            // false otherwise.

            // StartHi("hi there")-> true
            // StartHi("hi")-> true
            // StartHi("high up")-> false

            bool result = false;
            
            if (str.Length >= 2)
            {
                if (str.Length >= 3)
                {
                    if (str.IndexOf("hi") == 0 && char.IsLetterOrDigit(str[2]))
                        result = false;
                    else
                        result = true;
                }
                else
                {
                    if (str.IndexOf("hi") == 0)
                        result = true;
                }
            }
            
            
            return result;
            
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            //Given two temperatures, return true if one is less than 0 and the other
            //is greater than 100.

            //IcyHot(120, -1)-> true
            //IcyHot(-1, 120)-> true
            //IcyHot(2, 120)-> false

            bool output = false;

            if ((temp1 < 0 && temp2 > 100) || (temp2 < 0 && temp1 > 100))
            {
                output = true;
            }
           

            return output;

            
        }
        
        public bool Between10and20(int a, int b)
        {
            // Given 2 int values, return true if either of them is in the 
            // range 10..20 inclusive.

            // Between10and20(12, 99)-> true
            // Between10and20(21, 12)-> true
            // Between10and20(8, 99)-> false


            bool output = false;
           
            for (int rangeNumber = 10; rangeNumber <=20; rangeNumber++)
            {
                if (a == rangeNumber || b == rangeNumber)
                {
                    output = true;
                    break;
                }
            }
            

            return output;
        }
        
        public bool HasTeen(int a, int b, int c)
        {

            // We'll say that a number is "teen" if it is in the range 13..19 inclusive.
            // Given 3 int values, return true if 1 or more of them are teen. 

            // HasTeen(13, 20, 10)-> true
            // HasTeen(20, 19, 10)-> true
            // HasTeen(20, 10, 12)-> false



            bool output = false;

                
            if (a >= 13 && a <= 19) output = true;
            if (b >= 13 && b <= 19) output = true; 
            if (c >= 13 && c <= 19) output = true;



            return output;


        }
        
        public bool SoAlone(int a, int b)
        {

            //We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
            //Given 2 int values, return true if one or the other is teen, but not both. 

            //SoAlone(13, 99)-> true
            //SoAlone(21, 19)-> true
            //SoAlone(13, 13)-> false

            bool output = false;

            if (a >= 13 && a <= 19 && !(b <= 19)) output = true;
            if (b >= 13 && b <= 19 && !(a <= 19)) output = true;

            return output;
        }
        
        public string RemoveDel(string str)
        {

            //Given a string, if the string "del" appears starting at index 1, 
            //return a string where that "del" has been deleted.Otherwise, return
            //the string unchanged. 

            //RemoveDel("adelbc")-> "abc"
            //RemoveDel("adelHello")-> "aHello"
            //RemoveDel("adedbc")-> "adedbc"

            string output = str;
           

            if (str.Length >= 3)
            {
                if (str.Contains("del") && str.Substring(1,3) == "del")
                {
                    str = str.Remove(1, 3);
                }

            }

            return str;
        }
        
        public bool IxStart(string str)
        {

            //Return true if the given string begins with "*ix", 
            //the '*' can be anything, so "pix", "9ix"..all count.

            //IxStart("mix snacks")-> true
            //IxStart("pix snacks")-> true
            //IxStart("piz snacks")-> false

            bool output = false;

            if(str.Contains("ix"))
                
            {
                if (str.IndexOf('i') == 1 && str.IndexOf('x') == 2)
                {
                    output = true;
                }
                
            }

            return output;


        }
        
        public string StartOz(string str)
        {
            // Given a string, return a string made of the first 2 chars(if present),
            // however include first char only if it is 'o' and include the second only
            // if it is 'z', so "ozymandias" yields "oz".

            // StartOz("ozymandias")-> "oz"
            // StartOz("bzoo")-> "z"
            // StartOz("oxx")-> "o"

            string output = "";
            if (str.Length >= 2)
            {
                if (str.Substring(0,2) == "oz")
                {
                    output = "oz";

                }
                else
                {
                    if (str[0] == 'o' && str[1] != 'z') output = "o";
                    if (str[0] != 'o' && str[1] == 'z') output = "z";
                    
                }
            }
            return output;
        }
        
        public int Max(int a, int b, int c)
        {
            //Given three int values, a b c, return the largest.

            //Max(1, 2, 3)-> 3
            //Max(1, 3, 2)-> 3
            //Max(3, 2, 1)-> 3


            int max = 0;

            if (a<b && a<c)
            {
                if (b < c) max = c;
                else max = b;
            }
            else
            {
                if (a > c && a > b) max = a;
                else
                {
                    if (b < c) max = c;
                    else max = b;
                }
            }

            return max;
        }
        
        public int Closer(int a, int b)
        {

            // Given 2 int values, return whichever value is nearest to the value 10, 
            // or return 0 in the event of a tie.

            // Closer(8, 13) -> 8
            // Closer(13, 8) -> 8
            // Closer(13, 7) -> 0

            int output = 0;

            if (Math.Abs(10-a) != Math.Abs(10-b))
            {
                if (Math.Abs(10 - a) < Math.Abs(10 - b)) output = a;
                else output = b;
            }

            return output;

        }
        
        public bool GotE(string str)
        {
            //Return true if the given string contains between 1 and 3 'e' chars.

            //GotE("Hello")-> true
            //GotE("Heelle")-> true
            //GotE("Heelele")-> false


            int countE = 0;
            bool result = false;

            for (int index = 0; index < str.Length; index++)
            {
                if (str[index] == 'e') countE++;
                
                
            }
            if (countE <= 3 && countE >= 1) { result = true; }
            
            return result;
        }
        
        public string EndUp(string str)
        {

            //Given a string, return a new string where the last 3 chars are now in 
            //upper case. If the string has less than 3 chars, uppercase whatever 
            //is there.

            //EndUp("Hello")-> "HeLLO"
            //EndUp("hi there")-> "hi thERE"
            //EndUp("hi")-> "HI"


            string output = "";

            if (str.Length >= 3)
            {
                
                
                output = str.Substring(str.Length - 3, 3);
                output = str.Substring(0, str.Length - 3) + output.ToUpper();
            }
            else
            {
                output = str.ToUpper();
            }


            return output;
        }
        
        public string EveryNth(string str, int n)
        {
            //Given a non - empty string and an int N, return the string made 
            //starting with char 0, and then every Nth char of the string.So 
            //if N is 3, use char 0, 3, 6, ... and so on.N is 1 or more. 

            //EveryNth("Miracle", 2)-> "Mrce"
            //EveryNth("abcdefg", 2)-> "aceg"
            //EveryNth("abcdefg", 3)-> "adg"

            string output = "";

            for (int counter = 0; counter< str.Length; counter++)
            {
             
                if (counter % n == 0) output += str[counter];
            }

            return output;
        }
    }
}
