using RefactorResume.Models;
using System.Collections.Generic;

namespace RefactorResume.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
