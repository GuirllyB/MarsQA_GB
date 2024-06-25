using MarsQA_GB.SpecflowPages.Pages;
using MarsQA_GB.SpecflowPages.Utils;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_GB.StepDefinitions
{
    [Binding]
    public class SkillTestsStepDefinitions : CommonDriver
    {
        SignInPage signInPageObj = new SignInPage();
        HomePage homePageObj = new HomePage();
        SkillsPage skillsPageObj = new SkillsPage();

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

        [Given(@"user logs into Mars Website")]
        public void GivenUserLogsIntoMarsWebsite()
        {
            //SignIn page object initialisation and definition
            signInPageObj.LoginActions(webDriver, "xakiso2830@ahieh.com", "Mar$1234");
        }

        [Given(@"user navigates to Skills page")]
        public void GivenUserNavigatesToSkillsPage()
        {
            homePageObj.NavigateToSkillsPage(webDriver);
        }

        [When(@"user creates a new skill record '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewSkillRecord(string skill, string skillLevel)
        {
            skillsPageObj.CreateSkillRecord(webDriver, skill, skillLevel);
        }

        [Then(@"verify skill record is created '([^']*)' '([^']*)'")]
        public void ThenVerifySkillRecordIsCreated(string index, string skill)
        {
            skillsPageObj.VerifySkillRecordCreated(webDriver, index, skill);
        }

        [When(@"user edits an existing skill record '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingSkillRecord(string index, string newSkill, string newSkillLevel)
        {
            skillsPageObj.EditNewlyAddedSkillRecord(webDriver, index, newSkill, newSkillLevel);
        }

        [Then(@"verify skill record is updated '([^']*)' '([^']*)'")]
        public void ThenVerifySkillRecordIsUpdated(string index, string newSkill)
        {
            skillsPageObj.VerifyNewlyEditedSkillRecord(webDriver, index, newSkill);
        }

        [When(@"user deletes an existing skill record '([^']*)'")]
        public void WhenUserDeletesAnExistingSkillRecord(string index)
        {
            skillsPageObj.DeleteNewlyAddedSkill(webDriver, index);
        }

        [Then(@"verify skill record is deleted '([^']*)'")]
        public void ThenVerifySkillRecordIsDeleted(string index)
        {
            skillsPageObj.VerifyDeletedSkillRecord(webDriver, index);
        }


        //[TearDown]
        //public void CloseTestRun()
        //{
        //    webDriver.Quit();
        //}

    }
}
