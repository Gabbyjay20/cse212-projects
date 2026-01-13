using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with the given length.
        // 2. Loop from index 0 to length - 1.
        // 3. At each index, store number multiplied by (index + 1).
        // 4. Return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the list to the right by the given amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Repeat the rotation 'amount' times.
        // 2. Each time, store the last element of the list.
        // 3. Shift all elements one position to the right.
        // 4. Place the stored last element into index 0.

        for (int a = 0; a < amount; a++)
        {
            int last = data[data.Count - 1];

            for (int i = data.Count - 1; i > 0; i--)
            {
                data[i] = data[i - 1];
            }

            data[0] = last;
        }
    }
}
