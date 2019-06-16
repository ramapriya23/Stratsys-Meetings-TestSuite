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

    public class SetDateTimePageObject
    {
        private RemoteWebDriver _driver;
        public SetDateTimePageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;

        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public IWebElement monthdisplayed => _driver.FindElementByXPath("//*[@ng-bind = '$ctrl.calendar.getMonthString()']");
        public IWebElement nextMonthArrowBtn => _driver.FindElementByXPath("//*[@ng-click = '$ctrl.calendar.nextMonth()']");
        public IReadOnlyCollection<IWebElement> dates => _driver.FindElementsByXPath("//*[@ng-click = '$ctrl.select(day)']");
        public IWebElement timeTextbox => _driver.FindElementByXPath("//*[@name = 'start']");


        public void setDate(string date)
        {


            string monthDisplay = monthdisplayed.Text;

            DateTime toDateFormat = Convert.ToDateTime(date);
            string _date = toDateFormat.ToString("dd").TrimStart(new Char[] { '0' });

            string year = toDateFormat.ToString("yyyy");
            string month = toDateFormat.ToString("MMM");

            //----------------------------------------------select year

            switch (CheckDate.isSelectedYear(year, monthDisplay))
            {
                case 1: break;

                case -1: Console.WriteLine("Cannot create meeting for past year"); break;

                case 0:
                    {
                        while (!monthdisplayed.Text.Contains(year))
                        {
                            nextMonthArrowBtn.Click();
                        }
                    }
                    break;
            }

            //-----------------------------------------select month

            switch (CheckDate.isSelectedMonth(month, monthDisplay))
            {
                case 1: break;

                case -1: Console.WriteLine("Cannot create meeting for past month"); break;

                case 0:
                    {
                        while (!monthdisplayed.Text.Contains(month))
                        {
                            nextMonthArrowBtn.Click();
                        }
                    }
                    break;
            }
            //----------------------------------------select date
            foreach (IWebElement x in dates)
            {
                if (x.Text == _date)
                {
                    x.Click();
                    break;
                }
            }
            Thread.Sleep(500);

        }
        public void setTime(string time)
        {

            timeTextbox.Clear();

            timeTextbox.SendKeys(time);

            //timeTextbox.SendKeys(Keys.Enter);

            Thread.Sleep(1000);
        }

    }

}
