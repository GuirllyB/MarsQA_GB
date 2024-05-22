using MarsQA_GB.SpecflowPages.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class HomePage : CommonDriver
    {

        public void NavigateToLanguagesPage(IWebDriver webDriver) 
        {
            try 
            {
                //Navigate to Languages page
                IWebElement languagesTab = webDriver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
                languagesTab.Click();
                WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[1]/a[1]")));

            }
            catch (Exception ex)
            {
                Assert.Fail("Mars portal page did not display" + ex.Message);
            }

        }


        public void VerifyLoggedInUser(IWebDriver webDriver)
        {
            try 
            {
                //Check if user has logged in successfully
                IWebElement hiExaLink = webDriver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));
                Assert.That(hiExaLink.Text == "Hi Exa", "User hasn't been logged in.");
            }
            catch (Exception ex) 
            {
                Assert.Fail("User hasn't logged in :(" + ex.Message);
            }
        }
    }
}
