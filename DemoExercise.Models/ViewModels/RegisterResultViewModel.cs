namespace DemoExercise.Models.ViewModels
{
    public class RegisterResultViewModel
    {
        public bool Succeeded { get; }
        public string Message { get; }

        public RegisterResultViewModel(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
