
using System;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store numbers and their indices.
        // Key: The number itself.
        // Value: The index of that number in the 'nums' array.
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        // Iterate through the array with its indices.
        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            // Calculate the complement needed to reach the target.
            int complement = target - currentNum;

            // Check if the complement already exists in our map.
            // If it does, we've found the two numbers that sum up to the target.
            if (numMap.ContainsKey(complement)) {
                // Return the index of the complement (from the map) and the current index 'i'.
                return new int[] { numMap[complement], i };
            }

            // If the complement is not found, add the current number and its index to the map.
            // This prepares for future checks where 'currentNum' might be a complement for another number.
            // Using `numMap[currentNum] = i` safely adds the key-value pair if the key
            // is new, or updates the value if the key already exists. This is fine for this problem
            // as we only need to store one index per number to find *a* valid pair.
            numMap[currentNum] = i;
        }

        // According to the problem constraints, exactly one solution is guaranteed.
        // Therefore, this line should theoretically never be reached under valid inputs.
        // It's included for completeness and to satisfy compiler requirements for returning a value.
        throw new InvalidOperationException("No two sum solution found as per problem constraints.");
    }
}
