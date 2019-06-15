using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace StratsysMeetingsTestSuite
{
    class Program
    {

        static void Main(string[] args)
        {


        }

        [SetUp]
        public void initialize()
        {
            PropertyCollections.driver = new ChromeDriver();
            PropertyCollections.wait = new WebDriverWait(PropertyCollections.driver, new TimeSpan(0, 0, 5));
            PropertyCollections.driver.Navigate().GoToUrl("https://app.meetings.stratsys.com");
            PropertyCollections.driver.Manage().Window.Maximize();
            PropertyCollections.lpo = new LoginPageObjects(PropertyCollections.driver);

        }


        [Test]

        public void StratsysMeetingsTestSuite()
        {
            // ----TestCase 1  :  Log in to Stratsys meetings

            AddMeetingPageObject ampo = LoginPageObjects.Login();

            // ----TestCase 2  :  Create a new meeting

            AddAgendaPageObject aapo = ampo.AddMeeting("Week 1 : Scrum meeting", "This meeting is to get an update on the progress of the current project", "Conference room 2");

            // ----TestCase 3  :  Add an agenda point for the meeting

            AddActionAssignPageObject aaapo = aapo.addAgendaPoint("Developer Updates", "Update on progress, challenges faced, resource requirements if any", "Front End Completed, Testing in progress");

            // ----TestCase 4  :  Add an action and assign it to a fictive user

            UpdateDateTimePageObject udtpo = aaapo.addActionAssignToUser("Develop Analysis Charts", "ramapriya.chakrapani@gmail.com");

            //----TestCase 5   : Update meeting date 

            udtpo.updateMeetingDateTime("23-10-2019", "14:00");


        }


        [TearDown]
        public void cleanUp()
        {
            PropertyCollections.driver.Close();
        }



    }
}
