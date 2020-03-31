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
        private double totalCost;

        public double CalculateFare(double distance, double time)
        {
            totalCost = distance * costPerKilometre + time * costPerMinute;
            if (totalCost > minimumFare)
            {
                return totalCost;
            }

            return minimumFare;
        }
    }
}