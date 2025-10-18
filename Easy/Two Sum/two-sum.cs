public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store numbers and their indices.
        // The key is the number, and the value is its index.
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            int currentNum = nums[i];
            // Calculate the complement needed to reach the target
            int complement = target - currentNum;

            // Check if the complement already exists in our map
            if (numMap.ContainsKey(complement)) {
                // If it does, we found the two numbers.
                // Return the index of the complement and the current index.
                return new int[] { numMap[complement], i };
            }

            // If the complement is not found, add the current number and its index to the map
            // This allows future numbers to check against the current number.
            // We only add if not found to handle cases like target = 6, nums = [3,3].
            // If we try to add `numMap[3] = 0` then `numMap[3] = 1`, it would overwrite, 
            // but we need to ensure we don't use the same element twice unless it's a distinct one.
            // The problem states "you may not use the same element twice", which means 
            // `nums[i]` and `nums[j]` where `i != j`.
            // So, for distinct numbers, we add them.
            // If a number appears multiple times, like [3,3] target 6, 
            // the first 3 (at index 0) will be added. When the second 3 (at index 1) is processed, 
            // its complement (6-3=3) will be found in the map, and it correctly returns [0,1].
            numMap[currentNum] = i;
        }

        // As per the problem statement, there will always be exactly one solution,
        // so this line should ideally not be reached.
        return new int[0]; // Or throw an exception if no solution is guaranteed
    }
}
