using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int id);
    }
}
