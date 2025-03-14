# Linked List Operations Console Application

## Overview
This console application allows users to perform various operations on a linked list. The operations include insertion, deletion, sorting, splitting, and merging of linked lists. The application provides a menu-driven interface for users to interact with the linked list.

## Features

### 1. Insertion Operations:
- Insert a node at the beginning of the list.
- Insert a node at the end of the list.
- Insert a node at the correct position in a sorted list.

### 2. Deletion Operations:
- Delete the first node of the list.
- Delete the last node of the list.
- Delete a node at a specified index in the list.

### 3. Splitting Operation:
- Split the list into two sublists: one for the front half and one for the back half. If the number of elements is odd, the extra element goes in the front list.

### 4. Sorting Operation:
- Sort the linked list.

### 5. Merging Operation:
- Merge two sorted linked lists into one sorted list.

### 6. Utility Operation:
- Print the elements of the list.

## Requirements
- .NET 9
- C# 13.0

## How to Use

### 1. Clone the Repository:
```bash
git clone <repository-url>
cd <repository-directory>
```

### 2. Build the Project:
```bash
dotnet build
```

### 3. Run the Application:
```bash
dotnet run
```

### 4. Follow the Menu:
- The application will display a menu with various options for linked list operations.
- Enter the number corresponding to the operation you want to perform.
- Follow the prompts to enter the required data.

## Menu Options
1. Insert at Beginning: Prompts for a value and inserts it at the beginning of the list.
2. Insert at End: Prompts for a value and inserts it at the end of the list.
3. Insert into Sorted List: Prompts for a value and inserts it into the correct position in a sorted list.
4. Delete First Node: Deletes the first node of the list.
5. Delete Last Node: Deletes the last node of the list.
6. Delete at Index: Prompts for an index and deletes the node at that index.
7. Print List: Prints the current elements of the list.
8. Sort List: Sorts the linked list.
9. Front-Back Split: Splits the list into two sublists and prints both sublists.
10. Merge Two Sorted Lists: Prompts for values for two sorted lists, merges them, and prints the merged list.
11. Exit: Exits the application.

## Code Explanation

### Node Class
- Represents a node in the linked list.
- Contains data and a reference to the next node.

### LinkedList Class

#### Insertion Methods
- `InsertAtBeginning`: Inserts a new node at the beginning of the list.
- `InsertAtEnd`: Inserts a new node at the end of the list.
- `InsertIntoSorted`: Inserts a new node into the correct position in a sorted list.

#### Deletion Methods
- `DeleteFirst`: Deletes the first node of the list.
- `DeleteLast`: Deletes the last node of the list.
- `DeleteAtIndex`: Deletes the node at the specified index in the list.

#### Splitting Method
- `FrontBackSplit`: Splits the list into two sublists: one for the front half and one for the back half. If the number of elements is odd, the extra element goes in the front list.

#### Sorting Method
- `Sort`: Sorts the linked list by collecting all elements into a list, sorting them, and reconstructing the linked list in sorted order.

#### Merging Method
- `Merge`: Merges two sorted linked lists into one sorted list by traversing both lists and inserting the smaller element from either list into the merged list.

#### Utility Method
- `PrintList`: Prints the elements of the list.

### Program Class
- The `Main` method provides a console menu for interacting with the linked list, allowing the user to perform various operations such as inserting values, deleting nodes, printing the list, sorting the list, splitting the list, and merging two sorted lists.

## Conclusion
This console application provides a comprehensive set of operations for managing a linked list. The menu-driven interface makes it easy for users to interact with the list and perform various operations. The detailed comments and explanations in the code help understand the implementation and functionality of each method.

