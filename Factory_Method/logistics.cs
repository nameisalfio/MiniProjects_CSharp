using System;

namespace Factory_Metod
{
    // Product interface
    interface IVehicle
    {
        void Drive();
        void Deliver(string destination);
        string GetInfo();
    }

    abstract class Vehicle : IVehicle
    {
        protected string model;
        protected uint horsepower;

        public Vehicle(string _model, uint _horsepower)
        {
            model = _model;
            horsepower = _horsepower;
        }

        public string GetInfo()
        {
            return $"{model}, {horsepower}HP";
        }
    }

    // Concrete products
    class Car : Vehicle
    {
        public Car(string _model, uint _horsepower) : base(_model, _horsepower) { }

        public void Drive()
        {
            Console.WriteLine($"Driving the Car {model}");
        }

        public void Deliver(string destination)
        {
            Console.WriteLine($"Delivering the Car {model} to {destination}");
        }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(string _model, uint _horsepower) : base(_model, _horsepower) { }

        public void Drive()
        {
            Console.WriteLine($"Driving the Motorcycle {model}");
        }

        public void Deliver(string destination)
        {
            Console.WriteLine($"Delivering the Motorcycle {model} to {destination}");
        }
    }

    // Creator interface
    interface IVehicleFactory
    {
        IVehicle CreateVehicle();
    }

    // Concrete creators
    class CarFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Car("Sedan", 200);
        }
    }

    class MotorcycleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Motorcycle("Harley-Davidson Cruiser", 100);
        }
    }

    // Client 
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory carFactory = new CarFactory();
            IVehicle car = carFactory.CreateVehicle();

            IVehicleFactory motorcycleFactory = new MotorcycleFactory();
            IVehicle motorcycle = motorcycleFactory.CreateVehicle();

            Console.WriteLine("Car:");
            Console.WriteLine(car.GetInfo());
            car.Drive();
            car.Deliver("Customer A");

            Console.WriteLine("\nMotorcycle:");
            Console.WriteLine(motorcycle.GetInfo());
            motorcycle.Drive();
            motorcycle.Deliver("Customer B");
        }
    }
}