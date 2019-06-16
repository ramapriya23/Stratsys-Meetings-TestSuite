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
        private  static RemoteWebDriver _driver;
        public AddMeetingPageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;
        public  IWebElement createMeetingBtn => _driver.FindElementByXPath("//*[@value = 'Create meeting']");
        public  IWebElement Name => _driver.FindElementByXPath("//*[@data-placeholder = 'Name *']");
        public  IWebElement Description => _driver.FindElementByXPath("//*[@data-placeholder='Description']");
        public  IWebElement Location => _driver.FindElementByXPath("//*[@data-placeholder='Location']");
        public  IWebElement createBtn => _driver.FindElementByXPath("//*[@value='Create']");

        public IWebElement dateBtn => _driver.FindElementById("meetings--form-date-picker-controller--show-menu--arrow-drop_down");
        public IWebElement monthdisplayed => _driver.FindElementByXPath("//*[@ng-bind = '$ctrl.calendar.getMonthString()']");

        public IWebElement timeBtn => _driver.FindElementByXPath("//*[@data-placeholder = 'Start time']");
        public IWebElement durationTxt => _driver.FindElementByXPath("//*[@data-placeholder='Duration']");


        public  AddAgendaPageObject AddMeeting(string meetingName , string meetingDescription, string meetingLocation, string meetingDate, string meetingTime, int durationHours, int  durationMins)
        {
          

            createMeetingBtn.Click();

            Thread.Sleep(3000);

            Name.SendKeys(meetingName);

            Description.SendKeys(meetingDescription);

            Location.SendKeys(meetingLocation);

            dateBtn.Click();

            Thread.Sleep(500);

            SetDateTimePageObject setdateTime = new SetDateTimePageObject(_driver);

            setdateTime.setDate(meetingDate);

            timeBtn.Click();

            Thread.Sleep(500);

            setdateTime.setTime(meetingTime);

            Thread.Sleep(500);

            durationTxt.Clear();
           

            if(durationHours == 0)
            {
                durationTxt.SendKeys(durationMins+"m");
            }
            else if(durationMins == 0)
            {
                durationTxt.SendKeys(durationHours + "h");
            }
            else
            {
                durationTxt.SendKeys(durationHours + "h " + durationMins +"m");
            }


            Thread.Sleep(500);
            try
            {

                createBtn.Click();
            }
            catch{ }

            Thread.Sleep(1000);

            AddAgendaPageObject aapo = new AddAgendaPageObject(_driver);

            return aapo;

        }


    }
}
