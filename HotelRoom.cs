namespace HSM;

class HotelRoom
{

    public string? RoomName;
    public int Beds;
    public int Price;
    public RoomStatus roomstatus;
    public BedType bedtype;

    
    

    public HotelRoom(string roomname, int beds, int price, RoomStatus status, BedType typeofbed)
    {

        roomstatus = status;
        bedtype = typeofbed;
    }

    public enum RoomStatus
    {
        Available,
        Unavailable,
        Booked,
        Cleaning,
        Renovation,
    }
    public enum BedType
    {
        Twin,
        Full,
        Queen,
        King,
    }
}