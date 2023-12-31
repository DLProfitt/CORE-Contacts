﻿using COREContacts.Models;
using System.Collections.Generic;

namespace COREContacts.Data
{
    public interface IResumeRepository
    {
        Resume GetResume(int id);
        List<Resume> GetAllResumes();
        void AddResume(Resume resume);
        void UpdateResume(Resume resume);
        void DeleteResume(int id);
    }
}
