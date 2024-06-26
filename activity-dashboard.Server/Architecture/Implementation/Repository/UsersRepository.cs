﻿using activity_dashboard.Server.Architecture.DbModels;
using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class UsersRepository : IUserRepository
    {
        static List<Users> usersData;
        private static readonly string[] randomNames = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        static UsersRepository()
        {
            usersData = new List<Users>();
            for (int i = 1; i <= 10; i++)
            {
                usersData.Add(new Users
                {
                    Id = i,
                    UserName = "User_" + i,
                    Password = "Password_" + i,
                    Name = randomNames[new Random().Next(randomNames.Length)]
                });
            }
        }

        public Users UserLogin(TokenRequest tokenRequest)
        {
            return usersData.SingleOrDefault(x => x.UserName.ToLower() == tokenRequest.Email.ToLower()
            && x.Password == tokenRequest.Password);
        }

        public List<Users> GetAllUsers()
        {
            return usersData;
        }
    }
}
