using System;

namespace DoublyLinkedList
{
    public class Node<T>
    {
        public T Key { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T key)
        {
            Key = key;
            Next = Prev = null;
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

        public bool IsEmpty()
        {
            return Head == null && Tail == null;
        }

        public void InsertHead(T key)
        {
            Node<T> ToInsert = new Node<T>(key);
            if (IsEmpty())
            {
                Head = Tail = ToInsert;
                return;
            }

            ToInsert.Next = Head;
            Head.Prev = ToInsert;
            Head = ToInsert;
        }

        public void InsertTail(T key)
        {
            Node<T> ToInsert = new Node<T>(key);
            if (IsEmpty())
            {
                InsertHead(key);
                return;
            }

            ToInsert.Prev = Tail;
            Tail.Next = ToInsert;
            Tail = ToInsert;
        }

        public void RemoveHead()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return;
            }

            Head = Head.Next;
            Head.Prev = null;
        }

        public void RemoveTail()
        {
            if (IsEmpty())
            {
                RemoveHead();
                return;
            }

            Tail = Tail.Prev;
            Tail.Next = null;
        }

        public bool Search(T key, ref T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty list");
                return false;
            }

            Node<T> Current = Head;
            while (Current != null && !Current.Key.Equals(key))
                Current = Current.Next;


            if (Current == null)
            {
                Console.WriteLine($"Key {key} not found");
                return false;
            }

            value = Current.Key;
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
            DLList<int> list = new DLList<int>();

            list.InsertHead(3);
            list.InsertHead(2);
            list.InsertHead(1);
            list.InsertHead(0);

            list.InsertTail(4);
            list.InsertTail(5);
            list.InsertTail(6);

            list.Print();

            Console.WriteLine("\n--> RemoveHead: ");
            list.RemoveHead();
            list.Print();

            Console.WriteLine("\n--> RemoveTail: ");
            list.RemoveTail();
            list.Print();

            Console.WriteLine("\n--> Search 5: ");
            int value = 0;
            if (list.Search(5, ref value))
                Console.WriteLine($"Value: {value}");

        }
    }
}
