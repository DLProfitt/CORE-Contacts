using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Data
{
    public interface IPersonalInformationRepository
    {
        PersonalInformation Get(int id);
        void Add(PersonalInformation personalInformation);
        void Update(PersonalInformation personalInformation);
        void Delete(int id);
    }
}
