using EmptyRazorDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmptyRazorDemo.Controllers
{
    public class UsersController : Controller
    {
        public static List<Users> users = new List<Users>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Users user)
        {
            users.Add(user);
            return RedirectToAction("Get", users);

        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return View(users);
        }
        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)//display user
        {
            Users User = users.Where(use => use.Id.Equals(id)).Select(use => use).FirstOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Users user)
        {
            Users User = users.Where(use => use.Id == user.Id).FirstOrDefault();
            if (User != null)
            {
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.Gender = user.Gender;
                User.Age = user.Age;
            };
            return RedirectToAction("Get", users);
        }
        public IActionResult Delete(int id)
        {
            Users user = users.Where(s => s.Id.Equals(id)).Select(use => use).FirstOrDefault();
            users.Remove(user);
            return RedirectToAction("Get", users);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            Users use = users.Where(s => s.Id.Equals(id)).Select(user => user).FirstOrDefault();
            return View(use);
        }
    }
}
