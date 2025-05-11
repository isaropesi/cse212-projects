public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of doubles with the specified length.
        // Step 2: Loop through the array indices from 0 to length - 1.
        // Step 3: For each index i, calculate the multiple as number * (i + 1).
        // Step 4: Assign the calculated value to the array at index i.
        // Step 5: After the loop, return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the number of elements to move from the end to the front.
        // The last 'amount' elements will be moved to the front of the list.

        // Step 2: Use GetRange to get the last 'amount' elements from the list.
        List<int> lastElements = data.GetRange(data.Count - amount, amount);

        // Step 3: Remove the last 'amount' elements from the list using RemoveRange.
        data.RemoveRange(data.Count - amount, amount);

        // Step 4: Insert the saved elements at the beginning of the list using InsertRange.
        data.InsertRange(0, lastElements);

        // Step 5: The list is now rotated to the right by 'amount'.
    }
}
