using System.Diagnostics;
using HSM;

List<User> users = new();

users.Add(new User("test", "test"));
users[0].Permissions.Add(EmployPermissions.Admin);

User? activeUser = null;

bool running = true;

while (running)
{
    if (activeUser == null)
    {
        Console.Write("Enter your username:");
        string? usernameInput = Console.ReadLine();
        Debug.Assert(usernameInput != null);
        Console.Write("Enter you password");
        string? passwordInput = Console.ReadLine();
        Debug.Assert(passwordInput != null);

        if (string.IsNullOrWhiteSpace(usernameInput) || string.IsNullOrWhiteSpace(passwordInput))
        {
            System.Console.WriteLine("Invalid Input");
            Console.Write("Press Enter");
            Console.ReadLine();
            break;
        }

        activeUser = users.Find(u => u.Username == usernameInput && u.Password == passwordInput);
    }
    else
    {
        Dictionary<string, EmployPermissions> LoggedinMenu = new();
        int index = 1;
        foreach (EmployPermissions em_per in activeUser.Permissions)
        {
            LoggedinMenu[index.ToString()] = em_per;
            string MenuText = $"[{index}] - ";

            switch (em_per)
            {
                case EmployPermissions.Baseemply:
                    MenuText += "Welcome to the HSM menu:";
                    break;
            }
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
            case EmployPermissions.Baseemply:
                break;
            case EmployPermissions.Management:
                break;
            case EmployPermissions.Admin:
                break;
            case EmployPermissions.Logout:
                break;
            case EmployPermissions.Quit:
                break;
            default:
                break;
        }
    }
}
