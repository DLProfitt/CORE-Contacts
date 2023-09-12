using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Repositories
{
    public interface IReferenceRepository
    {
        List<Reference> GetAllReferences();
        Reference GetReferenceById(int id);
        void AddReference(Reference reference);
        void UpdateReference(Reference reference);
        void DeleteReference(int id);
    }
}
