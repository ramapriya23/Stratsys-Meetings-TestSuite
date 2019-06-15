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
        private RemoteWebDriver _driver;
        public UpdateDateTimePageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;

        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public IWebElement infoIconBtn => _driver.FindElementByXPath("//*[@title = 'View meeting details']");
        public IWebElement dateBtn => _driver.FindElementByXPath("//*[@title = 'Date']");

        public IWebElement monthdisplayed => _driver.FindElementByXPath("//*[@ng-bind = '$ctrl.calendar.getMonthString()']");

        public IWebElement nextMonthArrowBtn => _driver.FindElementByXPath("//*[@ng-click = '$ctrl.calendar.nextMonth()']");

        public IReadOnlyCollection<IWebElement> dates => _driver.FindElementsByXPath("//*[@ng-click = '$ctrl.select(day)']");
        public IWebElement scrollItem => _driver.FindElementById("id1560617841980");  

        public IWebElement timeBtn => _driver.FindElementByXPath("//*[@title = 'Start time']");

        public IWebElement timeTextbox => _driver.FindElementByXPath("//*[@name = 'start']");

        public void updateMeetingDateTime(string date, string time)
        {


            //--------------------------- Update Date


            infoIconBtn.Click();

            Thread.Sleep(500);

            dateBtn.Click();

            string monthDisplay = monthdisplayed.Text;

            DateTime toDateFormat = Convert.ToDateTime(date);

            string _date = toDateFormat.ToString("dd");
            string month = toDateFormat.ToString("MMM");
            string year = toDateFormat.ToString("yyyy");

            if (!monthDisplay.Contains(year))
            {

                int toYear = Convert.ToInt32(year);
                int currentYear = Convert.ToInt32(monthDisplay.Substring(5, monthDisplay.Length));

                int diff = toYear - currentYear;

                if (diff < 0)
                {
                    Console.WriteLine("Cannot book meeting for past year");
                }
                else
                {
                    while (!monthdisplayed.Text.Contains(year))
                    {
                        nextMonthArrowBtn.Click();
                    }

                }
            }

            if (!monthDisplay.Contains(month))
            {
                int indexofMonthDisplay = Array.IndexOf(months, monthDisplay.Substring(0, 3));
                int indexOfMonth = Array.IndexOf(months, month);

                if (indexOfMonth < indexofMonthDisplay)
                {
                    Console.WriteLine("Cannot book meeting for past year");
                }
                else
                {
                    while (!monthdisplayed.Text.Contains(month))
                    {
                        nextMonthArrowBtn.Click();
                    }
                }
            }
            foreach(IWebElement x in dates)
            {
                if(x.Text == _date)
                {
                    x.Click();
                    break;
                }
            }
            Thread.Sleep(500);

            //---------------------------------Update Time

           _driver.ExecuteScript("arguments[0].scrollIntoView()", timeBtn);

            Thread.Sleep(500);

            timeBtn.Click();

            Thread.Sleep(500);

            timeTextbox.Clear();

            timeTextbox.SendKeys(time);

            timeTextbox.SendKeys(Keys.Enter);

            Thread.Sleep(1000);



        }
    }
}
