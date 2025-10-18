
*   **Link:** https://leetcode.com/problems/two-sum/
*   **Difficulty:** Easy
*   **Question:** Two Sum
*   **Algorithm Explanation:**
    The problem asks us to find two numbers in a given array `nums` that sum up to a specific `target` value and then return the indices of these two numbers. Key constraints include: exactly one solution exists, and the same element cannot be used twice.

    A straightforward but inefficient approach would involve checking every possible pair of numbers using nested loops, leading to an O(n^2) time complexity. However, the follow-up question specifically prompts for an algorithm with better than O(n^2) time complexity.

    The optimal solution leverages a **hash map** (implemented as `Dictionary<int, int>` in C#) to achieve a linear time complexity. Here's the detailed algorithm:

    1.  **Initialize a Hash Map:** Create an empty hash map where keys will be numbers from the `nums` array, and their corresponding values will be their indices.
    2.  **Iterate Through the Array:** Loop through the `nums` array from the first element to the last, using an index `i`.
    3.  **Calculate Complement:** For each number `nums[i]` encountered during the iteration, calculate the `complement` needed to reach the `target`. The `complement` is `target - nums[i]`.
    4.  **Check in Hash Map:**
        *   **If the `complement` exists as a key in the hash map:** This signifies that we have previously encountered a number (at `numMap[complement]`) which, when added to the current `nums[i]`, sums up to the `target`. We have found our pair. Return the indices `numMap[complement]` and `i`.
        *   **If the `complement` does not exist in the hash map:** This means the current `nums[i]` is not part of a pair with any number processed so far to form the `target`. In this case, add the current number `nums[i]` and its index `i` to the hash map. This makes `nums[i]` available as a potential `complement` for numbers encountered later in the array. This step also inherently ensures that we don't use the same element twice, as we add the current element to the map *after* checking if its complement exists.

    Since the problem guarantees that exactly one valid solution exists, the loop will always find the correct pair and return, never completing the entire loop without a result.

    **Time Complexity:** O(n)
    The algorithm involves a single pass through the input array of size `n`. Hash map operations (insertion and lookup) have an average time complexity of O(1). Therefore, the overall time complexity is dominated by the single pass, resulting in O(n).

    **Space Complexity:** O(n)
    In the worst-case scenario, if the solution pair is found towards the end of the array, we might need to store almost all `n` elements in the hash map. This makes the space complexity proportional to the number of elements in the input array, resulting in O(n).
