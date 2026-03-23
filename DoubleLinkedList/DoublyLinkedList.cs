using System;
using System.Collections.Generic;

public class DoublyLinkedList<T> where T : IEquatable<T>
{
    private DoublyLinkedListNode<T>? head;
    private DoublyLinkedListNode<T>? tail;
    private int size;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public void InsertHead(T data)
    {
        var newNode = new DoublyLinkedListNode<T>(data);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }

        size++;
    }

    public void InsertTail(T data)
    {
        var newNode = new DoublyLinkedListNode<T>(data);

        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }

        size++;
    }

    public bool RemoveByIndex(int index)
    {
        if (index < 0 || index >= size)
            return false;

        DoublyLinkedListNode<T>? nodeToRemove;

        if (index < size / 2)
        {
            nodeToRemove = head;
            for (int i = 0; i < index; i++)
                nodeToRemove = nodeToRemove?.Next;
        }
        else
        {
            nodeToRemove = tail;
            for (int i = size - 1; i > index; i--)
                nodeToRemove = nodeToRemove?.Prev;
        }

        if (nodeToRemove == null)
            return false;

        RemoveNode(nodeToRemove);
        return true;
    }

    public bool RemoveByValue(T value)
    {
        var current = head;

        while (current != null)
        {
            if (current.Data.Equals(value))
            {
                var next = current.Next;
                RemoveNode(current);
                current = next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public void RemoveAllDuplicates()
    {
        if (head == null)
            return;

        var seen = new HashSet<T>();
        var current = head;

        while (current != null)
        {
            if (seen.Contains(current.Data))
            {
                var next = current.Next;
                RemoveNode(current);
                current = next;
            }
            else
            {
                seen.Add(current.Data);
                current = current.Next;
            }
        }
    }

    public int? Search(T value)
    {
        var current = head;
        int index = 0;

        while (current != null)
        {
            if (current.Data.Equals(value))
                return index;

            current = current.Next;
            index++;
        }

        return null;
    }

    public int Size => size;

    private void RemoveNode(DoublyLinkedListNode<T> node)
    {
        if (node.Prev != null)
            node.Prev.Next = node.Next;
        else
            head = node.Next;

        if (node.Next != null)
            node.Next.Prev = node.Prev;
        else
            tail = node.Prev;

        size--;
    }

    public void Display()
    {
        var current = head;
        Console.Write("List: ");

        while (current != null)
        {
            Console.Write(current.Data + " <-> ");
            current = current.Next;
        }

        Console.WriteLine("null");
    }
}