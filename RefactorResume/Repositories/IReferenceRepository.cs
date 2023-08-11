using RefactorResume.Models;

namespace RefactorResume.Repositories
{
    public interface IReferenceRepository
    {
        Reference GetReferenceById(int id);
        void AddReference(Reference reference);
        void UpdateReference(Reference reference);
        void DeleteReference(int id);
    }
}
