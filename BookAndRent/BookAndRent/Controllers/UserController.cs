using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using BookAndRent.Models.Intefaces;
using BookAndRent.Repository;
using BookAndRent.Views.ViewModels.UserModels;
using BookAndRent.Views.ViewModels.ApartmentModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Contract = BookAndRent.Views.ViewModels.UserModels.Contract;

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
                var us = Repository.Users.Search(user => user.Email == User.Identity.Name).SingleOrDefault();
                var accountUser = Mapper.Map<AccountInfo>(us);

                var repositoryContracts = Repository.Contracts.Search(contract => contract.RenterId == us.Id).ToList();

                foreach (var contract in repositoryContracts)
                {
                    contract.ContractStatus = contract.GetCurrentStatus(DateTime.UtcNow);
                    Repository.Contracts.Modify(contract);
                }
                Repository.Save();
                repositoryContracts = Repository.Contracts.Search(contract => contract.RenterId == us.Id).ToList();

                var contracts = new List<Contract>();
                foreach (var item in repositoryContracts)
                {
                    contracts.Add(Mapper.Map<Contract>(item));
                }
                foreach (var item in contracts)
                {
                    var apart = Mapper.Map<AvailableApartmentInfo>(Repository.Apartments.Search(ap => ap.Id == item.ApartmentId).FirstOrDefault());
                    item.Apartment = apart;
                }
                accountUser.Contracts = contracts;

                var repositoryApartments = Repository.Apartments.Search(ap => ap.HouseHolder.Id == us.Id).ToList();
                var apartments = new List<AvailableApartmentInfo>();
                foreach (var item in repositoryApartments)
                {
                    var apartment = Mapper.Map<AvailableApartmentInfo>(item);
                    apartment.ApartmentId = item.Id;
                    apartments.Add(apartment);
                }

                accountUser.Apartments = apartments;
                return View(accountUser);
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