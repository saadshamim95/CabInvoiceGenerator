//-----------------------------------------------------------------------
// <copyright file="InvoiceService.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Class Invoice Service for returning Invoice details
    /// </summary>
    public class InvoiceService
    {
        /// <summary>
        /// The cost per Kilometre for normal
        /// </summary>
        private readonly int costPerKilometreNormal = 10;

        /// <summary>
        /// The minimum fare normal
        /// </summary>
        private readonly int minimumFareNormal = 5;

        /// <summary>
        /// The cost per minute normal
        /// </summary>
        private readonly int costPerMinuteNormal = 1;

        /// <summary>
        /// The cost per Kilometre premium
        /// </summary>
        private readonly int costPerKilometrePremium = 15;

        /// <summary>
        /// The minimum fare premium
        /// </summary>
        private readonly int minimumFarePremium = 20;

        /// <summary>
        /// The cost per minute premium
        /// </summary>
        private readonly int costPerMinutePremium = 2;

        /// <summary>
        /// The total cost
        /// </summary>
        private double totalCost = 0;

        /// <summary>
        /// The total fare
        /// </summary>
        private double totalFare = 0;

        /// <summary>
        /// The average fare
        /// </summary>
        private double averageFare = 0;

        /// <summary>
        /// The number of rides
        /// </summary>
        private int numberOfRides = 0;

        /// <summary>
        /// Gets the average fare.
        /// </summary>
        /// <value>
        /// The average fare.
        /// </value>
        public double AverageFare
        {
            get 
            {
                return this.averageFare;
            }
        }

        /// <summary>
        /// Gets the number of rides.
        /// </summary>
        /// <value>
        /// The number of rides.
        /// </value>
        public int NumberOfRides
        {
            get
            {
                return this.numberOfRides;
            }
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="journeyType">Type of the journey.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns>It return fare for one journey.</returns>
        public double CalculateFare(string journeyType, double distance, double time)
        {
            if (journeyType == "Normal")
            {
                this.totalCost = (distance * this.costPerKilometreNormal) + (time * this.costPerMinuteNormal);
                if (this.totalCost > this.minimumFareNormal)
                {
                    return this.totalCost;
                }

                return this.minimumFareNormal;
            }

            this.totalCost = (distance * this.costPerKilometrePremium) + (time * this.costPerMinutePremium);
            if (this.totalCost > this.minimumFarePremium)
            {
                return this.totalCost;
            }

            return this.minimumFarePremium;
        }

        /// <summary>
        /// Calculates the monthly fare.
        /// </summary>
        /// <param name="ride">The ride.</param>
        /// <returns>It return Monthly fare.</returns>
        public double CalculateMonthlyFare(Ride[] ride)
        {
            foreach (var item in ride)
            {
                this.totalFare = this.totalFare + this.CalculateFare(item.JourneyType, item.Distance, item.Time);
            }

            this.numberOfRides = ride.Length;
            this.averageFare = this.totalFare / this.numberOfRides;
            return this.totalFare;
        }
    }
}