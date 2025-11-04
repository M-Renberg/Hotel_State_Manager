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
        Console.Write("Enter you password");
        string? passwordInput = Console.ReadLine();

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
    }
}
