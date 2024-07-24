// Susing System;
using HotelBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel();
        AddTestData(hotel);

        while (true)
        {
            Console.WriteLine("Hotel Booking System");
            Console.WriteLine("1. Rooms");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Booking");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
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
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void HandleRoomMenu(Hotel hotel)
    {
        Console.WriteLine("1. Add Room");
        Console.WriteLine("2. Remove Room");
        Console.WriteLine("3. List Rooms");
        int option = int.Parse(Console.ReadLine());

        // Implement room menu actions
        switch (option)
        {
            case 1:
                // Add room logic
                break;
            case 2:
                // Remove room logic
                break;
            case 3:
                // List rooms logic
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void HandleCustomerMenu(Hotel hotel)
    {
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Remove Customer");
        Console.WriteLine("3. List Customers");
        int option = int.Parse(Console.ReadLine());

        // Implement customer menu actions
        switch (option)
        {
            case 1:
                // Add customer logic
                break;
            case 2:
                // Remove customer logic
                break;
            case 3:
                // List customers logic
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void HandleBookingMenu(Hotel hotel)
    {
        Console.WriteLine("1. Book Room");
        Console.WriteLine("2. Checkout Room");
        Console.WriteLine("3. List Bookings");
        Console.WriteLine("4. List Available Rooms");
        Console.WriteLine("5. List Available Rooms by Bed Size");
        Console.WriteLine("6. List Past Bookings");
        int option = int.Parse(Console.ReadLine());

        // Implement booking menu actions
        switch (option)
        {
            case 1:
                // Book room logic
                break;
            case 2:
                // Checkout room logic
                break;
            case 3:
                // List bookings logic
                break;
            case 4:
                // List available rooms logic
                break;
            case 5:
                // List available rooms by bed size logic
                break;
            case 6:
                // List past bookings logic
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    public static void AddTestData(Hotel hotel)
    {
        hotel.AddRoom(new SingleRoom(101, 100m, true, "Queen", true));
        hotel.AddRoom(new DoubleRoom(102, 150m, true, "King", true, 2));
        hotel.AddRoom(new Suite(201, 300m, true, 50, true, 3));

        Customer customer1 = new Customer(1, "John Doe");
        hotel.AddCustomer(customer1);

        Booking booking1 = new Booking(1, customer1, hotel.Rooms[0], DateTime.Now, DateTime.Now.AddDays(2), "Active");
        hotel.BookRoom(booking1);
    }
}

