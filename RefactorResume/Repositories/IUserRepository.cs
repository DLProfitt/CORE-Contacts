using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
