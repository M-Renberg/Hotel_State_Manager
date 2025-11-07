namespace HSM;

class HotelManagmentSystem
{
    MenuOptions mo = new();

    public void RoomManagement(HotelRoom[][] Hotel)
    {
        System.Console.WriteLine("Your Hotel:");
        for (int i = 0; i < Hotel.Length; i++)
        {
            System.Console.WriteLine($"Floor number {i}, Rooms: {Hotel[i].Length}");
        }

        System.Console.WriteLine("[1] Select a room to edit");

        string? input = Console.ReadLine(); 
        switch (input)
        {
            case "1":
                break;
        }

        
    }

    public void Booking(HotelRoom[][] Hotel)
    {
        
    }

}