using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AISDemoApp
{
    public class DBService
    {
        private readonly Context _context;

        public DBService(Context context)
        {
            _context = context;
        }
        public void saveInventory(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            _context.SaveChanges();
        }
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

    }
}
