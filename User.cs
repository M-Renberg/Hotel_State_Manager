namespace HSM;

class User
{
    public string? Username;
    public string? Password;
    public List<EmployPermissions> Permissions = new();
    public List<ContactInfo> userContactInfo = new();

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == Password;
    }

    public bool PermissionLevel(EmployPermissions em_per)
    {
        return Permissions.Contains(em_per);
    }

    public void PermissionToggle(EmployPermissions em_per)
    {
        if (Permissions.Contains(em_per))
        {
            Permissions.Remove(em_per);
        }
        else
        {
            Permissions.Add(em_per);
        }
    }
}
