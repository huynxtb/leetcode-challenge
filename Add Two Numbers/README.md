# Add Two Numbers

*   **Link:** https://leetcode.com/problems/add-two-numbers/
*   **Difficulty:** Medium
*   **Question:** Add Two Numbers

## Algorithm Explanation

The problem requires us to add two non-negative integers represented by linked lists, where each digit is stored in reverse order in individual nodes. For example, the number 342 would be represented as `2 -> 4 -> 3`. We need to return the sum as a new linked list in the same format.

The algorithm simulates the manual process of adding numbers column by column from right to left, carrying over any tens digit to the next column.

1.  **Initialization:**
    *   Create a `dummyHead` `ListNode`. This node serves as a placeholder to simplify the creation of the result linked list. By starting with a dummy head, we avoid special handling for the first node of the sum list.
    *   Initialize a `current` `ListNode` pointer to `dummyHead`. This pointer will be used to traverse and build the result linked list.
    *   Initialize an integer `carry` to `0`. This variable will store any carry-over value when the sum of digits exceeds 9.

2.  **Iteration:**
    *   Enter a `while` loop that continues as long as there are remaining nodes in `l1`, or `l2`, or if there's a `carry` value that needs to be added. This ensures all digits are processed and any final carry is included.
    *   Inside the loop:
        *   **Retrieve Digit Values:** Get the value of the current digit from `l1`. If `l1` is `null` (meaning one list is shorter than the other), consider its value as `0`. Do the same for `l2`.
        *   **Calculate Sum:** Compute the sum of the two digit values (`val1`, `val2`) and the `carry` from the previous step.
        *   **Update Carry:** The new `carry` for the next iteration is obtained by integer division of the `sum` by `10` (e.g., if `sum` is 17, `carry` becomes 1).
        *   **Current Digit:** The digit to be placed in the current node of the result list is the `sum` modulo `10` (e.g., if `sum` is 17, the digit is 7).
        *   **Append Node:** Create a new `ListNode` with this `digit` and append it as `current.next`.
        *   **Advance Pointers:** Move the `current` pointer to this newly created node. Also, advance `l1` to `l1.next` (if `l1` is not `null`) and `l2` to `l2.next` (if `l2` is not `null`) to prepare for the next iteration.

3.  **Return Result:**
    *   Once the loop terminates, the entire sum has been computed. The actual head of the sum linked list is `dummyHead.next`. Return this node.

### Time Complexity

*   Let $N$ be the number of nodes in `l1` and $M$ be the number of nodes in `l2`.
*   The algorithm iterates through both linked lists once. The `while` loop continues for a number of iterations proportional to the length of the longer list, plus potentially one more iteration if there's a final carry.
*   In each iteration, constant time operations (arithmetic, node creation, pointer assignments) are performed.
*   Therefore, the time complexity is $O(\max(N, M))$.

### Space Complexity

*   A new linked list is constructed to store the sum. The maximum length of this new list can be $\max(N, M) + 1$ (in the case where a final carry results in an extra digit, e.g., 99 + 1 = 100).
*   The space required is directly proportional to the length of the resulting sum list.
*   Thus, the space complexity is $O(\max(N, M))$.