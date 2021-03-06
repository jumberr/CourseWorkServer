using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CourseworkWebApp
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectingString")));
            
            services.AddControllers();
            services.AddHttpClient();
            
            services.AddTransient<IRepository<Person>, RepositoryPerson>();
            services.AddTransient<PersonService, PersonService>();
            services.AddTransient<IRepository<ToDo>, ToDoListRepository>();
            services.AddTransient<ToDoService, ToDoService>();
            services.AddTransient<IRepository<Bday>, BdayRepository>();
            services.AddTransient<BdayService, BdayService>();
            services.AddTransient<IRepository<Note>, NoteRepository>();
            services.AddTransient<NoteService, NoteService>();
            
            services.AddControllers();
            
            services.AddSwaggerGen(c =>  
            {  
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CourseWork", Version = "v1" });  
            });  
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();  
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseWork v1"));  
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}