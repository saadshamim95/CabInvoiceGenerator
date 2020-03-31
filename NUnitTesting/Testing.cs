using CabInvoiceGenerator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenCalculate_ReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = {
                new Ride(5,15),
                new Ride(10,25)
            };
            double actual = invoiceService.CalculateFare(ride);
            Console.WriteLine(actual);
            Assert.AreEqual(190, actual);
        }
    }
}