using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; }
        public List<Booking> Bookings { get; set; }

        public Hotel()
        {
            Rooms = new List<Room>();
            Bookings = new List<Booking>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void RemoveRoom(int roomNumber)
        {
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
            if (room != null)
            {
                Rooms.Remove(room);
            }
        }

        public void AddCustomer(Customer customer)
        {
            // Implementation for adding a customer
        }

        public void RemoveCustomer(int customerId)
        {
            // Implementation for removing a customer
        }

        public void BookRoom(Booking booking)
        {
            // Implementation for booking a room
        }

        public void CheckoutRoom(int bookingID)
        {
            // Implementation for checking out a room
        }

        public List<Room> ListAvailableRooms()
        {
            return Rooms.Where(r => r.IsAvailable).ToList();
        }

        public List<Room> ListAvailableRoomsByBedSize(string bedSize)
        {
            return Rooms.Where(r => r.IsAvailable && (r is SingleRoom sr && sr.BedSize == bedSize) ||
                                     (r is DoubleRoom dr && dr.BedSize == bedSize)).ToList();
        }
    }

}
