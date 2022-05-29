using BussinesLogic.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Logics
{
    public class ResumeLogic : IResumeLogic
    {
        private readonly IUnitOfWork unitOfWork;
        public ResumeLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddResume(Resume NewResume)
        {
            await unitOfWork.Resumes.Add(NewResume);
        }

        public async Task DeleteResume(int Id)
        {
            await unitOfWork.Resumes.Delete(Id);
        }

        public async Task EditResume(int Id, Resume Resume)
        {
            await unitOfWork.Resumes.Modify(Id, Resume);
        }

        public IEnumerable<Resume> GetAllResumes()
        {
            return unitOfWork.Resumes.GetAll();
        }

        public async Task<Resume> GetResume(int Id)
        {
            return await unitOfWork.Resumes.Get(Id).ConfigureAwait(false);
        }
    }
}
