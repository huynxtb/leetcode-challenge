
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
            // If the currentNum is already in the map, it means there's a duplicate.
            // However, the problem statement "you may not use the same element twice" means
            // we shouldn't use nums[i] for nums[i], not that the array cannot contain duplicates.
            // The logic correctly handles duplicates by adding only the first occurrence's index
            // and if a duplicate appears later, it will still correctly find its pair
            // if the complement was an earlier element.
            // For example, nums = [3,3], target = 6.
            // First 3 (index 0): complement is 3. Map is empty. Add (3, 0).
            // Second 3 (index 1): complement is 3. Map contains 3 (at index 0). Return [0, 1].
            // So, 'if (!numMap.ContainsKey(currentNum))' is crucial to store only the first index of a duplicate.
            // However, the problem usually implies unique indices for the *output*, not that the *values* are unique.
            // Given "you may not use the same element twice" and "nums = [3,3], target = 6, Output: [0,1]",
            // it means we can use nums[0] and nums[1] even if their values are the same.
            // Storing the *first* encountered index for a value is generally correct for this problem.
            // Let's simplify: always add or update the index.
            // If there are duplicates, and one is needed for the complement, we'd want the first one's index
            // to fulfill the "use element once" implied by `numMap.Add(currentNum, i)`.
            // But if `currentNum` is itself the complement for an earlier number, the earlier
            // entry for `currentNum` in the map would be the target.
            // A simpler approach for the given constraints and typical LeetCode expectations
            // is to simply add the number and its index. If a number appears multiple times,
            // the dictionary will store the index of its *first* occurrence if we use .Add,
            // or the *latest* if we use map[key] = value.
            // For Two Sum, we want to find *any* pair.
            // Consider nums = [3, 2, 3], target = 6.
            // i=0, num=3, comp=3. Map empty. Add (3,0). Map: {3:0}
            // i=1, num=2, comp=4. Map doesn't have 4. Add (2,1). Map: {3:0, 2:1}
            // i=2, num=3, comp=3. Map has 3. Returns [map[3], 2] -> [0, 2]. Correct.
            // So the simple `numMap[currentNum] = i;` would override previous entries
            // if duplicate keys were handled this way, which would be problematic.
            // `numMap.Add` throws an error if key exists. `numMap.TryAdd` for .NET Core 3.0+.
            // The standard `Dictionary<K,V>` in C# doesn't allow duplicate keys.
            // So, `if (!numMap.ContainsKey(currentNum)) { numMap.Add(currentNum, i); }`
            // is the correct way to ensure we store the *first* index of a value.
            // This is important because the problem states "you may not use the same element twice",
            // which usually implies using `nums[i]` and `nums[j]` where `i != j`.
            // If `target = 6` and `nums = [3,3]`, we need `nums[0]` and `nums[1]`.
            // With `if (!numMap.ContainsKey(currentNum)) { numMap.Add(currentNum, i); }`:
            // 1. i=0, num=3. complement = 3. numMap empty. Add(3,0). Map: {3:0}
            // 2. i=1, num=3. complement = 3. numMap.ContainsKey(3) is true. Return [numMap[3], 1] -> [0, 1]. Correct.
            // This logic is robust for the given constraints.
        }

        // As per problem statement, "each input would have exactly one solution",
        // so this line should technically never be reached.
        throw new InvalidOperationException("No two sum solution");
    }
}
