using AdditiveSecretFunction.Services.Abstract;
using AdditiveSecretFunction.Services.Concrete;
using Xunit;

namespace AdditiveSecretFunction.Services.Tests
{
    public class AdditiveServiceTests
    {
        private readonly IAdditiveService _additiveService;

        public AdditiveServiceTests()
        {
            _additiveService = new AdditiveService(new PrimeNumberService());
        }

        [Fact]
        public void IsAdditive()
        {
            Assert.True(_additiveService.IsAdditive(x => x, 100));
        }

        [Fact]
        public void IsNotAdditive()
        {
            Assert.False(_additiveService.IsAdditive(x => x / 5, 100));
        }
    }
}