namespace AbstractFactory
{
    class Program
    {
        static void Main()
        {
            // Build a Tesla
            ICarFactory teslaFactory = new TeslaFactory();
            CarManufacturer teslaBuilder = new CarManufacturer(teslaFactory);
            Console.WriteLine(teslaBuilder.AssembleCar());

            // Build a Ford
            ICarFactory fordFactory = new FordFactory();
            CarManufacturer fordBuilder = new CarManufacturer(fordFactory);
            Console.WriteLine(fordBuilder.AssembleCar());
        }
    }
}
