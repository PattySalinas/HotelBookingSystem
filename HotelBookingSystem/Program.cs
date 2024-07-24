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
                    Console.Clear(); // Clear the console for a fresh look
                    Console.WriteLine("=====================================");
                    Console.WriteLine("    Welcome to the Hotel Booking System");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("1. Rooms");
                    Console.WriteLine("2. Customers");
                    Console.WriteLine("3. Booking");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("=====================================");
                    Console.Write("Select an option: ");

                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
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
                                Console.WriteLine("Exiting... Thank you for using the Hotel Booking System.");
                                return; // Exit the program
                            default:
                                Console.WriteLine("Invalid option. Please select a number between 1 and 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    // Pause for the user to see the message
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
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
                Console.Clear();
                Console.WriteLine("===== Room Menu =====");
                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Remove Room");
                Console.WriteLine("3. List Rooms");
                Console.WriteLine("======================");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
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
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
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
                Console.Clear();
                Console.WriteLine("===== Customer Menu =====");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Remove Customer");
                Console.WriteLine("3. List Customers");
                Console.WriteLine("==========================");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
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
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
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
                Console.Clear();
                Console.WriteLine("===== Booking Menu =====");
                Console.WriteLine("1. Book Room");
                Console.WriteLine("2. Checkout Room");
                Console.WriteLine("3. List Bookings");
                Console.WriteLine("4. List Available Rooms");
                Console.WriteLine("5. List Available Rooms by Bed Size");
                Console.WriteLine("6. List Past Bookings");
                Console.WriteLine("=========================");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
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
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
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
                Console.Clear();
                Console.WriteLine("===== Add Room =====");
                Console.Write("Enter Room Type (Single, Double, Suite): ");
                string roomType = Console.ReadLine().Trim();
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
                Console.Clear();
                Console.WriteLine("===== Remove Room =====");
                Console.Write("Enter Room Number to Remove: ");
                int roomNumberToRemove = int.Parse(Console.ReadLine());

                Room roomToRemove = hotel.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumberToRemove);

                if (roomToRemove != null)
                {
                    bool isBooked = hotel.Bookings.Any(b => b.Room.RoomNumber == roomNumberToRemove && b.Status == "Active");

                    if (isBooked)
                    {
                        Console.WriteLine("Cannot remove room. It is currently booked.");
                    }
                    else
                    {
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
                Console.Clear();
                Console.WriteLine("===== List of Rooms =====");

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
                        Console.WriteLine($"Living Area Size: {suite.LivingAreaSize} sq meters");
                        Console.WriteLine($"Has Jacuzzi: {(suite.HasJacuzzi ? "Yes" : "No")}");
                        Console.WriteLine($"Number of Rooms: {suite.NumberOfRooms}");
                    }

                    Console.WriteLine("=================================");
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
                Console.Clear();
                Console.WriteLine("===== Add Customer =====");
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Enter Customer Name: ");
                string name = Console.ReadLine();
                Customer customer = new Customer(customerId, name);
                hotel.AddCustomer(customer);
                Console.WriteLine("Customer added successfully: " + $"Customer ID: {customer.CustomerId}" + " | "+$"Name: {customer.Name}");
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
                Console.Clear();
                Console.WriteLine("===== Remove Customer =====");
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
                Console.Clear();
                Console.WriteLine("===== List of Customers =====");

                if (hotel.Customers.Count == 0)
                {
                    Console.WriteLine("No customers available.");
                    return;
                }

                foreach (var customer in hotel.Customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerId}" + $"Name: {customer.Name}");
                    Console.WriteLine("=================================");
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
                Console.Clear();
                Console.WriteLine("===== Book Room =====");
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

                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                if (room == null || !room.IsAvailable)
                {
                    Console.WriteLine("Room not available.");
                    return;
                }

                Booking booking = new Booking(hotel.Bookings.Count + 1, customer, room, checkInDate, checkOutDate, "Active");
                booking.CalculateTotalPrice();
                hotel.BookRoom(booking);

                Console.WriteLine($"Room booked successfully. Enjoy your stay!");
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
                Console.Clear();
                Console.WriteLine("===== Checkout Room =====");
                Console.Write("Enter Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());

                Booking booking = hotel.Bookings.FirstOrDefault(b => b.Room.RoomNumber == roomNumber && b.Status == "Active");

                if (booking != null)
                {
                    booking.Status = "Checked Out";
                    booking.Room.IsAvailable = true;
                    Console.WriteLine("Room checked out successfully.");
                }
                else
                {
                    Console.WriteLine("No active booking found for this room.");
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

        static void ListBookings(Hotel hotel)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("===== List of Bookings =====");

                if (hotel == null)
                {
                    Console.WriteLine("Hotel instance is null.");
                    return;
                }

                if (hotel.Bookings == null || hotel.Bookings.Count == 0)
                {
                    Console.WriteLine("No bookings available.");
                    return;
                }

                // Optional: Sort bookings by CheckInDate or any other criteria
                hotel.Bookings.Sort((b1, b2) => b1.CheckInDate.CompareTo(b2.CheckInDate));

                foreach (var booking in hotel.Bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingID}");
                    Console.WriteLine($"Customer: {booking.Customer?.Name ?? "N/A"}");
                    Console.WriteLine($"Room: {booking.Room?.GetRoomType() ?? "N/A"}");
                    Console.WriteLine($"Status: {booking.Status}");
                    Console.WriteLine($"Total Price: {booking.TotalPrice:C}");
                    Console.WriteLine($"Expected Nights: {booking.ExpectedNights}");
                    Console.WriteLine(new string('-', 40)); // Separator
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
                Console.Clear();
                Console.WriteLine("===== List of Available Rooms =====");

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
                    Console.WriteLine("=================================");
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
                Console.Clear();
                Console.WriteLine("===== List Available Rooms by Bed Size =====");
                Console.Write("Enter Bed Size: ");
                string bedSize = Console.ReadLine();

                var availableRooms = hotel.Rooms
                    .Where(r => r is SingleRoom singleRoom && singleRoom.BedSize.Equals(bedSize, StringComparison.OrdinalIgnoreCase) && r.IsAvailable)
                    .ToList();

                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("No rooms available with the specified bed size.");
                    return;
                }

                foreach (var room in availableRooms)
                {
                    Console.WriteLine($"Room Number: {room.RoomNumber}");
                    Console.WriteLine($"Price: {room.Price:C}");
                    Console.WriteLine("=================================");
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
                Console.Clear();
                Console.WriteLine("===== List of Past Bookings =====");

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
                    Console.WriteLine("=================================");
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

                hotel.AddCustomer(new Customer(1, "Fulano Perez"));
                hotel.AddCustomer(new Customer(2, "Mengana Perez"));
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