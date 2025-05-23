using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace practical_work_ii
{
    public class UserStore
    {
        private string filePath = "Files\\Users.csv";
        public UserStore(){}
        public bool RegisterUser(string name, string username, string email, string password, string confirmPassword, bool acceptedPolicy)//This registers the info sent, on the csv
        {
            if (name == null || name == "" || username == null || username == "" || email == null || email == "" || password == null || password == "" || confirmPassword == null || confirmPassword == "")
                return (false);

            if (!acceptedPolicy) return (false);

            if (name == username) return (false);

            if (password != confirmPassword) return (false);

            if (!IsValidPassword(password)) return (false);//checks if the password is on the correct format as specified

            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                string[] existingLines = File.ReadAllLines(filePath);
                foreach (string line in existingLines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length >= 3 && parts[1] == username)
                        return (false);

                    lines.Add(line);//Adds all the lines to an auxiliary list, which is called lines
                }
            }

            string newUser = $"{name};{username};{email};{password};0";
            lines.Add(newUser);//Adds the new user registered to the list
            File.WriteAllLines(filePath, lines.ToArray());//rewrites all the csv with each line that was before, and the new ones, line by line, converting the strings of the list into arrays, which would be each line

            return (true);
        }

        private bool IsValidPassword(string password)//Checks if the password has digits, Upper case, Lower case, has a symbol, and has at least 8
        {
            if (password.Length < 8) return (false);

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSymbol = true;
            }

            return (hasUpper && hasLower && hasDigit && hasSymbol);
        }

        public bool LoginUser(string username, string password)//Checks the Log In
        {
            if (!File.Exists(filePath)) return false;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 4 && parts[1] == username && parts[3] == password)
                    return (true);
            }
            return (false);
        }

    }
}
