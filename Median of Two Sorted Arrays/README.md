# Median of Two Sorted Arrays

*   **Link:** https://leetcode.com/problems/median-of-two-sorted-arrays/
*   **Difficulty:** Hard
*   **Question:** Median of Two Sorted Arrays

## Algorithm Explanation:

The problem asks us to find the median of two sorted arrays, `nums1` and `nums2`, with an overall time complexity of `O(log(m+n))`. This time complexity requirement is a strong hint that a binary search approach is needed.

The core idea is to virtually merge the two sorted arrays and find the "cut" points in both arrays such that the combined left partitions contain `(m + n + 1) / 2` elements, and the elements satisfy the median property: `max(left_elements) <= min(right_elements)`.

1.  **Preprocessing (Swapping Arrays):**
    To simplify the binary search, we first ensure that `nums1` is always the shorter array (i.e., `nums1.Length <= nums2.Length`). If `nums1` is longer, we swap the arrays. This ensures that the binary search range, which will be applied to the shorter array, is minimized.

2.  **Determining Partition Sizes:**
    Let `m` be the length of `nums1` and `n` be the length of `nums2`.
    The `totalLength` of the combined arrays is `m + n`.
    We aim to divide the `totalLength` elements into two halves. The left half should contain `halfLength = (totalLength + 1) / 2` elements. This `halfLength` ensures that if `totalLength` is odd, the left partition will naturally contain the median element. If `totalLength` is even, both left and right partitions will have `totalLength / 2` elements.

3.  **Binary Search for the `nums1` Partition:**
    We perform a binary search on the possible number of elements to take from `nums1` for the left partition. Let this be `i`. The range for `i` is `[0, m]` (inclusive).
    Once `i` is chosen, the number of elements to take from `nums2` for the left partition, `j`, is automatically determined by `j = halfLength - i`.

4.  **Checking the Partition (Median Condition):**
    For a chosen `i` and calculated `j`, we need to verify if this partition is valid. This involves checking four boundary elements:
    *   `L1`: The last element of the left part of `nums1`. If `i` is 0 (no elements taken from `nums1`), we consider `L1 = int.MinValue`. Otherwise, `L1 = nums1[i-1]`.
    *   `R1`: The first element of the right part of `nums1`. If `i` is `m` (all elements from `nums1` are in the left part), we consider `R1 = int.MaxValue`. Otherwise, `R1 = nums1[i]`.
    *   `L2`: The last element of the left part of `nums2`. If `j` is 0, we consider `L2 = int.MinValue`. Otherwise, `L2 = nums2[j-1]`.
    *   `R2`: The first element of the right part of `nums2`. If `j` is `n`, we consider `R2 = int.MaxValue`. Otherwise, `R2 = nums2[j]`.

    A perfect partition is found when two conditions are met:
    *   `L1 <= R2`: The largest element in the left part of `nums1` is less than or equal to the smallest element in the right part of `nums2`.
    *   `L2 <= R1`: The largest element in the left part of `nums2` is less than or equal to the smallest element in the right part of `nums1`.

5.  **Adjusting Binary Search Range:**
    *   If `L1 > R2`: This means we took too many elements from `nums1` for the left partition (or `i` is too large). We need to shift the partition in `nums1` to the left. So, we update `high = i - 1`.
    *   If `L2 > R1`: This means we took too few elements from `nums1` for the left partition (or `i` is too small). We need to shift the partition in `nums1` to the right. So, we update `low = i + 1`.

6.  **Calculating the Median:**
    Once the binary search converges (i.e., `L1 <= R2 && L2 <= R1` is true), the correct `i` and `j` values are found.
    *   Calculate `maxLeft = Math.Max(L1, L2)`. This is the largest element in the combined left partition.
    *   If `totalLength` is odd, `maxLeft` is the median.
    *   If `totalLength` is even, we also need to find `minRight = Math.Min(R1, R2)`. This is the smallest element in the combined right partition. The median is then `(maxLeft + minRight) / 2.0`.

### Complexity Analysis:

*   **Time Complexity: `O(log(min(m, n)))`**
    The binary search is performed on the length of the shorter array (`min(m, n)`). In each step, we do constant time operations. Since `min(m, n)` is always less than or equal to `m + n`, this satisfies the `O(log(m+n))` requirement.

*   **Space Complexity: `O(1)`**
    The algorithm only uses a few constant-size variables for indices and temporary storage during the binary search. It does not create any new data structures whose size depends on the input array lengths beyond a potential temporary swap of array references.
