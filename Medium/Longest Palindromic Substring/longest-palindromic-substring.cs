public class Solution {
    private int start = 0;
    private int maxLength = 0;

    public string LongestPalindrome(string s) {
        if (s == null || s.Length < 1) {
            return "";
        }

        for (int i = 0; i < s.Length; i++) {
            ExpandAroundCenter(s, i, i);
            ExpandAroundCenter(s, i, i + 1);
        }

        return s.Substring(start, maxLength);
    }

    private void ExpandAroundCenter(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        if (maxLength < right - left - 1) {
            maxLength = right - left - 1;
            start = left + 1;
        }
    }
}