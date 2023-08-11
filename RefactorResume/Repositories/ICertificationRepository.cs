using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Data
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
