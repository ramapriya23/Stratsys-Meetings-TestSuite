using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;

namespace StratsysMeetingsTestSuite
{

    public class LoginPageObjects
    {

        private static RemoteWebDriver _driver;
        public  LoginPageObjects(IWebDriver driver) => _driver = (RemoteWebDriver)driver;

        public static IWebElement AllowCookieAccessBtn => _driver.FindElementById("hs-eu-confirmation-button");

        public static IWebElement userName => _driver.FindElementByXPath("//input[@equal-to='$ctrl.equalToModel'][@name = 'UserName']");

        public static IWebElement password => _driver.FindElementByXPath("//input[@equal-to='$ctrl.equalToModel'][@name = 'password']");

        public static IWebElement loginBtn => _driver.FindElementByXPath("//*[@value = 'Log in']");

        public static AddMeetingPageObject Login()
        {
           
            AllowCookieAccessBtn.Click();     //---------------------HANDLE ALLOW COOKIES POP UP
        
            userName.SendKeys(ConfigurationManager.AppSettings["Username"]);
       
            password.SendKeys(ConfigurationManager.AppSettings["Password"]);
        
            loginBtn.Click();

            Thread.Sleep(5000);

            AddMeetingPageObject ampo = new AddMeetingPageObject(_driver);

            return ampo;

        }
    }



}
