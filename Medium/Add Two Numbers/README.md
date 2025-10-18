# Add Two Numbers
*   **Link:** https://leetcode.com/problems/add-two-numbers/
*   **Difficulty:** Medium
*   **Question:** Add Two Numbers

## Algorithm Explanation
The problem asks us to add two numbers represented by linked lists, where digits are stored in reverse order. This means the head of the list contains the least significant digit, making addition straightforward, similar to how we perform manual addition from right to left (least significant digit to most significant digit).

The algorithm proceeds as follows:
1.  **Initialize a Dummy Head:** Create a `dummyHead` node for the resulting linked list. This simplifies handling the first node and avoids null checks. A `current` pointer will traverse this new list, starting from `dummyHead`.
2.  **Initialize Carry:** A `carry` variable is initialized to 0. This variable will store any carry-over value from summing two digits that result in 10 or more.
3.  **Iterate Through Lists:** Use a `while` loop that continues as long as either `l1` or `l2` has remaining nodes, or if there's a `carry` value. This ensures that all digits and any final carry are processed.
4.  **Extract Digits:** Inside the loop, get the digit value from the current node of `l1` (if `l1` is not null) and `l2` (if `l2` is not null). If a list has been exhausted (i.e., `l1` or `l2` is null), treat its value as 0 for that position.
5.  **Calculate Sum and Carry:**
    *   Calculate `sum = val1 + val2 + carry`.
    *   The digit for the current position in the result list is `sum % 10`.
    *   The new `carry` for the next iteration is `sum / 10`.
6.  **Create New Node:** Create a new `ListNode` with the calculated `digit` and append it to the `current` pointer's `next`.
7.  **Advance Pointers:** Move the `current` pointer to the newly created node. Also, advance `l1` and `l2` to their next nodes if they are not null.
8.  **Final Carry:** After the loop finishes, the `while` loop condition `carry != 0` automatically handles any remaining `carry` (e.g., adding 99 + 1 results in 100, so a final carry of 1 needs to be added). If `carry` is 0, the loop terminates.
9.  **Return Result:** The result list starts from `dummyHead.next`.

### Time Complexity
The algorithm iterates through both linked lists at most once. The number of operations is proportional to the length of the longer list.
Let N be the number of nodes in `l1` and M be the number of nodes in `l2`.
Therefore, the time complexity is O(max(N, M)).

### Space Complexity
A new linked list is created to store the sum. In the worst case, the sum linked list can have `max(N, M) + 1` nodes (e.g., adding 99 + 1 results in 3 digits if N and M are 2).
Therefore, the space complexity is O(max(N, M)).