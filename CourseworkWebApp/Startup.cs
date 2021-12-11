using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using CourseProject.HelperClasses.Constant;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CourseProject
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
//
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
//
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //}
//
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
//
        //    var dbController = new DbController(Configuration);
//
        //    // CheckIfUserExists [GET]
        //    var checkIfUserExistsHandler = new RouteHandler(CheckIfUserExists);
        //    var checkIfUserExists = new RouteBuilder(app, checkIfUserExistsHandler);
        //    checkIfUserExists.MapRoute("CheckIfUserExists", "/CheckIfUserExists/{username}/{password}");
        //    app.UseRouter(checkIfUserExists.Build());
//
        //    // Register [POST]
        //    var registerHandler = new RouteHandler(RegisterPlayer);
        //    var register = new RouteBuilder(app, registerHandler);
        //    register.MapRoute("RegisterPlayer", "/RegisterPlayer/{username}/{password}");
        //    app.UseRouter(register.Build());
        //}
//
        //private async Task CheckIfUserExists(HttpContext context)
        //{
        //    var routeValues = context.GetRouteData().Values;
        //    var command = new SqlCommand($"Select count(*) from {Tables.UsersCredentials} where {routeValues.ElementAt(0).Key}" +
        //                                 $" = '{routeValues.ElementAt(0).Value}' and {routeValues.ElementAt(1).Key}" +
        //                                 $" = '{routeValues.ElementAt(1).Value}'", DbController.Instance.SqlConnection);
//
        //    var result = command.ExecuteScalar();
        //    await SendJsonToClient(context, result);
        //}
        //
        //private async Task RegisterPlayer(HttpContext context)
        //{
        //    var routeValues = context.GetRouteData().Values;
        //    var command = new SqlCommand($"Insert into {Tables.UsersCredentials} " +
        //                                 $"Values ('{routeValues.ElementAt(0).Value}', " +
        //                                 $"'{routeValues.ElementAt(1).Value}')", DbController.Instance.SqlConnection);
//
        //    var result = command.ExecuteScalar();
        //    await SendJsonToClient(context, result);
        //}
//
        //private static async Task SendJsonToClient<T>(HttpContext context, T data)
        //{
        //    //var routeValues = context.GetRouteData().Values;
        //    await context.Response.WriteAsJsonAsync(data);
        //}
        //
        //private static void About(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("About");
        //    });
        //}

        public readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.  
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectingString")));
            
            services.AddControllers();
            services.AddHttpClient();
            services.AddTransient<IRepository<Person>, RepositoryPerson>();
            services.AddTransient<PersonService, PersonService>();
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