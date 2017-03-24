using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExitMemoComments.Models;
using Microsoft.Extensions.DependencyInjection;
using ExitMemoComments.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace ExitMemoComments.Data
{
    public class SampleData
    {
        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            await db.Database.EnsureCreatedAsync();

            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure chad (IsAdmin)
            var chad = await userManager.FindByNameAsync("chad.conklin@mossadams.com");
            if (chad == null)
            {
                // create user
                chad = new ApplicationUser
                {
                    UserName = "chad.conklin@mossadams.com",
                    Email = "chad.conklin@mossadams.com",
                    ExitMemoComments = new List<ExitMemoComment>
                    {
                        new ExitMemoComment { Title = "Accounts Receivable", Narrative ="Accounts receivable are the bomb.", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "Accounts Payable", Narrative ="Accounts payable are the bomb.", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "Revenues", Narrative ="Revenues are the bomb.", DateAdded = DateTime.Parse("2017-02-25") }
                    }
                };
                await userManager.CreateAsync(chad, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(chad, new Claim("IsAdmin", "true"));
            }

            // Ensure Gregg (not IsAdmin)
            var gregg = await userManager.FindByNameAsync("gregg.amend@mossadams.com");
            if (gregg == null)
            {
                // create user
                gregg = new ApplicationUser
                {
                    UserName = "gregg.amend@mossadams.com",
                    Email = "gregg.amend@mossadams.com",
                    ExitMemoComments = new List<ExitMemoComment>
                    {
                        new ExitMemoComment { Title = "Cash", Narrative ="Cash is the bomb.", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "Fixed Assets", Narrative ="Fixed assets are the bomb.", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "Debt", Narrative ="Debt is the bomb.", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "I like cheese!", Narrative = "Peanuts are bad and walnuts are worse!", DateAdded = DateTime.Parse("2017-02-25") },
                        new ExitMemoComment { Title = "Dude, Where's my laptop!", Narrative = "I left my laptop on the plane in Anchorage.", DateAdded = DateTime.Parse("2017-02-25") }
                    }
                };
                await userManager.CreateAsync(gregg, "Secret234!");
            }
            db.SaveChanges();
        }
    }
}
