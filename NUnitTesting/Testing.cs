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
            double actual = invoiceService.CalculateFare("Normal", 0.1, 1);
            Assert.AreEqual(5, actual);
        }

        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenCalculate_ReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = {
                new Ride("Normal",5,15),
                new Ride("Normal",10,25)
            };
            double actual = invoiceService.CalculateFare(ride);
            Assert.AreEqual(190, actual);
        }

        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenAnalyze_ReturnTotalFareNumberOfRidesAndAverageFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = {
                new Ride("Normal",5,15),
                new Ride("Normal",10,25),
                new Ride("Normal",15,40)
            };
            double totalFare = invoiceService.CalculateFare(ride);
            double averageFare = Math.Round(invoiceService.AverageFare, 2);
            int numberOfRides = invoiceService.NumberOfRides;
            Assert.AreEqual(380, totalFare);
            Assert.AreEqual(126.67, averageFare);
            Assert.AreEqual(3, numberOfRides);
        }

        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "saad@gmail.com";
            Ride[] ride = {
                new Ride("Normal",5,15),
                new Ride("Normal",10,25),
                new Ride("Normal",15,40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoiceService = new InvoiceService();
            double totalFare = invoiceService.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(380, totalFare);
        }

        [Test]
        public void PremiumRides()
        {
            string userId = "saad@gmail.com";
            Ride[] ride = {
                new Ride("Normal",10,20),
                new Ride("Premium",0.1,1),
                new Ride("Premium",12,25),
                new Ride("Normal",0.2,2)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoiceService = new InvoiceService();
            double totalFare = invoiceService.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(375, totalFare);
        }
    }
}