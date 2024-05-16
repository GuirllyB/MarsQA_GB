using MarsQA_GB.SpecflowPages.Utils;
using OpenQA.Selenium;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class SignIn : CommonDriver
    {
        //private readonly By signInButtonLocator = By.XPath("//a[normalize-space()='Sign In']");
        //IWebElement signInButton;
        private readonly By emailTextboxLocator = By.CssSelector("input[placeholder='Email address']");
        IWebElement emailTextbox;
        private readonly By passwordTextboxLocator = By.CssSelector("input[placeholder='Password']");
        IWebElement passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//button[normalize-space()='Login']");
        IWebElement loginButton;



        public void LoginActions(IWebDriver webDriver, string emailaddress, string password)
        { 
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //Launch Mars Portal
            string baseURL = "http://localhost:5000/Home";
            webDriver.Navigate().GoToUrl(baseURL);

            Thread.Sleep(2000);

            //Identify SignIn Button and click
            IWebElement signInButton = webDriver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
            signInButton.Click();


            //Identify email address textbox and enter valid email
            emailTextbox = webDriver.FindElement(emailTextboxLocator);
            emailTextbox.SendKeys(emailaddress);

           //Identify password textbox and enter valid password
            passwordTextbox = webDriver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);

            //Identify login button and click on the button
            loginButton = webDriver.FindElement(loginButtonLocator);
            loginButton.Click();

        }





    }
}
