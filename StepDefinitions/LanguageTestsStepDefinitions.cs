using MarsQA_GB.SpecflowPages.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using MarsQA_GB.SpecflowPages.Utils;

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
        public void WhenUserCreatesANewLanguageRecord(string language, string languageLevel)
        {
            languagesPageObj.CreateLanguageRecord(webDriver, language, languageLevel);
        }

        [Then(@"verify language record is created '([^']*)' '([^']*)'")]
        public void ThenVerifyLanguageRecordIsCreated(string index, string language)
        {
            languagesPageObj.VerifyLanguageRecordCreated(webDriver, index, language);
        }

        [When(@"user edits an existing language record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingLanguageRecord(string index, string newLanguage, string newLanguageLevel)
        {
            languagesPageObj.EditNewlyAddedLanguageRecord(webDriver, index, newLanguage, newLanguageLevel);
        }

        [Then(@"verify language record is updated '([^']*)' '([^']*)'")]
        public void ThenVerifyLanguageRecordIsUpdated(string index, string newLanguage)
        {
            languagesPageObj.VerifyNewlyEditedLanguageRecord(webDriver, index, newLanguage);
        }

        [When(@"user deletes an existing language record '([^']*)'")]
        public void WhenUserDeletesAnExistingLanguageRecord(string newLanguage)
        {
            languagesPageObj.DeleteNewlyAddedLanguage(webDriver, newLanguage);
        }

        [Then(@"verify language record is deleted '([^']*)'")]
        public void ThenVerifyLanguageRecordIsDeleted(string newLanguage)
        {
            languagesPageObj.VerifyDeletedLanguageRecord(webDriver, newLanguage);
        }


        //[TearDown]
        //public void CloseTestRun()
        //{
        //    webDriver.Quit();
        //}
    }
}
