using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    public class NavigationTests
    {
        [Fact]
        public void InventoryPage_ShouldContainAddToCartButtons()
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
            var buttons = driver.FindElements(By.ClassName("btn_inventory"));
            Assert.True(buttons.Count > 0);
        }
    }
}
