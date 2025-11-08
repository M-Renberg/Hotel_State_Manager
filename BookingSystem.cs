namespace HSM;

class BookingSystem
{

    public List<Booking> Bookings = new();
    public HotelRoom[][] Hotel;

    public BookingSystem(HotelRoom[][] hotel)
    {
        Hotel = hotel;
    }

    public bool IsRoomAvailable(int floor, int room, DateTime checkIn, DateTime checkOut)
    {
        foreach (var booking in Bookings)
        {
            if (booking.Floor == floor && booking.Room == room)
            {
                if (checkIn < booking.Checkout && booking.CheckIn < checkOut)
                {
                    return false;

                }
            }
        }
        return true;
    }

    public void RoomBooking()
    {
        System.Console.WriteLine("Select the floor you would like to do the booking on: ");
        int floor = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Select the room you would like to book");
        int room = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the check in date:");
        Console.Write("YYYY-MM-DD");
        DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the check out date:");
        Console.Write("YYYY-MM-DD");
        DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

        if (IsRoomAvailable(floor, room, checkIn, checkOut))
        {
            Bookings.Add(new Booking(floor, room, checkIn, checkOut));
            System.Console.WriteLine("The room has now been booked");
        }
        else
        {
            System.Console.WriteLine("Error:");
            System.Console.WriteLine("Something went wrong or the room is unavailable");
        }
    }

    public void ShowBookings()
    {
        if (Bookings.Count == 0)
        {
            System.Console.WriteLine("No rooms are booked");
        }
        else
        {
            foreach(var booking in Bookings)
            {
                System.Console.WriteLine($"Floor: {booking.Floor}, Room: {booking.Room}, Dates: {booking.CheckIn:yyyy-MM-dd} - {booking.Checkout:yyyy-MM-dd}");
            }
        }
    }

}