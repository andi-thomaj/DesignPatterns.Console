namespace AbstractFactory
{
    public interface IEngine
    {
        string GetEngineType();
    }

    public interface IChassis
    {
        string GetChassisType();
    }

    public class TeslaEngine : IEngine
    {
        public string GetEngineType() => "Tesla Electric Motor";
    }

    public class TeslaChassis : IChassis
    {
        public string GetChassisType() => "Tesla Chassis";
    }

    public class FordEngine : IEngine
    {
        public string GetEngineType() => "Ford V8 Engine";
    }

    public class FordChassis : IChassis
    {
        public string GetChassisType() => "Ford Chassis";
    }

    public interface ICarFactory
    {
        IEngine CreateEngine();
        IChassis CreateChassis();
    }

    public class TeslaFactory : ICarFactory
    {
        public IEngine CreateEngine() => new TeslaEngine();

        public IChassis CreateChassis() => new TeslaChassis();
    }

    public class FordFactory : ICarFactory
    {
        public IEngine CreateEngine() => new FordEngine();
        public IChassis CreateChassis() => new FordChassis();
    }

    public class CarManufacturer(ICarFactory factory)
    {
        private readonly IEngine _engine = factory.CreateEngine();
        private readonly IChassis _chassis = factory.CreateChassis();

        public string AssembleCar()
        {
            return $"Assembled a car with {_engine.GetEngineType()} and {_chassis.GetChassisType()}";
        }
    }
}
