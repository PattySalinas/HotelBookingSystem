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
        public List<Customer> Customers { get; set; }
        public Hotel()
        {
            Rooms = new List<Room>();
            Bookings = new List<Booking>();
            Customers = new List<Customer>();
        }

        // Implementation for adding a room
        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        // Implementation for removing a room
        public void RemoveRoom(int roomNumber)
        {
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && r.IsAvailable);
            if (room != null)
            {
                Rooms.Remove(room);
            }
        }

        // Implementation for adding a customer
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        // Implementation for removing a customer
        public void RemoveCustomer(int customerId)
        {
            // Find the customer to remove
            Customer customerToRemove = Customers.FirstOrDefault(c => c.CustomerId == customerId);

            if (customerToRemove != null)
            {
                // Check if the customer has any active bookings
                bool isOccupyingRoom = Bookings.Any(b => b.Customer.CustomerId == customerId && b.Status == "Active");

                if (isOccupyingRoom)
                {
                    Console.WriteLine("Cannot remove customer. They are currently occupying a room.");
                }
                else
                {
                    // Remove the customer from the list
                    Customers.Remove(customerToRemove);
                    Console.WriteLine("Customer removed successfully.");
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void BookRoom(Booking booking)
        {
            Bookings.Add(booking);
            booking.Room.IsAvailable = false;
        }

        public void CheckoutRoom(int bookingID)
        {
            // Find the booking by ID
            Booking bookingToCheckout = Bookings.FirstOrDefault(b => b.BookingID == bookingID);

            if (bookingToCheckout != null)
            {
                if (bookingToCheckout.Status == "Closed")
                {
                    Console.WriteLine("The room is already checked out.");
                    return;
                }

                // Calculate the total price
                bookingToCheckout.CalculateTotalPrice();

                // Calculate additional fee if the customer stayed more nights than anticipated
                int numberOfNightsBooked = (bookingToCheckout.CheckOutDate - bookingToCheckout.CheckInDate).Days;
                int actualStayNights = (DateTime.Now - bookingToCheckout.CheckInDate).Days;

                if (actualStayNights > numberOfNightsBooked)
                {
                    decimal extraFee = (actualStayNights - numberOfNightsBooked) * (bookingToCheckout.Room.Price * 0.5m);
                    bookingToCheckout.TotalPrice += extraFee;
                }

                // Mark the booking as closed
                bookingToCheckout.Status = "Closed";

                // Make the room available
                bookingToCheckout.Room.IsAvailable = true;

                Console.WriteLine($"Checkout completed. Total price: {bookingToCheckout.TotalPrice:C}");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
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
