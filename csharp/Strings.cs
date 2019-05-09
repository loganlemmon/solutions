public class Strings
{

    //in-place reversal of a string - O(n)
    string ReverseString(string input)
    {
        //set index to the end of input
        int index = input.Length - 1;
        //store original length of input
        int originalLength = input.Length;

        //loop through input from right to left, add character at index to end
        while (index >= 0)
        {
            input += input[index];
            index -= 1;
        }

        //remove original word from input, return
        return input.Remove(0, originalLength);
    }

}