﻿namespace CabInvoiceGenerator
{
    public class Riderepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public Riderepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID, list);

                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }
        public Ride[] GetRides(string userID)
        {
            try
            {
                return this.userRides[userID].ToArray();
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Id.");
            }
        }
    }
}
