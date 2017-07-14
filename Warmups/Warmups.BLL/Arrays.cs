using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {

            //Given an array of ints, return true if 6 appears as either the first or last element 
            //in the array. The array will be length 1 or more. 

            //FirstLast6({ 1, 2, 6}) -> true
            //FirstLast6({ 6, 1, 2, 3}) -> true
            //FirstLast6({ 13, 6, 1, 2, 3}) -> false

            bool result = false;

            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6) result = true;

            return result;

        }

        public bool SameFirstLast(int[] numbers)
        {

            //Given an array of ints, return true if the array is length 1 or more, and the 
            //first element and the last element are equal.

            //SameFirstLast({ 1, 2, 3}) -> false
            //SameFirstLast({ 1, 2, 3, 1}) -> true
            //SameFirstLast({ 1, 2, 1}) -> true

            bool result = false;

            if (numbers.Length >= 1 && numbers[0] == numbers[numbers.Length-1]) result = true;

            return result;

        }
        public int[] MakePi(int n)
        {
            //Return an int array length n containing the first n digits of pi.

            double pi = Math.PI;
            int[] output = new int[n];
            int transfer = 0;




            pi = pi * Math.Pow(10, n - 1);

            pi = Math.Truncate(pi);
            transfer = (int)pi;


            for (int power=n; power >= 1; power--)
            {
                output[output.Length - power] = transfer / (int)Math.Pow(10, power-1);
                transfer = transfer % (int)Math.Pow(10, power - 1);
            }

            
        

            return output;

            
        }

        public bool CommonEnd(int[] a, int[] b)
        {

            //Given 2 arrays of ints, a and b, return true if they have 
            //the same first element or they have the same last element.
            //Both arrays will be length 1 or more. 

            //CommonEnd({ 1, 2, 3}, { 7, 3}) -> true
            //CommonEnd({ 1, 2, 3}, { 7, 3, 2}) -> false
            //CommonEnd({ 1, 2, 3}, { 1, 3}) -> true

            bool output = false;

            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]) output = true;

            return output;
        }
        
        public int Sum(int[] numbers)
        {

            //Given an array of ints, return the sum of all the elements.

            //Sum({ 1, 2, 3}) -> 6
            //Sum({ 5, 11, 2}) -> 18
            //Sum({ 7, 0, 0}) -> 7
            int output = 0;

            for(int index = 0; index < numbers.Length; index++)
            {
                output += numbers[index];
            }

            return output;
        }

        public int[] RotateLeft(int[] numbers)
        {

            //Given an array of ints, return an array with the elements 
            //"rotated left" so { 1, 2, 3} yields { 2, 3, 1}. 

            //RotateLeft({ 1, 2, 3}) -> { 2, 3, 1}
            //RotateLeft({ 5, 11, 9}) -> { 11, 9, 5}
            //RotateLeft({ 7, 0, 0}) -> { 0, 0, 7}

            int[] output = new int[numbers.Length];
            int numberIndex0 = numbers[0];
            for (int index = 1; index < numbers.Length; index++)
                output[index - 1] = numbers[index];

            output[numbers.Length - 1] = numberIndex0;

            return output;
        }
        
        public int[] Reverse(int[] numbers)
        {



            //Given an array of ints length 3, return a new array with the 
            //elements in reverse order, so for example { 1, 2, 3}
            //becomes { 3, 2, 1}. 

            int[] reverse = new int[numbers.Length];

            for (int index = numbers.Length - 1; index >= 0; index--)
                reverse[numbers.Length - 1 - index] = numbers[index];


            return reverse;

            
        }

        public int[] HigherWins(int[] numbers)
        {
            //Given an array of ints, figure out which is larger between the 
            //first and last elements in the array, and set all the other 
            //elements to be that value.Return the changed array. 

            //HigherWins({ 1, 2, 3}) -> { 3, 3, 3}
            //HigherWins({ 11, 5, 9}) -> { 11, 11, 11}
            //HigherWins({ 2, 11, 3}) -> { 3, 3, 3}

            if (numbers[0] > numbers[numbers.Length - 1])
            {
                for (int index = 1; index < numbers.Length; index++)
                    numbers[index] = numbers[0];
            }
            else
            {
                for (int index = (numbers.Length - 1) - 1; index >=0; index--)
                    numbers[index] = numbers[(numbers.Length - 1)];
            }

            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {

            //Given 2 int arrays, a and b, each length 3, return a new array length 2 
            //containing their middle elements. 

            //GetMiddle({ 1, 2, 3}, { 4, 5, 6}) -> { 2, 5}
            //GetMiddle({ 7, 7, 7}, { 3, 8, 0}) -> { 7, 8}
            //GetMiddle({ 5, 2, 9}, { 1, 4, 5}) -> { 2, 4}

            int[] output = new int[2];

            output[0] = a[1];
            output[1] = b[1];

            return output;
        }
        
        public bool HasEven(int[] numbers)
        {

            //Given an int array, return true if it contains an even number(HINT: Use Mod(%)). 

            //HasEven({ 2, 5}) -> true
            //HasEven({ 4, 3}) -> true
            //HasEven({ 7, 5}) -> false
            bool output = false;

            for (int index = 0; index < numbers.Length; index++)
                if (numbers[index] % 2 == 0)
                {
                    output = true;
                    break;
                }

            return output;
        }
        
        public int[] KeepLast(int[] numbers)
        {

            //Given an int array, return a new array with double the length 
            //where its last element is the same as the original array, and 
            //all the other elements are 0.The original array will be 
            //length 1 or more. Note: by default, a new int array contains all 0's. 

            //KeepLast({ 4, 5, 6}) -> { 0, 0, 0, 0, 0, 6}
            //KeepLast({ 1, 2}) -> { 0, 0, 0, 2}
            //KeepLast({ 3}) -> { 0, 3}

            int[] output = new int[numbers.Length * 2];

            output[output.Length - 1] = numbers[numbers.Length - 1];
           

            return output;
        }
        
        public bool Double23(int[] numbers)
        {
            //Given an int array, return true if the array contains 2 twice
            //, or 3 twice.

            //Double23({ 2, 2, 3}) -> true
            //Double23({ 3, 4, 5, 3}) -> true
            //Double23({ 2, 3, 2, 2}) -> false
            int twoCounter = 0;
            int threeCounter = 0;
            bool result = false;

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] == 2) twoCounter++;
                if (numbers[index] == 3) threeCounter++;
                
            }
            
            if (twoCounter == 2 || threeCounter == 2) result = true;

            return result;

        }
        
        public int[] Fix23(int[] numbers)
        {

            //Given an int array length 3, if there is a 2 in the array 
            //immediately followed by a 3, set the 3 element to 0.
            //Return the changed array.

            //Fix23({ 1, 2, 3}) ->{ 1, 2, 0}
            //Fix23({ 2, 3, 5}) -> { 2, 0, 5}
            //Fix23({ 1, 2, 1}) -> { 1, 2, 1}

            for (int index = 0; index < numbers.Length - 1; index++)
                if (numbers[index] == 2 && numbers[index + 1] == 3)
                {
                    numbers[index + 1] = 0;
                }

            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {

            //We'll say that a 1 immediately followed by a 3 in an array is 
            //an "unlucky" 1. 
            //Return true if the given array contains an unlucky 1 in the 
            //first 2 or last 2 positions in the array. 

            //Unlucky1({ 1, 3, 4, 5}) -> true
            //Unlucky1({ 2, 1, 3, 4, 5}) -> true
            //Unlucky1({ 1, 1, 1}) -> false

            bool unluckyFound = false;

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] == 3)
                {

                    if (index >= 1 && index <= (numbers.Length - 2))
                    {
                        if (numbers[index - 1] == 1) unluckyFound = true;
                        if (numbers[index + 1] == 1) unluckyFound = true;
                    }


                    if (index >= 2 && index <= (numbers.Length - 3))
                    {
                        if (numbers[index - 2] == 1 || numbers[index - 1] == 1) unluckyFound = true;
                        if (numbers[index + 2] == 1 || numbers[index + 1] == 1) unluckyFound = true;
                    }
                }
            }

          

            return unluckyFound;



        }
        
        public int[] Make2(int[] a, int[] b)
        {

            //Given 2 int arrays, a and b, return a new array length 2 containing,
            //as much as will fit, the elements from a followed by the elements 
            //from b.The arrays may be any length, including 0, but there will 
            //be 2 or more elements available between the 2 arrays.

            //Make2({ 4, 5}, { 1, 2, 3}) -> { 4, 5}
            //Make2({ 4}, { 1, 2, 3}) -> { 4, 1}
            //Make2({ }, { 1, 2}) -> { 1, 2}

            int[] output = new int[2];

            if (a.Length < 2)
            {
                if (a.Length == 0)
                {
                    output[0] = b[0];
                    output[1] = b[1];

                }
                else
                {
                    output[0] = a[0];
                    output[1] = b[0];

                }
            }
            if (a.Length == 2) output = a;

            return output;
            
        }

    }
}
