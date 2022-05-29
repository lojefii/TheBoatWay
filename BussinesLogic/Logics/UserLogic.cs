using BussinesLogic.Exceptions;
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
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork unitOfWork;
        public User CurrentUser;
        public UserLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddUser(User NewUser)
        {
            await unitOfWork.Users.Add(NewUser);
        }

        public async Task DeleteUser(int Id)
        {
            await unitOfWork.Users.Delete(Id);
        }

        public async Task EditUser(int Id, User user)
        {
            await unitOfWork.Users.Modify(Id, user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return unitOfWork.Users.GetAll();
        }

        public async Task<User> GetUser(int Id)
        {
            return await unitOfWork.Users.Get(Id).ConfigureAwait(false);
        }

        public User Login(string Login, string Password)
        {
            CurrentUser = unitOfWork.Users.GetAll(user => user.Login == Login).FirstOrDefault();
            if (CurrentUser == null)
            {
                throw new InvalidLoginPasswordException("Invalid login");
            }
            if (!String.Equals(CurrentUser.Password, Password))
            {
                throw new InvalidLoginPasswordException("Invalid password");
            }
            return CurrentUser;
        }
        public void Logout()
        {
            CurrentUser = null;
        }
        public async void AddResume(Resume NewResume)
        {
            if (CurrentUser == null)
            {
                throw new WrongUserException("Login to add resume");
            }
            if (CurrentUser.UserType != UserType.User)
            {
                throw new WrongUserException("Function availible only for users");
            }
            Resume Resume = new Resume(CurrentUser.Id, NewResume.Position, NewResume.Experience, NewResume.Salary);
            CurrentUser.Resumes.Add(Resume);
            await unitOfWork.Resumes.Add(Resume);
        }
        public async void AddVacancy(Vacancy NewVacancy)
        {
            if (CurrentUser == null)
            {
                throw new WrongUserException("Login to add vacancy");
            }
            if (CurrentUser.UserType != UserType.User)
            {
                throw new WrongUserException("Function availible only for managers");
            }
            Vacancy Vacancy = new Vacancy(CurrentUser.Id, NewVacancy.Position, NewVacancy.Experience, NewVacancy.Salary);
            CurrentUser.Vacancies.Add(Vacancy);
            await unitOfWork.Vacancies.Add(Vacancy);
        }
        public IEnumerable<Vacancy> SearchVacancy(Resume Resume)
        {
            return unitOfWork.Vacancies.GetAll(vacancy => vacancy.Id, vacancy => vacancy.Position == Resume.Position,
                vacancy => vacancy.Experience == Resume.Experience,
                vacancy => vacancy.Salary == Resume.Salary);
        }
        public IEnumerable<Resume> SearchResume(Resume Resume)
        {
            return unitOfWork.Resumes.GetAll(resume => resume.Id, resume => resume.Position == Resume.Position,
                resume => resume.Experience == Resume.Experience,
                resume => resume.Salary == Resume.Salary);
        }
    }
}
