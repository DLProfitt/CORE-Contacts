using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        void AddContact(Contact contact);
        Contact GetContact(int id);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}