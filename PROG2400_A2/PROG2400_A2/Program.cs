using System;
using System.Collections.Generic;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList
{
    private Node head;
    private Node tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    // a) Insertion at the beginning
    // This method inserts a new node with the given data at the beginning of the list.
    // It updates the head to point to the new node and adjusts the tail if the list was empty.
    public void InsertAtBeginning(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
        if (tail == null)
        {
            tail = newNode;
        }
    }

    // a) Insertion at the end
    // This method inserts a new node with the given data at the end of the list.
    // It updates the tail to point to the new node and adjusts the head if the list was empty.
    public void InsertAtEnd(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    // a) Insertion at the given location in the sorted list
    // This method inserts a new node with the given data into the correct position in a sorted list.
    // It traverses the list to find the appropriate location and inserts the new node there.
    public void InsertIntoSorted(int data)
    {
        Node newNode = new Node(data);
        if (head == null || head.Data >= data)
        {
            InsertAtBeginning(data);
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data < data)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;

        if (newNode.Next == null)
        {
            tail = newNode;
        }
    }

    // b) Deletion of the first node
    // This method deletes the first node of the list.
    // It updates the head to point to the next node and adjusts the tail if the list becomes empty.
    public void DeleteFirst()
    {
        if (head != null)
        {
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
        }
    }

    // b) Deletion of the last node
    // This method deletes the last node of the list.
    // It traverses the list to find the second-to-last node and updates its next pointer to null.
    public void DeleteLast()
    {
        if (head == null) return;

        if (head.Next == null)
        {
            head = null;
            tail = null;
            return;
        }

        Node current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        current.Next = null;
        tail = current;
    }

    // b) Deletion of the given item index from sorted list
    // This method deletes the node at the specified index in the list.
    // It traverses the list to find the node at the given index and updates the pointers to remove it.
    public void DeleteAtIndex(int index)
    {
        if (head == null || index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            DeleteFirst();
            return;
        }

        Node current = head;
        for (int i = 0; current != null && i < index - 1; i++)
        {
            current = current.Next;
        }

        if (current == null || current.Next == null)
            throw new ArgumentOutOfRangeException(nameof(index));

        current.Next = current.Next.Next;

        if (current.Next == null)
        {
            tail = current;
        }
    }

    // c) Front-Back Split
    // This method splits the list into two sublists: one for the front half and one for the back half.
    // If the number of elements is odd, the extra element goes in the front list.
    // It uses the slow and fast pointer technique to find the middle of the list.
    public (LinkedList front, LinkedList back) FrontBackSplit()
    {
        LinkedList front = new LinkedList();
        LinkedList back = new LinkedList();

        if (head == null)
            return (front, back);

        Node slow = head;
        Node fast = head.Next;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        Node current = head;
        while (current != slow.Next)
        {
            front.InsertAtEnd(current.Data);
            current = current.Next;
        }

        while (current != null)
        {
            back.InsertAtEnd(current.Data);
            current = current.Next;
        }

        return (front, back);
    }

    // d) Sort the linked list
    // This method sorts the linked list.
    // It collects all the elements into a list, sorts them, and then reconstructs the linked list in sorted order.
    public void Sort()
    {
        List<int> elements = new List<int>();
        Node current = head;
        while (current != null)
        {
            elements.Add(current.Data);
            current = current.Next;
        }
        elements.Sort();

        head = null;
        tail = null;
        foreach (int num in elements)
        {
            InsertAtEnd(num);
        }
    }

    // d) Merge two sorted linked lists
    // This method merges two sorted linked lists into one sorted list.
    // It traverses both lists and inserts the smaller element from either list into the merged list.
    public static LinkedList Merge(LinkedList a, LinkedList b)
    {
        LinkedList mergedList = new LinkedList();
        Node currentA = a.head;
        Node currentB = b.head;

        while (currentA != null && currentB != null)
        {
            if (currentA.Data <= currentB.Data)
            {
                mergedList.InsertAtEnd(currentA.Data);
                currentA = currentA.Next;
            }
            else
            {
                mergedList.InsertAtEnd(currentB.Data);
                currentB = currentB.Next;
            }
        }

        while (currentA != null)
        {
            mergedList.InsertAtEnd(currentA.Data);
            currentA = currentA.Next;
        }

        while (currentB != null)
        {
            mergedList.InsertAtEnd(currentB.Data);
            currentB = currentB.Next;
        }

        return mergedList;
    }

    // Utility method to print the list
    // This method prints the elements of the list.
    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        LinkedList list = new LinkedList();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Linked List Operations Menu:");
            Console.WriteLine("1. Insert at Beginning");
            Console.WriteLine("2. Insert at End");
            Console.WriteLine("3. Insert into Sorted List");
            Console.WriteLine("4. Delete First Node");
            Console.WriteLine("5. Delete Last Node");
            Console.WriteLine("6. Delete at Index");
            Console.WriteLine("7. Print List");
            Console.WriteLine("8. Sort List");
            Console.WriteLine("9. Front-Back Split");
            Console.WriteLine("10. Merge Two Sorted Lists");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter value to insert at beginning: ");
                    int value1 = int.Parse(Console.ReadLine());
                    list.InsertAtBeginning(value1);
                    break;
                case "2":
                    Console.Write("Enter value to insert at end: ");
                    int value2 = int.Parse(Console.ReadLine());
                    list.InsertAtEnd(value2);
                    break;
                case "3":
                    Console.Write("Enter value to insert into sorted list: ");
                    int value3 = int.Parse(Console.ReadLine());
                    list.InsertIntoSorted(value3);
                    break;
                case "4":
                    list.DeleteFirst();
                    Console.WriteLine("First node deleted.");
                    break;
                case "5":
                    list.DeleteLast();
                    Console.WriteLine("Last node deleted.");
                    break;
                case "6":
                    Console.Write("Enter index to delete: ");
                    int index = int.Parse(Console.ReadLine());
                    try
                    {
                        list.DeleteAtIndex(index);
                        Console.WriteLine($"Node at index {index} deleted.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;
                case "7":
                    Console.WriteLine("Current List:");
                    list.PrintList();
                    break;
                case "8":
                    list.Sort();
                    Console.WriteLine("List sorted.");
                    break;
                case "9":
                    var splitLists = list.FrontBackSplit();
                    Console.WriteLine("Front list after split:");
                    splitLists.front.PrintList();
                    Console.WriteLine("Back list after split:");
                    splitLists.back.PrintList();
                    break;
                case "10":
                    LinkedList listA = new LinkedList();
                    LinkedList listB = new LinkedList();
                    Console.WriteLine("Enter values for first sorted list (comma separated): ");
                    string[] valuesA = Console.ReadLine().Split(',');
                    foreach (var val in valuesA)
                    {
                        listA.InsertIntoSorted(int.Parse(val.Trim()));
                    }
                    Console.WriteLine("Enter values for second sorted list (comma separated): ");
                    string[] valuesB = Console.ReadLine().Split(',');
                    foreach (var val in valuesB)
                    {
                        listB.InsertIntoSorted(int.Parse(val.Trim()));
                    }
                    LinkedList mergedList = LinkedList.Merge(listA, listB);
                    Console.WriteLine("Merged list:");
                    mergedList.PrintList();
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}

