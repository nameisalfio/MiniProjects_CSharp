using System;
using Test.cs;

namespace DoublyLinkedList
{
    public class Node<T>
    {
        public T Key { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node()
        {
            Next = Prev = null;
        }

        public Node(T key) : this()
        {
            Key = key;
        }

        public void Print()
        {
            Console.Write($"[{Key}] -> ");
        }
    }

    public class DLList<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        public bool IsEmpty => Head == null && Tail == null;

        public void InsertHead(T key)
        {
            var newNode = new Node<T>(key);
            if (IsEmpty)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
                Head = newNode;
            }
        }

        public void InsertTail(T key)
        {
            var newNode = new Node<T>(key);
            if (IsEmpty)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public void RemoveHead()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Empty list");
                return;
            }

            Head = Head.Next;
            if (Head != null)
            {
                Head.Prev = null;
            }
            else
            {
                Tail = null;
            }
        }

        public void RemoveTail()
        {
            if (IsEmpty)
            {
                RemoveHead();
                return;
            }

            Tail = Tail.Prev;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
        }

        public bool Search(T key, out T value)
        {
            value = default(T);
            if (IsEmpty)
            {
                Console.WriteLine("Empty list");
                return false;
            }

            Node<T> current = Head;
            while (current != null && !current.Key.Equals(key))
            {
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine($"Key {key} not found");
                return false;
            }

            value = current.Key;
            return true;
        }

        public void Print()
        {
            Node<T> current = Head;
            Console.Write("HEAD -> ");
            while (current != null)
            {
                current.Print();
                current = current.Next;
            }
            Console.WriteLine("NIL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
