using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public interface IWorkExperienceRepository
    {
        List<WorkExperience> GetAllWorkExperiences();
        void AddWorkExperience(WorkExperience workExperience);
        void UpdateWorkExperience(WorkExperience workExperience);
        void DeleteWorkExperience(int id);
    }
}
