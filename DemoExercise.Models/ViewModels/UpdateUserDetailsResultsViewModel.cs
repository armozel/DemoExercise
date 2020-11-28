namespace DemoExercise.Models.ViewModels
{
    public class UpdateUserDetailsResultsViewModel
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public UpdateUserDetailsResultsViewModel(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}
