using System;
using System.Collections.Generic;

namespace DemoExercise.Models.ViewModels
{
    public class LoginHistoryResultViewModel
    {
        public List<DateTime> LoginDates { get; }

        public LoginHistoryResultViewModel(List<DateTime> loginDates)
        {
            LoginDates = loginDates;
        }
    }
}
