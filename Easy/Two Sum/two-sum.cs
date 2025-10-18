
using System;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store numbers and their indices.
        // Key: number, Value: index
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            // Calculate the complement needed to reach the target.
            int complement = target - currentNum;

            // Check if the complement exists in our map.
            // If it does, we found the two numbers.
            if (numMap.ContainsKey(complement)) {
                // Return the index of the complement and the current number's index.
                return new int[] { numMap[complement], i };
            }

            // If the complement is not found, add the current number and its index to the map.
            // We only add it after checking, to ensure we don't use the same element twice.
            if (!numMap.ContainsKey(currentNum))
            {
                numMap.Add(currentNum, i);
            }
        }

        // As per problem statement, "each input would have exactly one solution",
        // so this line should technically never be reached.
        throw new InvalidOperationException("No two sum solution");
    }
}
