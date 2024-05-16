using MarsQA_GB.SpecflowPages.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class HomePage : CommonDriver
    {
        public void VerifyLoggedInUser(IWebDriver webDriver)
        {
            try 
            {
                //Check if user has logged in successfully
                IWebElement hiGuirllyLink = webDriver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));
                Assert.That(hiGuirllyLink.Text == "Hi Guirlly", "User hasn't been logged in.");
            }
            catch (Exception ex) 
            {
                Assert.Fail("User hasn't logged in :(" + ex.Message);
            }
        }
    }
}
