using System;
using System.Collections.Generic;
using System.Linq;

public class Arrays
{

    //Log all pairs in an array - O(n)
    void LogAllPairs(int[] input)
    {
        int first = 0;
        int second = 0;

        //loop through array until first == the length of the array
        while (first != input.Length)
        {
            //iterate through the second digit first
            Console.WriteLine(input[first] + ", " + input[second]);
            second++;

            //once the second index is equal to the length of input...
            if (second == input.Length)
            {
                //...add to the first index and reset the second to the beginning
                first++;
                second = 0;
            }

            //repeat until all those good good pairs are printed
        }
    }

    //find the second largest integer in a given array
    string SecondLargest(int[] input)
    {
        //order given array by descending
        var orderByDescending = from x in input
                                orderby x descending
                                select x;

        //if array is empty, return an error
        if (orderByDescending.Count() == 0)
        {
            return "array is empty";
        }

        //convert ordered enumerable to an array, select second largest, and return
        return orderByDescending.ToArray()[1].ToString();

    }

    //alternative to the above
    int? SecondLargest2(int[] input)
    {
        //declare two nullable integers, because we'd like to do null checks below (rather than checking for 0)
        int? largest = null;
        int? secondLargest = null;

        //loop through given array
        for (int i = 0; i < input.Length; i++)
        {
            //if largest hasn't been given a value...
            if (largest == null)
            {
                //... set the largest value to the element at current index
                largest = input[i];
            }
            //then, if largest already has a value and the element at the current index is bigger than largest...
            else if (input[i] > largest)
            {
                //... set secondLargest to largest, so we don't lose the value...
                secondLargest = largest;
                //... and largest to the next, larger number!
                largest = input[i];
            }
            //if the second largest number hasn't been set so far...
            else if (secondLargest == null)
            {
                //... set secondLargest to the element at current index.
                secondLargest = input[i];
            }
            //now, if the element at current index is larger than secondLargest...
            else if (input[i] > secondLargest)
            {
                //... second largest needs to be set to the current number.
                secondLargest = input[i];
            }

        }

        //return the result
        return secondLargest;

    }

    //given a sorted grid, where negative integers make up the upper left and positives the lower right,
    //return the number of negatives using O(n) complexity.
    // ex. { { -3, -2, 1} , { -2, -2, 1}, { 1, 1, 0 } }
    int CountNegativesInGrid(int[,] grid)
    {
        int count = 0;
        int row_i = 0;
        int col_i = grid.GetLength(0) - 1;

        //loop through grid, starting from top right (which should be a positive number)
        while (col_i >= 0 && row_i < grid.Length)
        {
            //if we encounter a negative number, we know we've found the delination between positve and negative integers
            if (grid[row_i, col_i] < 0)
            {
                //increase the count by however many spaces are to the left of the current index
                count += col_i + 1;
                //move on to the next row
                row_i += 1;
            }
            else
            {
                //if we don't find a negative, move on to the next column
                col_i -= 1;
            }
        }

        return count;

    }


}

