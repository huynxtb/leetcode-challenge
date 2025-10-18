*   **Link:** https://leetcode.com/problems/two-sum/
*   **Difficulty:** Easy
*   **Question:** Two Sum
*   **Algorithm Explanation:**
    This problem asks us to find two numbers in a given array `nums` that add up to a specific `target` value, and return their indices. We are guaranteed that there is exactly one solution and that we cannot use the same element twice (meaning `nums[i]` and `nums[j]` where `i != j`).

    The most efficient way to solve this problem, achieving a time complexity better than O(n^2), is to use a hash map (or dictionary in C#). The algorithm works as follows:

    1.  **Initialize a Hash Map:** Create a dictionary, `numMap`, to store `(number, index)` pairs. The key will be an integer from the `nums` array, and its value will be the corresponding index.

    2.  **Iterate Through the Array:** Loop through the `nums` array from left to right, processing each number `nums[i]` at its current index `i`.

    3.  **Calculate Complement:** For each `nums[i]`, calculate the `complement` needed to reach the `target`. The `complement` is `target - nums[i]`.

    4.  **Check in Hash Map:** Before adding `nums[i]` to the map, check if the `complement` already exists as a key in `numMap`.
        *   If `numMap.ContainsKey(complement)` is true, it means we have previously encountered a number (at `numMap[complement]`) that, when added to the current `nums[i]`, equals `target`. In this case, we have found our pair of indices: `[numMap[complement], i]`. We can immediately return these indices.

    5.  **Add to Hash Map:** If the `complement` is not found in `numMap`, it means the current `nums[i]` is not the second part of a pair with any previously processed number. So, we add `nums[i]` and its index `i` to the `numMap` (i.e., `numMap[nums[i]] = i`). This makes `nums[i]` available as a potential complement for numbers we will encounter later in the iteration.

    **Time Complexity:**
    *   The algorithm iterates through the `nums` array exactly once, which takes O(n) time, where 'n' is the number of elements in `nums`.
    *   Inside the loop, hash map operations (insertion and lookup) take an average time complexity of O(1).
    *   Therefore, the overall time complexity is **O(n)**.

    **Space Complexity:**
    *   In the worst-case scenario, if no solution is found until the very end, or if all elements are unique and need to be stored, the hash map `numMap` could store up to 'n' elements.
    *   Each element stored requires constant space.
    *   Therefore, the overall space complexity is **O(n)**.