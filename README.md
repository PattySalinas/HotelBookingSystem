# HotelBookingSystem
[Jalasoft] Dev Fundamentals 1 - Final Project

HOTEL BOOKING SYSTEM
Objective: Develop a console-based Hotel Booking System.

Entities
SingleRoom
• RoomNumber (int): Unique identifier for the room.
• Price (decimal): Price per night.
• IsAvailable (bool): Availability status.
• BedSize (string): Size of the bed (e.g., Twin, Queen).
• HasBalcony (bool): Indicates if the room has a balcony.
DoubleRoom
• RoomNumber (int): Unique identifier for the room.
• Price (decimal): Price per night.
• IsAvailable (bool): Availability status.
• BedSize (string): Size of the bed (e.g., Queen, King).
• HasMiniBar (bool): Indicates if the room has a mini bar.
• NumberOfBeds (int): Number of beds in the room.
Suite
• RoomNumber (int): Unique identifier for the room.
• Price (decimal): Price per night.
• IsAvailable (bool): Availability status.
• LivingAreaSize (double): Size of the living area in square meters.
• HasJacuzzi (bool): Indicates if the room has a jacuzzi.
• NumberOfRooms (int): Number of rooms in the suite.
Booking
• BookingID (int): Unique identifier for the booking.
• Customer (Customer): Customer who made the booking.
• Room (Room): Room that is booked.
• CheckInDate (DateTime): Check-in date.
• CheckOutDate (DateTime): Check-out date.
• Status (string): Describes if a booking is active or not. (Active, Closed).
• TotalPrice (decimal): 
Customer
• CustomerId (int): Unique identifier for the customer.
• Name (string): Name of the customer.

Hotel
• Rooms (List<Room>): List of all rooms.
• Bookings (List<Booking>): List of all bookings.

Menu
• Rooms
  o Add Room
  o Remove Room
  o List rooms
• Customers
  o Add Customer
  o Remove customer
  o List customers
• Booking
  o Book Room
  o Checkout Room
  o List Bookings
  o List Available Rooms
  o List Available Rooms by Bed Size
  o List Past Bookings
• Exit

Menu actions description
• Rooms > Add Room: Ad a room to the hotel.
• Rooms > Remove Room: Remove a hotel from hotel.
	o Can’t remove if booked.
• Rooms > Display all rooms: Display all rooms in the hotel.
• Customers > Add Customer: Add a customer.
• Customers > Remove Customer: Remove a customer.
	o Can’t remove if currently occupying a room.
• Customers > List customers: List all customers.
• Booking > Book Room: Book a room to a customer.
	o Can only book empty rooms.
	o Don’t charge the user yet.
• Booking > Checkout Room: Find a booking for a customer and checkout.
	o Calculate TotalPrice, based on number of nights the customer stayed.
	o Add a fee to the TotalPrice if the user stayed more nights than anticipated. Fee is 50% of the room’s rate.
• Booking > List All Bookings: List occupied rooms.
• Booking > List Available Rooms: List unoccupied rooms.
• Booking > List Available Rooms by Bed Size: User chooses a bed size, then list all unoccupied rooms that have that bed size.
• Booking > List Closed Bookings: List all closed bookings.
• Exit: Terminate the program.

