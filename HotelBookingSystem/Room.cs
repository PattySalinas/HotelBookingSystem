using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public abstract class Room
    {
        public int RoomNumber { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        protected Room(int roomNumber, decimal price, bool isAvailable)
        {
            RoomNumber = roomNumber;
            Price = price;
            IsAvailable = isAvailable;
        }
    }

}
