using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using System;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext context;
        private IRepository<Resume> resumes;
        private IRepository<Vacancy> vacancies;
        private IRepository<User> users;
        public IRepository<Resume> Resumes
        {
            get
            {
                if (resumes == null)
                    resumes = new GenericRepository<Resume>(context);
                return resumes;
            }
        }

        public IRepository<Vacancy> Vacancies
        {
            get
            {
                if (vacancies == null)
                    vacancies = new GenericRepository<Vacancy>(context);
                return vacancies;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (users == null)
                    users = new GenericRepository<User>(context);
                return users;
            }
        }

        public void DeleteDB()
        {
            context.Database.Delete();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}