using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAndRent.Models.Implementations;
using BookAndRent.Models.Intefaces;
using BookAndRent.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookAndRent.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        IRepository Repository { get; set; }

        private IMapper Mapper { get; set; }

        public UserController(IMapper mapper, IRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        [HttpGet("registration")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("registration")]
        public IActionResult Registration(Views.ViewModels.UserRegistration viewUser)
        {
            IUser user = Mapper.Map<IUser>(viewUser);
            Repository.Users.Add(user);
            Repository.Save();

            var newUser = Repository.Users.Last();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Authorization()
        {
            return View();
        }
    }
}