using System;
using System.Data;
using LearningLanguagePlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LearningLanguagePlatform.Controllers
{
    public class RegistrationAndLoginController : Controller
    {
        private readonly string _connectionString;

        public RegistrationAndLoginController(IConfiguration configuration)
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LLP;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO [User] (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return RedirectToAction("Login");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine(ex.Message);
                        return View("Error");
                    }
                }
            }
            else
            {
                // If model state is not valid, return to the registration page with validation errors
                return View("Registration", user);
            }
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id FROM [User] WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return RedirectToAction("SelectLanguage", "UserSelection");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Invalid email or password.";
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
            }
        }

    }
}
