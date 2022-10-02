using API.Models;
using Newtonsoft.Json;
using System.Text;

namespace API
{
    public class Tests
    {
        public static string URL;
        public static HttpClient HttpClient;

        [SetUp]
        public void Setup()
        {
            URL = "https://fg1ap986e9.execute-api.eu-west-1.amazonaws.com/Dev/";
            HttpClient = new HttpClient(); 
        }

        [Test]
        public static async Task VerifyDiscountPercent()
        {
            string discountString = "55555";
            var response = await HttpClient.PostAsync(URL + "coupon?coupon=" + discountString, null);
            string body = await response.Content.ReadAsStringAsync();
            DiscountAmount discount = JsonConvert.DeserializeObject<DiscountAmount>(body);
            Assert.That(discount.Discount, Is.EqualTo(discountString.Length));
        }

        [Test]
        public static async Task VerifyWrongCreditCardNumberLength()
        {
            Item item = new Item
            {
                FirstName = "Test",
                LastName = "Test",
                PaymentMethod = "on",
                CC_Name = "Test Test",
                CC_Number = "123456789456123", //lenght = 15
                CC_Expiration = "11/22",
                CC_CVV = "123"
            };
            var jsonData = JsonConvert.SerializeObject(item);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(URL + "checkout", data);
            string body = await response.Content.ReadAsStringAsync();
            CheckoutResponse checkoutResponse = JsonConvert.DeserializeObject<CheckoutResponse>(body);
            Assert.That(checkoutResponse.Message, Is.EqualTo("Invalid Card Number"));
        }

        [TearDown]
        public void TearDown()
        {
            HttpClient.Dispose();
        }
    }
}