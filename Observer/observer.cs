using System;
using System.Collections.Generic;

namespace Observer
{
    public struct Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string GetInfo() => $"Name: {Name}\nPrice: {Price}";
    }

    // Observer interface
    public interface ICustomer
    {
        void Update(Product product);
    }

    // Concrete Observer
    public class Customer : ICustomer
    {
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void Update(Product product)
        {
            Console.WriteLine($"Customer {Name} received notification: {product.Name} is now available in the store.");
        }
    }

    // Subject interface
    public interface IStore
    {
        void Attach(ICustomer customer);
        void Detach(ICustomer customer);
        void Notify(string productName);
        void AddProduct(Product product);
    }

    // Concrete Subject
    public class Store : IStore
    {
        private readonly List<ICustomer> customers;
        private readonly Dictionary<Product, string> products;

        public Store()
        {
            customers = new List<ICustomer>();
            products = new Dictionary<Product, string>();
        }

        public void Attach(ICustomer customer)
        {
            customers.Add(customer);
        }

        public void Detach(ICustomer customer)
        {
            customers.Remove(customer);
        }

        public void Notify(string productName)
        {
            foreach (var customer in customers)
            {
                foreach (var product in products.Keys)
                {
                    if (product.Name == productName)
                    {
                        customer.Update(product);
                    }
                }
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product, product.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.AddProduct(new Product("iPhone", 10.99));
            store.AddProduct(new Product("Mac-Book", 20.99));

            Customer bob = new Customer("Bob");
            Customer alice = new Customer("Alice");

            store.Attach(bob);
            store.Attach(alice);

            store.Notify("iPhone");
        }
    }
}
