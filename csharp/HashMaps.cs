using System;
using System.Collections.Generic;

public class HashMaps
{

    //if two arrays share a common item, return true, else false
    //O(n)
    bool FindPairInArraysWithHashmap(string[] a1, string[] a2)
    {
        //define a hash map
        Dictionary<string, string> map = new Dictionary<string, string>();

        //add contents of first array to hash map
        for (int i = 0; i < a1.Length; i++)
        {
            if (!map.ContainsKey(a1[i]))
            {
                map.Add(a1[i], "");
            }
        }

        //check hash map against second array for existing entries
        for (int j = 0; j < a2.Length; j++)
        {
            if (map.ContainsKey(a2[j]))
            {
                return true;
            }
        }

        return false;
    }


    //given an array (ex: {3, 6, 3, 4, 2, 5}), return two values (if any) which add up to 10
    //O(n)
    string PairTen(int[] array)
    {
        Dictionary<int, int> foundInts = new Dictionary<int, int>(); //initialize a hash map

        //loop through the array
        for (int i = 0; i < array.Length; i++)
        {
            //check if element at current index from array is present in hash map
            if (!foundInts.ContainsKey(array[i]))
            {
                //check if hash map contains key which would equal 10 if added to current index
                if (foundInts.ContainsKey(10 - array[i]))
                {
                    //if found, return both values;
                    return (10 - array[i]).ToString() + ", " + array[i].ToString();
                }

                //otherwise, add value to foundInts and move on to element at next index
                foundInts.Add(array[i], 1);
            }
        }

        //if entire array has no pairs, return failure
        return "no pairs found";
    }

    //accepts a string (lower case a-z), converts to morse code
    //O(n)
    string MorseCode(string input)
    {
        //hash map which will contain both morse code and abcs as Key/Value pairs
        Dictionary<string, string> translationTable = new Dictionary<string, string>();

        string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
            "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-",
                ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", " "};
        string[] abcs = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q",
                "r","s","t","u","v","w","x","y","z"," " };

        string result = "";

        //add both arrays to hash map as Key/Value pairs
        for (int i = 0; i < morse.Length; i++)
        {
            translationTable.Add(abcs[i], morse[i]);
        }

        //scan input string, concatenate translation onto result
        foreach (char c in input)
        {
            result = result + translationTable[c.ToString()];
        }

        Console.WriteLine(translationTable[0]);

        return result;
    }

    //brute force alternative to above, not using a hashmap
    //O(n^2)
    string MorseCode2(string input)
    {

        string result = "";

        string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.",
            "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-",
                ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", " "};
        string[] abcs = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q",
                "r","s","t","u","v","w","x","y","z"," " };
                
        //loop through each character in input
        foreach (char c in input)
        {
            //loop through abcs until matching character is found
            for (int i = 0; i < abcs.Length; i++)
            {
                if (c.ToString() == abcs[i])
                {
                    //concatenate found matching character onto result
                    result = result + morse[i];
                }
            }

        }

        return result;
    }
}