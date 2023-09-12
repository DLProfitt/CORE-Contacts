using COREContacts.Models;

namespace COREContacts.Data
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
