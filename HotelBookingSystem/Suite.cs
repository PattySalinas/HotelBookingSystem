using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Suite : Room
    {
        public double LivingAreaSize { get; set; }
        public bool HasJacuzzi { get; set; }
        public int NumberOfRooms { get; set; }

        public Suite(int roomNumber, decimal price, bool isAvailable, double livingAreaSize, bool hasJacuzzi, int numberOfRooms)
        : base(roomNumber, price, isAvailable)
        {
            LivingAreaSize = livingAreaSize;
            HasJacuzzi = hasJacuzzi;
            NumberOfRooms = numberOfRooms;
        }

        public Suite(int roomNumber, decimal price, double livingAreaSize, bool hasJacuzzi, int numberOfRooms)
        {
            RoomNumber = roomNumber;
            Price = price;
            LivingAreaSize = livingAreaSize;
            HasJacuzzi = hasJacuzzi;
            NumberOfRooms = numberOfRooms;
        }

        public override string GetRoomType() => "Suite";
    }


}
