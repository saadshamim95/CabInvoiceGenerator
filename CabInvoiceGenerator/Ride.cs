using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        string journeyType;
        double distance;
        double time;

        public Ride(string journeyType, double distance, double time)
        {
            this.journeyType = journeyType;
            this.distance = distance;
            this.time = time;
        }

        public string JourneyType
        {
            get
            {
                return this.journeyType;
            }
        }

        public double Distance
        {
            get
            {
                return this.distance;
            }
        }

        public double Time
        {
            get
            {
                return this.time;
            }
        }
    }
}