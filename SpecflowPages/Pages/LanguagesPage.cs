using MarsQA_GB.SpecflowPages.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection.Emit;

namespace MarsQA_GB.SpecflowPages.Pages
{
    public class LanguagesPage : CommonDriver
    {
        public void CreateLanguageRecord(IWebDriver webDriver, string language, string level) 
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
            IWebElement languageLevelDropdown = webDriver.FindElement(By.XPath("//select[@name='level']"));
            languageLevelDropdown.Click();
            IWebElement chooseLanguageLevel = webDriver.FindElement(By.XPath("//option[normalize-space()='Choose Language Level']"));
            chooseLanguageLevel.Click();
            IWebElement basicLevel = webDriver.FindElement(By.XPath("//option[@value='Basic']"));
            basicLevel.Click();
            IWebElement conversationalLevel = webDriver.FindElement(By.XPath("//option[@value='Conversational']"));
            conversationalLevel.Click();
            IWebElement fluentLevel = webDriver.FindElement(By.XPath("//option[@value='Fluent']"));
            fluentLevel.Click();
            //IWebElement nativeBilingualLevel = webDriver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
            //nativeBilingualLevel.Click();

            //Click Add button
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//input[@value='Add']", 3);
            IWebElement addButton = webDriver.FindElement(By.XPath("//input[@value='Add']"));
            addButton.Click();

            Thread.Sleep(2000);
         
            

        }

        public void VerifyLanguageRecordCreated(IWebDriver webDriver, string language, string level) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: "'{Language}' has been added to your languages"
            //Check if new language record has bene created successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[1]/input[1]", 3);
            IWebElement latestAddedLanguage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[1]/input[1]"));

            Assert.That(latestAddedLanguage.Text == language, "Language record hasn't been edited.");
            Thread.Sleep(2000);

        }

        public void EditNewlyAddedLanguageRecord(IWebDriver webDriver, string language, string level)
        {

            Thread.Sleep(2000);

            //Click 1st pencil icon to edit language 1
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//td[@class='right aligned'])[1]", 3);
            IWebElement editFirstPencilButton = webDriver.FindElement(By.XPath("(//span)[12]"));
            editFirstPencilButton.Click();

            //Edit the 1st language in the Add Language text box
            IWebElement editFirstLanguageTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editFirstLanguageTextbox.SendKeys(language);

            //Edit 1st language level from Choose Language Level dropdown list
            IWebElement editFirstLanguageLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editFirstLanguageLevelDropdown.Click();
            IWebElement editFirstChooseLanguageLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[1]"));
            editFirstChooseLanguageLevel.Click();
            IWebElement editFirstBasicLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[2]"));
            editFirstBasicLevel.Click();
            IWebElement editFirstConversationalLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[3]"));
            editFirstConversationalLevel.Click();
            IWebElement editFirstFluentLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[4]"));
            editFirstFluentLevel.Click();
            IWebElement editFirstNativeBilingualLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[5]"));
            editFirstNativeBilingualLevel.Click();

            //Click 1st Update button
            IWebElement firstUpdateLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            firstUpdateLanguageButton.Click();

            //Click 1st Cancel button
            IWebElement firstCancelButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            firstCancelButton.Click();

            //User sees this message on upper right upon adding: ""'{Language}' has been added to your languages"" in blue"



            //Clicks 2nd pencil icon to edit language 2
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//td[@class='right aligned'])[2]", 3);
            IWebElement editSecondPencilButton = webDriver.FindElement(By.XPath("(//span)[14]"));
            editSecondPencilButton.Click();

            //Edit the 2nd language in the Add Language text box
            IWebElement editSecondLanguageTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editSecondLanguageTextbox.SendKeys(language);

            //Edit 2nd language level from Choose Language Level dropdown list
            IWebElement editSecondLanguageLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editSecondLanguageLevelDropdown.Click();
            IWebElement editSecondChooseLanguageLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[1]"));
            editSecondChooseLanguageLevel.Click();
            IWebElement editSecondBasicLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[2]"));
            editSecondBasicLevel.Click();
            IWebElement editSecondConversationalLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[3]"));
            editSecondConversationalLevel.Click();
            IWebElement editSecondFluentLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[4]"));
            editSecondFluentLevel.Click();
            IWebElement editSecondNativeBilingualLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[5]"));
            editSecondNativeBilingualLevel.Click();

            //Click 2nd Update button
            IWebElement secondUpdateLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            secondUpdateLanguageButton.Click();

            //Click 2nd Cancel button
            IWebElement secondCancelLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[2]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            secondCancelLanguageButton.Click();



            //Clicks 3rd pencil icon to edit language 3
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//td[@class='right aligned'])[3]", 3);
            IWebElement editThirdPencilButton = webDriver.FindElement(By.XPath("(//span)[16]"));
            editThirdPencilButton.Click();

            //Edit the 3rd language in the Add Language text box
            IWebElement editThirdLanguageTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editThirdLanguageTextbox.SendKeys(language);

            //Edit 3rd language level from Choose Language Level dropdown list
            IWebElement editThirdLanguageLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editThirdLanguageLevelDropdown.Click();
            IWebElement editThirdChooseLanguageLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[1]"));
            editThirdChooseLanguageLevel.Click();
            IWebElement editThirdBasicLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[2]"));
            editThirdBasicLevel.Click();
            IWebElement editThirdConversationalLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[3]"));
            editThirdConversationalLevel.Click();
            IWebElement editThirdFluentLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[4]"));
            editThirdFluentLevel.Click();
            IWebElement editThirdNativeBilingualLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[5]"));
            editThirdNativeBilingualLevel.Click();

            //Click 3rd Update button
            IWebElement thirdUpdateLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            thirdUpdateLanguageButton.Click();

            //Click 3rd Cancel button
            IWebElement thirdCancelLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[3]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            thirdCancelLanguageButton.Click();


            //Clicks 4th pencil icon to edit language 4
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "(//td[@class='right aligned'])[4]", 3);
            IWebElement editFourthPencilButton = webDriver.FindElement(By.XPath("(//span)[18]"));
            editFourthPencilButton.Click();

            //Edit the 4th language in the Add Language text box
            IWebElement editFourthLanguageTextbox = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[1]/input[1]"));
            editFourthLanguageTextbox.SendKeys(language);

            //Edit 4th language level from Choose Language Level dropdown list
            IWebElement editFourthLanguageLevelDropdown = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]"));
            editFourthLanguageLevelDropdown.Click();
            IWebElement editFourthChooseLanguageLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[1]"));
            editFourthChooseLanguageLevel.Click();
            IWebElement editFourthBasicLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[2]"));
            editFourthBasicLevel.Click();
            IWebElement editFourthConversationalLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[3]"));
            editFourthConversationalLevel.Click();
            IWebElement editFourthFluentLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[4]"));
            editFourthFluentLevel.Click();
            IWebElement editFourthNativeBilingualLevel = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[2]/select[1]/option[5]"));
            editFourthNativeBilingualLevel.Click();

            //Click 4th Update button
            IWebElement fourthUpdateLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/span[1]/input[1]"));
            fourthUpdateLanguageButton.Click();

            //Click 4th Cancel button
            IWebElement fourthCancelLanguageButton = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/span[1]/input[2]"));
            fourthCancelLanguageButton.Click();

            Thread.Sleep(2000);
        }

        public void VerifyNewlyEditedLanguageRecord(IWebDriver webDriver, string language) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: ""'{Language}' has been added to your languages"" in blue"
            //Check if latest language record has been edited successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[1]/input[1]", 3);
            IWebElement latestEditedLanguage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]/td[1]/div[1]/div[1]/input[1]"));

            Assert.That(latestEditedLanguage.Text == language, "Language record hasn't been edited.");
            Thread.Sleep(2000);
        }


        public void DeleteNewlyAddedLanguage(IWebDriver webDriver, string language) 
        {
            Thread.Sleep(2000);

            //Delete latest added language
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "(//i)[21]", 3);
            IWebElement lastDeleteLanguageButton = webDriver.FindElement(By.XPath("(//i)[21]"));
            lastDeleteLanguageButton.Click();

            Thread.Sleep(2000);

        }

        public void VerifyDeletedLanguageRecord(IWebDriver webDriver, string language) 
        {
            Thread.Sleep(2000);
            //User sees this message on upper right upon adding: "'{Language}' has been deleted from your languages" in blue
            //Check if new language record has been deleted successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]", 3);
            IWebElement deletedLanguage = webDriver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[4]/tr[1]"));

            Assert.That(deletedLanguage.Text == language, "Language record hasn't been deleted.");

        }

    }
}
