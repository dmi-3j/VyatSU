using System;
using System.Security.Cryptography;
using System.Text;

namespace ServiceCenter.Classes
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Генерируем соль (теперь с использованием RandomNumberGenerator)
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Создаем хеш с солью
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Комбинируем соль и хеш
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Конвертируем в строку base64
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(enteredPassword))
                return false;

            try
            {
                // Конвертируем хранимый хеш из base64
                byte[] hashBytes = Convert.FromBase64String(storedHash);

                // Извлекаем соль
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                // Хешируем введенный пароль с той же солью
                var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000, HashAlgorithmName.SHA256);
                byte[] hash = pbkdf2.GetBytes(20);

                // Сравниваем хеши
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}