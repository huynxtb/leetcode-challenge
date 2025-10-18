# Median of Two Sorted Arrays
*   **Link:** https://leetcode.com/problems/median-of-two-sorted-arrays/
*   **Difficulty:** Hard
*   **Question:** Median of Two Sorted Arrays

## Algorithm Explanation
The problem asks us to find the median of two sorted arrays, `nums1` and `nums2`, with an overall time complexity of `O(log (m+n))`. This time complexity strongly suggests a binary search approach.

The core idea is to partition both arrays into two parts (left and right) such that:
1.  The total number of elements in the left parts equals `(m + n + 1) / 2` (for the median calculation, `halfLen`).
2.  All elements in the left partitions are less than or equal to all elements in the right partitions. Specifically, `max(left_part_from_nums1, left_part_from_nums2) <= min(right_part_from_nums1, right_part_from_nums2)`.

To achieve this, we perform a binary search on the shorter of the two arrays (let's say `nums1` after potentially swapping to ensure `m <= n`). We try to find a partition point `i` in `nums1` (meaning `i` elements are taken from `nums1` for the left partition). The corresponding partition point `j` in `nums2` will then be `halfLen - i`, where `halfLen = (m + n + 1) / 2`. The `+1` in `halfLen` handles both odd and even total lengths by making `halfLen` consistently represent the size of the left half of the conceptual merged array.

We define four elements crucial for checking the partition:
*   `maxLeft1`: The element `nums1[i-1]` if `i > 0`, otherwise `int.MinValue` (a sentinel value).
*   `minRight1`: The element `nums1[i]` if `i < m`, otherwise `int.MaxValue` (a sentinel value).
*   `maxLeft2`: The element `nums2[j-1]` if `j > 0`, otherwise `int.MinValue`.
*   `minRight2`: The element `nums2[j]` if `j < n`, otherwise `int.MaxValue`.

The binary search proceeds as follows:
1.  Initialize `low = 0` and `high = m` (where `m` is the length of `nums1`, the shorter array).
2.  In each iteration, calculate `i = low + (high - low) / 2` to find a midpoint for the partition in `nums1`.
3.  Calculate `j = halfLen - i` to determine the corresponding partition in `nums2`.
4.  Check the partition condition:
    *   If `maxLeft1 <= minRight2` and `maxLeft2 <= minRight1`: We have found the correct partition.
        *   If `(m + n)` is odd, the median is `Math.Max(maxLeft1, maxLeft2)`.
        *   If `(m + n)` is even, the median is `(Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0`.
    *   If `maxLeft1 > minRight2`: This means we have taken too many elements from `nums1` for the left partition (or `i` is too large). We need to move the partition left in `nums1` by setting `high = i - 1`.
    *   If `maxLeft2 > minRight1`: This means we have taken too few elements from `nums1` for the left partition (or `i` is too small). We need to move the partition right in `nums1` by setting `low = i + 1`.

This binary search approach efficiently narrows down the search space until the correct partition is found, from which the median can be directly calculated.

### Time Complexity
Let `m` be the length of the shorter array and `n` be the length of the longer array. The algorithm performs a binary search on the shorter array (`nums1` after potential swap). The binary search takes `O(log m)` iterations. Each iteration involves constant time operations (array accesses and comparisons). Therefore, the overall time complexity is `O(log m)`. Since `m` is `min(length of nums1, length of nums2)`, this can be expressed as `O(log(min(m, n)))`. This satisfies the required `O(log (m+n))` complexity because `log(min(m, n))` is always less than or equal to `log(m+n)`.

### Space Complexity
The algorithm uses a constant number of variables to store array lengths, indices, and temporary values. No auxiliary data structures are created that scale with the input size. Hence, the space complexity is `O(1)`.