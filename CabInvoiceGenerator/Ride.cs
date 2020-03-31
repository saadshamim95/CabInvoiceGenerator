using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        double distance;
        double time;

        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
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