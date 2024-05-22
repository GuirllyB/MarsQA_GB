using MarsQA_GB.SpecflowPages.Pages;
using MarsQA_GB.SpecflowPages.Utils;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_GB.StepDefinitions
{
    [Binding]
    public class LanguageTestsStepDefinitions : CommonDriver
    {
        SignInPage signInPageObj = new SignInPage();
        HomePage homePageObj = new HomePage();
        LanguagesPage languagesPageObj = new LanguagesPage();

        [Before]
        public void Before()
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();
            Thread.Sleep(1000);

        }

        [After]
        public void After()
        {
            webDriver.Quit();
        }


        [Given(@"user logs into Mars portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            //SignIn page object initialisation and definition
            signInPageObj.LoginActions(webDriver, "xakiso2830@ahieh.com", "Mar$1234");
        }

        [Given(@"user navigates to Languages page")]
        public void GivenUserNavigatesToLanguagesPage()
        {
            homePageObj.NavigateToLanguagesPage(webDriver);
        }

        [When(@"user creates a new language record '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewLanguageRecord(string language, string level)
        {
            languagesPageObj.CreateLanguageRecord(webDriver, "French", "Basic");
        }

        [Then(@"verify language record is created")]
        public void ThenVerifyLanguageRecordIsCreated(string language, string level)
        {
            languagesPageObj.VerifyLanguageRecordCreated(webDriver, language, level);
        }
    }
}
