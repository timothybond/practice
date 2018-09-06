using System;
using System.Collections;

namespace Practice
{
    public class ArraysAndStrings
    {
        //PalindromePermutation
        //Write a function to check if tit is a permutation of a palindrome.

        //Read characters to a alphabetic hashtable keeping count each character

        //bool IsPermutationOfPalinddrome(string s)
        //{
        //    int[] table = BuildCharFrequencyArray(s);
        //    Char.GetNumericValue()
        //}

        //Count how many times each letter appears
        int[] BuildCharFrequencyArray(string s)
        {
            int[] table = new int['z' - 'a' + 1];
            foreach (var letter in s.ToCharArray())
            {
                int num = GetCharNumber(letter);
                if(num!= -1)
                {
                    table[num]++;
                }
            }
            return table;
        }

        int GetCharNumber(Char c)
        {
            if('a' <= c && c <= 'z')
            {
                return 'a' - c;
            }
            return - 1;
        }

    }
}
