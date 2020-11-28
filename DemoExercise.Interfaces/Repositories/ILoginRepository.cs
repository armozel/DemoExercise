using DemoExercise.Context.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoExercise.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string userName);
        Task<List<UserLoginHistory>> GetUserHistories(int userId);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task AddUserHistory(int userId, DateTime dateLogged);
    }
}