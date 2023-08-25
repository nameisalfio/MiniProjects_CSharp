using System;

namespace Singleton
{
    class MyClass
    {
        // Lazy<T> permette l'inizializzazione ritardata. Il secondo parametro 'true' implica un comportamento thread safe
        private static readonly Lazy<MyClass> lazyInstance = new Lazy<MyClass>(() => new MyClass(), true);

        private MyClass() { Console.WriteLine("Creation of an object of class MyClass"); }

        public static MyClass Instance => lazyInstance.Value;

        public void DoSomething() { Console.WriteLine("I'm doing something"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass.Instance.DoSomething();
        }
    }
}
