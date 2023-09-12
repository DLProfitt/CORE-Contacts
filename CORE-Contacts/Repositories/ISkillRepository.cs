using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Repositories
{
    public interface ISkillRepository
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
