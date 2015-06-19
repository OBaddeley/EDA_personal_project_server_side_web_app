using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ShopShopShop.Controllers;
using ShopShopShop.Models;

namespace ShopShopShop.Tests.Controllers
{
    [TestClass]
    public class ProductContollerTest 
    {
        [TestMethod]
        public void Index()
        {   //arrange
            ProductsController controller = new ProductsController();
           
            //Act
           ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.IsNotNull(result);
        }
    }
}
