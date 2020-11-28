using DemoExercise.Context;
using DemoExercise.Context.Entities;
using DemoExercise.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoExercise.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly DemoContext _context;

        public LoginRepository(DemoContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            if(_context.Entry(user).State == EntityState.Detached)
            {
                _context.Attach(user);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddUserHistory(int userId, DateTime dateLogged)
        {
            if (!_context.Users.Any(e => e.Id == userId))
            {
                return;
            }

            var userHistory = new UserLoginHistory
            {
                UserId = userId,
                DateLogged = dateLogged
            };

            await _context.UserLoginHistories.AddAsync(userHistory);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.UserEmail == userName);
        }

        public async Task<List<UserLoginHistory>> GetUserHistories(int userId)
        {
            return await _context.UserLoginHistories.Where(e => e.UserId == userId).ToListAsync();
        }
    }
}