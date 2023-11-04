﻿namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private readonly int capacity = 10;
        private string car;

        private Dictionary<string, string> ticket2carParking = new Dictionary<string, string>();

        private Dictionary<string, string> ticket2carFetched = new Dictionary<string, string>();

        public ParkingLot()
        {
        }

        public int NumOfParkedCars { get => ticket2carParking.Count; }
        public int Capacity { get => capacity; }

        public Dictionary<string, string> Ticket2carParking
        {
            get => ticket2carParking;
        }

        public string Park(string car)
        {
            if (NumOfParkedCars < capacity)
            {
                string ticket = "T-" + car;
                ticket2carParking.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new WrongTicketException("No available position.");
            }
        }

        public string Fetch(string ticket)
        {
            if (ticket == null || !ticket2carParking.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string carToBeFetched = ticket2carParking[ticket];

            ticket2carParking.Remove(ticket);
            ticket2carFetched.Add(ticket, carToBeFetched);

            return carToBeFetched;
        }
    }
}
