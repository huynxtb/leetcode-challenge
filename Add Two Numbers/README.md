# Add Two Numbers
*   **Link:** https://leetcode.com/problems/add-two-numbers/
*   **Difficulty:** Medium
*   **Question:** Add Two Numbers

## Algorithm Explanation
The problem asks us to add two non-negative integers represented by linked lists, where digits are stored in reverse order. We need to return the sum as a new linked list in the same reverse-digit format.

The approach involves simulating the manual process of adding two numbers, digit by digit, from right to left (which corresponds to iterating through the linked lists from head to tail due to the reverse order storage).

1.  **Initialization:** We create a `dummyHead` node for the resulting linked list. This simplifies handling the first node of the result. A `current` pointer is initialized to `dummyHead` to track the last node added to the result. A `carry` variable is initialized to 0, which will store any carry-over to the next digit's sum.

2.  **Iteration:** We iterate as long as there are still digits in `l1`, or `l2`, or if there's a `carry` from the previous sum. This ensures all digits are processed and any final carry is also added.
    *   In each iteration, we retrieve the `val` of the current node from `l1` and `l2`. If a list is exhausted (i.e., `l1` or `l2` is `null`), we treat its current digit as 0.
    *   We calculate the `sum` of these two digit values plus the `carry` from the previous step.
    *   The new `carry` for the next step is determined by `sum / 10`.
    *   The digit to be added to the result list is `sum % 10`.
    *   A new `ListNode` with this `digit` is created and appended to `current.next`.
    *   The `current` pointer is then moved to this newly created node to prepare for the next digit.
    *   Finally, we advance `l1` and `l2` to their respective next nodes if they are not `null`.

3.  **Return Result:** Once the loop finishes, `dummyHead.next` points to the actual head of the sum linked list, which we return. The `dummyHead` itself is discarded.

### Time Complexity
The algorithm traverses each linked list at most once. If `m` is the number of nodes in `l1` and `n` is the number of nodes in `l2`, the loop will run approximately $O(\max(m, n))$ times. In each iteration, a constant number of operations are performed (arithmetic operations, node creation, pointer assignments). Therefore, the time complexity is $O(\max(m, n))$.

### Space Complexity
A new linked list is constructed to store the sum. In the worst-case scenario, the length of the sum list can be $O(\max(m, n) + 1)$ (e.g., adding 99 to 9 gives 108, requiring one extra digit). Thus, the space complexity is proportional to the length of the longer input list, plus potentially one extra node. This is $O(\max(m, n))$.