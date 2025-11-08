namespace HSM;

class Booking
{
    public int Floor;
    public int Room;
    public DateTime CheckIn;
    public DateTime Checkout;

    public Booking(int floor, int room, DateTime checkIn, DateTime checkOut)
    {
        Floor = floor;
        Room = room;
        CheckIn = checkIn;
        Checkout = checkOut;
    }
}