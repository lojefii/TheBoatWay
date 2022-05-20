using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Resume> Resumes { get; }
        IRepository<Vacancy> Vacancies { get; }
        IRepository<User> Users { get; }
        void DeleteDB();
    }
}