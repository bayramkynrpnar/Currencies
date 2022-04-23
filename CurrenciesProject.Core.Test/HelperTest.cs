using CurrenciesProject.Core.Helper;
using Xunit;

namespace CurrenciesProject.Core.Test
{
    public class HelperTest
    {
        [Fact]
        public void GetData_Test()
        {
            var data = Helper.Helper.Instance.GetData();
            Assert.NotNull(data);
            Assert.NotEmpty(data.Result);
            Assert.IsType<string>(data.Result);
        }
        [Fact]
        public void CalculatePercentage_Test()
        {
            int number1 = 1;
            int number2 = 2;
            string response = Helper.Helper.Instance.CalculatePercentage(number1, number2);
            Assert.NotNull(response);
            Assert.Equal("100%", response);
        }

        [Fact]
        public void XmlDeserialize_Test()
        {
            var xml = Helper.Helper.Instance.GetData().Result;
            var response = Helper.Helper.Instance.XmlDeserialize<Dates>(xml);

            Assert.NotNull(xml);
            Assert.IsType<Dates>(response);
        }

    }
}