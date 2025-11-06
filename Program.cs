using System.Diagnostics;
using System.Runtime.CompilerServices;
using HSM;

MenuOptions menuOptions = new();
List<User> users = new();

users.Add(new User("test", "test"));
users[0].Permissions.Add(EmployPermissions.Admin);

User? activeUser = null;

bool running = true;

while (running)
{
    if (activeUser == null)
    {
        ClearText();
        Console.Write("Enter your username: ");
        string? usernameInput = Console.ReadLine();
        Debug.Assert(usernameInput != null);
        Console.Write("Enter you password: ");
        string? passwordInput = Console.ReadLine();
        Debug.Assert(passwordInput != null);

        if (string.IsNullOrWhiteSpace(usernameInput) || string.IsNullOrWhiteSpace(passwordInput))
        {
            try { Console.Clear(); } catch { }
            System.Console.WriteLine("Invalid Input");
            Console.Write("Press Enter");
            Console.ReadLine();
            break;
        }

        activeUser = users.Find(u => u.Username == usernameInput && u.Password == passwordInput);
    }
    else
    {
        ClearText();
        System.Console.WriteLine($"Welcome {activeUser.Username}");
        Dictionary<string, EmployPermissions> LoggedinMenu = new();
        int index = 1;
        foreach (EmployPermissions em_per in activeUser.Permissions)
        {
            LoggedinMenu[index.ToString()] = em_per;
            string MenuText = $"[{index}] - {em_per}";

            System.Console.WriteLine(MenuText);
            index += 1;
        }
        LoggedinMenu[index.ToString()] = EmployPermissions.Logout;
        System.Console.WriteLine($"[{index}] - Logout");
        index += 1;
        LoggedinMenu[index.ToString()] = EmployPermissions.Quit;
        System.Console.WriteLine($"[{index}] - Quit");

        string? menuInput = Console.ReadLine();
        Debug.Assert(menuInput != null);
        switch (LoggedinMenu[menuInput])
        {
            case EmployPermissions.Menu:
                ClearText();
                System.Console.WriteLine("Menu");
                Console.ReadLine();
                break;
            case EmployPermissions.Management:
                ClearText();
                System.Console.WriteLine("Management menu");
                Console.ReadLine();
                break;
            case EmployPermissions.Admin:
                ClearText();
                System.Console.WriteLine("+-----------------------+");
                System.Console.WriteLine("|       Admin menu:     |");
                System.Console.WriteLine("+-----------------------+");
                System.Console.WriteLine("|                       |");
                System.Console.WriteLine("|[1] Change Permissions |");
                System.Console.WriteLine("|[2] Create new employ  |");
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                switch (Console.ReadLine())
                {
                    case "1":
                        ClearText();
                        menuOptions.ChangePermissions(activeUser.Permissions, users);
                        break;
                    case "2":
                        ClearText();
                        menuOptions.CreateNewUser();
                        break;
                }
                Console.ReadLine();
                break;
            case EmployPermissions.Logout:
                activeUser = null;
                break;
            case EmployPermissions.Quit:
                running = false;
                break;
            default:
                break;
        }
    }
}

static void ClearText()
{
    try { Console.Clear(); } catch { }
}
