using System.Text.Json;
namespace HSM;

class FileHandler
{
    public string dataDir;
    public string userData;
    public string hotelData;
    public string bookingData;

    public FileHandler()
    {
        dataDir = Path.Combine(Directory.GetCurrentDirectory(), "data");
        userData = Path.Combine(dataDir, "User.json");
        hotelData = Path.Combine(dataDir, "Hotel.json");
        bookingData = Path.Combine(dataDir, "Booking.json");

        // Se till att mappen finns
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);
    }

    public void LoadUser(ref List<User> users)
    {
        if (!File.Exists(userData)) return;

        string json = File.ReadAllText(userData);
        if (string.IsNullOrWhiteSpace(json)) return;

        var loaded = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions { IncludeFields = true });
        if (loaded == null) return;

        users.Clear();
        users.AddRange(loaded);
    }

    public void SaveUser(ref List<User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(userData, json);
    }

    public HotelRoom[][] LoadHotel()
    {
        if (!File.Exists(hotelData)) return Array.Empty<HotelRoom[]>();

        string json = File.ReadAllText(hotelData);
        if (string.IsNullOrWhiteSpace(json)) return Array.Empty<HotelRoom[]>();

        var loaded = JsonSerializer.Deserialize<HotelRoom[][]>(json, new JsonSerializerOptions { IncludeFields = true });
        return loaded ?? Array.Empty<HotelRoom[]>();
    }

    public void SaveHotel(HotelRoom[][] hotel)
    {
        string json = JsonSerializer.Serialize(hotel, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(hotelData, json);
    }

    public void LoadBooking(ref List<Booking> bookings)
    {
        if (!File.Exists(bookingData)) return;

        string json = File.ReadAllText(bookingData);
        if (string.IsNullOrWhiteSpace(json)) return;

        var loaded = JsonSerializer.Deserialize<List<Booking>>(json, new JsonSerializerOptions { IncludeFields = true });
        if (loaded == null) return;

        bookings.Clear();
        bookings.AddRange(loaded);
    }

    public void SaveBooking(ref List<Booking> bookings)
    {
        string json = JsonSerializer.Serialize(bookings, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(bookingData, json);
    }
}
