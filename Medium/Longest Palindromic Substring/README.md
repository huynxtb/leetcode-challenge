# Longest Palindromic Substring
*   **Link:** https://leetcode.com/problems/longest-palindromic-substring/
*   **Difficulty:** Medium
*   **Question:** Longest Palindromic Substring

## Algorithm Explanation
The problem asks us to find the longest palindromic substring within a given string `s`. A palindromic string reads the same forwards and backward.

The chosen algorithm is the "Expand Around Center" approach, which is efficient and intuitive. A palindrome can be centered around a single character (e.g., "aba" where 'b' is the center) or between two identical characters (e.g., "abba" where 'bb' is the center).

The algorithm proceeds as follows:
1.  We iterate through each possible character in the string `s` using an index `i`.
2.  For each `i`, we consider two scenarios for potential palindromes:
    *   **Odd-length palindromes:** We assume `s[i]` is the center of an odd-length palindrome. We call a helper function `ExpandAroundCenter` with `left = i` and `right = i`.
    *   **Even-length palindromes:** We assume `s[i]` and `s[i+1]` form the center of an even-length palindrome (if `s[i]` and `s[i+1]` are the same and `i+1` is a valid index). We call `ExpandAroundCenter` with `left = i` and `right = i + 1`.
3.  The `ExpandAroundCenter(string s, int left, int right)` helper function expands outwards from the given `left` and `right` indices. It decrements `left` and increments `right` as long as `left` is within bounds, `right` is within bounds, and `s[left]` equals `s[right]`.
4.  Once the loop in `ExpandAroundCenter` terminates (meaning `s[left]` and `s[right]` no longer match or boundaries are hit), the `left` and `right` pointers will be one step *outside* the actual palindrome. The length of this palindrome is calculated as `right - left - 1`, and its starting index is `left + 1`.
5.  We maintain two global (or class-level) variables: `maxLength` to store the length of the longest palindrome found so far, and `start` to store its starting index. If a newly found palindrome's length is greater than `maxLength`, we update `maxLength` and `start`.
6.  After iterating through all possible centers, we construct and return the substring from `s` using the `start` index and `maxLength`.

Edge cases such as an empty string or a string of length 1 are handled: an empty string returns an empty string, and a string of length 1 correctly returns itself as the longest palindrome.

### Time Complexity
The time complexity is $O(N^2)$, where $N$ is the length of the input string `s`.
This is because the main loop iterates $N$ times. Inside the loop, the `ExpandAroundCenter` function can, in the worst case (e.g., a string like "aaaaa"), iterate up to $O(N)$ times as it expands outwards. Since `ExpandAroundCenter` is called twice for each character, the total time complexity becomes $N * O(N) = O(N^2)$.

### Space Complexity
The space complexity is $O(1)$.
This is because the algorithm only uses a few constant-size variables (`start`, `maxLength`, loop counters) regardless of the input string's length. No auxiliary data structures that scale with the input size are allocated.