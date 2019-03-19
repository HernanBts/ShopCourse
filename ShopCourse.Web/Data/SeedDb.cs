namespace ShopCourse.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            // Add user
            var user = await this.userHelper.GetUserByEmailAsync("admin@shop.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = "admin@shop.com",
                    UserName = "admin@shop.com",
                    PhoneNumber = "admin"
                };

                var result = await this.userHelper.AddUserAsync(user, "admin");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var IsInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!IsInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }
            // Add products
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
