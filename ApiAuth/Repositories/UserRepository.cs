using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>()
            {
                new User { Id = 1, Username = "yuri", Password = "teste", Role = "manager" },
                new User { Id = 1, Username = "magna", Password = "magna", Role = "employee" }
            };

            return users
                .FirstOrDefault(u => 
                     u.Username.ToLower() == username.ToLower() && 
                     u.Password == password)!;
        }
    }
}