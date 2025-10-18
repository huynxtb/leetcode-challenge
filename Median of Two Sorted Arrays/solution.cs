
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // Ensure nums1 is the shorter array to optimize binary search range.
        // We will perform binary search on the partition point of the shorter array.
        if (nums1.Length > nums2.Length) {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
        }

        int m = nums1.Length;
        int n = nums2.Length;

        int totalLength = m + n;
        // `halfLength` represents the total number of elements we want in the left partition
        // of the combined sorted array. For odd `totalLength`, it ensures the median element
        // (which is the largest in the left partition) is captured.
        int halfLength = (totalLength + 1) / 2;

        int low = 0;
        int high = m; // Binary search range for the partition point `i` in nums1

        int i = 0; // Partition point for nums1 (number of elements taken from nums1 for the left half)
        int j = 0; // Partition point for nums2 (number of elements taken from nums2 for the left half)

        while (low <= high) {
            // Calculate `i` (partition point for nums1)
            i = low + (high - low) / 2;
            // Calculate `j` (partition point for nums2) based on `i` and `halfLength`
            j = halfLength - i;

            // Define L1, R1, L2, R2 with edge case handling using sentinel values.
            // L1: last element of left part of nums1. If i=0, no elements from nums1, so use MinValue.
            int L1 = (i == 0) ? int.MinValue : nums1[i - 1];
            // R1: first element of right part of nums1. If i=m, all elements from nums1 are in left, so use MaxValue.
            int R1 = (i == m) ? int.MaxValue : nums1[i];
            // L2: last element of left part of nums2. If j=0, no elements from nums2, so use MinValue.
            int L2 = (j == 0) ? int.MinValue : nums2[j - 1];
            // R2: first element of right part of nums2. If j=n, all elements from nums2 are in left, so use MaxValue.
            int R2 = (j == n) ? int.MaxValue : nums2[j];

            // Check if the partition is correct:
            // The maximum element of the left partition must be less than or equal to
            // the minimum element of the right partition.
            if (L1 <= R2 && L2 <= R1) {
                // Perfect partition found. The loop will terminate, and `i`, `j` will hold the correct partition indices.
                break;
            } else if (L1 > R2) {
                // L1 is too large, meaning we took too many elements from nums1 (or `i` is too large).
                // Move the partition in nums1 to the left.
                high = i - 1;
            } else { // L2 > R1
                // L2 is too large, meaning we need to take more elements from nums1 (or `i` is too small).
                // Move the partition in nums1 to the right.
                low = i + 1;
            }
        }

        // After the loop, `i` and `j` represent the correct partition points.
        // Recalculate L1, L2, R1, R2 with the final `i` and `j` to get the actual elements.
        int finalL1 = (i == 0) ? int.MinValue : nums1[i - 1];
        int finalL2 = (j == 0) ? int.MinValue : nums2[j - 1];
        int finalR1 = (i == m) ? int.MaxValue : nums1[i];
        int finalR2 = (j == n) ? int.MaxValue : nums2[j];

        int maxLeft = Math.Max(finalL1, finalL2);

        // If totalLength is odd, the median is the largest element in the left partition.
        if (totalLength % 2 == 1) {
            return maxLeft;
        } else {
            // If totalLength is even, the median is the average of the largest element in the left partition
            // and the smallest element in the right partition.
            int minRight = Math.Min(finalR1, finalR2);
            return (maxLeft + minRight) / 2.0;
        }
    }
}
