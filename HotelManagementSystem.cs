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
        System.Console.WriteLine("[2] Exit");
        

        string? input = Console.ReadLine(); 
        switch (input)
        {
            case "1":
                System.Console.WriteLine("Write the floor number you would like to edit:");
                int floorSelect = int.Parse(Console.ReadLine()!);
                System.Console.WriteLine($"You have selected floor {floorSelect}");
                System.Console.WriteLine("Select a room you would like to edit:");
                int roomSelect = int.Parse(Console.ReadLine()!);

                bool roomEditing = true;
                while (roomEditing)
                {
                System.Console.WriteLine($"You have selected room {Hotel[floorSelect][roomSelect].RoomName}");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("What would you like to edit?");
                System.Console.WriteLine("[1] Room name");
                System.Console.WriteLine("[2] Number of beds and type");
                System.Console.WriteLine("[3] Price of the room");
                System.Console.WriteLine("[4] Room status");
                System.Console.WriteLine("[5] Exit");
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
                                int bedSelectTwin = int.Parse(Console.ReadLine()!);
                                Hotel[floorSelect][roomSelect].Beds = bedSelectTwin;
                                Hotel[floorSelect][roomSelect].bedtype = HotelRoom.BedType.Twin;

                                System.Console.WriteLine($"Room {Hotel[floorSelect][roomSelect]}");
                                System.Console.WriteLine($"Beds has been update to: {Hotel[floorSelect][roomSelect].Beds}");
                                System.Console.WriteLine($"Type of bed has been updated to:{Hotel[floorSelect][roomSelect].bedtype}");
                                break;
                            case "2":
                                System.Console.WriteLine("How many bed do you want the room to have?");
                                int bedSelectFull = int.Parse(Console.ReadLine()!);
                                Hotel[floorSelect][roomSelect].Beds = bedSelectFull;
                                Hotel[floorSelect][roomSelect].bedtype = HotelRoom.BedType.Twin;

                                System.Console.WriteLine($"Room {Hotel[floorSelect][roomSelect]}");
                                System.Console.WriteLine($"Beds has been update to: {Hotel[floorSelect][roomSelect].Beds}");
                                System.Console.WriteLine($"Type of bed has been updated to:{Hotel[floorSelect][roomSelect].bedtype}");
                                break;
                            case "3":
                                System.Console.WriteLine("How many bed do you want the room to have?");
                                int bedSelectQueen = int.Parse(Console.ReadLine()!);
                                Hotel[floorSelect][roomSelect].Beds = bedSelectQueen;
                                Hotel[floorSelect][roomSelect].bedtype = HotelRoom.BedType.Twin;

                                System.Console.WriteLine($"Room {Hotel[floorSelect][roomSelect]}");
                                System.Console.WriteLine($"Beds has been update to: {Hotel[floorSelect][roomSelect].Beds}");
                                System.Console.WriteLine($"Type of bed has been updated to:{Hotel[floorSelect][roomSelect].bedtype}");
                            break;
                            case "4":
                                System.Console.WriteLine("How many bed do you want the room to have?");
                                int bedSelectKing = int.Parse(Console.ReadLine()!);
                                Hotel[floorSelect][roomSelect].Beds = bedSelectKing;
                                Hotel[floorSelect][roomSelect].bedtype = HotelRoom.BedType.Twin;

                                System.Console.WriteLine($"Room {Hotel[floorSelect][roomSelect]}");
                                System.Console.WriteLine($"Beds has been update to: {Hotel[floorSelect][roomSelect].Beds}");
                                System.Console.WriteLine($"Type of bed has been updated to:{Hotel[floorSelect][roomSelect].bedtype}");
                                    break;
                                case "5":
                                    roomEditing = false;
                                    break;
                            default:
                                System.Console.WriteLine("Invalid Input");
                                Console.ReadKey();
                            break;
                        }
                        break;
                        case "3":
                            System.Console.WriteLine($"Write the price you would like {Hotel[floorSelect][roomSelect].RoomName} to have");
                            System.Console.WriteLine($"Current price of the room is: {Hotel[floorSelect][roomSelect].Price}");
                            System.Console.WriteLine("[1] Change price");
                            System.Console.WriteLine("[2] Exit");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    System.Console.WriteLine("Input the new price you would like the room to have:");
                                    string? newPrice = Console.ReadLine();
                                    if (int.TryParse(newPrice, out int newPriceInt))
                                    {
                                        Hotel[floorSelect][roomSelect].Price = newPriceInt;
                                        System.Console.WriteLine($"The new price of the room is now {Hotel[floorSelect][roomSelect].Price}");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Error");
                                        Console.ReadLine();
                                    }
                                    break;
                                case "2":
                                    break;
                                default:
                                System.Console.WriteLine("Invalid input");
                                    break;
                            }
                        break;
                        case "4":
                            System.Console.WriteLine("Change the status of the room");
                            System.Console.WriteLine("[1] Available");
                            System.Console.WriteLine("[2] Unavailable");
                            System.Console.WriteLine("[3] Booked");
                            System.Console.WriteLine("[4] Cleaning");
                            System.Console.WriteLine("[5] Renovation");
                            System.Console.WriteLine("[6] Exit");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Hotel[floorSelect][roomSelect].roomstatus = HotelRoom.RoomStatus.Available;
                                    System.Console.WriteLine("The status of the room has now been changed");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Hotel[floorSelect][roomSelect].roomstatus = HotelRoom.RoomStatus.Unavailable;
                                    System.Console.WriteLine("The status of the room has now been changed");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Hotel[floorSelect][roomSelect].roomstatus = HotelRoom.RoomStatus.Booked;
                                    System.Console.WriteLine("The status of the room has now been changed");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Hotel[floorSelect][roomSelect].roomstatus = HotelRoom.RoomStatus.Cleaning;
                                    System.Console.WriteLine("The status of the room has now been changed");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    Hotel[floorSelect][roomSelect].roomstatus = HotelRoom.RoomStatus.Renovation;
                                    System.Console.WriteLine("The status of the room has now been changed");
                                    Console.ReadLine();
                                    break;
                                case "6":
                                    break;
                                default:
                                    System.Console.WriteLine("Invalid input");
                                    Console.ReadLine();
                                break;
                            }
                        break;
                    }    
                }
                break;
            case "2":
                break;
            default:
                System.Console.WriteLine("Invalid input");
            break;
        }
    }
}