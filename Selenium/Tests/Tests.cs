using Selenium.Pages;

namespace Selenium.Tests
{
    public class Tests : BaseTest
    {

        [Test]
        public void VerifyValidationMessagesForMandatoryFields()
        {
            CheckoutFormPage checkoutFormPage = new CheckoutFormPage(Driver);
            checkoutFormPage.ClickOnCheckOutButton();
            Assert.Multiple(() =>
            {
                checkoutFormPage.VerifyFirstNameFieldRequired();
                checkoutFormPage.VerifyLastNameFieldRequired();
                checkoutFormPage.VerifyCardNameFieldRequired();
                checkoutFormPage.VerifyCardNumberFieldRequired();
                checkoutFormPage.VerifyCardExpFieldRequired();
                checkoutFormPage.VerifyCardCVVFieldRequired();
            });
        }

        [Test]
        public void VerifyCartIsOpened()
        {
            CheckoutFormPage checkoutFormPage = new CheckoutFormPage(Driver);
            Assert.IsTrue(checkoutFormPage.CartIsLoaded());
        }

        [Test]
        public void VerifyTotalCalculation()
        {
            CheckoutFormPage checkoutFormPage = new CheckoutFormPage(Driver);
            Assert.IsTrue(checkoutFormPage.CheckTotaAmountlCalculation());
        }

        [Test]
        public void VerifySuccessfullyPlacedOrder()
        {
            CheckoutFormPage checkoutFormPage = new CheckoutFormPage(Driver);
            checkoutFormPage.FillFirstName("TestFirstName");
            checkoutFormPage.FillLastName("TestLastName");
            checkoutFormPage.FillCardName("TestFirstName TestLastName");
            checkoutFormPage.FillCardNumber("1234567894561235");
            checkoutFormPage.FillCardExp("11/22");
            checkoutFormPage.FillCardCVV("123");
            checkoutFormPage.ClickOnCheckOutButton();
            Assert.IsTrue(checkoutFormPage.VerifySuccessfullyPlacedOrder());
        }
    }
}