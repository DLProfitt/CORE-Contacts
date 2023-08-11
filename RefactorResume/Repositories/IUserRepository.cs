using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
