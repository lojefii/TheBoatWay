using BussinesLogic.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Conroller : ControllerBase
    {
        private readonly ILogger<Conroller> _logger;

        private readonly IResumeLogic resumeLogic;

        private readonly IUserLogic userLogic;

        private readonly IVacancyLogic vacancyLogic;


        public Conroller(ILogger<Conroller> logger, IUserLogic userLogic, IVacancyLogic vacancyLogic, IResumeLogic resumeLogic)
        {
            _logger = logger;
            this.userLogic = userLogic;
            this.vacancyLogic = vacancyLogic;
            this.resumeLogic = resumeLogic;
        }

        [HttpPost]
        [Route("user")]
        public async Task CreateUser(User user)
        {
            await this.userLogic.AddUser(user).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("user")]
        public async Task DeleteUser(int id)
        {
            await this.userLogic.DeleteUser(id).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("user")]
        public async Task UpdateUser(int id, User user)
        {
            await this.userLogic.EditUser(id, user).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("login")]
        public async Task<User> Login(string login, string password)
        {
            var res = this.userLogic.Login(login, password);
            return res;
        }

        [HttpGet]
        [Route("resume")]
        public async Task<Resume> GetResume(int id)
        {

            var res = await this.resumeLogic.GetResume(id).ConfigureAwait(false);
            return res;
        }

        [HttpGet]
        [Route("resumes")]
        public async Task<IEnumerable<Resume>> GetResumes(User user)
        {
            var res = user.UserType == UserType.Manager ? this.resumeLogic.GetAllResumes() : null;
            return res;
        }

        [HttpDelete]
        [Route("resume")]
        public async Task DelereResume(User user, int id)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.resumeLogic.DeleteResume(id).ConfigureAwait(false);
            }
        }

        [HttpPut]
        [Route("resume")]
        public async Task UpdateResume(User user, int id, Resume resume)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.resumeLogic.EditResume(id, resume).ConfigureAwait(false);
            }
        }

        [HttpPost]
        [Route("resume")]
        public async Task CreateResume(User user, Resume resume)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.resumeLogic.AddResume(resume).ConfigureAwait(false);
            }
        }

        [HttpGet]
        [Route("vacancy")]
        public async Task<Vacancy> GetVacancy(int id)
        {
            var res = await this.vacancyLogic.GetVacancy(id).ConfigureAwait(false);
            return res;
        }

        [HttpGet]
        [Route("vacancies")]
        public async Task<IEnumerable<Vacancy>> GetVacancys(User user)
        {
            var res = user.UserType == UserType.User ? this.vacancyLogic.GetAllVacancysTemplates() : null;
            return res;
        }

        [HttpDelete]
        [Route("vacancy")]
        public async Task DelereVacancy(User user, int id)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.resumeLogic.DeleteResume(id).ConfigureAwait(false);
            }
        }

        [HttpPut]
        [Route("vacancy")]
        public async Task UpdateVacancy(User user, int id, Vacancy vacancy)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.vacancyLogic.EditVacancy(id, vacancy).ConfigureAwait(false);
            }
        }

        [HttpPost]
        [Route("vacancy")]
        public async Task CreateVacancy(User user, Vacancy vacancy)
        {
            if (user.UserType == UserType.Manager)
            {
                await this.vacancyLogic.AddVacancy(vacancy).ConfigureAwait(false);
            }
        }
    }
}
