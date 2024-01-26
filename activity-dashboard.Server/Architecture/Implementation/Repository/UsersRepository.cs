using activity_dashboard.Server.Architecture.DbModals;
using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class UsersRepository : Architecture.Services.IRepository.IUserRepository
    {
        static IList<Users> usersData;
        static UsersRepository()
        {
            usersData = new List<Users>();
            for (int i = 0; i <= 10; i++)
            {
                usersData.Add(new Users { UserName = "User_" + i, Password = "Password_" + 1 });
            }            
        }

        public Users UserLogin(TokenRequest tokenRequest)
        {
            return usersData.SingleOrDefault(x => x.UserName.ToLower() == tokenRequest.Email.ToLower()
            && x.Password == tokenRequest.Password);
        }
    }
}
