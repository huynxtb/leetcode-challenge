# Two Sum
*   **Link:** https://leetcode.com/problems/two-sum/
*   **Difficulty:** Easy
*   **Question:** Two Sum

## Algorithm Explanation
The problem asks us to find two numbers in an array `nums` that add up to a specific `target` and return their indices. We are guaranteed that there is exactly one solution and we cannot use the same element twice.

A brute-force approach would involve checking every possible pair of numbers, resulting in an O(n^2) time complexity. To achieve a more efficient solution, specifically O(n) time complexity, we can utilize a hash map (dictionary in C#).

The algorithm proceeds as follows:
1.  Initialize an empty hash map, let's call it `numMap`. This map will store `(number, index)` pairs.
2.  Iterate through the `nums` array from left to right, with an index `i`.
3.  For each number `nums[i]`:
    a.  Calculate the `complement` needed to reach the `target`. This is `complement = target - nums[i]`.
    b.  Check if this `complement` already exists as a key in our `numMap`.
        i.  If `numMap` contains the `complement` as a key, it means we have found the two numbers. The index of the `complement` is `numMap[complement]`, and the index of the current number is `i`. We return these two indices.
        ii. If `numMap` does not contain the `complement`, it means the current `nums[i]` has not yet found its pair. In this case, we add the current number `nums[i]` and its index `i` to the `numMap`. We store `nums[i]` as the key and `i` as its value. This makes `nums[i]` available as a complement for future numbers in the array.
4.  Since the problem guarantees that exactly one solution exists, our loop will always find a pair and return before exhausting the array.

### Time Complexity
The algorithm iterates through the `nums` array once. In each iteration, hash map operations (insertion and lookup) take an average time complexity of O(1). Therefore, the overall time complexity is **O(n)**, where `n` is the number of elements in the `nums` array.

### Space Complexity
In the worst-case scenario, if no pair is found until the last or second to last element, we might store up to `n-1` elements in the hash map. Each entry in the hash map stores an integer key and an integer value. Therefore, the space complexity is **O(n)**, where `n` is the number of elements in the `nums` array.