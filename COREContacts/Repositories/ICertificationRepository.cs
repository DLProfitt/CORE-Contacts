using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Data
{
    public interface ICertificationRepository
    {
        List<Certification> GetAllCertifications();
        Certification GetCertificationById(int id);
        void AddCertification(Certification certification);
        void UpdateCertification(Certification certification);
        void DeleteCertification(int id);
    }
}
