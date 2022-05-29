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
        public UnitOfWork()
        {
            //this.context = new DatabaseContext();
        }

        public IRepository<Resume> Resumes
        {
            get
            {
                if (resumes == null)
                {
                    resumes = new GenericRepository<Resume>(new DatabaseContext());
                }
                return resumes;
            }
        }
        public IRepository<Vacancy> Vacancies
        {
            get
            {
                if (vacancies == null)
                {
                    vacancies = new GenericRepository<Vacancy>(new DatabaseContext());
                }
                return vacancies;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (users == null)
                {
                    users = new GenericRepository<User>(new DatabaseContext());
                }
                return users;
            }
        }
        public void DeleteDB()
        {
            new DatabaseContext().Database.Delete();
        }
        private bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    new DatabaseContext().Dispose();
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