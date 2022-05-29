using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public User(string name, string surname, UserType userType, string login, string password)
        {
            Name = name;
            Surname = surname;
            UserType = userType;
            Login = login;
            Password = password;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserType UserType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<Resume> Resumes { get; set; }
        public virtual List<Vacancy> Vacancies { get; set; }
    }
}