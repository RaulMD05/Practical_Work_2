using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace practical_work_ii
{
    public class UserStore
    {
        private string filePath = "Files\\Users.csv";

        public bool RegisterUser(string name, string username, string email, string password, string confirmPassword, bool acceptedPolicy)
        {
            // Validaciones básicas
            if (name == null || name == "" || username == null || username == "" || email == null || email == "" || password == null || password == "" || confirmPassword == null || confirmPassword == "")
                return (false);

            if (!acceptedPolicy) return (false);

            if (name == username) return (false);

            if (password != confirmPassword) return (false);

            if (!IsValidPassword(password)) return (false);

            // Leer usuarios
            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                string[] existingLines = File.ReadAllLines(filePath);
                foreach (string line in existingLines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length >= 3 && parts[1] == username)
                        return (false); // username ya en uso

                    lines.Add(line); // añadir línea existente
                }
            }

            // Agregar nuevo usuario
            string newUser = $"{name};{username};{email};{password};0";
            lines.Add(newUser);
            File.WriteAllLines(filePath, lines.ToArray());

            return (true);
        }

        private bool IsValidPassword(string password)
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

        public bool LoginUser(string username, string password)
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
