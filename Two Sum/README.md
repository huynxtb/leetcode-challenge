**Link:** https://leetcode.com/problems/two-sum/
**Difficulty:** Easy
**Question:** Two Sum
**Algorithm Explanation:**
This problem asks us to find two numbers in an array that sum up to a specific target value and return their indices. The problem guarantees that there will be exactly one solution and that we cannot use the same element twice (implying different indices). We are also challenged to find a solution with less than O(n^2) time complexity.

The most efficient approach for this problem is to use a hash map (or dictionary in C#). The idea is to iterate through the array once. For each number `nums[i]`, we calculate the "complement" needed to reach the `target` (i.e., `complement = target - nums[i]`).

1.  **Initialization:** We start by creating an empty hash map (e.g., `Dictionary<int, int>` in C#). This map will store numbers from the array as keys and their corresponding indices as values.

2.  **Iteration:** We then iterate through the `nums` array from the first element to the last, keeping track of the current index `i`.

3.  **Complement Check:** In each iteration, for the current number `nums[i]`:
    *   We calculate the `complement` ( `target - nums[i]` ).
    *   We check if this `complement` already exists as a key in our hash map.
        *   If it does exist, it means we have found the two numbers that sum up to `target`. The index of the `complement` is retrieved from the hash map, and the current index `i` is the index of `nums[i]`. We return these two indices.
    *   If the `complement` does not exist in the hash map, it means `nums[i]` is not part of a pair with any previously seen number *yet*. So, we add the current number `nums[i]` and its index `i` to the hash map. This prepares the map for future numbers that might need `nums[i]` as their complement. If `nums[i]` is already in the map, we update its index to the current `i`. This is generally fine because if an earlier occurrence of `nums[i]` was part of a solution, it would have already found its complement and returned.

4.  **Guaranteed Solution:** Since the problem states that there is "exactly one solution," our loop will always find a pair and return before completing all iterations or reaching the end of the method.

**Time Complexity:** $O(N)$
The algorithm iterates through the `nums` array once. Inside the loop, hash map operations (`ContainsKey` and adding/updating an entry) take, on average, O(1) time. Therefore, the overall time complexity is linear, proportional to the number of elements in the array, $O(N)$, where $N$ is the length of `nums`.

**Space Complexity:** $O(N)$
In the worst-case scenario (e.g., the two sum elements are the last two in the array, or the target value is very specific), the hash map might store up to $N$ elements from the `nums` array. Each element stored in the map consumes a constant amount of space. Therefore, the space complexity is $O(N)$, proportional to the number of elements in the array.