//-----------------------------------------------------------------------
// <copyright file="Ride.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Class for storing ride details.
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// The journey type
        /// </summary>
        private string journeyType;

        /// <summary>
        /// The distance
        /// </summary>
        private double distance;

        /// <summary>
        /// The time
        /// </summary>
        private double time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="journeyType">Type of the journey.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(string journeyType, double distance, double time)
        {
            this.journeyType = journeyType;
            this.distance = distance;
            this.time = time;
        }

        /// <summary>
        /// Gets the type of the journey.
        /// </summary>
        /// <value>
        /// The type of the journey.
        /// </value>
        public string JourneyType
        {
            get
            {
                return this.journeyType;
            }
        }

        /// <summary>
        /// Gets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public double Distance
        {
            get
            {
                return this.distance;
            }
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public double Time
        {
            get
            {
                return this.time;
            }
        }
    }
}