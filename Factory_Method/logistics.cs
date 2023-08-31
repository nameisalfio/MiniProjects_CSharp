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

        protected string typeLogistic;

        public Vehicle(string _model, string _typeLogistic)
        {
            model = _model;
            typeLogistic = _typeLogistic;
        }

        public void Drive()
        {
            Console.WriteLine($"Driving the {model} on the {typeLogistic}");
        }

        public void Deliver(string destination)
        {
            Console.WriteLine($"Delivering the {model} to {destination}");
        }

        public abstract string GetInfo();
    }

    // Concrete products
    class RoadVehicle : Vehicle
    {
        private uint averageSpeed;

        public RoadVehicle(string _model, uint _averageSpeed) : base(_model, "road")
        {
            averageSpeed = _averageSpeed;
        }

        public override string GetInfo() => $"Road Vehicle: {model}, Average Speed: {averageSpeed} km/h";

        public string CalculateDeliveryTime(uint distanceInKilometers)
        {
            double time = (double)distanceInKilometers / averageSpeed;
            return $"Estimated delivery time for {distanceInKilometers} km: {time} hours";
        }
    }

    class SeaVehicle : Vehicle
    {
        private uint cargoCapacity;

        public SeaVehicle(string _model, uint _cargoCapacity) : base(_model, "sea")
        {
            cargoCapacity = _cargoCapacity;
        }

        public override string GetInfo() => $"Sea Vehicle: {model}, Cargo Capacity: {cargoCapacity} tons";

        public string CalculateOptimalRoute(string start, string end)
        {
            return $"Optimal route from {start} to {end}: Route details...";
        }
    }

    // Creator interface
    interface IVehicleFactory
    {
        IVehicle CreateVehicle();

        IVehicle CreateSpecialVehicle();
    }

    // Concrete creators 
    class RoadFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new RoadVehicle("Truck", 60);
        }

        public IVehicle CreateSpecialVehicle()
        {
            return new RoadVehicle("Sports car", 150);
        }
    }

    class SeaFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new SeaVehicle("Ship", 5000);
        }

        public IVehicle CreateSpecialVehicle()
        {
            return new SeaVehicle("Yatch", 1800);
        }
    }

    // Client 
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory factory = new RoadFactory();

            IVehicle vehicle = factory.CreateVehicle();

            vehicle.Deliver("Augusta city");
            vehicle.Drive();
            Console.WriteLine($"Info -> {vehicle.GetInfo()}");
            Console.WriteLine(vehicle.CalculateDeliveryTime(5000)); // non è possibile invocare metodi della sottoclasse di IVehicle 
        }
    }
}