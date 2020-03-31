using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService
    {
        private readonly int costPerKilometre = 10;
        private readonly int minimumFare = 5;
        private readonly int costPerMinute = 1;
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

        public double CalculateFare(double distance, double time)
        {
            totalCost = distance * costPerKilometre + time * costPerMinute;
            if (totalCost > minimumFare)
            {
                return totalCost;
            }

            return minimumFare;
        }

        public double CalculateFare(Ride[] ride)
        {
            foreach (var item in ride)
            {
                totalFare = totalFare + CalculateFare(item.Distance, item.Time);
            }

            numberOfRides = ride.Length;
            averageFare = totalFare / numberOfRides;
            return totalFare;
        }
    }
}