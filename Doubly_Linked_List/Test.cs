using System;
using DoublyLinkedList;

namespace Test_DLList
{
    public class ListOperationsTests
    {
        public static void TestInsertHead()
        {
            // Crea una nuova istanza di DLList<int> e testa l'operazione InsertHead
            DLList<int> list = new DLList<int>();
            list.InsertHead(1);

            // Verifica se l'operazione ha avuto successo e se la lista è nell'aspettato stato
            Console.WriteLine("Test InsertHead:");
            list.Print(); // Stampa la lista
            Console.WriteLine();
        }

        public static void TestInsertTail()
        {
            // Crea una nuova istanza di DLList<int> e testa l'operazione InsertTail
            DLList<int> list = new DLList<int>();
            list.InsertTail(1);

            // Verifica se l'operazione ha avuto successo e se la lista è nell'aspettato stato
            Console.WriteLine("Test InsertTail:");
            list.Print(); // Stampa la lista
            Console.WriteLine();
        }

        // Aggiungi altri metodi di test per le altre operazioni della lista
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Esegui i test delle operazioni sulla lista
            ListOperationsTests.TestInsertHead();
            ListOperationsTests.TestInsertTail();

            // Esegui altri test qui
        }
    }
}
