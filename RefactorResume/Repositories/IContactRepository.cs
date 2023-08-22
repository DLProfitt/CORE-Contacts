using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int id);
        Contact GetContact(int id);
        List<Contact> GetContacts();
        void UpdateContact(Contact contact);
    }
}