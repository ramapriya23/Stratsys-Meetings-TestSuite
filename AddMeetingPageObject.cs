using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;

namespace StratsysMeetingsTestSuite
{
    public class AddMeetingPageObject
    {
        private  RemoteWebDriver _driver;
        public AddMeetingPageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;
        public  IWebElement createMeetingBtn => _driver.FindElementByXPath("//*[@value = 'Create meeting']");
        public  IWebElement Name => _driver.FindElementByXPath("//*[@data-placeholder = 'Name *']");
        public  IWebElement Description => _driver.FindElementByXPath("//*[@data-placeholder='Description']");
        public  IWebElement Location => _driver.FindElementByXPath("//*[@data-placeholder='Location']");
        public  IWebElement createBtn => _driver.FindElementByXPath("//*[@value='Create']");

        public  AddAgendaPageObject AddMeeting(string meetingName , string meetingDescription, string meetingLocation)
        {
            createMeetingBtn.Click();

            Thread.Sleep(4000);

            Name.SendKeys(meetingName);

            Description.SendKeys(meetingDescription);

            Location.SendKeys(meetingLocation);

            createBtn.Click();

            Thread.Sleep(3000);

            AddAgendaPageObject aapo = new AddAgendaPageObject(_driver);

            return aapo;

        }


    }
}
