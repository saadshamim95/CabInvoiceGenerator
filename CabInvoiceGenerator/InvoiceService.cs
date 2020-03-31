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
                totalCost = totalCost + CalculateFare(item.Distance, item.Time);
            }

            return totalCost;
        }
    }
}