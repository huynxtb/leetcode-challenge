/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // Dummy head node to simplify the creation of the result linked list.
        // It helps to avoid special handling for the first node.
        ListNode dummyHead = new ListNode();
        ListNode current = dummyHead; // Pointer to the current node of the result list
        int carry = 0; // Variable to store the carry-over from digit addition

        // Loop continues as long as there are digits in either list or a carry remains
        while (l1 != null || l2 != null || carry != 0) {
            // Get the value of the current digit from l1. If l1 is null, treat its value as 0.
            int val1 = (l1 != null) ? l1.val : 0;
            // Get the value of the current digit from l2. If l2 is null, treat its value as 0.
            int val2 = (l2 != null) ? l2.val : 0;

            // Calculate the sum of the current digits and the carry
            int sum = val1 + val2 + carry;
            
            // Determine the new carry for the next iteration (integer division by 10)
            carry = sum / 10;
            // Determine the digit to be placed in the current result node (remainder when divided by 10)
            int digit = sum % 10;

            // Create a new node with the calculated digit and append it to the result list
            current.next = new ListNode(digit);
            // Move the current pointer to the newly added node
            current = current.next;

            // Advance l1 to its next node if it's not null
            if (l1 != null) {
                l1 = l1.next;
            }
            // Advance l2 to its next node if it's not null
            if (l2 != null) {
                l2 = l2.next;
            }
        }

        // The result linked list starts from dummyHead.next because dummyHead was a placeholder.
        return dummyHead.next;
    }
}