using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DemoExercise.Context
{
    public static class SeedData
    {
        public static void InitializeData(IServiceProvider serviceProvider)
        {
            using (var context = new DemoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DemoContext>>()))
            {
                if(context.Users.Any())
                {
                    return;
                }

                context.Users.AddRange(
                    new Entities.User
                    {
                        UserEmail = "test@test.com",
                        Password = "Password123",
                        FirstName = "John",
                        LastName = "Doe"
                    });

                context.SaveChanges();
            }
        }
    }
}
