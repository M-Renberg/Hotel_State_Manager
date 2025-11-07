using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace HSM;



class MenuOptions
{

    public HotelRoom[][]? Hotel;


    public void ChangePermissions(List<EmployPermissions> permissions, List<User> users)
    {
        foreach (User user in users)
        {
            Console.WriteLine($"[{user.Username}]");
        }
        Console.WriteLine("------------------");
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        //Debug.Assert(ssn != null);
        User? user_edit = users.Find(u => u.Username == username);
        if (user_edit != null)
        {
            bool editing = true;
            while (editing)
            {
                Console.Clear();
                Console.WriteLine($"{user_edit.Username}'s permissions");
                EmployPermissions[] permissions_all = Enum.GetValues<EmployPermissions>();
                int option_max_num = 0;
                for (int i = 0; i < permissions_all.Length; ++i)
                {
                    EmployPermissions permissions1 = permissions_all[i];
                    if (permissions1 != EmployPermissions.Logout && permissions1 != EmployPermissions.Quit)
                    {
                        Console.WriteLine($"[{i + 1}] - {permissions1} \t is allowed: {user_edit.PermissionLevel(permissions1)}");
                        option_max_num += 1;
                    }
                }
                Console.WriteLine($"[1 - {option_max_num}] - toggle the permission");
                Console.WriteLine("[f] - finish editing");
                string? selected_option = Console.ReadLine();
                //Debug.Assert(selected_option != null);
                if (selected_option == "f")
                {
                    editing = false;
                }
                else if (int.TryParse(selected_option, out int selected_index))
                {
                    EmployPermissions permissions2 = permissions_all[selected_index - 1];
                    if (permissions2 != EmployPermissions.Logout && permissions2 != EmployPermissions.Quit)
                    {
                        user_edit.PermissionToggle(permissions2);
                    }
                }
            }
        }
    }

    public void CreateNewUser()
    {
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|  Create new employ  |");
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter first name:  |");
        System.Console.WriteLine("+---------------------+");
        Console.Write("        ");
        string? newFirstName = Console.ReadLine();
        Debug.Assert(newFirstName != null);
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter last name:   |");
        Console.Write("        ");
        string? newLastName = Console.ReadLine();
        Debug.Assert(newLastName != null);
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter birthday:    |");
        Console.Write("        ");
        string? newBirstday = Console.ReadLine();
        Debug.Assert(newBirstday != null);
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter adress:      |");
        Console.Write("        ");
        string? newAdress = Console.ReadLine();
        Debug.Assert(newAdress != null);
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter email:       |");
        Console.Write("        ");
        string? newEmail = Console.ReadLine();
        Debug.Assert(newEmail != null);
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Enter phonenumber  |");
        Console.Write("        ");
        string? newPhonenumber = Console.ReadLine();
        Debug.Assert(newPhonenumber != null);
        System.Console.WriteLine("+---------------------+");
        Console.ReadLine();

        string newUsernameNumbers = "";
        Random rnd = new();
        string numbers = "1234567890";
        for (int i = 0; i < 4; i++)
        {
            newUsernameNumbers += numbers[rnd.Next(0, numbers.Length - 1)];
        }
        string? newUsername = newFirstName + newUsernameNumbers;

        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Employ username:   |");
        System.Console.WriteLine($"|  {newUsername}      |");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("+---------------------+");
        string? newPassword = newLastName;
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("|  Employ password:   |");
        System.Console.WriteLine($"|  {newPassword}      |");
        System.Console.WriteLine("|                     |");
        System.Console.WriteLine("+---------------------+");
        System.Console.WriteLine("|  [Y] to confime     |");
        System.Console.WriteLine("|  [N] to Cancel      |");
        System.Console.WriteLine("+---------------------+");
        string? ynSelect = Console.ReadLine();
        ynSelect = ynSelect!.ToUpper();
        switch (ynSelect)
        {
            case "Y":

                if (int.TryParse(newBirstday, out int newBirstdayInt) && int.TryParse(newPhonenumber, out int newPhonenumberInt))
                {
                    User newUser = new User(newUsername, newPassword!);
                    newUser.userContactInfo.Add(new ContactInfo(newFirstName, newLastName, newBirstdayInt, newAdress, newEmail, newPhonenumberInt));
                    newUser.Permissions.Add(EmployPermissions.Menu);
                }
                else
                {
                    System.Console.WriteLine("Something went wrong");
                    System.Console.WriteLine("Please try again");
                    Console.ReadLine();
                    break;
                }
                break;
            case "N":
                System.Console.Write("Press ENTER to cancel");
                Console.ReadKey();
                break;
            default:
                System.Console.WriteLine("Somthing went wrong please try again later");
                System.Console.Write("Press ENTER to continue:");
                Console.ReadKey();
                break;
        }

    }

    public void HotelRoomSetup()
    {
        bool setuprunning = true;
        while (setuprunning)
        {
            ClearText();
            System.Console.WriteLine("Hotel setup:");
            System.Console.WriteLine("[1] Setup a new Hotel");
            System.Console.WriteLine("[2] View current hotel");
            System.Console.WriteLine("[3] Edit current Hotel size");
            System.Console.WriteLine("[4] Set default value on rooms");
            System.Console.WriteLine("[5] FAQ");
            System.Console.WriteLine("[6] Exit");
            string? hsSelect = Console.ReadLine();
            Debug.Assert(hsSelect != null);
            switch (hsSelect)
            {
                case "1":
                    ClearText();
                    System.Console.WriteLine("How many floors are the hotel?");
                    System.Console.WriteLine("including the ground floor");
                    int floors = int.Parse(Console.ReadLine()!);
                    Hotel = new HotelRoom[floors][];

                    for (int i = 0; i < Hotel.Length; i++)
                    {
                        System.Console.WriteLine($"How many rooms do you want floor {i} to have?");
                        int rooms = int.Parse(Console.ReadLine()!);

                        Hotel[i] = new HotelRoom[rooms];
                    }
                    System.Console.WriteLine("Your hotel is now created");
                    System.Console.Write("Press ENTER to continue");
                    Console.ReadLine();
                    break;
                case "2":
                    ClearText();
                    if (Hotel == null)
                    {
                        System.Console.WriteLine("You have not created a hotel yet.");
                        Console.ReadLine();
                    }
                    else
                    {
                        for (int floor = 0; floor < Hotel.Length; floor++)
                        {
                            System.Console.WriteLine($"Floor {floor}: {Hotel[floor].Length} rooms");
                        }
                    }

                    Console.ReadLine();
                    break;
                case "3":
                    ClearText();
                    if (Hotel == null)
                    {
                        System.Console.WriteLine("You have not created a hotel yet");
                    }
                    else
                    {
                        System.Console.WriteLine("Your current hotel size:");
                        for (int i = 0; i < Hotel.Length; i++)
                        {
                            Console.WriteLine($"Floor number {i}, Rooms: {Hotel[i].Length}");

                        }
                        System.Console.WriteLine("What would you like to change:");
                        System.Console.WriteLine("[1] number of floors");
                        System.Console.WriteLine("[2] number of rooms on a floor");
                        string? editSelect = Console.ReadLine();
                        switch (editSelect)
                        {
                            case "1":
                                ClearText();
                                System.Console.WriteLine("How many floors do you want the hotel to have?");
                                System.Console.WriteLine("Including the ground floor");
                                int newfloors = int.Parse(Console.ReadLine()!);

                                Hotel = new HotelRoom[newfloors][];

                                for (int i = 0; i < Hotel.Length; i++)
                                {
                                    System.Console.WriteLine($"How many rooms do you want floor {i} to have?");
                                    int rooms = int.Parse(Console.ReadLine()!);

                                    Hotel[i] = new HotelRoom[rooms];
                                }

                                System.Console.WriteLine("Your new hotel:");

                                for (int i = 0; i < Hotel.Length; i++)
                                {
                                    Console.WriteLine($"Floor number {i}, Rooms: {Hotel[i].Length}");

                                }
                                Console.ReadLine();
                                break;
                            case "2":
                                ClearText();
                                System.Console.WriteLine("Select the floor you want to edit:");
                                int selectedFloor = int.Parse(Console.ReadLine()!);

                                System.Console.WriteLine($"You have selected floor {selectedFloor}");
                                System.Console.WriteLine($"This floor has {Hotel[selectedFloor].Length} rooms");
                                System.Console.WriteLine("How many rooms do you want this floor to have?");
                                int Rooms = int.Parse(Console.ReadLine()!);

                                HotelRoom[] newRooms = new HotelRoom[Rooms];

                                for (int i = 0; i < Math.Min(Rooms, Hotel[selectedFloor].Length); i++)
                                {
                                    newRooms[i] = Hotel[selectedFloor][i];
                                }

                                Hotel[selectedFloor] = newRooms;

                                System.Console.WriteLine("Your new hotel:");

                                for (int i = 0; i < Hotel.Length; i++)
                                {
                                    Console.WriteLine($"Floor number {i}, Rooms: {Hotel[i].Length}");

                                }

                                Console.ReadLine();

                                break;
                            default:
                                ClearText();
                                System.Console.WriteLine("Invalid input");
                                Console.ReadLine();
                                break;
                        }

                    }

                    break;
                case "4":
                    ClearText();
                    if(Hotel == null)
                    {
                        System.Console.WriteLine("You have not created a hotel yet.");
                        Console.ReadLine();
                    }
                    else
                    {
                        for (int i = 0; i < Hotel.Length; i++)
                        {
                            for (int j = 0; j < Hotel[i].Length; j++)
                            {
                                Hotel[i][j] = new HotelRoom(
                                roomname: $"{i}0{j}",
                                beds: 1,
                                price: 100,
                                status: HotelRoom.RoomStatus.Available
                                );
                            }
                        }
                        System.Console.WriteLine("Your hotel rooms have now been set with default values");
                        Console.ReadLine();
                    }
                    break;
                case "5":
                    ClearText();
                    System.Console.WriteLine("+------------------------------------+");
                    System.Console.WriteLine("|                  FAQ               |");
                    System.Console.WriteLine("+------------------------------------+");
                    System.Console.WriteLine("|                                    |");
                    System.Console.WriteLine("| Use the setup to start a new hotel |");
                    System.Console.WriteLine("| After setup you can edit the hotel |");
                    System.Console.WriteLine("|                                    |");
                    System.Console.WriteLine("| The default values are:            |");
                    System.Console.WriteLine("| Room name: floor nr + 0 + room nr  |");
                    System.Console.WriteLine("| Beds: 1                            |");
                    System.Console.WriteLine("| Price: 100                         |");
                    System.Console.WriteLine("| Room status: Available             |");
                    System.Console.WriteLine("|                                    |");
                    System.Console.WriteLine("| A manager can edit this later      |");
                    System.Console.WriteLine("|                                    |");
                    System.Console.WriteLine("+------------------------------------+");
                    System.Console.WriteLine(" ");
                    Console.Write("Press ENTER to continue");
                    Console.ReadLine();
                    break;
                case "6":
                    ClearText();
                    setuprunning = false;
                    System.Console.WriteLine("Press ENTER to continue");
                    break;
                default:
                    ClearText();
                    System.Console.WriteLine("Invalid input");
                    Console.Write("Press ENTER to continue");
                    Console.ReadLine();
                    break;
            }
        }

    }



static void ClearText()
{
    try { Console.Clear(); } catch { }
}

}

