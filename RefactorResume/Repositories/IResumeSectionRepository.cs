using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IResumeSectionRepository
    {
        ResumeSection Get(int id);
        void Add(ResumeSection resumeSection);
        void Update(ResumeSection resumeSection);
        void Delete(int id);
    }
}
