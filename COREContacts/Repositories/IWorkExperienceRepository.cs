using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Data
{
    public interface IWorkExperienceRepository
    {
        List<WorkExperience> GetAllWorkExperiences();
        WorkExperience GetWorkExperienceById(int id);
        void AddWorkExperience(WorkExperience workExperience);
        void UpdateWorkExperience(WorkExperience workExperience);
        void DeleteWorkExperience(int id);
    }
}
