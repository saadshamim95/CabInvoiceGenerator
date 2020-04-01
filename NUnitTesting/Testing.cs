//-----------------------------------------------------------------------
// <copyright file="Testing.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace NUnitTesting
{
    using System;
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Class for Testing
    /// </summary>
    public class Testing
    {
        /// <summary>
        /// The Setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Given the distance and time when check should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeWhenCheck_ShouldReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            double actual = invoiceService.CalculateFare("Normal", 0.1, 1);
            Assert.AreEqual(5, actual);
        }

        /// <summary>
        /// Invoices the generator should take multiple rides when calculate return total fare.
        /// </summary>
        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenCalculate_ReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = 
            {
                new Ride("Normal", 5, 15),
                new Ride("Normal", 10, 25)
            };
            double actual = invoiceService.CalculateMonthlyFare(ride);
            Assert.AreEqual(190, actual);
        }

        /// <summary>
        /// Invoice the generator should take multiple rides when analyze return total fare number of rides and average fare.
        /// </summary>
        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenAnalyze_ReturnTotalFareNumberOfRidesAndAverageFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = 
            {
                new Ride("Normal", 5, 15),
                new Ride("Normal", 10, 25),
                new Ride("Normal", 15, 40)
            };
            double totalFare = invoiceService.CalculateMonthlyFare(ride);
            double averageFare = Math.Round(invoiceService.AverageFare, 2);
            int numberOfRides = invoiceService.NumberOfRides;
            Assert.AreEqual(380, totalFare);
            Assert.AreEqual(126.67, averageFare);
            Assert.AreEqual(3, numberOfRides);
        }

        /// <summary>
        /// Given the user identifier invoice service gets list of rides from ride repository return invoice.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "saad@gmail.com";
            Ride[] ride = 
            {
                new Ride("Normal", 5, 15),
                new Ride("Normal", 10, 25),
                new Ride("Normal", 15, 40)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoiceService = new InvoiceService();
            double totalFare = invoiceService.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(380, totalFare);
        }

        /// <summary>
        /// Normal the and premium rides.
        /// </summary>
        [Test]
        public void NormalAndPremiumRides()
        {
            string userId = "saad@gmail.com";
            Ride[] ride = 
            {
                new Ride("Normal", 10, 20),
                new Ride("Premium", 0.1, 1),
                new Ride("Premium", 12, 25),
                new Ride("Normal", 0.2, 2)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            InvoiceService invoiceService = new InvoiceService();
            double totalFare = invoiceService.CalculateMonthlyFare(rideRepository.GetRides(userId));
            Assert.AreEqual(375, totalFare);
        }
    }
}