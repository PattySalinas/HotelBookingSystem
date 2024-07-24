using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class DoubleRoom : Room
    {
        public string BedSize { get; set; }
        public bool HasMiniBar { get; set; }
        public int NumberOfBeds { get; set; }
        public string? DoubleBedSize { get; }

        public DoubleRoom(int roomNumber, decimal price, bool isAvailable, string bedSize, bool hasMiniBar, int numberOfBeds)
            : base(roomNumber, price, isAvailable)
        {
            RoomNumber = roomNumber;
            BedSize = bedSize;
            HasMiniBar = hasMiniBar;
            NumberOfBeds = numberOfBeds;
        }

        public DoubleRoom(int v1, decimal v2, string v3, bool v4, int v5)
        {
        }

        public DoubleRoom(int roomNumber, decimal price, bool isAvailable, string? doubleBedSize, int numberOfBeds) : base(roomNumber, price, isAvailable)
        {
            DoubleBedSize = doubleBedSize;
            NumberOfBeds = numberOfBeds;
        }

        public override string GetRoomType() => "Double Room";
    }
}
