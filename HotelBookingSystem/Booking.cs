using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        public int BookingID { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public Booking(int bookingID, Customer customer, Room room, DateTime checkInDate, DateTime checkOutDate, string status)
        {
            BookingID = bookingID;
            Customer = customer;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = status;
            TotalPrice = 0;
        }

        public void CalculateTotalPrice()
        {
            int numberOfNights = (CheckOutDate - CheckInDate).Days;
            TotalPrice = numberOfNights * Room.Price;
        }
    }

}
