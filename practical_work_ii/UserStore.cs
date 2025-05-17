using System;
using System.IO;

namespace practical_work_ii;

public class UserStore
{
    private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "Users.csv");

    public bool RegisterUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "");

        var users = File.ReadAllLines(filePath);
        foreach (var line in users)
        {
            var parts = line.Split(',');
            if (parts.Length == 2 && parts[0] == username)
                return false; // user already exists
        }

        File.AppendAllText(filePath, $"{username},{password}\n");
        return true;
    }

    public bool LoginUser(string username, string password)
    {
        if (!File.Exists(filePath)) return false;

        var users = File.ReadAllLines(filePath);
        foreach (var line in users)
        {
            var parts = line.Split(',');
            if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                return true;
        }

        return false;
    }
}
