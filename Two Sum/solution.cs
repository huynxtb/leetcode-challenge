public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store numbers and their indices.
        // Key: number, Value: index
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            // Calculate the complement needed to reach the target
            int complement = target - nums[i];

            // Check if the complement exists in our map
            if (numMap.ContainsKey(complement)) {
                // If it exists, we found the two numbers.
                // Return their indices: the index of the complement from the map,
                // and the current index 'i'.
                return new int[] { numMap[complement], i };
            }

            // If the complement is not found, add the current number and its index to the map.
            // If the number already exists as a key, update its index. This is fine
            // because if an earlier occurrence was part of the solution, it would have been found.
            numMap[nums[i]] = i;
        }

        // According to the problem constraints ("exactly one solution"),
        // this part of the code should never be reached.
        // However, a return statement is required for completeness.
        return new int[0];
    }
}