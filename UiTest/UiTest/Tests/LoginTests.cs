using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTest.Tests
{
    public class LoginTests
    {
        [Fact]
        public void ValidLogin_ShouldRedirectToInventory()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");

            // Use runtime-resolved output folder so CI runners (Linux) find the driver
            var driverPath = AppContext.BaseDirectory;
            var service = ChromeDriverService.CreateDefaultService(driverPath);
            using var driver = new ChromeDriver(service, options);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            Assert.Contains("inventory", driver.Url);
        }
    }
}
