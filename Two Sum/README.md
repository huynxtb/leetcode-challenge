# Two Sum
*   **Link:** https://leetcode.com/problems/two-sum/
*   **Difficulty:** Easy
*   **Question:** Two Sum

## Algorithm Explanation
The problem asks us to find two numbers in an array `nums` that sum up to a given `target` and return their indices. We are guaranteed that there is exactly one solution and we cannot use the same element twice. The follow-up question encourages finding a solution with better than `O(n^2)` time complexity.

A brute-force approach would involve using two nested loops, checking every possible pair, which would result in `O(n^2)` time complexity. To achieve better performance, we can leverage a hash map (or dictionary in C#).

The algorithm proceeds as follows:
1.  Initialize an empty hash map, let's call it `numMap`. This map will store key-value pairs where the key is a number from `nums` and the value is its corresponding index.
2.  Iterate through the `nums` array using a single loop, from index `i = 0` to `nums.Length - 1`.
3.  For each number `nums[i]` at the current index `i`:
    a.  Calculate the `complement` needed to reach the `target`. The `complement` is `target - nums[i]`.
    b.  Check if this `complement` already exists as a key in our `numMap`.
        i.  If `numMap` contains the `complement` as a key, it means we have found the two numbers that sum up to `target`. The index of the `complement` is `numMap[complement]`, and the index of the current number is `i`. We then return these two indices as an array: `[numMap[complement], i]`.
        ii. If `numMap` does not contain the `complement`, it means the current `nums[i]` is not part of a pair found so far. In this case, we add the current number `nums[i]` and its index `i` to the `numMap` for future lookups: `numMap[nums[i]] = i`. We add it *after* checking for its complement to ensure we don't use the same element twice (i.e., `nums[i]` as both the current number and its own complement).
4.  Since the problem guarantees exactly one solution, the loop will always find a pair and return before completing all iterations. Thus, no code outside the loop for returning an answer is strictly needed, but a placeholder return is included for completeness in C#.

### Time Complexity
The algorithm iterates through the `nums` array once. Inside the loop, hash map operations (insertion and lookup) take an average of `O(1)` time. Therefore, the overall time complexity is **O(n)**, where `n` is the number of elements in the `nums` array.

### Space Complexity
In the worst-case scenario, if no solution is found until the very last iteration (or if the target is such that we need to store almost all numbers), the hash map might store up to `n` elements. Thus, the space complexity is **O(n)**, where `n` is the number of elements in the `nums` array.