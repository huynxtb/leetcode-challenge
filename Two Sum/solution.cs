public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            if (numMap.ContainsKey(complement)) {
                return new int[] { numMap[complement], i };
            }

            numMap[nums[i]] = i;
        }

        // As per problem constraints, exactly one solution exists,
        // so this line should never be reached.
        return new int[2];
    }
}