using RefactorResume.Models;

namespace RefactorResume.Data
{
    public interface IResumeSectionRepository
    {
        List<ResumeSection> GetAll();
        ResumeSection Get(int id);
        void Add(ResumeSection resumeSection);
        void Update(ResumeSection resumeSection);
        void Delete(int id);
    }
}
