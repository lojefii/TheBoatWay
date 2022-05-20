using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
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