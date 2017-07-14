using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            //Given a string name, e.g. "Bob", return a greeting of the 
            //form "Hello Bob!".

            //SayHi("Bob")-> "Hello Bob!"
            //SayHi("Alice")-> "Hello Alice!"
            //SayHi("X")-> "Hello X!"

            return $"Hello {name}!";
        }

        public string Abba(string a, string b)
        {

            //Given two strings, a and b, return the result of putting them 
            //together in the order abba, e.g. "Hi" and "Bye" returns "HiByeByeHi".

            //Abba("Hi", "Bye")-> "HiByeByeHi"
            //Abba("Yo", "Alice")-> "YoAliceAliceYo"
            //Abba("What", "Up")-> "WhatUpUpWhat"

            return (a + b + b + a);

        }

        public string MakeTags(string tag, string content)
        {

            //The web is built with HTML strings like "<i>Yay</i>" which draws
            //Yay as italic text.In this example, the "i" tag makes<i> and</ i >
            //which surround the word "Yay".Given tag and word strings, create 
            //the HTML string with tags around the word, e.g. "<i>Yay</i>".

            //MakeTags("i", "Yay")-> "<i>Yay</i>"
            //MakeTags("i", "Hello")-> "<i>Hello</i>"
            //MakeTags("cite", "Yay")-> "<cite>Yay</cite>"

            return ($"<{tag}>{content}</{tag}>");

        }

        public string InsertWord(string container, string word) {

            //Given an "out" string length 4, such as "<<>>", and a word,
            //return a new string where the word is in the middle of the 
            //out string, e.g. "<<word>>".

            //Hint: Substrings are your friend here

            //InsertWord("<<>>", "Yay")-> "<<Yay>>"
            //InsertWord("<<>>", "WooHoo")-> "<<WooHoo>>"
            //InsertWord("[[]]", "word")-> "[[word]]"

            return (container.Substring(0, 2) + word + container.Substring(2, 2));

        }

        public string MultipleEndings(string str)
        {
            //Given a string, return a new string made of 3 copies of 
            //the last 2 chars of the original string.The string length 
            //will be at least 2.

            //MultipleEndings("Hello")-> "lololo"
            //MultipleEndings("ab")-> "ababab"
            //MultipleEndings("Hi")-> "HiHiHi"
            string result = string.Empty;

            for(int count = 0; count < 3;count++)
            {
                result += str.Substring((str.Length - 1) - 1, 2);
            }

            return result;
        }

        public string FirstHalf(string str)
        {

            //Given a string of even length, return the first half.
            //So the string "WooHoo" yields "Woo".

            //FirstHalf("WooHoo")-> "Woo"
            //FirstHalf("HelloThere")-> "Hello"
            //FirstHalf("abcdef")-> "abc"

            return (str.Substring(0, str.Length / 2));

        }

        public string TrimOne(string str)
        {

            //Given a string, return a version without the first and last char,
            //so "Hello" yields "ell".The string length will be at least 2.

            //TrimOne("Hello")-> "ell"
            //TrimOne("java")-> "av"
            //TrimOne("coding")-> "odin"
           
            str = str.Remove(str.Length - 1);
            str = str.Substring(1, str.Length-1);
            return str;
        }

        public string LongInMiddle(string a, string b)
        {

            //Given 2 strings, a and b, return a string of the form 
            //short+long + short, with the shorter string on the 
            //outside and the longer string on the inside. The 
            //strings will not be the same length, but they may 
            //be empty(length 0). 

            //LongInMiddle("Hello", "hi")-> "hiHellohi"
            //LongInMiddle("hi", "Hello")-> "hiHellohi"
            //LongInMiddle("aaa", "b")-> "baaab"

            string result = string.Empty;
            if (a.Length > b.Length)
            {
                result = b + a + b;
            }
            else
            {
                result = a + b + a;
            }

            return result;
        }

        public string RotateLeft2(string str)
        {

            //Given a string, return a "rotated left 2" version where the 
            //first 2 chars are moved to the end. The string length will 
            //be at least 2.

            //Rotateleft2("Hello")-> "lloHe"
            //Rotateleft2("java")-> "vaja"
            //Rotateleft2("Hi")-> "Hi"

            string output = string.Empty;

            if (str.Length % 2 == 0)
            {

                output = str.Substring((str.Length - 1) - 1, 2);
                output += str;
                output = output.Remove((output.Length - 1) - 1);

            }
            else
            {

                output = str.Substring((str.Length - 2) - 1, 3);
                output += str;
                output = output.Remove((output.Length - 2) - 1);

            }
            return output;



        }

        public string RotateRight2(string str)
        {

            //Given a string, return a "rotated right 2" version where the 
            //last 2 chars are moved to the start. The string length will 
            //be at least 2.

            //RotateRight2("Hello")-> "loHel"
            //RotateRight2("java")-> "vaja"
            //RotateRight2("Hi")-> "Hi"

            string output = string.Empty;

            if (str.Length % 2 == 0)
            {

                output = str.Substring((str.Length - 1) - 1, 2);
                output += str;
                output = output.Remove((output.Length - 1) - 1, 2);

            }
            else
            {

                output = str.Substring((str.Length - 1) - 1, 2);
                output += str;
                output = output.Remove((output.Length - 1) - 1);

            }
            return output;

        }

        public string TakeOne(string str, bool fromFront)
        {

            //Given a string, return a string length 1 from its front, 
            //unless front is false, in which case return a string length
            //1 from its back.The string will be non-empty.

            //TakeOne("Hello", true)-> "H"
            //TakeOne("Hello", false)-> "o"
            //TakeOne("oh", true)-> "o"

            string output = string.Empty;
            
            if (fromFront)
            {
                output = str.Substring(0, 1);
            }
            else
            {
                output = str.Substring(str.Length - 1, 1);
            }

            return output;
        }

        public string MiddleTwo(string str)
        {

            //Given a string of even length, return a string made of the 
            //middle two chars, so the string "string" yields "ri".The 
            //string length will be at least 2.

            //MiddleTwo("string")-> "ri"
            //MiddleTwo("code")-> "od"
            //MiddleTwo("Practice")-> "ct"

            string result = string.Empty;

            if (str.Length % 2  == 0)
            {
                result = str.Substring((str.Length / 2 - 1), 2);

            }
            else
            {
                result = str.Substring((str.Length / 2 - 1), 2);
            }

            return result;

        }

        public bool EndsWithLy(string str)
        {

            //Given a string, return true if it ends in "ly".

            //EndsWithLy("oddly")-> true
            //EndsWithLy("y")-> false
            //EndsWithLy("oddy")-> false

            bool result = false;

            if (str.Length >=2)
            {
                if (str.Substring((str.Length - 2), 2) == "ly") result = true;
            }
          

            return result;
        }

        public string FrontAndBack(string str, int n)
        {

            //Given a string and an int n, return a string made of 
            //the first and last n chars from the string.The string 
            //length will be at least n.

            //FrontAndBack("Hello", 2)-> "Helo"
            //FrontAndBack("Chocolate", 3)-> "Choate"
            //FrontAndBack("Chocolate", 1)-> "Ce"
            string result = string.Empty;

            result = str.Substring(0, n);
            result += str.Substring((str.Length - 1) - (n - 1),n);

            return result;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            //Given a string and an index, return a string length 2 starting
            //at the given index.If the index is too big or too small to 
            //define a string length 2, use the first 2 chars.The string 
            //length will be at least 2.

            //TakeTwoFromPosition("java", 0)-> "ja"
            //TakeTwoFromPosition("java", 2)-> "va"
            //TakeTwoFromPosition("java", 3)-> "ja"

            string output = "";

            if (n >= str.Length-1)
            {
                output = str.Substring(0,1);
                output += str.Substring(1, 1); ;
            }
            else
            {
                
                    output = str.Substring(n, 2);
            }

            return output;
           
        }

        public bool HasBad(string str)
        {


            //Given a string, return true if "bad" appears starting at index 0 or 1 
            //in the string, such as with "badxxx" or "xbadxx" but not "xxbadxx".
            //The string may be any length, including 0.

            //HasBad("badxx")-> true
            //HasBad("xbadxx")-> true
            //HasBad("xxbadxx")-> false

            bool result = false;
            string pattern = "bad";
            
            if (str.Contains(pattern))
            {

                if (str.IndexOf(pattern) <= 1) result = true;
                
            }

            return result;
        }

        public string AtFirst(string str)
        {
            //Given a string, return a string length 2 made of its first 2 chars.
            //If the string length is less than 2, use '@' for the missing chars.

            //AtFirst("hello")-> "he"
            //AtFirst("hi")-> "hi"
            //AtFirst("h")-> "h@"

            string output = "";


            if (str.Length >= 2)
            {
                output = str.Substring(0, 2);
            }
            else
            {
                if (str.Length == 0)
                    output = "@@";
                else
                    output = str + "@";
            }

            return output;
            
            
        }

        public string LastChars(string a, string b)
        {

            //Given 2 strings, a and b, return a new string made of the first 
            //char of a and the last char of b, so "yo" and "java" yields "ya".
            //If either string is length 0, use '@' for its missing char.

            //LastChars("last", "chars")-> "ls"
            //LastChars("yo", "mama")-> "ya"
            //LastChars("hi", "")-> "h@"

            string output = "";

            if (a.Length == 0)
                output += "@";
            else
                output += a.Substring(0,1);

            if (b.Length == 0)
                output += "@";
            else
                output += b.Substring(b.Length-1, 1);

            return output;
        }

        public string ConCat(string a, string b)
        {

            //Given two strings, append them together(known as "concatenation") 
            //and return the result.However, if the concatenation creates a 
            //double-char, then omit one of the chars, so "abc" and "cat" 
            //yields "abcat".

            //ConCat("abc", "cat")-> "abcat"
            //ConCat("dog", "cat")-> "dogcat"
            //ConCat("abc", "")-> "abc"

            string output = "";
            if (a.Length == 0 || b.Length == 0) output = a + b;
            else
            {
                if (a[a.Length - 1] == b[0])
                {
                    output = a.Remove(a.Length - 1);
                    output += b;
                }
                else
                {
                  

                    if (a.Length > 1 || b.Length > 1) output = a + b;
                }

            }
        
            
            return output;
           

        }

        public string SwapLast(string str)
        {

            //Given a string of any length, return a new string where 
            //the last 2 chars, if present, are swapped, so "coding" 
            //yields "codign".

            //SwapLast("coding")-> "codign"
            //SwapLast("cat")-> "cta"
            //SwapLast("ab")-> "ba"

            string output = "";
            if (str.Length > 2)
            {
                output = str.Substring(0, str.Length - 2);
                output = output + str[str.Length - 1] + str[str.Length - 2];
            }
            else
            {
                if (str.Length == 2)
                    output = $"{str[str.Length - 1]}{str[str.Length - 2]}";
                else
                    output = str;
            }
            return output;
                

        }

        public bool FrontAgain(string str)
        {

            //Given a string, return true if the first 2 chars in the string 
            //also appear at the end of the string, such as with "edited".

            //FrontAgain("edited")-> true
            //FrontAgain("edit")-> false
            //FrontAgain("ed")-> true

            bool result = false;

            if (str.Length >= 2)
            {
                string lastTwo = str.Substring(str.Length - 2, 2);

                if (str.Substring(0, 2) == lastTwo) result = true;
            }

            return result;
        }

        public string MinCat(string a, string b)
        {
            //Given two strings, append them together(known as "concatenation") 
            //and return the result.However, if the strings are different lengths,
            //omit chars from the longer string so it is the same length as the 
            //shorter string.So "Hello" and "Hi" yield "loHi".The strings may be 
            //any length.

            //MinCat("Hello", "Hi")-> "loHi"
            //MinCat("Hello", "java")-> "ellojava"
            //MinCat("java", "Hello")-> "javaello"

            int whichLonger = 0;

            if (a.Length >= b.Length) whichLonger = b.Length;
            else whichLonger = a.Length;

            return a.Substring(a.Length - whichLonger, whichLonger) + b.Substring(b.Length - whichLonger, whichLonger);
            

        }

        public string TweakFront(string str)
        {

            //Given a string, return a version without the first 2 chars.Except keep the first char
            //if it is 'a' and keep the second char if it is 'b'.The string may be any length.

            //TweakFront("Hello")-> "llo"
            //TweakFront("away")-> "aay"
            //TweakFront("abed")-> "abed"

            string output = "";


            if (str.Length >= 2)
            {
                if (str.Substring(0, 1) == "a") output += "a";
                if (str.Substring(1, 1) == "b") output += "b";
                output += str.Substring(2, str.Length - 2);
            }
            else
            {
                if (str.Length == 1)
                    if (str.Substring(0, 1) == "a" || str.Substring(0, 1) == "b") output = str;
            }
            
            
            return output; 
        }

        public string StripX(string str)
        {

            //Given a string, if the first or last chars are 'x', return
            //the string without those 'x' chars, and otherwise return 
            //the string unchanged. 

            //StripX("xHix")-> "Hi"
            //StripX("xHi")-> "Hi"
            //StripX("Hxix")-> "Hxi"



            if (str.Length != 0)
            {
                if (str.Length >= 2)
                {
                    if (str.Substring(str.Length - 1, 1) == "x") str = str.Remove(str.Length - 1);
                    if (str.Substring(0, 1) == "x") str = str.Substring(1, str.Length - 1);
                }
                else
                    if (str.Substring(0, 1) == "x") str = "";
            }
            return str;
        }
    }
}
