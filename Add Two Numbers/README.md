### Link: https://leetcode.com/problems/add-two-numbers/
### Difficulty: Medium
### Question: Add Two Numbers

### Algorithm Explanation:

This problem asks us to add two non-negative integers represented by linked lists, where digits are stored in reverse order. Each node in the linked list contains a single digit. We need to return the sum as a new linked list, also with digits in reverse order.

The core idea is to simulate the process of manual addition that we perform with pen and paper, starting from the least significant digit (which are the heads of our linked lists).

1.  **Initialization:**
    *   Create a `dummyHead` node for the resulting linked list. This simplifies handling the first node of the result.
    *   Initialize a `current` pointer to `dummyHead`. This pointer will be used to build the new linked list by appending new nodes.
    *   Initialize a `carry` variable to `0`. This will store any carry-over from the sum of digits.

2.  **Iteration:**
    *   We iterate using a `while` loop. The loop continues as long as there are still digits in either `l1` or `l2`, or if there's a remaining `carry` from previous additions.
    *   Inside the loop, for each step:
        *   Retrieve the value of the current node from `l1`. If `l1` has become `null` (meaning we've processed all its digits), consider its value as `0`. Then, advance `l1` to `l1.next` if it's not `null`.
        *   Do the same for `l2`.
        *   Calculate the `sum` of `val1` (from `l1`), `val2` (from `l2`), and the current `carry`.
        *   Update the `carry` for the next iteration: `carry = sum / 10`. (e.g., if `sum` is 17, `carry` becomes 1).
        *   Determine the `digit` for the current position in the result list: `digit = sum % 10`. (e.g., if `sum` is 17, `digit` becomes 7).
        *   Create a new `ListNode` with this `digit` and append it to the `current` node's `next`.
        *   Move the `current` pointer to the newly created node, preparing for the next digit.

3.  **Final Result:**
    *   Once the loop finishes, all digits have been processed, and any final `carry` has been added.
    *   Return `dummyHead.next`. This skips the initial dummy node and gives us the actual head of the sum linked list.

**Example:**
l1 = [2,4,3] (represents 342)
l2 = [5,6,4] (represents 465)

*   **Step 1:** (2+5+0) = 7. `carry` = 0. Result: [7]
*   **Step 2:** (4+6+0) = 10. `carry` = 1. Result: [7,0]
*   **Step 3:** (3+4+1) = 8. `carry` = 0. Result: [7,0,8]
*   Loop ends as l1, l2 are null and carry is 0.
*   Final Result: [7,0,8] (represents 807), which is 342 + 465.

---

### Complexity Analysis:

*   **Time Complexity:** O(max(N, M))
    *   Where N is the number of nodes in `l1` and M is the number of nodes in `l2`.
    *   We traverse both linked lists at most once. The loop runs for a number of iterations proportional to the length of the longer list, plus potentially one more iteration if there's a final carry. Each operation inside the loop (addition, modulo, division, node creation) takes constant time. Therefore, the overall time complexity is linear with respect to the maximum length of the input linked lists.

*   **Space Complexity:** O(max(N, M))
    *   A new linked list is created to store the sum. In the worst-case scenario (e.g., adding 999 to 99, resulting in 1098), the resulting linked list can have `max(N, M) + 1` nodes. The space required for this new list is proportional to its length. Hence, the space complexity is also linear with respect to the maximum length of the input linked lists.