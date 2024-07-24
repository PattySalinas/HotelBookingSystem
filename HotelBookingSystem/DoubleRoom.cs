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

        public DoubleRoom(int roomNumber, decimal price, bool isAvailable, string bedSize, bool hasMiniBar, int numberOfBeds)
            : base(roomNumber, price, isAvailable)
        {
            BedSize = bedSize;
            HasMiniBar = hasMiniBar;
            NumberOfBeds = numberOfBeds;
        }
    }

}
