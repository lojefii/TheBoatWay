using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Vacancy
    {
        public Vacancy(int userId, string position, string experience, string salary)
        {
            UserId = userId;
            Position = position;
            Experience = experience;
            Salary = salary;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
    }
}