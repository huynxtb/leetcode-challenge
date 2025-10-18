public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        // Dummy head node for the result linked list
        ListNode dummyHead = new ListNode(0);
        // Pointer to traverse and build the result list
        ListNode current = dummyHead;
        // Variable to store any carry-over from addition
        int carry = 0;

        // Loop continues as long as there are digits in l1 or l2,
        // or if there's a remaining carry from previous additions.
        while (l1 != null || l2 != null || carry != 0) {
            // Get the value of the current node from l1. If l1 is null, consider its value as 0.
            int val1 = (l1 != null) ? l1.val : 0;
            // Get the value of the current node from l2. If l2 is null, consider its value as 0.
            int val2 = (l2 != null) ? l2.val : 0;

            // Calculate the sum of the current digits and the carry
            int sum = val1 + val2 + carry;
            // Update the carry for the next iteration (e.g., if sum is 17, carry becomes 1)
            carry = sum / 10;
            // Get the digit for the current position in the result list (e.g., if sum is 17, digit becomes 7)
            int digit = sum % 10;

            // Create a new node with the calculated digit and append it to the result list
            current.next = new ListNode(digit);
            // Move the current pointer to the newly added node, preparing for the next digit
            current = current.next;

            // Move to the next nodes in l1 and l2 if they exist
            if (l1 != null) {
                l1 = l1.next;
            }
            if (l2 != null) {
                l2 = l2.next;
            }
        }

        // Return the head of the result list, skipping the initial dummy node
        return dummyHead.next;
    }
}