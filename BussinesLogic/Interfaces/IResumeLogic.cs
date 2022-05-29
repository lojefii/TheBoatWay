using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IResumeLogic
    {
        Task AddResume(Resume NewResume);
        Task EditResume(int Id, Resume Resume);
        IEnumerable<Resume> GetAllResumes();
        Task<Resume> GetResume(int Id);
        Task DeleteResume(int Id);
    }
}


