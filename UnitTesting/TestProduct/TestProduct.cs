using System;
using mediabazaar_s2_cb06_1.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.TestProduct
{
    [TestClass]
    public class TestProduct
    {
        private Product product = new Product(000001, "Iphone", "phones", "", 2500.50, 10);

        [TestMethod]
        public void CorrectTestGetId()
        {
            int id = product.GetId();
            Assert.AreEqual(000001, id);
        }

        [TestMethod]
        public void CorrectTestGetAmount()
        {
            int amount = product.GetAmount();
            Assert.AreEqual(10, amount);
        }

        [TestMethod]
        public void CorrectTestChangeAmount()
        {
            product.ChangeAmount(8);
            int amount = product.GetAmount();
            Assert.AreEqual(8, amount);
        }

        [TestMethod]
        public void WrongTestGetAmount()
        {
            product.ChangeAmount(8);
            int amount = product.GetAmount();
            Assert.AreNotEqual(10, amount);
        }
    }
}
