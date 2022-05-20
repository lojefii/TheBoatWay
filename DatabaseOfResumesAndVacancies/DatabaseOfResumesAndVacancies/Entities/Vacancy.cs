using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
    }
}