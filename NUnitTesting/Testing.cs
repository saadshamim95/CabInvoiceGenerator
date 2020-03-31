using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTimeWhenCheck_ShouldReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            double actual = invoiceService.CalculateFare(0.1, 1);
            Assert.AreEqual(5, actual);
        }
    }
}