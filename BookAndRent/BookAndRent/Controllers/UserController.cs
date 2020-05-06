using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BookAndRent.Models.Implementations;
using BookAndRent.Models.Intefaces;
using BookAndRent.Repository;
using BookAndRent.Views.ViewModels.UserModels;
using BookAndRent.Views.ViewModels.ApartmentModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult GetRegistrationView()
        {
            return View("Registration");
        }

        [HttpPost("registration")]
        public IActionResult Registration(UserRegistration userRegistration)
        {
            if (!Repository.Users.Search(us => us.Email == userRegistration.Email).Any())
            {
                IUser user = Mapper.Map<IUser>(userRegistration);                

                Repository.Users.Add(user);
                Repository.Save();

                //var newUser = Repository.Users.Last();

                var authUser = new LoginRequest();
                authUser.Email = userRegistration.Email;
                authUser.Password = userRegistration.Password;

                Authorization(authUser);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //TempData["RegMessage"] = "Пользователь с таким логином уже существует";
                //return RedirectToAction("registration", "user");

                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                return View(userRegistration);

            }

        }

        [HttpGet("authorization")]
        public IActionResult GetAuthorizationView()
        {
            return View("Authorization");
        }

        [HttpPost("authorization")]
        public IActionResult Authorization(LoginRequest loginRequest)
        {

            if (Repository.Users.Search(user => user.Email == loginRequest.Email && user.Password == loginRequest.Password).Any())
            {
                Authorize(loginRequest.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // TempData["AuthMessage"] = "Неверный логин или пароль";
                ModelState.AddModelError("", "Неверный логин или пароль");
                return RedirectToAction("authorization", "user");
            }

            
        }

        [HttpGet("account")]
        public IActionResult Account()
        {
            if (User.Identity.IsAuthenticated)
            {
                var log = User.Identity.Name;
                var us = Repository.Users.Search(user => user.Email == log).SingleOrDefault();

                UserRegistration AccountUser = Mapper.Map<UserRegistration>(us);
                return View(AccountUser);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        private void Authorize(string name)
        {
            // TODO: translate to english

            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id)).Wait();
        }        
    }
}