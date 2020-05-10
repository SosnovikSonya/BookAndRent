using BookAndRent.Models.Implementations;
using BookAndRent.Models.Intefaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAndRent.Test
{
    [TestClass]
    public class BookAndRentTests
    {
        private Apartment apartment;
        private DateTime availableStartDate1 = new DateTime(2020, 4, 1);
        private DateTime availableEndDate1 = new DateTime(2020, 4, 30);
        private DateTime availableStartDate2 = new DateTime(2020, 6, 1);
        private DateTime availableEndDate2 = new DateTime(2020, 6, 30);
        private DateTime contractStartDate = new DateTime(2020, 4, 11);
        private DateTime contractEndDate = new DateTime(2020, 4, 16);

        [TestInitialize]
        public void TestInit()
        {
            apartment = new Apartment();
            apartment.AvailableDates.Add(
                new AvailableDate
                {
                    StartDate = availableStartDate1,
                    EndDate = availableEndDate1
                }
            );
            apartment.AvailableDates.Add(
               new AvailableDate
               {
                   StartDate = availableStartDate2,
                   EndDate = availableEndDate2
               }
           );
            apartment.Contracts.Add(
                new Contract
                {
                    CheckIn = contractStartDate,
                    CheckOut = contractEndDate
                });
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterAvailableStart_RequestedIsLessAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(4), availableStartDate1.AddDays(6));
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsEqualAvailableStart_RequestedIsEqualAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1, availableEndDate1);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsEqualAvailableStart_RequestedIsLessAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1, availableStartDate1.AddDays(5));
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterAvailableStart_RequestedIsEqualAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(3), availableEndDate1);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsEqualContractEnd_RequestedIsLessAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(contractEndDate, availableEndDate1.AddDays(-1));
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterAvailableStart_RequestedIsEqualContractStart_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(3), contractStartDate);
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterContractEnd_RequestedIsLessAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(contractEndDate.AddDays(1), availableEndDate1.AddDays(-1));
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterAvailableStart_RequestedIsLessContractStart_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(1), contractStartDate.AddDays(-1));
            Assert.IsTrue(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsLessAvailableStart_ReturnsFalse()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(-10), availableStartDate1.AddDays(-6));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsGreaterAvailableEnd_ReturnsFalse()
        {
            var isAvailable = apartment.IsDateAvailable(availableEndDate1.AddDays(6), availableEndDate1.AddDays(10));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsLessAvailableStart_RequestedIsGreaterAvailableStart_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(-6), availableStartDate1.AddDays(6));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsLessAvailableEnd_RequestedIsGreaterAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableEndDate1.AddDays(-6), availableEndDate1.AddDays(6));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsLessAvailableStart_RequestedIsGreaterAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(-6), availableEndDate1.AddDays(6));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsLessAvailableStart_RequestedIsEqualAvailableStart_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableStartDate1.AddDays(-6), availableStartDate1);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void IsDateAvailable_RequestedIsEqualAvailableEnd_RequestedIsGreaterAvailableEnd_ReturnsTrue()
        {
            var isAvailable = apartment.IsDateAvailable(availableEndDate1, availableEndDate1.AddDays(6));
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void CheckContractStatus_DateGreaterThenCheckout_ReturnsCompleted()
        {
            var contract = new Contract
            {
                CheckIn = contractStartDate,
                CheckOut = contractEndDate,
                ContractStatus = ContractStatus.New
            };
            var dateNow = DateTime.UtcNow;

            var actualStatus = contract.GetCurrentStatus(dateNow);
            Assert.AreEqual(ContractStatus.Completed, actualStatus);
        }

        [TestMethod]
        public void CheckContractStatus_DateInRange_ReturnsInProgress()
        {
            var contract = new Contract
            {
                CheckIn = contractStartDate,
                CheckOut = contractEndDate,
                ContractStatus = ContractStatus.Approved
            };
            var dateNow = contractStartDate.AddDays(1);

            var actualStatus = contract.GetCurrentStatus(dateNow);
            Assert.AreEqual(ContractStatus.InProgress, actualStatus);
        }

        [TestMethod]
        public void CheckContractStatus_DateLessThenCheckin_ReturnsTheSame()
        {
            var contract = new Contract
            {
                CheckIn = contractStartDate,
                CheckOut = contractEndDate,
                ContractStatus = ContractStatus.Approved
            };
            var dateNow = contractStartDate.AddDays(-1);

            var actualStatus = contract.GetCurrentStatus(dateNow);
            Assert.AreEqual(contract.ContractStatus, actualStatus);
        }

        [TestMethod]
        public void CheckContractStatus_DateInRangeAlreadyRejected_ReturnsRejected()
        {
            var contract = new Contract
            {
                CheckIn = contractStartDate,
                CheckOut = contractEndDate,
                ContractStatus = ContractStatus.Rejected
            };
            var dateNow = contractStartDate.AddDays(1);

            var actualStatus = contract.GetCurrentStatus(dateNow);
            Assert.AreEqual(contract.ContractStatus, actualStatus);
        }

        [TestMethod]
        public void CheckContractStatus_DateGreaterThenCheckoutAlreadyRejected_ReturnsRejected()
        {
            var contract = new Contract
            {
                CheckIn = contractStartDate,
                CheckOut = contractEndDate,
                ContractStatus = ContractStatus.Rejected
            };
            var dateNow = contractEndDate.AddDays(1);

            var actualStatus = contract.GetCurrentStatus(dateNow);
            Assert.AreEqual(contract.ContractStatus, actualStatus);
        }
    }    
}
