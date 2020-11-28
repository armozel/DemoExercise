using DemoExercise.Context.Entities;
using DemoExercise.Interfaces.Repositories;
using DemoExercise.Interfaces.Services;
using DemoExercise.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoExercise.Services
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository  _repository;

        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoginHistoryResultViewModel> GetLoginHistory(string userName)
        {
            var user = await _repository.GetUserByName(userName);

            if (user == null)
            {
                return new LoginHistoryResultViewModel(new List<DateTime>());
            }

            var userHistories = await _repository.GetUserHistories(user.Id);

            return new LoginHistoryResultViewModel(userHistories.Select(e => e.DateLogged).ToList());
        }

        public async Task<UpdateUserDetailsViewModel> GetUserDetails(string userName)
        {
            var existingUser = await _repository.GetUserByName(userName);

            if(existingUser == null)
            {
                return null;
            }

            return new UpdateUserDetailsViewModel
            {
                Id = existingUser.Id,
                UserEmail = existingUser.UserEmail,
                Password = existingUser.Password,
                ConfirmPassword = existingUser.Password,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName
            };
        }

        public async Task<LoginResultViewModel> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await _repository.GetUserByName(loginViewModel.Email);
            
            if(user == null)
            {
                return new LoginResultViewModel(false, "User not found");
            }

            if(string.Equals(loginViewModel.Password, user.Password, StringComparison.InvariantCulture))
            {
                await _repository.AddUserHistory(user.Id, DateTime.UtcNow);
                return new LoginResultViewModel(user.UserEmail, user.FirstName, user.LastName);
            }

            return new LoginResultViewModel(false, "Invalid password");
        }

        public async Task<RegisterResultViewModel> RegisterUser(RegisterViewModel registerViewModel)
        {
            var existingUser = await _repository.GetUserByName(registerViewModel.UserEmail);

            if(existingUser != null)
            {
                return new RegisterResultViewModel(false, "User already exists");
            }

            var user = new User
            {
                UserEmail = registerViewModel.UserEmail,
                Password = registerViewModel.Password,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName
            };
            await _repository.CreateUser(user);
            return new RegisterResultViewModel(true, "Registration successful");
        }

        public async Task<UpdateUserDetailsResultsViewModel> UpdateUser(UpdateUserDetailsViewModel updateUserDetailsViewModel)
        {
            var existingUser = await _repository.GetUserById(updateUserDetailsViewModel.Id);

            if (existingUser == null)
            {
                return new UpdateUserDetailsResultsViewModel(false, "User does not exist");
            }

            existingUser.UserEmail = updateUserDetailsViewModel.UserEmail;
            existingUser.Password = updateUserDetailsViewModel.Password;
            existingUser.FirstName = updateUserDetailsViewModel.FirstName;
            existingUser.LastName = updateUserDetailsViewModel.LastName;
            await _repository.UpdateUser(existingUser);
            return new UpdateUserDetailsResultsViewModel(true, "Update succeeded");
        }
    }
}