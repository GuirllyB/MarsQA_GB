using MarsQA_GB.SpecflowPages.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class SkillsPage : CommonDriver
    {
        public void CreateSkillRecord(IWebDriver webDriver, string skill, string skillLevel)
        {
            //Create a new Skill record
            Thread.Sleep(2000);
            //User clicks Skills tab
            IWebElement skillsTab = webDriver.FindElement(By.XPath("//a[normalize-space()='Skills']"));
            skillsTab.Click();

            //Click on Add New button
            IWebElement addNewSkillButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[3]/div[1]"));
            addNewSkillButton.Click();

            //Enter a skill in the Add Skill text box
            IWebElement skillTextbox = webDriver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            skillTextbox.SendKeys(skill);

            Thread.Sleep(2000);


            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//select[@class='ui fluid dropdown']", 3);
            IWebElement skillLevelDropdown = webDriver.FindElement(By.XPath("(//select[@class='ui fluid dropdown']"));
            skillLevelDropdown.Click();

            //dropdown menus
            int skillIndex = webDriver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")).Count();
            for (int i = 1; i <= skillIndex; i++)
            {
                IWebElement skillLevelValue = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]/option[" + i + "]"));
                if (skillLevelValue.Text == skillLevel)
                {
                    Console.WriteLine("Record was found");
                    webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]/option[" + i + "]")).Click();
                    break;
                }


            }

            //Click Add button
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//input[@value='Add'])[2]", 3);
            IWebElement addSkillButton = webDriver.FindElement(By.XPath("(//input[@value='Add'])[2]"));
            addSkillButton.Click();

            Thread.Sleep(2000);

        }

        public void VerifySkillRecordCreated(IWebDriver webDriver, string index, string skill)
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: "'{Skill}' has been added to your skills"
            //Check if new skill record has bene created successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]", 3);
            IWebElement latestAddedSkill = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]"));

            Assert.That(latestAddedSkill.Text == skill, "Skill record hasn't been created.");
            Thread.Sleep(2000);

        }

        public void EditNewlyAddedSkillRecord(IWebDriver webDriver, string index, string newSkill, string newSkillLevel)
        {

            Thread.Sleep(2000);

            int editSkillButtonIndex = Int32.Parse(index) * 2 + 10;

            //Click pencil icon to edit skill Int 12, 14, 16, 18
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//span)[" + editSkillButtonIndex + "]", 3);
            IWebElement editSkillPencilButton = webDriver.FindElement(By.XPath("(//span)[" + editSkillButtonIndex + "]"));
            editSkillPencilButton.Click();

            //Edit the skill in the Add skill text box
            IWebElement editSkillTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editSkillTextbox.Clear();
            editSkillTextbox.SendKeys(newSkill);

            //Edit language level from Choose Language Level dropdown list
            IWebElement editSkillLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editSkillLevelDropdown.Click();

            //Choose new language level from the dropdown list
            int newSkillLevelValue = webDriver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option")).Count();
            for (int i = 1; i <= newSkillLevelValue; i++)
            {
                IWebElement newSkLevelValue = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[" + i + "]"));
                if (newSkLevelValue.Text == newSkillLevel)
                {
                    Console.WriteLine("Record was found");
                    webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[" + i + "]")).Click();
                    break;
                }


            }

            //Click  Update button
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/span[1]/input[1]", 3);
            IWebElement updateSkillButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            updateSkillButton.Click();

            ////Click Cancel button
            //IWebElement cancelUpdateSkillButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody["+ index +"]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            //cancelUpdateSkillButton.Click();

            Thread.Sleep(2000);

        }

        public void VerifyNewlyEditedSkillRecord(IWebDriver webDriver, string index, string newSkill)
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: ""'{Skill}' has been added to your skills"" in blue"
            //Check if latest skill record has been edited successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]", 3);
            IWebElement latestEditedSkill = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]"));

            Assert.That(latestEditedSkill.Text == newSkill, "Skill record hasn't been edited.");
            Thread.Sleep(2000);
        }

        public void DeleteNewlyAddedSkill(IWebDriver webDriver, string index)
        {
            Thread.Sleep(2000);

            //Delete latest added skill options 19 to 13
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//span)[" + index + "]", 3);
            IWebElement deleteSkillButton = webDriver.FindElement(By.XPath("(//span)[" + index + "]"));
            deleteSkillButton.Click();

            Thread.Sleep(2000);

            webDriver.Navigate().Refresh();

            Thread.Sleep(2000);

        }

        public void VerifyDeletedSkillRecord(IWebDriver webDriver, string index)
        {
            Thread.Sleep(2000);

            //Check if new skill record has been deleted successfully

            int deletedSkillRowIndex = (Int32.Parse(index) - 11) / 2;

            Assert.That(!webDriver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]")).Any(), "Skill record hasn't been deleted.");
            Thread.Sleep(2000);
        }

    }

}

    
