using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {


            //Given a string and a non-negative int n, return a larger string that 
            //is n copies of the original string.

            // StringTimes("Hi", 2)-> "HiHi"
            //StringTimes("Hi", 3)-> "HiHiHi"
            //StringTimes("Hi", 1)-> "Hi"

            string output = "";

            for (int counter = 0; counter < n; counter ++)
            {
                output += str;
            }

            return output;
        }

        public string FrontTimes(string str, int n)
        {

            //Given a string and a non-negative int n, we'll say that the front of the string
            //is the first 3 chars, or whatever is there if the string is less than length 3.
            //Return n copies of the front; 

            //FrontTimes("Chocolate", 2)-> "ChoCho"
            //FrontTimes("Chocolate", 3)-> "ChoChoCho"
            //FrontTimes("Abc", 3)-> "AbcAbcAbc"

            string output = "";


            for (int counter = 0; counter < n; counter++)
            {
                output += str.Substring(0,3);
            }

            return output;


        }

        public int CountXX(string str)
        {

            //Count the number of "xx" in the given string.We'll say that overlapping is 
            //allowed, so "xxx" contains 2 "xx". 

            //CountXX("abcxx")-> 1
            //CountXX("xxx")-> 2
            //CountXX("xxxx")-> 3

            int output = 0;


            for (int counter = 0; counter < str.Length-1; counter++)
            {
                 if (str.Substring(counter, 2) == "xx") output++;
            }

            return output;

        }

        public bool DoubleX(string str)
        {

            //Given a string, return true if the first instance of "x" in the string is 
            //immediately followed by another "x".

            //DoubleX("axxbb")-> true
            //DoubleX("axaxxax")-> false
            //DoubleX("xxxxx")-> true

            bool output = false;


            for (int counter = 0; counter < str.Length - 1; counter++)
            {
                if (str[counter] == 'x') 

                {
                    if (str[counter + 1] == 'x') output = true;

                    break;
                }
            }

            return output;

        }

        public string EveryOther(string str)
        {

            //Given a string, return a new string made of every other char starting with 
            //the first, so "Hello" yields "Hlo".

            //EveryOther("Hello")-> "Hlo"
            //EveryOther("Hi")-> "H"
            //EveryOther("Heeololeo")-> "Hello"


            string output = "";

            for (int index = 0; index < str.Length; index++)
            {
                if (index % 2 == 0) output += str[index];

            }

            return output;

        }

        public string StringSplosion(string str)
        {

            //Given a non - empty string like "Code" return a string like "CCoCodCode".  
            //(first char, first two, first 3, etc)

            //StringSplosion("Code")-> "CCoCodCode"
            //StringSplosion("abc")-> "aababc"
            //StringSplosion("ab")-> "aab"

            string output = "";

            for (int length = 1; length <= str.Length; length++)
            {
                output += str.Substring(0, length);

            }

            return output;


        }

        public int CountLast2(string str)
        {

            //Given a string, return the count of the number of times that a 
            //substring length 2 appears in the string and also as the last 
            //2 chars of the string, so "hixxxhi" yields 1(we won't count 
            //the end substring). 


            // CountLast2("hixxhi")-> 1
            // CountLast2("xaxxaxaxx")-> 1
            // CountLast2("axxxaaxx")-> 2

            int output = 0;

            string pattern = str.Substring(str.Length-2, 2);
            for (int index = 0; index < str.Length-3; index++)

            {
                if (pattern[0] == str[index] && pattern[1] == str[index + 1]) output++;

            }

            return output;
        }

        public int Count9(int[] numbers)
        {

            //Given an array of ints, return the number of 9's in the array. 

            //Count9({ 1, 2, 9}) -> 1
            //Count9({ 1, 9, 9}) -> 2
            //Count9({ 1, 9, 9, 3, 9}) -> 3

            int output = 0;
            
            for (int index=0; index < numbers.Length; index++)
            {

                if (numbers[index] == 9) output++;
            }

            return output;
        }

        public bool ArrayFront9(int[] numbers)
        {

            //Given an array of ints, return true if one of the first 4 elements 
            //in the array is a 9.The array length may be less than 4.

            //ArrayFront9({ 1, 2, 9, 3, 4}) -> true
            //ArrayFront9({ 1, 2, 3, 4, 9}) -> false
            //ArrayFront9({ 1, 2, 3, 4, 5}) -> false

            bool output = false;

            for (int index = 0; index < 4; index++)
            {

                if (numbers[index] == 9)
                { 
                output = true;
                break;
                }
            }

            return output;

        }

        public bool Array123(int[] numbers)
        {

            //Given an array of ints, return true if .. 1, 2, 3, .. 
            //appears in the array somewhere.

            //Array123({ 1, 1, 2, 3, 1}) -> true
            //Array123({ 1, 1, 2, 4, 1}) -> false
            //Array123({ 1, 1, 2, 1, 2, 3}) -> true

            bool found = false;

            if (numbers.Length >= 3)
            {
                for (int index = 0; index < numbers.Length - 2; index++)
                {
                    if (numbers[index] == 1 && numbers[index + 1] == 2 && numbers[index + 2] == 3)
                    {
                        found = true;
                        break;
                    }

                }
            }

            return found;

          

        }
        public int SubStringMatch(string a, string b)
        {

            //Given 2 strings, a and b, return the number of the positions where they 
            //contain the same length 2 substring.So "xxcaazz" and "xxbaaz" yields 3,
            //since the "xx", "aa", and "az" substrings appear in the same place in 
            //both strings. 

            //SubStringMatch("xxcaazz", "xxbaaz")-> 3
            //SubStringMatch("abc", "abc")-> 2
            //SubStringMatch("abc", "axc")-> 0


            string patternSource = "";
            string stringCompareToSource = "";
            int result = 0;

            if (a.Length <= b.Length)
            {
                patternSource = a;
                stringCompareToSource = b;
            }
            else
            {
                patternSource = b;
                stringCompareToSource = a;
            }


            string[] compinationOfPatterns;
            compinationOfPatterns = new string[patternSource.Length - 1];


            for (int index = 0; index < compinationOfPatterns.Length; index++)
            {

                compinationOfPatterns[index] = patternSource.Substring(index, 2);
            }



            for (int index1 = 0; index1 < compinationOfPatterns.Length; index1++)

            {
                for (int index2 = 0; index2 < stringCompareToSource.Length - 1; index2++)
                {
                    if (compinationOfPatterns[index1] == stringCompareToSource.Substring(index2, 2)) result++;
                }

            }
            return result;

        

        }

        public string StringX(string str)
        {

            //Given a string, return a version where all the "x" have been 
            //removed.Except an "x" at the very start or end should not be 
            //removed. 

            //StringX("xxHxix")-> "xHix"
            //StringX("abxxxcd")-> "abcd"
            //StringX("xabxxxcdx")-> "xabcdx"

            string output = "";

            bool[] xPresentMap = new bool[str.Length];

            for (int index = 0; index < xPresentMap.Length; index++)
            {
                if (str[index] == 'x') xPresentMap[index] = true;
                else xPresentMap[index] = false;
                
            }

            for (int index = 0; index < str.Length; index++)
            {
                if (xPresentMap[index] == true)
                {
                    if (index == 0 || index == str.Length - 1) output += str[index];
                    else

                    {
                        while (xPresentMap[index]) index++;
                        output += str[index];
                    }
                }
                else
                {
                    output += str[index];

                }
            }

            
                return output;


            

        }

        public string AltPairs(string str)
        {
            //Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9...so "kittens" yields "kien".

            //AltPairs("kitten")-> "kien"
            //AltPairs("Chocolate")-> "Chole"
            //AltPairs("CodingHorror")-> "Congrr"

          

            string output = "";
            int switchCounter = 0;
            bool write = true;
            for (int index = 0; index < str.Length; index++)
            {
                if (switchCounter < 2 && write)
                {
                    output += str[index];


                    switchCounter++;
                    if (switchCounter == 2) write = false;
                }
                else
                {
                    if (switchCounter > 0 && !write)
                    {
                        switchCounter--;

                        if (switchCounter == 0) write = true;
                    }
                    
                }

            }



            return output;
           
        }

        public string DoNotYak(string str)
        {

            //Suppose the string "yak" is unlucky.Given a string, return a version where all 
            //the "yak" are removed, but the "a" can be any char.The "yak" strings will not overlap. 

            //DoNotYak("yakpak")-> "pak"
            //DoNotYak("pakyak")-> "pak"
            //DoNotYak("yak123ya")-> "123ya"

            string output = "";

            int trackFirstAppear = 0;
            for (int index = 0; index < str.Length; index++)


            {

                trackFirstAppear = str.IndexOf("yak");

                if (trackFirstAppear == index)

                {
                    index += 2;
                }
                else
                {
                    output += str[index];
                }


            }


            return output;
        }

        public int Array667(int[] numbers)
        {

            //Given an array of ints, return the number of times that 
            //two 6's are next to each other in the array. Also count 
            //instances where the second "6" is actually a 7. 

            //Array667({ 6, 6, 2}) -> 1
            //Array667({ 6, 6, 2, 6}) -> 1
            //Array667({ 6, 7, 2, 6}) -> 1

            int output = 0;

            for (int index = 0; index < numbers.Length; index++ )
            {
                if (index <= numbers.Length - 2)
                {


                    if (numbers[index] == 6 && numbers[index + 1] == 6 || numbers[index + 1] == 7)
                    {
                        output++;
                        index++;
                    }

                    
                    
                }
                else break;
              

            }


            return output;
        }

        public bool NoTriples(int[] numbers)
        {


            //Given an array of ints, we'll say that a triple is a value 
            //appearing 3 times in a row in the array. Return true if 
            //the array does not contain any triples. 

            //NoTriples({ 1, 1, 2, 2, 1}) -> true
            //NoTriples({ 1, 1, 2, 2, 2, 1}) -> false
            //NoTriples({ 1, 1, 1, 2, 2, 2, 1}) -> false


            bool result = true;


            for (int index = 0; index < numbers.Length - 2; index++)
            {
                if (index < numbers.Length - 2)
                {

                    if (numbers[index] == numbers[index + 1] && numbers[index] == numbers[index + 2])
                    {
                        result = false;
                        break;
                    }
                    
                }

            }

            return result;


            

        }

        public bool Pattern51(int[] numbers)
        {

            //Given an array of ints, return true if it contains a 2, 7, 1 pattern-- a value, followed by the value plus 5, followed by the value minus 1.

            //Pattern51({ 1, 2, 7, 1}) -> true
            //Pattern51({ 1, 2, 8, 1}) -> false
            //Pattern51({ 2, 7, 1}) -> true


            bool result = false;
          
            
            for (int index = 0; index < numbers.Length - 2; index++)
            {
                if (index < numbers.Length - 2)
                {
                   
                    if (numbers[index] + 5  == numbers[index + 1] && numbers[index] - 1 == numbers[index+2]) result = true;

                }
                
            }

            return result;



        }

    }
}
