using System;
using DomainModel;

namespace BusinessLogic
{
    public class User : DomainModel.IUser
    {
        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }
        
        public int GetId()
        {
            return Id;
        }

        public string GetUsername()
        {
            return Username;
        }

        private readonly int Id;
        private readonly string Username;
    }
}