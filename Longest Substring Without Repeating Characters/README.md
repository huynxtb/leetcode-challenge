### Link: https://leetcode.com/problems/longest-substring-without-repeating-characters/
### Difficulty: Medium
### Question: Longest Substring Without Repeating Characters

### Algorithm Explanation:

This problem can be efficiently solved using the **Sliding Window** technique combined with a hash map (dictionary in C#) to keep track of character occurrences and their indices.

1.  **Initialize Variables:**
    *   `maxLength`: An integer to store the maximum length of the substring found so far, initialized to `0`.
    *   `left`: An integer representing the left boundary (start) of the current sliding window, initialized to `0`.
    *   `charIndexMap`: A `Dictionary<char, int>` to store the last seen index of each character. The key is the character, and the value is its index in the string.

2.  **Iterate with Right Pointer:**
    *   Use a `for` loop with a `right` pointer that iterates from `0` to `s.Length - 1`. This `right` pointer defines the right boundary (end) of the current sliding window.

3.  **Handle Duplicates:**
    *   Inside the loop, get the `currentChar = s[right]`.
    *   Check if `currentChar` is already present in `charIndexMap`. If it is, this means we've seen this character before.
    *   If a duplicate is found:
        *   We need to ensure the substring remains unique. The `left` pointer must be moved to the position immediately after the *previous* occurrence of `currentChar`. We use `left = Math.Max(left, charIndexMap[currentChar] + 1);`. The `Math.Max` ensures that `left` only moves forward and is not reset to a position *before* a previously encountered duplicate's resolution. This effectively shrinks the window from the left to exclude the earlier occurrence of the duplicate character.

4.  **Update Character Index:**
    *   Regardless of whether a duplicate was found or not, update the `charIndexMap` with the current character's latest index: `charIndexMap[currentChar] = right`. This keeps the map up-to-date with the most recent position of each character.

5.  **Calculate Current Substring Length and Max Length:**
    *   Calculate the length of the current valid substring: `currentLength = right - left + 1`.
    *   Update `maxLength = Math.Max(maxLength, currentLength)`.

6.  **Return `maxLength`:**
    *   After the loop finishes, `maxLength` will hold the length of the longest substring without repeating characters.

**Time Complexity:**
*   The `right` pointer traverses the string from left to right once, performing `N` iterations where `N` is the length of the string `s`.
*   Inside the loop, dictionary operations (`ContainsKey`, index access, update) take `O(1)` time on average.
*   The `left` pointer also only moves forward, at most `N` times in total over the entire execution.
*   Therefore, the overall time complexity is **O(N)**.

**Space Complexity:**
*   The `charIndexMap` stores at most `M` unique characters, where `M` is the size of the character set (e.g., 128 for ASCII or 256 for extended ASCII characters, as specified by problem constraints like 'English letters, digits, symbols and spaces').
*   Since `M` is a fixed constant, the space complexity is considered **O(1)**. In the theoretical case where the character set is unlimited and all characters in `s` are unique, the space complexity would be `O(N)`. However, for the given constraints, `O(1)` is a more accurate practical assessment.
