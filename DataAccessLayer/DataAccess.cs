using System;
using System.IO;
using System.Text;
using DataAccessLayer.Models;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class DataAccess
    {
        private const string url = "localhost";
        private const string uid = "root";
        private const string pathToPwfile = "root_pw.txt";
        private const string dbName = "shop";
        
        private MySql.Data.MySqlClient.MySqlConnection DbConnection;

        public DataAccess(string connString)
        {
            try
            {

                DbConnection = new MySqlConnection(connString);
                DbConnection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #nullable enable
        public static string GetPassword(string? pathToPw)
        {
            var en = File.ReadLines(pathToPw == null ? pathToPwfile : pathToPw).GetEnumerator();
            en.MoveNext();
            return en.Current;
        }
        #nullable disable

        // usage example 
        private static int Main(string[] args)
        {
            string connectionString = $"server={url};uid={uid};pwd={GetPassword(null)};database={dbName}";

            using (var context = new ShopContext(connectionString))
            {
                var users = context.Users;
                foreach (var user in users)
                {
                    var userLine = new StringBuilder();
                    System.Console.WriteLine($"Id: {user.Id}, First: {user.Firstname}, Last: {user.Lastname}");
                }
            }
            
            return 0;
        }
    }
}