using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        private int v1;
        private Customer customer1;
        private DateTime now;
        private DateTime dateTime;
        private string v2;

        public int BookingID { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public int ExpectedNights { get; set; } // Add expected nights for comparison

        public Booking(int bookingID, Customer customer, Room room, DateTime checkInDate, DateTime checkOutDate, string status, int expectedNights)
        {
            BookingID = bookingID;
            Customer = customer;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = status;
            TotalPrice = 0;
            ExpectedNights = expectedNights;
        }

        public Booking(int v1, Customer customer1, Room room, DateTime now, DateTime dateTime, string v2)
        {
            this.v1 = v1;
            this.customer1 = customer1;
            Room = room;
            this.now = now;
            this.dateTime = dateTime;
            this.v2 = v2;
        }

        public void CalculateTotalPrice()
        {
            int numberOfNights = (CheckOutDate - CheckInDate).Days;
            TotalPrice = numberOfNights * Room.Price;

            // Apply penalty if stayed more than expected nights
            if (numberOfNights > ExpectedNights)
            {
                decimal penalty = (numberOfNights - ExpectedNights) * (Room.Price * 0.5m); // 50% penalty
                TotalPrice += penalty;
            }
        }
    }
}
