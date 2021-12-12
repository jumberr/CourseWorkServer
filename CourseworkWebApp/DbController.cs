using System.Data.SqlClient;
using CourseProject.HelperClasses.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CourseProject
{
    public class DbController : Controller
    {
        //private static DbController _instance;
        //public static DbController Instance => _instance;
//
        //private readonly IConfiguration _configuration;
        //public SqlConnection SqlConnection { get; set; }
//
        //public DbController(IConfiguration configuration)
        //{
        //    _instance = this;
        //    _configuration = configuration;
        //    StartServer();
        //}
//
        //public void StartServer()
        //{
        //    var connString = _configuration.GetConnectionString(Constants.DefaultConnection);
//
        //    var conn = new SqlConnection(connString);
        //    conn.Open();
        //    SqlConnection = conn;
        //}
//
        //public void ExitServer()
        //{
        //    SqlConnection.Close();
        //}
    }
}