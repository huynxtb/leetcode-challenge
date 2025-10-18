# Longest Substring Without Repeating Characters
*   **Link:** https://leetcode.com/problems/longest-substring-without-repeating-characters/
*   **Difficulty:** Medium
*   **Question:** Longest Substring Without Repeating Characters

## Algorithm Explanation
The problem asks us to find the length of the longest substring within a given string `s` that does not contain any repeating characters. We can solve this efficiently using the **sliding window** technique.

The core idea is to maintain a "window" of characters `[left, right]` that represents the current substring being evaluated. We also use a `HashSet<char>` (or a boolean array for fixed character sets like ASCII) to keep track of characters present within the current window.

1.  Initialize `maxLength` to 0, `left` pointer to 0, and an empty `HashSet<char>` called `charSet`.
2.  Iterate with a `right` pointer from `0` to `s.Length - 1`:
    *   For each character `s[right]`:
        *   **Check for duplicates:** If `s[right]` is already present in `charSet`, it means we have a repeating character within our current window `[left, right-1]`. To eliminate the duplicate, we need to shrink the window from the left. We do this by repeatedly removing `s[left]` from `charSet` and incrementing `left` until `s[right]` is no longer a duplicate (i.e., it's removed from the set, or the `left` pointer has moved past the previous occurrence of `s[right]`).
        *   **Add current character:** Once `s[right]` is unique within the current window, add `s[right]` to `charSet`.
        *   **Update maximum length:** Calculate the current window's length (`right - left + 1`) and update `maxLength` if the current length is greater.
3.  After iterating through all characters, `maxLength` will hold the length of the longest substring without repeating characters.

### Time Complexity
The time complexity is $O(N)$, where $N$ is the length of the input string `s`. Both the `left` and `right` pointers traverse the string at most once. Each character is added to and removed from the `HashSet` at most once. `HashSet` operations (add, remove, contains) take average $O(1)$ time.

### Space Complexity
The space complexity is $O(M)$, where $M$ is the size of the character set. In this problem, `s` consists of English letters, digits, symbols, and spaces. This implies a fixed and relatively small character set (e.g., ASCII characters, typically 128 or 256 possible characters). Therefore, the `HashSet` will store at most $M$ distinct characters. This can be considered $O(1)$ for a fixed-size character set, as $M$ is a constant. If the character set were unbounded (e.g., full Unicode), the space complexity could be $O(N)$ in the worst case (all characters in the string are unique).