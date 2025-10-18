# Longest Substring Without Repeating Characters
*   **Link:** https://leetcode.com/problems/longest-substring-without-repeating-characters/
*   **Difficulty:** Medium
*   **Question:** Longest Substring Without Repeating Characters

## Algorithm Explanation
This problem asks us to find the length of the longest substring within a given string `s` that does not contain any repeating characters. We can solve this efficiently using the **sliding window** technique.

1.  **Initialize Variables:**
    *   `maxLength`: An integer to store the maximum length of the non-repeating substring found so far, initialized to 0.
    *   `left`: An integer representing the left pointer of our sliding window, initialized to 0.
    *   `charExists`: A boolean array of size 128 (to cover all standard ASCII characters) to keep track of characters currently present in our sliding window. Each index `i` corresponds to the ASCII value of a character, and `charExists[i]` will be `true` if the character is in the window, `false` otherwise. This provides O(1) average time complexity for checking character presence.

2.  **Iterate with `right` Pointer:**
    We use a `right` pointer to expand our window. It iterates from the beginning of the string `s` to its end.

3.  **Handle Duplicates (Shrink Window):**
    For each character `s[right]`:
    *   We check if `s[right]` is already present in our current window (i.e., `charExists[s[right]]` is `true`).
    *   If a duplicate is found, we need to shrink the window from the `left` side. We do this by setting `charExists[s[left]] = false` (removing the character at the `left` pointer from our window's tracking) and incrementing `left`. This process continues in a `while` loop until the duplicate character `s[right]` is no longer in the window.

4.  **Add Current Character (Expand Window):**
    Once `s[right]` is guaranteed to be unique within the current `[left, right]` window, we add it to our tracking by setting `charExists[s[right]] = true`.

5.  **Update `maxLength`:**
    After expanding or shrinking the window, the current substring `s[left...right]` is guaranteed to have no repeating characters. We calculate its length (`right - left + 1`) and update `maxLength` if this length is greater than the current `maxLength`.

6.  **Return `maxLength`:**
    After the `right` pointer has traversed the entire string, `maxLength` will hold the length of the longest substring without repeating characters.

### Time Complexity
The time complexity is $O(N)$, where $N$ is the length of the input string `s`. Both the `left` and `right` pointers traverse the string at most once. Each character is added to and removed from the `charExists` array at most once. Operations on the boolean array (`charExists`) take constant time, $O(1)$. Therefore, the total time spent is proportional to the length of the string.

### Space Complexity
The space complexity is $O(1)$. We use a boolean array of fixed size 128 (representing the ASCII character set) to keep track of characters. Since the size of the character set is constant regardless of the input string's length, the space used does not grow with $N$, making it constant space complexity. In a more general sense (if the character set were not limited to ASCII), it would be $O(min(N, A))$, where $A$ is the size of the alphabet/character set.