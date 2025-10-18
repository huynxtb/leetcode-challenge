using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }

        // Using a boolean array for ASCII characters (0-127) for O(1) lookups.
        // The problem states "s consists of English letters, digits, symbols and spaces.",
        // which fall within the ASCII range.
        bool[] charExists = new bool[128]; // Max ASCII value is 127
        int maxLength = 0;
        int left = 0; // Left pointer of the sliding window

        for (int right = 0; right < s.Length; right++) {
            // If the character at `right` is already in the current window,
            // shrink the window from the `left` until the duplicate is removed.
            while (charExists[s[right]]) {
                charExists[s[left]] = false; // Remove character at `left` from window
                left++;                      // Move `left` pointer to shrink window
            }

            // Add the current character at `right` to the window
            charExists[s[right]] = true;
            // Update the maximum length found so far
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
