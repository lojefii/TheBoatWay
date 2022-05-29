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
    public class VacancyLogic : IVacancyLogic
    {
        private readonly IUnitOfWork unitOfWork;
        public VacancyLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddVacancy(Vacancy NewVacancy)
        {
            await unitOfWork.Vacancies.Add(NewVacancy);
        }

        public async Task DeleteVacancy(int Id)
        {
            await unitOfWork.Vacancies.Delete(Id);
        }

        public async Task EditVacancy(int Id, Vacancy vacancy)
        {
            await unitOfWork.Vacancies.Modify(Id, vacancy);
        }

        public IEnumerable<Vacancy> GetAllVacancysTemplates()
        {
            return unitOfWork.Vacancies.GetAll();
        }

        public async Task<Vacancy> GetVacancy(int Id)
        {
            return await unitOfWork.Vacancies.Get(Id).ConfigureAwait(false);
        }
    }
}
