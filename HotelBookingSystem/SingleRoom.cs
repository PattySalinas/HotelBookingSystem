using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class SingleRoom : Room
    {
        public string BedSize { get; set; }
        public bool HasBalcony { get; set; }

        public SingleRoom(int roomNumber, decimal price, bool isAvailable, string bedSize, bool hasBalcony)
            : base(roomNumber, price, isAvailable)
        {
            BedSize = bedSize;
            HasBalcony = hasBalcony;
        }
    }

}
