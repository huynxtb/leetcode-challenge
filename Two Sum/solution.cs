
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store numbers and their indices.
        // Key: number, Value: index
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            int complement = target - currentNum;

            // Check if the complement exists in the dictionary
            if (numMap.ContainsKey(complement)) {
                // If it exists, we found the two numbers.
                // Return their indices.
                return new int[] { numMap[complement], i };
            }

            // If the complement does not exist, add the current number and its index to the dictionary.
            // This handles cases where the current number might be a complement for a future number.
            // It also ensures that we don't use the same element twice as we add the current element *after* checking for its complement.
            numMap[currentNum] = i;
        }

        // According to the problem constraints, there will always be exactly one solution,
        // so this line should technically not be reached. A common practice for LeetCode is to return an empty array or null
        // if no solution is found, though this problem guarantees a solution.
        return new int[0]; 
    }
}
