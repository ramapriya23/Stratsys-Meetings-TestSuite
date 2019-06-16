using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace StratsysMeetingsTestSuite
{
    public class UpdateDateTimePageObject
    {
        private static RemoteWebDriver _driver;
        public UpdateDateTimePageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;

     
        public IWebElement infoIconBtn => _driver.FindElementByXPath("//*[@title = 'View meeting details']");
        public IWebElement dateBtn => _driver.FindElementByXPath("//*[@title = 'Date']");
       
        public IWebElement scrollItem => _driver.FindElementById("id1560617841980");
        public IWebElement timeBtn => _driver.FindElementByXPath("//*[@title = 'Start time']");


        SetDateTimePageObject sdtpo = new SetDateTimePageObject(_driver);

        public void updateMeetingDateTime(string date, string time)
        {


            //--------------------------------- Update Date
            infoIconBtn.Click();


            Thread.Sleep(500);

            dateBtn.Click();

            sdtpo.setDate(date);
           //----------------------------------------------------------------update time

            _driver.ExecuteScript("arguments[0].scrollIntoView()", timeBtn);

            timeBtn.Click();

            Thread.Sleep(500);

            sdtpo.setTime(time);

            Thread.Sleep(500);

           


        }
     

    }
}
