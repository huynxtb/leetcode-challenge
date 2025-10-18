using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }

        HashSet<char> charSet = new HashSet<char>();
        int maxLength = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++) {
            // If the character is already in the set, it means we have a duplicate.
            // Shrink the window from the left until the duplicate is removed.
            while (charSet.Contains(s[right])) {
                charSet.Remove(s[left]);
                left++;
            }
            // Add the current character to the set and expand the window.
            charSet.Add(s[right]);
            // Update the maximum length found so far.
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
