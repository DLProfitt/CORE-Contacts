﻿using COREContacts.Models;

namespace COREContacts.Repositories
{
    public interface IObjectiveRepository
    {
        Objective GetObjective(int id);
        void AddObjective(Objective objective);
        void UpdateObjective(Objective objective);
        void DeleteObjective(int id);
    }
}
