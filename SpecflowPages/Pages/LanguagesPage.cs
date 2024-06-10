using MarsQA_GB.SpecflowPages.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection.Emit;
using static System.Collections.Specialized.BitVector32;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class LanguagesPage : CommonDriver
    {
        public void CreateLanguageRecord(IWebDriver webDriver, string language, string languageLevel) 
        {
            //Create a new Language record
            Thread.Sleep(2000);
            //User clicks Languages tab
            IWebElement languagesTab = webDriver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
            languagesTab.Click();

            //Click on Add New button
            IWebElement addNewButton = webDriver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));
            addNewButton.Click();

            //Enter a language in the Add Language text box
            IWebElement languageTextbox = webDriver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            languageTextbox.SendKeys(language);

            //Choose language level from Choose Language Level dropdown list
            //IWebElement languageLevelDropdown = webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
            //languageLevelDropdown.Click();

            Thread.Sleep(2000);

            WaitUtils.WaitToBeClickable(webDriver, "Xpath", "//select[@name='level']", 3);
            IWebElement languageLevelDropdown = webDriver.FindElement(By.XPath("//select[@name='level']"));
            languageLevelDropdown.Click();

            //dropdown menus
            int languageLevelValue = webDriver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option")).Count();
               for (int i = 1; i <= languageLevelValue; i++) 
                {
                    IWebElement levelValue = webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[" + i + "]"));
                    if (levelValue.Text == languageLevel) 
                    {
                        Console.WriteLine("Record was found");
                        webDriver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[" + i + "]")).Click();
                        break;
                    }
                

                }
            

            //Click Add button
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//input[@value='Add']", 3);
            IWebElement addButton = webDriver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(2000);
         
            

        }

        public void VerifyLanguageRecordCreated(IWebDriver webDriver, string index, string language) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: "'{Language}' has been added to your languages"
            //Check if new language record has bene created successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody["+ index + "]/tr/td[1]", 3);
            IWebElement latestAddedLanguage = webDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + index + "]/tr/td[1]"));

            Assert.That(latestAddedLanguage.Text == language, "Language record hasn't been created.");
            Thread.Sleep(2000);

        }

        public void EditNewlyAddedLanguageRecord(IWebDriver webDriver, string index, string newLanguage, string newLanguageLevel)
        {

            Thread.Sleep(2000);

            int editButtonIndex = Int32.Parse(index)*2+10;

            //Click pencil icon to edit language
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//span)[" + editButtonIndex + "]", 3);
            IWebElement editPencilButton = webDriver.FindElement(By.XPath("(//span)[" + editButtonIndex + "]"));
            editPencilButton.Click();

            //Edit the language in the Add Language text box
            IWebElement editLanguageTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editLanguageTextbox.Clear();
            editLanguageTextbox.SendKeys(newLanguage);

            //Edit language level from Choose Language Level dropdown list
            IWebElement editLanguageLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editLanguageLevelDropdown.Click();

            //Choose new language level from the dropdown list
            int newLanguageLevelValue = webDriver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option")).Count();
            for (int i = 1; i <= newLanguageLevelValue; i++)
            {
                IWebElement newLevelValue = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[" + i + "]"));
                if (newLevelValue.Text == newLanguageLevel)
                {
                    Console.WriteLine("Record was found");
                    webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[" + i + "]")).Click();
                    break;
                }


            }

            
          
            //Click  Update button
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody["+ index + "]/tr[1]/td[1]/div[1]/span[1]/input[1]", 3);
            IWebElement updateLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            updateLanguageButton.Click();

            ////Click Cancel button
            //IWebElement cancelUpdateButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[" + index + "]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            //cancelUpdateButton.Click();

            //User sees this message on upper right upon adding: ""'{Language}' has been added to your languages"" in blue"

            Thread.Sleep(2000);
                       
        }

        public void VerifyNewlyEditedLanguageRecord(IWebDriver webDriver, string index, string newLanguage) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: ""'{Language}' has been added to your languages"" in blue"
            //Check if latest language record has been edited successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + index + "]/tr/td[1]", 3);
            IWebElement latestEditedLanguage = webDriver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + index + "]/tr/td[1]"));

            Assert.That(latestEditedLanguage.Text == newLanguage, "Language record hasn't been edited.");
            Thread.Sleep(2000);
        }


        public void DeleteNewlyAddedLanguage(IWebDriver webDriver, string index) 
        {
            Thread.Sleep(2000);

            //int deleteButtonIndex = Int32.Parse(index) * 2 + 11;

            //Click X icon to delete language
            //WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//span)[" + deleteButtonIndex + "]", 3);
            //IWebElement deleteExButton = webDriver.FindElement(By.XPath("(//span)[" + deleteButtonIndex + "]"));
            //deleteExButton.Click();

            //IWebElement recordToBeDeleted = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]"));

            //Delete latest added language options 19 to 13
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//span)["+ index +"]", 3);
            IWebElement deleteLanguageButton = webDriver.FindElement(By.XPath("(//span)[" + index + "]"));
            deleteLanguageButton.Click();
            
            Thread.Sleep(2000);

            webDriver.Navigate().Refresh();

            Thread.Sleep(2000);

        }

        public void VerifyDeletedLanguageRecord(IWebDriver webDriver, string index) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: "'{Language}' has been deleted from your languages" in blue
            //Check if new language record has been deleted succe/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]sfully
            //WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[1]", 3);
            //IWebElement deletedLanguage = webDriver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[1]"));
            //IWebElement deleteLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]"));

            int deletedRowIndex = (Int32.Parse(index) - 11) / 2;

            Assert.That(!webDriver.FindElements(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody["+ index +"]")).Any(), "Language record hasn't been deleted.");
            Thread.Sleep(2000);
        }

    }
}
