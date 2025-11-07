namespace HSM;

class HotelRoom
{

    public string? RoomName;
    public int Beds;
    public int Price;
    public RoomStatus roomstatus;

    
    

    public HotelRoom(string roomname, int beds, int price, RoomStatus status)
    {

        roomstatus = status;
    }

    public enum RoomStatus
    {
        Available,
        Unavailable,
        Booked,
        Cleaning,
    }
}