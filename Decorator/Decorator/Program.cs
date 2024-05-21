using System;

public interface IPlayerProfile
{
    string GetDetails();
}

public class BasicPlayerProfile : IPlayerProfile
{
    private string Username;
    private string PreferiraneIgre;
    private string SkillLevel;
    private string PreferredGameModes;
    private string TimeZone;

    public BasicPlayerProfile(string username, string preferredGames, string skillLevel, string preferredGameModes, string timeZone)
    {
        Username = username;
        PreferiraneIgre = preferredGames;
        SkillLevel = skillLevel;
        PreferredGameModes = preferredGameModes;
        TimeZone = timeZone;
    }

    public string GetDetails()
    {
        return $"Username: {Username}, \nPreferirane igre: {PreferiraneIgre}, \nNivo vestine: {SkillLevel}, \nPreferirani rezim igre: {PreferredGameModes}, \nVremenska zona: {TimeZone}";
    }
}


public class ContactInfoDecorator : IPlayerProfile
{
    private IPlayerProfile PlayerProfile;
    private string Email;
    private string BrojTelefona;

    public ContactInfoDecorator(IPlayerProfile playerProfile, string email, string phoneNumber)
    {
        PlayerProfile = playerProfile;
        Email = email;
        BrojTelefona = phoneNumber;
    }

    public string GetDetails()
    {
        return $"{PlayerProfile.GetDetails()}, \nEmail: {Email}, \nBroj Telefona: {BrojTelefona}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        IPlayerProfile basicProfile = new BasicPlayerProfile("Igrac", "Fifa, UFC", "Odlican", "Sport", "GMT+1");

       
        IPlayerProfile extendedProfile = new ContactInfoDecorator(basicProfile, "igrac@gmail.com", "064444213");

       
        Console.WriteLine("Basic Profil:");
        Console.WriteLine(basicProfile.GetDetails());

        Console.WriteLine("\nDecorattor Profil:");
        Console.WriteLine(extendedProfile.GetDetails());
    }
}
