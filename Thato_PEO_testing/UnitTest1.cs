using Thato_final_PEO.Controllers;
using Thato_final_PEO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Thato_final_PEO.TESTS
{
    [TestClass]
    public class HomeControllerTests
    {
        private disasteralleviationfoundationdbContext contextDB = new disasteralleviationfoundationdbContext();
        [TestMethod]
        public void AllocateMoney()
        {
            var moneyLeft = contextDB.DonationsOfMoneys.Select(s => s.DonationAmount).Sum() - contextDB.AllocationOfMoneys.Select(s => s.AmountAllocated).Sum() - contextDB.PurchasesOfGoods.Select(a => a.AmountRequired).Sum();
            var allocatedValue = 100000;
              Assert.IsFalse(moneyLeft > allocatedValue);
        }

        [TestMethod]
        public void TestAddANewActiveDisasterView()
        {
            var controller = new HomeController();
            var result = controller.AddANewActiveDisaster() as ViewResult;
          Assert.AreEqual("AddANewActiveDisaster", result.ViewName);

        }

        [TestMethod]
        public void TestMakeAMoneyDonationView()
        {
            var controller = new HomeController();
            var result = controller.MakeAMoneyDonation() as ViewResult;
          Assert.AreEqual("MakeAMoneyDonation", result.ViewName);

        }


        [TestMethod]
        public void TestAddANewCategoryOfGoodsView()
        {
            var controller = new HomeController();
            var result = controller.AddANewCategoryOfGoods() as ViewResult;
            Assert.AreEqual("AddANewCategoryOfGoods", result.ViewName);

        }

        [TestMethod]
        public void TestMakeAGoodsDonationViewData()
        {
            var controller = new HomeController();
            var result = controller.MakeAGoodsDonation() as ViewResult;
            var data = new SelectList(contextDB.DonationOfGoodsCategories, "DonationCategoryId", "DonationCategoryName");
            Assert.AreEqual("MakeAGoodsDonation", data);
        }
    }
}