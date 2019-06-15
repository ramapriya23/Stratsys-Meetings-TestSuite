using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Remote;

namespace StratsysMeetingsTestSuite
{
    public class AddAgendaPageObject
    {
        private RemoteWebDriver _driver;
        public AddAgendaPageObject(IWebDriver driver) => _driver = (RemoteWebDriver)driver;
        public IWebElement createAgendaBtn => _driver.FindElementByXPath("//*[@ng-click='$ctrl.createAgenda()']");
        public IWebElement Title => _driver.FindElementByXPath("//*[@data-placeholder='Title']");
        public IWebElement Description => _driver.FindElementByXPath("//*[@data-placeholder='Description'][@class = 'rym-focus-line focus-line-padding text(body-italic)']");
        public IWebElement Note => _driver.FindElementByXPath("//*[@data-placeholder='Notes']");

        public AddActionAssignPageObject addAgendaPoint(string agendaTitle, string agendaDescription, string agendaNote)
        {
            createAgendaBtn.Click();

            Title.SendKeys(agendaTitle);

            Description.SendKeys(agendaDescription);

            Note.SendKeys(agendaNote);

            AddActionAssignPageObject aaapo = new AddActionAssignPageObject(_driver);

            return aaapo;

        }

    }

    
}
