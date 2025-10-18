public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;

        // Ensure nums1 is the shorter array to optimize binary search range
        if (m > n) {
            int[] temp = nums1;
            nums1 = nums2;
            nums2 = temp;
            int tmp = m;
            m = n;
            n = tmp;
        }

        int low = 0;
        int high = m;
        // halfLen represents the total number of elements in the left partition of the combined array.
        // The '+1' ensures that for odd total lengths, the median element is included in the left partition.
        int halfLen = (m + n + 1) / 2;

        while (low <= high) {
            // i is the partition point for nums1. It means i elements are taken from nums1 for the left partition.
            int i = low + (high - low) / 2;
            // j is the partition point for nums2. It means j elements are taken from nums2 for the left partition.
            // j is derived from halfLen to ensure i + j = halfLen.
            int j = halfLen - i;

            // Define maxLeft and minRight for both arrays, handling edge cases where i or j is 0 or at array end.
            // int.MinValue is used when there are no elements on the left side (i.e., i=0 or j=0).
            // int.MaxValue is used when there are no elements on the right side (i.e., i=m or j=n).
            int maxLeft1 = (i == 0) ? int.MinValue : nums1[i - 1];
            int minRight1 = (i == m) ? int.MaxValue : nums1[i];

            int maxLeft2 = (j == 0) ? int.MinValue : nums2[j - 1];
            int minRight2 = (j == n) ? int.MaxValue : nums2[j];

            // Check if the partition is correct:
            // max element of left partition from nums1 <= min element of right partition from nums2
            // AND max element of left partition from nums2 <= min element of right partition from nums1
            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {
                // Correct partition found
                if ((m + n) % 2 == 1) {
                    // Total length is odd, median is the maximum of the elements in the left partition.
                    return Math.Max(maxLeft1, maxLeft2);
                } else {
                    // Total length is even, median is the average of the two middle elements.
                    // These are the maximum of the left partition and the minimum of the right partition.
                    return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                }
            } else if (maxLeft1 > minRight2) {
                // Partition in nums1 is too far to the right (i is too large).
                // Need to move the partition left in nums1, so reduce 'high'.
                high = i - 1;
            } else { // maxLeft2 > minRight1
                // Partition in nums1 is too far to the left (i is too small).
                // Need to move the partition right in nums1, so increase 'low'.
                low = i + 1;
            }
        }
        
        // This line should logically not be reached if the input constraints are met and the logic is sound,
        // as a valid partition will always be found. It's a safeguard or error indicator.
        return 0.0;
    }
}