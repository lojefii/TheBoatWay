using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IVacancyLogic
    {
        Task AddVacancy(Vacancy NewVacancy);
        Task EditVacancy(int Id, Vacancy vacancy);
        IEnumerable<Vacancy> GetAllVacancysTemplates();
        Task<Vacancy> GetVacancy(int Id);
        Task DeleteVacancy(int Id);
    }
}
