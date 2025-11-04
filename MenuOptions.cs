namespace HSM;

class MenuOptions
{
    






    public void ChangePermissions(List<EmployPermissions> permissions, List<User> users)
    {
        
                foreach(User user in users)
                {
                    Console.WriteLine($"[{user.Username}]");
                }
                Console.WriteLine("------------------");
                Console.Write("Username: ");
                string? username = Console.ReadLine();
                //Debug.Assert(ssn != null);
                User? user_edit = users.Find(u => u.Username == username);
                if(user_edit != null)
                {
                    bool editing = true;
                    while(editing)
                    {
                Console.Clear();
                        Console.WriteLine($"{user_edit.Username}'s permissions");
                        EmployPermissions[] permissions_all = Enum.GetValues<EmployPermissions>();
                        int option_max_num = 0;
                        for(int i = 0; i < permissions_all.Length; ++i)
                        {
                            EmployPermissions permissions1 = permissions_all[i];
                            if(permissions1 != EmployPermissions.Logout && permissions1 != EmployPermissions.Quit)
                            {
                                Console.WriteLine($"[{i + 1}] - {permissions1} \t is allowed: {user_edit.PermissionLevel(permissions1)}");
                                option_max_num += 1;
                            }
                        }
                        Console.WriteLine($"[1 - {option_max_num}] - toggle the permission");
                        Console.WriteLine("[f] - finish editing");
                        string? selected_option = Console.ReadLine();
                        //Debug.Assert(selected_option != null);
                        if(selected_option == "f")
                        {
                            editing = false;
                        }
                        else if(int.TryParse(selected_option, out int selected_index))
                        {
                            EmployPermissions permissions2 = permissions_all[selected_index - 1];
                            if(permissions2 != EmployPermissions.Logout && permissions2 != EmployPermissions.Quit)
                            {
                                user_edit.PermissionToggle(permissions2);
                            }
                        }
                    }
                }
            }
    
}