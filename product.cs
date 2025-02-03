using System;

namespace Product
{
    public class ProductProgram
    {    
        static void Main(string[] args)
        {
            Laptop acer = new Laptop("Acer Aspire 5", 10, 15000, new ScreenSize(1920, 1080), 5000);
            PC ryzen = new PC("Ryzen 5 3600", 5, 20000, Case.MidiTower, 500);
            Console.WriteLine(acer);
            Console.WriteLine(ryzen);
        }
        public enum Case
        {
            Tower,
            MiniTower,
            MidiTower,
            BigTower
        }

        public struct ScreenSize
        {
            public int Width { get; }
            public int Height { get; }

            public ScreenSize(int width, int height)
            {
                if (width <= 0)
                    throw new ArgumentOutOfRangeException(nameof(width), "Width should be a positive number");
                if (height <= 0)
                    throw new ArgumentOutOfRangeException(nameof(height), "Height should be a positive number");

                Width = width;
                Height = height;
            }

            public override string ToString() => $"{Width}x{Height}";
        }

        public class Product
        {
            public string Name { get; private set; }
            public int Quantity { get; private set; }
            public decimal Price { get; private set; }

            public Product(string name, int quantity, decimal price)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
            }

            public void SetPrice(decimal newPrice)
            {
                if (newPrice < 0)
                    throw new ArgumentOutOfRangeException(nameof(newPrice), "Price should be positive");
                Price = newPrice;
            }

            public void SetQuantity(int newQuantity)
            {
                if (newQuantity < 0)
                    throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity should be positive");
                Quantity = newQuantity;
            }

            public decimal GetTotalPrice() {
                return Quantity * Price;
            }

            public override string ToString()
            {
                return $"Product: {Name}, Quantity: {Quantity}, Price: {Price}, Total: {GetTotalPrice()}";
            }
        }

        public class Laptop : Product
        {
            public ScreenSize ScreenSize { get; private set; }
            public int BatteryCapacity { get; private set; }

            public Laptop(string name, int quantity, decimal price, ScreenSize screenSize, int batteryCapacity)
                : base(name, quantity, price)
            {
                if (batteryCapacity <= 0)
                    throw new ArgumentOutOfRangeException(nameof(batteryCapacity), "Battery Capacity");

                ScreenSize = screenSize;
                BatteryCapacity = batteryCapacity;
            }

            public override string ToString()
            {
                return base.ToString() + $", Screen Size: {ScreenSize}, Battery Capacity: {BatteryCapacity}";
            }
        }

        public class PC : Product
        {
            public Case CaseType { get; private set; }
            public int PowerSupply { get; private set; }

            public PC(string name, int quantity, decimal price, Case caseType, int powerSupply)
                : base(name, quantity, price)
            {
                if (powerSupply <= 0)
                    throw new ArgumentOutOfRangeException(nameof(powerSupply), "Power Supply should be positive");

                CaseType = caseType;
                PowerSupply = powerSupply;
            }

            public override string ToString()
            {
                return base.ToString() + $", Case Type: {CaseType}, Power Supply (W): {PowerSupply}";
            }
        }
    }
}
