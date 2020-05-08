using System;
using System.Linq;
using AutoMapper;
using BookAndRent.Models.Intefaces;
using Microsoft.AspNetCore.Mvc;
using BookAndRent.Repository;
using BookAndRent.Views.ViewModels.ApartmentModels;
using BookAndRent.Views.ViewModels.UserModels;
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
                .Select(a => new Views.ViewModels.ApartmentModels.Facility
                {
                    Title = a
                })
            };      
            
            return View("AddFacilities", apartmentFacilities);
        }        

        [HttpPost("AddFacilities")]
        public IActionResult AddFacilities(IFormCollection formCollection)
        {
            var apartment = Repository.Apartments
                .Search(ap => ap.Id.ToString() == formCollection["ApartmentId"].Single()).Single();

            var facility = Models.Intefaces.Facility.None;
            var selectedFacilities = formCollection["facility"].Select(facilityStr => Enum.Parse<Models.Intefaces.Facility>(facilityStr));
            if (selectedFacilities.Count() != 0)
            {
                foreach (var item in selectedFacilities)
                {
                    facility = facility | item;
                }
                facility = facility & ~Models.Intefaces.Facility.None;
            }          
           
            apartment.Facilities = facility;

            Repository.Apartments.Modify(apartment);
            Repository.Save();

            return View("AddPictures", new ApartmentIdentifier { ApartmentId = apartment.Id});
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
                byte[] imageData = null;

                foreach (var formPicture in formCollection.Files)
                {
                    using (var binaryReader = new BinaryReader(formPicture.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)formPicture.Length);
                    }
                    apartmentPicture.PictureBytes = imageData;

                    IPicture picture = Mapper.Map<IPicture>(apartmentPicture);
                    Repository.Pictures.Add(picture);
                    Repository.Save();
                }                
            }

            return View("AddAvailableDates", new ApartmentIdentifier { ApartmentId = int.Parse(formCollection["ApartmentId"].Single()) });
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

        [AllowAnonymous]
        [HttpPost("AvailableApartments")]
        public IActionResult SearchAvailableApartment(SearchModel searchModel)
        {

            var availableApartments = Repository.Apartments
               .Search(
                   ap => ap.SleepingPlaces >= searchModel.GuestsNumber
                   && ap.Address.Contains(searchModel.Address)
                   && ap.IsDateAvailable(searchModel.CheckIn, searchModel.CheckOut)
                   )
               .Select(apartment => new AvailableApartmentInfo
               {
                   ApartmentId = apartment.Id,
                   Address = apartment.Address,
                   Title = apartment.Title,
                   CostPerNight = apartment.CostPerNight,
                   Coordinates = apartment.Coordinates,
                   Pictures = apartment.Pictures.Select(pict => Mapper.Map<ApartmentPicture>(pict)).ToList(),
                   CheckIn = searchModel.CheckIn,
                   CheckOut = searchModel.CheckOut,
                   GuestsNumber = searchModel.GuestsNumber,
                   Amount = (searchModel.CheckOut - searchModel.CheckIn).Duration().Days * apartment.CostPerNight
               });
          
            return View("AvailableApartments", availableApartments);
        }
        
        [HttpGet("RentApartmentInfo")]
        public IActionResult RentApartmentInfo(int id, DateTime CheckIn, DateTime CheckOut, decimal Amount, int GuestsNumber)
        {
            var apartment = Repository.Apartments.FindById(id);
            var apartmentInfo = Mapper.Map<AvailableApartmentInfo>(apartment);
            apartmentInfo.CheckIn = CheckIn;
            apartmentInfo.CheckOut = CheckOut;
            apartmentInfo.Amount = Amount;
            apartmentInfo.GuestsNumber = GuestsNumber;
            apartmentInfo.ApartmentId = id;
            return View("RentApartmentInfo", apartmentInfo);
        }

        [HttpGet("Rent")]
        public IActionResult Rent(int id, DateTime CheckIn, DateTime CheckOut, decimal Amount)
        {
            var Renter = Repository.Users.Search(user => user.Email == User.Identity.Name).FirstOrDefault();
            var apartment = Repository.Apartments.FindById(id);
            var contract = apartment.Rent(Renter, CheckIn, CheckOut, Amount);
            Repository.Contracts.Add(contract);
            Repository.Save();

            return RedirectToAction("Account", "User");
        }
       
        [HttpGet("ApartmentInfo")]
        public IActionResult ApartmentInfo(int id)
        {
            var repositoryContracts = Repository.Contracts.Search(contract => contract.ApartmentId == id);
            for (int i = 0; i < repositoryContracts.Count(); i++)
            {
                var contract = repositoryContracts.ElementAt(i);
                contract.ContractStatus = contract.GetCurrentStatus(DateTime.UtcNow);
                Repository.Contracts.Modify(contract);
            }
            
            Repository.Save();

            var apartment = Repository.Apartments.FindById(id);
            var apartmentInfo = Mapper.Map<ApartmentInfo>(apartment);
            apartmentInfo.ApartmentId = id;
            apartmentInfo.Contracts = Repository.Contracts
                .Search(contract => contract.ApartmentId == id)
                .Select(contract => Mapper.Map<Contract>(contract))
                .ToList();
            foreach (var contract in apartmentInfo.Contracts)
            {
                contract.Renter = Mapper.Map<UserRegistration>(Repository.Users.FindById(contract.RenterId));
            }
            return View("ApartmentInfo", apartmentInfo);
        }

        [HttpGet("ApartmentUpdateView/{id}")]
        public IActionResult GetApartmentUpdateView([FromRoute]int id)
        {
            var apartment = Repository.Apartments.FindById(id);
            var apartmentInfo = Mapper.Map<UpdateApartment>(apartment);
            return View("ApartmentUpdate", apartmentInfo);
        }

        [HttpPost("UpdateApartment")]
        public IActionResult UpdateApartment(UpdateApartment viewAapartment)
        {
            var updatedApartment = Mapper.Map<IApartment>(viewAapartment);

            var existingApartment = Repository.Apartments.FindById(updatedApartment.Id);
            existingApartment.Address = updatedApartment.Address;
            existingApartment.Coordinates = updatedApartment.Coordinates;
            existingApartment.Title = updatedApartment.Title;
            existingApartment.Description = updatedApartment.Description;
            existingApartment.CostPerNight = updatedApartment.CostPerNight;
            existingApartment.SleepingPlaces = updatedApartment.SleepingPlaces;
            existingApartment.RoomAmount = updatedApartment.RoomAmount;

            Repository.Apartments.Modify(existingApartment);
            Repository.Save();

            var apartmentFacilities = new ApartmentFacilities
            {
                ApartmentId = updatedApartment.Id,
                Facilities = Enum.GetNames(typeof(Models.Intefaces.Facility))
                .Select(a => new Views.ViewModels.ApartmentModels.Facility
                {
                    Title = a,
                    
                })
            };

            return View("AddFacilities", apartmentFacilities);
        }

        [HttpGet("ContractStatus")]
        public IActionResult ContractStatus(int id, string status)
        {
            var contract = Repository.Contracts.FindById(id);
            contract.ContractStatus = Enum.Parse<Models.Intefaces.ContractStatus>(status);
            Repository.Contracts.Modify(contract);
            Repository.Save();
          
            return RedirectToAction("Account", "User");
        }

        [HttpGet("AddCommentView/{id}")]
        public IActionResult AddCommentView([FromRoute]int id)
        {
            var contract = Repository.Contracts.FindById(id);
            var contractInfo = Mapper.Map<Contract>(contract);
            return View("AddComment", contractInfo);
        }

        [HttpPost("AddComment")]
        public IActionResult AddComment(IFormCollection formCollection)
        {
            var us = Repository.Users.Search(user => user.Email == User.Identity.Name).FirstOrDefault();
            var comment = new Comment
            {

                ApartmentId = int.Parse(formCollection["ApartmentId"].Single()),
                CommentatorId = us.Id,
                Content = formCollection["Content"].Single(),
                Date = DateTime.UtcNow

            };

            var newComment = Mapper.Map<IComment>(comment);
            Repository.Comments.Add(newComment);
            Repository.Save();
            return RedirectToAction("Account", "User");
        }
    }
}