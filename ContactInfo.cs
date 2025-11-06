namespace HSM;

class ContactInfo
{

    public string Firstname;
    public string Lastname;
    public int Birthday;
    public string Adress;
    public string Email;
    public int PhoneNumber;

    public ContactInfo(string firstname, string lastname, int birthday, string adress, string email, int phonenumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        Birthday = birthday;
        Adress = adress;
        Email = email;
        PhoneNumber = phonenumber;
    }

    public override string ToString()
    {
        return $"{Firstname} {Lastname} ({Birthday}) - {Email}, {PhoneNumber}";
    }





}