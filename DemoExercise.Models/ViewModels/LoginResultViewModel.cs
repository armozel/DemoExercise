namespace DemoExercise.Models.ViewModels
{
    public class LoginResultViewModel
    {
        public string UserEmail { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public bool Succeeded { get; }
        public string Message { get; }

        public LoginResultViewModel(bool success, string message)
        {
            Succeeded = success;
            Message = message;
        }

        public LoginResultViewModel(string userEmail, string firstName, string lastName)
        {
            Succeeded = true;
            Message = string.Empty;
            UserEmail = userEmail;
            FirstName = firstName;
            LastName = lastName;
        }


    }
}
