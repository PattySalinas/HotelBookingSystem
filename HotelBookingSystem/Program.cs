// Susing System;
using HotelBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Hotel hotel = new Hotel();
                //Add some test data for demo Wednesday July 24
                AddTestData(hotel);

                while (true)
                {
                    Console.WriteLine("Hotel Booking System");
                    Console.WriteLine("1. Rooms");
                    Console.WriteLine("2. Customers");
                    Console.WriteLine("3. Booking");
                    Console.WriteLine("4. Exit");
                    Console.Write("Select an option: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            HandleRoomMenu(hotel);
                            break;
                        case 2:
                            HandleCustomerMenu(hotel);
                            break;
                        case 3:
                            HandleBookingMenu(hotel);
                            break;
                        case 4:
                            return; // Exit the program
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void HandleRoomMenu(Hotel hotel)
        {
            try
            {
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Remove Room");
                Console.WriteLine("3. List Rooms");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddRoom(hotel);
                        break;
                    case 2:
                        RemoveRoom(hotel);
                        break;
                    case 3:
                        ListRooms(hotel);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void HandleCustomerMenu(Hotel hotel)
        {
            try
            {
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Remove Customer");
                Console.WriteLine("3. List Customers");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                // Implement customer menu actions
                switch (option)
                {
                    case 1:
                        AddCustomer(hotel);
                        break;
                    case 2:
                        RemoveCustomer(hotel);
                        break;
                    case 3:
                        ListCustomers(hotel);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void HandleBookingMenu(Hotel hotel)
        {
            try
            {
                Console.WriteLine("1. Book Room");
                Console.WriteLine("2. Checkout Room");
                Console.WriteLine("3. List Bookings");
                Console.WriteLine("4. List Available Rooms");
                Console.WriteLine("5. List Available Rooms by Bed Size");
                Console.WriteLine("6. List Past Bookings");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                // Implement booking menu actions
                switch (option)
                {
                    case 1:
                        BookRoom(hotel);
                        break;
                    case 2:
                        CheckoutRoom(hotel);
                        break;
                    case 3:
                        ListBookings(hotel);
                        break;
                    case 4:
                        ListAvailableRooms(hotel);
                        break;
                    case 5:
                        ListAvailableRoomsByBedSize(hotel);
                        break;
                    case 6:
                        ListPastBookings(hotel);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AddRoom(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Room Type (Single, Double, Suite): ");
                string roomType = Console.ReadLine();
                Console.Write("Enter Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Room room = null;
                switch (roomType.ToLower())
                {
                    case "single":
                        Console.Write("Enter Bed Size: ");
                        string bedSize = Console.ReadLine();
                        Console.Write("Has Balcony (true/false): ");
                        bool hasBalcony = bool.Parse(Console.ReadLine());
                        room = new SingleRoom(roomNumber, price, hasBalcony, bedSize);
                        Console.WriteLine($"Created SingleRoom: Number={roomNumber}, Price={price}, BedSize={bedSize}, HasBalcony={hasBalcony}");
                        break;
                    case "double":
                        Console.Write("Enter Bed Size: ");
                        string doubleBedSize = Console.ReadLine();
                        Console.Write("Has Mini Bar (true/false): ");
                        bool hasMiniBar = bool.Parse(Console.ReadLine());
                        Console.Write("Enter Number of Beds: ");
                        int numberOfBeds = int.Parse(Console.ReadLine());
                        room = new DoubleRoom(roomNumber, price, hasMiniBar, doubleBedSize, numberOfBeds);
                        Console.WriteLine($"Created DoubleRoom: Number={roomNumber}, Price={price}, BedSize={doubleBedSize}, HasMiniBar={hasMiniBar}, NumberOfBeds={numberOfBeds}");
                        break;
                    case "suite":
                        Console.Write("Enter Living Area Size: ");
                        double livingAreaSize = double.Parse(Console.ReadLine());
                        Console.Write("Has Jacuzzi (true/false): ");
                        bool hasJacuzzi = bool.Parse(Console.ReadLine());
                        Console.Write("Enter Number of Rooms: ");
                        int numberOfRooms = int.Parse(Console.ReadLine());
                        room = new Suite(roomNumber, price, livingAreaSize, hasJacuzzi, numberOfRooms);
                        Console.WriteLine($"Created Suite: Number={roomNumber}, Price={price}, LivingAreaSize={livingAreaSize}, HasJacuzzi={hasJacuzzi}, NumberOfRooms={numberOfRooms}");
                        break;
                    default:
                        Console.WriteLine("Invalid room type.");
                        return;
                }
                hotel.AddRoom(room);
                Console.WriteLine("Room added successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void RemoveRoom(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Room Number to Remove: ");
                int roomNumberToRemove = int.Parse(Console.ReadLine());

                // Find the room to remove
                Room roomToRemove = hotel.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumberToRemove);

                if (roomToRemove != null)
                {
                    // Check if the room is currently booked
                    bool isBooked = hotel.Bookings.Any(b => b.Room.RoomNumber == roomNumberToRemove && b.Status == "Active");

                    if (isBooked)
                    {
                        Console.WriteLine("Cannot remove room. It is currently booked.");
                    }
                    else
                    {
                        // Remove the room from the list
                        hotel.Rooms.Remove(roomToRemove);
                        Console.WriteLine("Room removed successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Room not found.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListRooms(Hotel hotel)
        {
            try
            {
                Console.WriteLine("List of Rooms:");

                if (hotel.Rooms.Count == 0)
                {
                    Console.WriteLine("No rooms available.");
                    return;
                }

                foreach (var room in hotel.Rooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}");
                    Console.WriteLine($"Type: {room.GetType().Name}");
                    Console.WriteLine($"Price: {room.Price:C}");
                    Console.WriteLine($"Availability: {(room.IsAvailable ? "Available" : "Not Available")}");

                    // Display additional details based on room type
                    if (room is SingleRoom singleRoom)
                    {
                        Console.WriteLine($"Bed Size: {singleRoom.BedSize}");
                        Console.WriteLine($"Has Balcony: {(singleRoom.HasBalcony ? "Yes" : "No")}");
                    }
                    else if (room is DoubleRoom doubleRoom)
                    {
                        Console.WriteLine($"Bed Size: {doubleRoom.BedSize}");
                        Console.WriteLine($"Has Mini Bar: {(doubleRoom.HasMiniBar ? "Yes" : "No")}");
                        Console.WriteLine($"Number of Beds: {doubleRoom.NumberOfBeds}");
                    }
                    else if (room is Suite suite)
                    {
                        Console.WriteLine($"Living Area Size: {suite.LivingAreaSize} sqm");
                        Console.WriteLine($"Has Jacuzzi: {(suite.HasJacuzzi ? "Yes" : "No")}");
                        Console.WriteLine($"Number of Rooms: {suite.NumberOfRooms}");
                    }

                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void AddCustomer(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();
                Customer customer = new Customer(customerId, name);
                hotel.AddCustomer(customer);
                Console.WriteLine("Customer added successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void RemoveCustomer(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Customer ID to Remove: ");
                int customerId = int.Parse(Console.ReadLine());

                Customer customerToRemove = hotel.Customers.FirstOrDefault(c => c.CustomerId == customerId);

                if (customerToRemove != null)
                {
                    hotel.RemoveCustomer(customerId);
                    Console.WriteLine("Customer removed successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListCustomers(Hotel hotel)
        {
            try
            {
                Console.WriteLine("List of Customers:");

                if (hotel.Customers.Count == 0)
                {
                    Console.WriteLine("No customers available.");
                    return;
                }

                foreach (var customer in hotel.Customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}");
                    Console.WriteLine($"Name: {customer.Name}");
                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void BookRoom(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Enter Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter Check-in Date (yyyy-mm-dd): ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Check-out Date (yyyy-mm-dd): ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

                Customer customer = hotel.Customers.FirstOrDefault(c => c.CustomerId == customerId);
                Room room = hotel.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                if (customer == null || room == null || !room.IsAvailable)
                {
                    Console.WriteLine("Invalid customer or room details. Room may not be available on the selected dates");
                    return;
                }

                Booking booking = new Booking(hotel.Bookings.Count + 1, customer, room, checkInDate, checkOutDate, "Active");
                booking.CalculateTotalPrice();
                hotel.BookRoom(booking);

                Console.WriteLine($"Room booked successfully. Enjoy your stay! Total Price: {booking.TotalPrice:C}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void CheckoutRoom(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Booking ID to Checkout: ");
                int bookingID = int.Parse(Console.ReadLine());

                hotel.CheckoutRoom(bookingID);

                Console.WriteLine("Room checked out successfully.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListBookings(Hotel hotel)
        {
            try
            {
                Console.WriteLine("List of Bookings:");

                if (hotel.Bookings.Count == 0)
                {
                    Console.WriteLine("No bookings available.");
                    return;
                }

                foreach (var booking in hotel.Bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingID}");
                    Console.WriteLine($"Customer: {booking.Customer.Name}");
                    Console.WriteLine($"Room Number: {booking.Room.RoomNumber}");
                    Console.WriteLine($"Check-in Date: {booking.CheckInDate.ToShortDateString()}");
                    Console.WriteLine($"Check-out Date: {booking.CheckOutDate.ToShortDateString()}");
                    Console.WriteLine($"Status: {booking.Status}");
                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListAvailableRooms(Hotel hotel)
        {
            try
            {
                Console.WriteLine("List of Available Rooms:");

                var availableRooms = hotel.Rooms.Where(r => r.IsAvailable).ToList();

                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("No rooms available.");
                    return;
                }

                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}");
                    Console.WriteLine($"Type: {room.GetType().Name}");
                    Console.WriteLine($"Price: {room.Price:C}");
                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListAvailableRoomsByBedSize(Hotel hotel)
        {
            try
            {
                Console.Write("Enter Bed Size to Filter (e.g., King, Queen): ");
                string bedSize = Console.ReadLine();

                var availableRooms = hotel.Rooms
                    .Where(r => r.IsAvailable && (r is SingleRoom sr && sr.BedSize.Equals(bedSize, StringComparison.OrdinalIgnoreCase)
                                                 || r is DoubleRoom dr && dr.BedSize.Equals(bedSize, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                Console.WriteLine($"List of Available Rooms with Bed Size '{bedSize}':");

                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("No rooms available with the specified bed size.");
                    return;
                }

                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}");
                    Console.WriteLine($"Type: {room.GetType().Name}");
                    Console.WriteLine($"Price: {room.Price:C}");
                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListPastBookings(Hotel hotel)
        {
            try
            {
                Console.WriteLine("List of Past Bookings:");

                var pastBookings = hotel.Bookings
                    .Where(b => b.CheckOutDate < DateTime.Now)
                    .ToList();

                if (pastBookings.Count == 0)
                {
                    Console.WriteLine("No past bookings available.");
                    return;
                }

                foreach (var booking in pastBookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingID}");
                    Console.WriteLine($"Customer: {booking.Customer.Name}");
                    Console.WriteLine($"Room Number: {booking.Room.RoomNumber}");
                    Console.WriteLine($"Check-in Date: {booking.CheckInDate.ToShortDateString()}");
                    Console.WriteLine($"Check-out Date: {booking.CheckOutDate.ToShortDateString()}");
                    Console.WriteLine($"Status: {booking.Status}");
                    Console.WriteLine(); // Blank line for readability
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        // Add some test data for demo purposes
        static void AddTestData(Hotel hotel)
        {
            try
            {
                hotel.AddRoom(new SingleRoom(101, 100, "King", true));
                hotel.AddRoom(new DoubleRoom(102, 150, "Queen", true, 2));
                hotel.AddRoom(new Suite(103, 300, 50.0, true, 3));

                hotel.AddCustomer(new Customer(1, "John Doe"));
                hotel.AddCustomer(new Customer(2, "Jane Smith"));
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}