using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }

        int maxLength = 0;
        int left = 0;
        
        // Dictionary to store the last seen index of each character.
        // Key: character, Value: index
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

        // Iterate through the string with the 'right' pointer
        for (int right = 0; right < s.Length; right++) {
            char currentChar = s[right];

            // If the current character is already in the map and its previous occurrence
            // is within the current sliding window (i.e., its index is >= left),
            // then we have found a duplicate.
            if (charIndexMap.ContainsKey(currentChar)) {
                // To remove the duplicate, move the 'left' pointer to the position
                // immediately after the previous occurrence of 'currentChar'.
                // Use Math.Max to ensure 'left' only moves forward, preventing it
                // from going back if a previous duplicate already pushed it further right.
                left = Math.Max(left, charIndexMap[currentChar] + 1);
            }
            
            // Update the last seen index of the current character to its current position.
            charIndexMap[currentChar] = right;
            
            // Calculate the length of the current substring without repeating characters
            // (right - left + 1) and update the maximum length found so far.
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}