using System;
using System.IO;
using System.Collections.Generic;

namespace FileIO
{
    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }
    class Program
    {
        static List<Person> ReadFile(string filePath)
        {
            List<Person> list = new List<Person>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Person item = ParseLine(line);
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }

            return list;
        }

        static void HandleError(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        static Person ParseLine(string line)
        {
            string[] parts = line.Split(' ');
            string name = parts[0];
            int age = int.Parse(parts[1]);
            return new Person(name, age);
        }

        static void Main(string[] args)
        {
            string filePath = "input.txt";
            List<Person> list = ReadFile(filePath);

            foreach (Person item in list)
                item.Print();
        }
        
    }

}
