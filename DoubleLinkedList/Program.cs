using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Doubly Linked List Implementation ===\n");

        var list = new DoublyLinkedList<int>();

        // Test: Insert Head
        Console.WriteLine("1. Inserting at head: 10, 20, 30");
        list.InsertHead(10);
        list.InsertHead(20);
        list.InsertHead(30);
        list.Display();
        Console.WriteLine($"Size: {list.Size}\n");

        // Test: Insert Tail
        Console.WriteLine("2. Inserting at tail: 15, 25");
        list.InsertTail(15);
        list.InsertTail(25);
        list.Display();
        Console.WriteLine($"Size: {list.Size}\n");

        // Test: Search
        Console.WriteLine("3. Searching for value 15");
        var index = list.Search(15);
        Console.WriteLine(index.HasValue ? $"Found at index: {index.Value}" : "Not found");
        Console.WriteLine();

        // Test: Remove by Index
        Console.WriteLine("4. Removing element at index 2");
        list.RemoveByIndex(2);
        list.Display();
        Console.WriteLine($"Size: {list.Size}\n");

        // Test: Remove Duplicates
        Console.WriteLine("5. Adding duplicates: 30, 10, 15, 20");
        list.InsertTail(30);
        list.InsertTail(10);
        list.InsertTail(15);
        list.InsertTail(20);
        list.Display();
        Console.WriteLine($"Size: {list.Size}");

        Console.WriteLine("\n6. Removing all duplicates");
        list.RemoveAllDuplicates();
        list.Display();
        Console.WriteLine($"Size: {list.Size}\n");

        // Test: Remove by Value
        Console.WriteLine("7. Removing element with value 25");
        list.RemoveByValue(25);
        list.Display();
        Console.WriteLine($"Size: {list.Size}");
    }
}