using AuthDemo.Data;
using AuthDemo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=AuthDemo;Integrated Security=true;";

        public IActionResult Index()
        {
            var vm = new HomePageViewModel
            {
                IsAuthenticated = User.Identity.IsAuthenticated
            };
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name; //this will equal the email that we put into the claims when logging in the user
                var repo = new UserRepository(_connectionString);
                vm.CurrentUser = repo.GetByEmail(email);
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
    }
}
