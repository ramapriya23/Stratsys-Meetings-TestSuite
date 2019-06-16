using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;
using System;

namespace StratsysMeetingsTestSuite
{
    public class AddActionAssignPageObject
    {
        private RemoteWebDriver _driver;
        public AddActionAssignPageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;
        public IWebElement actionText => _driver.FindElementByXPath("//*[@data-placeholder = 'Action']");
        public IWebElement responsibleBtn => _driver.FindElementByXPath("//*[@title = 'Responsible']");
        public IWebElement inviteUser => _driver.FindElementByXPath("//*[@placeholder = 'Search or invite']");
        public IWebElement inviteNewUserBtn => _driver.FindElementByXPath("//*[@ng-click = '$ctrl.invite()']");
        public IWebElement inviteExistingUserBtn => _driver.FindElementByXPath("//*[@ng-click = '$ctrl.toggleSelect($event, user)']");

        public string _actionText =>_driver.FindElementByXPath("//*[@data-placeholder = 'Action']").Text;
        
        public IWebElement shiftFocus => _driver.FindElementByXPath("//*[@data-placeholder = 'Decision']");
        

        public  UpdateDateTimePageObject addActionAssignToUser(string action,string responsibleUser)
        {
            actionText.SendKeys(action);

            actionText.Click();

            responsibleBtn.Click();

            Thread.Sleep(500);

            inviteUser.SendKeys(responsibleUser);

            Thread.Sleep(1000);

            try
            {
                inviteNewUserBtn.Click();
            }
            catch
            {
                inviteExistingUserBtn.Click();
            }

            Thread.Sleep(1000);

            Console.Write(_actionText);

            shiftFocus.SendKeys("");

            Thread.Sleep(1000);

            UpdateDateTimePageObject udtpo = new UpdateDateTimePageObject(_driver);

            return udtpo;
        }
       

    }
}
