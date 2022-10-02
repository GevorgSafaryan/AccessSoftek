using OpenQA.Selenium;
using Selenium.Framework;

namespace Selenium.Pages
{
    public class CheckoutFormPage : BasePage
    {
        private string fisrtNameField = "firstName";
        private string lastNameField = "lastName";
        private string ccName = "cc-name";
        private string ccNumber = "cc-number";
        private string ccExpiration = "cc-expiration";
        private string ccCVV = "cc-cvv";
        private string checkOutButton = ".btn.btn-primary.btn-lg.btn-block";
        private string cart = ".col-md-4.order-md-2.mb-4";
        private string cartLoader = "loading";
        private string itemsList = "itemsList";
        private string listItems = "//li[@class = 'list-group-item d-flex justify-content-between lh-condensed']";
        private string fisrtNameValidationMessage = "//input[@id = 'firstName']/following-sibling::div[@class = 'invalid-feedback']";
        private string lastNameValidationMessage = "//input[@id = 'lastName']/following-sibling::div[@class = 'invalid-feedback']";
        private string ccNameValidationMessage = "//input[@id = 'cc-name']/following-sibling::div[@class = 'invalid-feedback']";
        private string ccNumberValidationMessage = "//input[@id = 'cc-number']/following-sibling::div[@class = 'invalid-feedback']";
        private string ccExpValidationMessage = "//input[@id = 'cc-expiration']/following-sibling::div[@class = 'invalid-feedback']";
        private string ccCVVExpValidationMessage = "//input[@id = 'cc-cvv']/following-sibling::div[@class = 'invalid-feedback']";
        private string promoCodeField = "promoCode";
        private string redeemButton = ".btn.btn-secondary";
        private string totalAmount = "totalAmount";
        private string success = "success";
        private string successText = "//div[@id = 'success']/h2";

        public CheckoutFormPage(IWebDriver driver) : base(driver)
        {

        }

        public void ClickOnCheckOutButton()
        {
            Driver.FindElement(By.CssSelector(checkOutButton)).Click();
        }

        public bool VerifyFirstNameFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(fisrtNameValidationMessage, "Valid first name is required.");
        }

        public bool VerifyLastNameFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(lastNameValidationMessage, "Valid last name is required.");
        }

        public bool VerifyCardNameFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(ccNameValidationMessage, "Name on card is required");
        }

        public bool VerifyCardNumberFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(ccNumberValidationMessage, "Credit card number is required");
        }

        public bool VerifyCardExpFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(ccExpValidationMessage, "Expiration date required");
        }

        public bool VerifyCardCVVFieldRequired()
        {
            return VerifyValidationMessagesAreDisplayed(ccCVVExpValidationMessage, "Security code required");
        }

        private bool VerifyValidationMessagesAreDisplayed(string locator, string text)
        {
            return Driver.FindElement(By.XPath(locator)).Displayed && Driver.FindElement(By.XPath(locator)).Text == text;
        }

        public bool CartIsLoaded()
        {
            return Wait.GetWait(Driver).Until(WaitConditions.ElemensIsNotDisplayed(By.Id(cartLoader)))
                && Driver.FindElements(By.XPath(listItems)).Count > 0;
        }

        public bool CheckTotaAmountlCalculation()
        {
            Wait.GetWait(Driver).Until(WaitConditions.ElemensIsNotDisplayed(By.Id(cartLoader)));
            decimal initial = int.Parse(Driver.FindElement(By.Id(totalAmount)).Text);
            Driver.FindElement(By.Id(promoCodeField)).SendKeys("55555");
            int discount = Driver.FindElement(By.Id(promoCodeField)).GetAttribute("value").Length;
            Driver.FindElement(By.CssSelector(redeemButton)).Click();
            Wait.GetWait(Driver).Until(WaitConditions.ElementIsNotVisible(By.Id(promoCodeField)));
            decimal result = Convert.ToDecimal(Driver.FindElement(By.Id(totalAmount)).Text);
            return initial - ((initial * discount) / 100) == result;
        }

        public void FillFirstName(string firstName)
        {
            Driver.FindElement(By.Id(fisrtNameField)).SendKeys(firstName);
        }

        public void FillLastName(string lastName)
        {
            Driver.FindElement(By.Id(lastNameField)).SendKeys(lastName);
        }

        public void FillCardName(string cardName)
        {
            Driver.FindElement(By.Id(ccName)).SendKeys(cardName);
        }

        public void FillCardNumber(string cardNumber)
        {
            Driver.FindElement(By.Id(ccNumber)).SendKeys(cardNumber);
        }

        public void FillCardExp(string cardExp)
        {
            Driver.FindElement(By.Id(ccExpiration)).SendKeys(cardExp);
        }

        public void FillCardCVV(string cardCVV)
        {
            Driver.FindElement(By.Id(ccCVV)).SendKeys(cardCVV);
        }

        public bool VerifySuccessfullyPlacedOrder()
        {
            Wait.GetWait(Driver).Until(WaitConditions.ElemensIsDisplayed(By.Id(success)));
            return Driver.FindElement(By.XPath(successText)).Text == "Your order was placed. Thank you for purchasing.";
        }
    }
}
