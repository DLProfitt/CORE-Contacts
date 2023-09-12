using COREContacts.Models;

namespace COREContacts.Data
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetEducations();
        Education GetEducationById(int id);
        void AddEducation(Education education);
        void UpdateEducation(Education education);
        void DeleteEducation(int id);
    }
}
