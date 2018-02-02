using System.Linq;
using AspnetCorePatch.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCorePatch
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DemoDbContext>(options => { options.UseSqlite("Data Source=demo.db"); });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DemoDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            dbContext.Database.EnsureCreated();

            if (!dbContext.Heroes.Any())
            {
                dbContext.Heroes.Add(new Hero { Name = "Diana Prince", Description = "Diana Prince Description" });
                dbContext.Heroes.Add(new Hero { Name = "Bruce Wayne", Description = "Bruce Wayne Description" });
            }

            dbContext.SaveChanges();
        }
    }
}
