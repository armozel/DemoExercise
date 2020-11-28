using DemoExercise.Models.ViewModels;
using System.Threading.Tasks;

namespace DemoExercise.Interfaces.Services
{
    public interface ILoginService
    {
        Task<LoginHistoryResultViewModel> GetLoginHistory(string userName);
        Task<UpdateUserDetailsViewModel> GetUserDetails(string userName);
        Task<LoginResultViewModel> LoginAsync(LoginViewModel loginViewModel);
        Task<RegisterResultViewModel> RegisterUser(RegisterViewModel registerViewModel);
        Task<UpdateUserDetailsResultsViewModel> UpdateUser(UpdateUserDetailsViewModel updateUserDetailsViewModel);
    }
}