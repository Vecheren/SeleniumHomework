using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Practice1.Pages;
using SeleniumExtras.WaitHelpers;

namespace Practice1
{
    [TestFixture]
    public class LabirintTests : LabirintTestBase
    {
        [Test]
        public void Labirint_AddBookAndChooseDeliveryService_Success()
        {
            var homePage = new HomePage(driver, wait);
            homePage.OpenPage();
            homePage.AddBookToCard();

            var cardPage = new CardPage(driver, wait);
            cardPage.OpenPage();

            var deliveryPage = new DeliveryPage(driver, wait);
            deliveryPage.SwitchToDeliveryTab();
            deliveryPage.FillInAddress(true);

            deliveryPage.ChooseDeliveryService();
            Assert.DoesNotThrow(() => deliveryPage.ReturnToCard(), "После выбора доставки остались на экране выбора");
        }

        [Test]
        public void Labirint_UseInvalidAddress_AddressValidation()
        {
            var homePage = new HomePage(driver, wait);
            homePage.OpenPage();
            homePage.AddBookToCard();

            var cardPage = new CardPage(driver, wait);
            cardPage.OpenPage();

            var deliveryPage = new DeliveryPage(driver, wait);
            deliveryPage.SwitchToDeliveryTab();
            deliveryPage.FillInAddress(false);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(deliveryPage.IsVisibleAddressError(), "Нет предупреждения об ошибочном адресе");
                Assert.AreEqual("Уточните адрес для доставки курьером", deliveryPage.GetAddressErrorText(), "Некорректный текст ошибки при неправильном адресе");
            });
            
            
        }
    }
}