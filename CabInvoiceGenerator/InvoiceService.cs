using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService
    {
        private readonly int costPerKilometreNormal = 10;
        private readonly int minimumFareNormal = 5;
        private readonly int costPerMinuteNormal = 1;
        private readonly int costPerKilometrePremium = 15;
        private readonly int minimumFarePremium = 20;
        private readonly int costPerMinutePremium = 2;
        private double totalCost = 0;
        private double totalFare = 0;
        private double averageFare = 0;
        private int numberOfRides = 0;

        public double AverageFare
        {
            get 
            {
                return this.averageFare;
            }
        }

        public int NumberOfRides
        {
            get
            {
                return this.numberOfRides;
            }
        }

        public double CalculateFare(string journeyType, double distance, double time)
        {
            if (journeyType == "Normal")
            {
                totalCost = distance * costPerKilometreNormal + time * costPerMinuteNormal;
                if (totalCost > minimumFareNormal)
                {
                    return totalCost;
                }

                return minimumFareNormal;
            }

            totalCost = distance * costPerKilometrePremium + time * costPerMinutePremium;
            if (totalCost > minimumFarePremium)
            {
                return totalCost;
            }

            return minimumFarePremium;
        }

        public double CalculateFare(Ride[] ride)
        {
            foreach (var item in ride)
            {
                totalFare = totalFare + CalculateFare(item.JourneyType, item.Distance, item.Time);
            }

            numberOfRides = ride.Length;
            averageFare = totalFare / numberOfRides;
            return totalFare;
        }
    }
}