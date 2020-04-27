using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookAndRent.Models.Intefaces;
using Microsoft.AspNetCore.Mvc;
using BookAndRent.Repository;
using BookAndRent.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BookAndRent.Controllers
{
    [Authorize]
    [Route("apartment")]
    public class ApartmentController : Controller
    {
        private IRepository Repository { get; set; }

        private IMapper Mapper { get; set; }

        public ApartmentController(IMapper mapper, IRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        
        [HttpGet]
        public IActionResult GetApartmentCreationView()
        {
            RedirectToAction("CreateApartment", "Apartment");
            return View("CreateApartment");
        }

        [HttpPost]
        public IActionResult CreateApartment(CreateApartment createApartment)
        {
            IApartment apartment = Mapper.Map<IApartment>(createApartment);

            var log = User.Identity.Name;
            var us = Repository.Users.Search(user => user.Email == log).FirstOrDefault();
            apartment.HouseHolder = us;

            Repository.Apartments.Add(apartment);
            Repository.Save();

            var newApartment = Repository.Apartments.Search(ap => true).Last();

            var apartmentFacilities = new ApartmentFacilities
            {
                ApartmentId = newApartment.Id,
                Facilities = Enum.GetNames(typeof(Models.Intefaces.Facility))
                .Select(a => new Views.ViewModels.Facility
                {
                    Title = a
                })
            };      
            
            return View("AddFacilities", apartmentFacilities);
        }

        [HttpGet("AddFacilities")]
        public IActionResult GetAddFacilitiesView()
        {
            return View("AddFacilities");
        }

        [HttpPost("AddFacilities")]
        public IActionResult AddFacilities(IFormCollection formCollection)
        {
            var apartment = Repository.Apartments
                .Search(ap => ap.Id.ToString() == formCollection["ApartmentId"].Single()).Single();

            var facility = Models.Intefaces.Facility.None;
            var a = formCollection["facility"].Select(facilityStr => Enum.Parse<Models.Intefaces.Facility>(facilityStr));
            foreach (var item in a)
            {
                facility = facility | item;
            }
            apartment.Facilities = facility;

            Repository.Apartments.Modify(apartment);
            Repository.Save();

            return View("AddPictures", new ApartmentInfo { ApartmentId = int.Parse(formCollection["ApartmentId"].Single())});
        }

        [HttpGet("AddPictures")]
        public IActionResult GetAddPicturesView()
        {
            return View("AddPictures");
        }

        [HttpPost("AddPictures")]
        public IActionResult AddPictures(IFormCollection formCollection)
        {
            var apartmentPicture = new ApartmentPicture
            {
                ApartmentId = int.Parse(formCollection["ApartmentId"].Single())
            };

            if (formCollection.Files.Count != 0)
            {
                var formPicture = formCollection.Files.Single();
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(formPicture.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)formPicture.Length);
                }
                apartmentPicture.PictureBytes = imageData;

                IPicture picture = Mapper.Map<IPicture>(apartmentPicture);
                Repository.Pictures.Add(picture);
                Repository.Save();
            }

            return View("AddAvailableDates", new ApartmentInfo { ApartmentId = int.Parse(formCollection["ApartmentId"].Single()) });
        }

        [HttpGet("AddAvailableDates")]
        public IActionResult GetAddAvailableDatesView()
        {

            return View("AddAvailableDates");
        }

        [HttpPost("AddAvailableDates")]
        public IActionResult AddAvailableDates(IFormCollection formCollection)
        {
            var availableDates = new AvailableDates
            {
                ApartmentId = int.Parse(formCollection["ApartmentId"].Single()),
                StartDate = DateTime.Parse(formCollection["StartDate"].Single()),
                EndDate = DateTime.Parse(formCollection["EndDate"].Single())
            };

            IAvailableDate dates = Mapper.Map<IAvailableDate>(availableDates);
            Repository.AvailableDates.Add(dates);
            Repository.Save();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost("availableApartments")]
        public IActionResult SearchAvailableApartment()
        {
            
            return View();
        }
    }
}