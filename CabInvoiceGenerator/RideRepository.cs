//-----------------------------------------------------------------------
// <copyright file="RideRepository.cs" company="BridgeLabz">
//     Copyright © 2020 
// </copyright>
// <creator name="Saad Shamim"/>
//-----------------------------------------------------------------------

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Class Ride Repository
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// The user rides
        /// </summary>
        private Dictionary<string, List<Ride>> userRides = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Adds the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        public void AddRides(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userID, list);
            }
        }

        /// <summary>
        /// Gets the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>It return all the rides of the user.</returns>
        public Ride[] GetRides(string userID)
        {
            return this.userRides[userID].ToArray();
        }
    }
}