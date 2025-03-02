namespace FactoryMethod
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
    }

    public class CountryDiscountService(string countryIdentifier) : DiscountService
    {
        public override int DiscountPercentage
        {
            get
            {
                return countryIdentifier switch
                {
                    // if you're from Belgium, you get a better discount :)
                    "BE" => 20,
                    _ => 10
                };
            }
        }
    }

    public class CodeDiscountService(Guid code) : DiscountService
    {
        private readonly Guid _code = code;

        public override int DiscountPercentage => 15;
    }

    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CountryDiscountFactory(string countryIdentifier) : DiscountFactory
    {
        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(countryIdentifier);
        }
    }

    public class CodeDiscountFactory(Guid code) : DiscountFactory
    {
        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(code);
        }
    }
}
