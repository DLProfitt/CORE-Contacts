using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetEducations();
        Education GetEducationById(int id); // Added method
        void AddEducation(Education education);
        void UpdateEducation(Education education);
        void DeleteEducation(int id);
    }
}
