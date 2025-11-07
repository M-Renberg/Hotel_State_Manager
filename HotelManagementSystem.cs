using System.Diagnostics;

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
                System.Console.WriteLine("Write the floor number you would like to edit:");
                int floorSelect = int.Parse(Console.ReadLine()!);
                System.Console.WriteLine($"You have selected floor {floorSelect}");
                System.Console.WriteLine("Select a room you would like to edit:");
                int roomSelect = int.Parse(Console.ReadLine()!);

                System.Console.WriteLine($"You have selected room {Hotel[floorSelect][roomSelect].RoomName}");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("What would you like to edit?");
                System.Console.WriteLine("[1] Room name");
                System.Console.WriteLine("[2] Number of beds and type");
                System.Console.WriteLine("[3] Price of the room");
                System.Console.WriteLine("[4] Room status");
                string? inputroom = Console.ReadLine();
                switch (inputroom)
                {
                    case "1":
                        System.Console.WriteLine("What would you like the new name to be?");
                        string? newRoomName = Console.ReadLine();
                        if (newRoomName != null)
                        {
                            Hotel[floorSelect][roomSelect].RoomName = newRoomName;
                            System.Console.WriteLine("The room name has now been changed");
                            System.Console.WriteLine($"New room name: {Hotel[floorSelect][roomSelect].RoomName}");
                            Console.Write("Press ENTER to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid input");
                            Console.ReadKey();
                            break;
                        }
                        break;
                    case "2":
                        System.Console.WriteLine("What type of beds do you want the room to have?");
                        System.Console.WriteLine("[1] Twin");
                        System.Console.WriteLine("[2] Full");
                        System.Console.WriteLine("[3] Queen");
                        System.Console.WriteLine("[4] King");
                        string? inputbed = Console.ReadLine();
                        switch (inputbed)
                        {
                            case "1":
                                System.Console.WriteLine("How many bed do you want the room to have?");
                                int bedSelect = int.Parse(Console.ReadLine()!);
                                Hotel[floorSelect][roomSelect].Beds = bedSelect;
                                Hotel[floorSelect][roomSelect].bedtype = HotelRoom.BedType.Twin;

                                System.Console.WriteLine($"Room {Hotel[floorSelect][roomSelect]}");
                                System.Console.WriteLine($"Beds has been update to: {Hotel[floorSelect][roomSelect].Beds}");
                                System.Console.WriteLine($"Type of bed has been updated to:{Hotel[floorSelect][roomSelect].bedtype}");
                                break;
                            case "2":
                                break;
                            case "3":
                                break;
                            case "4":
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }


                break;
        }

        
    }

    public void Booking(HotelRoom[][] Hotel)
    {
        
    }

}