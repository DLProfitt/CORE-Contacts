using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetEducations();
        void AddEducation(Education education);
        void UpdateEducation(Education education);
        void DeleteEducation(int id);
    }
}
