# Longest Substring Without Repeating Characters
*   **Link:** https://leetcode.com/problems/longest-substring-without-repeating-characters/
*   **Difficulty:** Medium
*   **Question:** Longest Substring Without Repeating Characters

## Algorithm Explanation
This problem can be efficiently solved using the sliding window technique. We maintain a window `[left, right)` which represents the current substring being examined for unique characters. We also use a `HashSet<char>` to quickly check for the presence of characters within the current window and to ensure no duplicates exist.

1.  Initialize `maxLength` to 0, which will store the length of the longest substring found so far.
2.  Initialize `left` pointer to 0, marking the beginning of our current sliding window.
3.  Create an empty `HashSet<char>` named `charSet` to keep track of unique characters within the `[left, right)` window.
4.  Iterate with a `right` pointer from `0` to `s.Length - 1`:
    a.  For each character `s[right]`, check if it's already present in the `charSet`.
    b.  If `s[right]` is already in `charSet`, it means we have found a duplicate. To resolve this, we need to shrink our window from the `left` side. We do this by repeatedly removing `s[left]` from `charSet` and incrementing `left` until `s[right]` is no longer a duplicate within the current window (i.e., `charSet` no longer contains `s[right]`).
    c.  Once `s[right]` is unique in the window, add `s[right]` to `charSet`.
    d.  Calculate the current window's length (`right - left + 1`) and update `maxLength` if the current length is greater.
5.  After the `right` pointer has traversed the entire string, `maxLength` will hold the length of the longest substring without repeating characters.

### Time Complexity
The time complexity is $O(N)$, where $N$ is the length of the input string `s`. Both the `left` and `right` pointers traverse the string at most once. `HashSet` operations (add, remove, contains) take an average of $O(1)$ time.

### Space Complexity
The space complexity is $O(1)$. In the worst case, the `HashSet` might store up to the number of unique characters in the alphabet (e.g., 128 for ASCII characters). Since the alphabet size is constant and relatively small, the space required does not grow with the input string length, making it constant space.