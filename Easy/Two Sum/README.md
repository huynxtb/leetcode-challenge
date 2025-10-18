
# Two Sum
*   **Link:** https://leetcode.com/problems/two-sum/
*   **Difficulty:** Easy
*   **Question:** Two Sum

## Algorithm Explanation
The problem requires us to find two numbers in a given array `nums` that sum up to a specific `target` integer, and then return their 0-based indices. We are guaranteed that there is exactly one solution and that we cannot use the same element twice (meaning `nums[i]` and `nums[j]` where `i` and `j` are different indices). The follow-up hints at an algorithm more efficient than O(n^2).

A straightforward brute-force approach would involve using nested loops to check every possible pair of numbers, which would result in an O(n^2) time complexity. To achieve better performance, we can utilize a hash map (known as `Dictionary<TKey, TValue>` in C#).

The optimized algorithm proceeds as follows:
1.  Initialize an empty hash map, let's call it `numMap`. This map will store numbers from the `nums` array as keys and their corresponding indices as values.
2.  Iterate through the `nums` array using a single loop, with an index `i` ranging from `0` to `nums.Length - 1`.
3.  For each number `nums[i]` at the current index `i`:
    a.  Calculate the `complement` value that, when added to `nums[i]`, would equal the `target`. The `complement` is `target - nums[i]`.
    b.  Check if this calculated `complement` already exists as a key in our `numMap`.
        *   If `numMap` contains the `complement` as a key, it means we have found the two numbers that sum up to `target`. The first number is the one whose index is stored in `numMap` under the `complement` key, and the second number is `nums[i]` itself. In this case, we immediately return a new integer array containing `[numMap[complement], i]`.
        *   If the `complement` is not found in `numMap`, it means `nums[i]` has not yet found its pair. We then add `nums[i]` and its current index `i` to the `numMap`. It's important to only add the number to the map after checking for its complement to ensure we don't mistakenly use the same element twice (i.e., `nums[i]` as its own complement). Specifically, if `nums[i]` is not already in the map, we add `(nums[i], i)`. This handles cases where duplicate numbers exist in the input array by storing the index of their first occurrence.

4.  Since the problem guarantees that "exactly one solution" exists, the loop will always find a pair and return the result before iterating through the entire array without finding a solution. Therefore, no explicit handling for a "no solution" case is strictly necessary within the LeetCode context, though adding a `throw` statement for robustness in general programming is good practice.

### Time Complexity
The algorithm involves a single pass through the `nums` array. Within the loop, operations such as calculating the complement and performing hash map lookups (`ContainsKey`) and insertions (`Add`) take, on average, O(1) time. Therefore, the overall time complexity is **O(n)**, where 'n' is the number of elements in the `nums` array.

### Space Complexity
In the worst-case scenario, if the desired pair is found near the end of the array, or if no complements are found until the last iteration, we might end up storing nearly all 'n' elements and their indices in the `numMap`. This means the space utilized by the hash map can grow proportionally with the input size. Hence, the space complexity is **O(n)**.
