using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface IUserLogic
    {
        Task AddUser(User NewUser);
        Task <IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int Id);
        Task DeleteUser(int Id);
        Task EditUser(int Id, User user);
        User Login(string Login, string Password);
    }

}