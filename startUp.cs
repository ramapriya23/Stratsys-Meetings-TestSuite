using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace StratsysMeetingsTestSuite
{
    class StartUp
    {

        static void Main(string[] args)
        {


        }

        [SetUp]
        public void initialize()
        {
            PropertyCollections.driver = new ChromeDriver();
            PropertyCollections.lpo = new LoginPageObjects(PropertyCollections.driver);
            PropertyCollections.driver.Navigate().GoToUrl("https://app.meetings.stratsys.com");
            PropertyCollections.driver.Manage().Window.Maximize();
            Thread.Sleep(2000);



        }


        [Test]

        public void StratsysMeetingsTestSuite()
        {
            // Log in to Stratsys meetings

            AddMeetingPageObject ampo = LoginPageObjects.Login();



            // ----TestCase 1 :  Create a new meeting

            AddAgendaPageObject aapo = ampo.AddMeeting("Week 1 : Scrum meeting", "This meeting is to get an update on the progress of the current project", "Conference room 2", "07-05-2018", "10:00",0,30);

            // ----TestCase 2  :  Add an agenda point for the meeting

            AddActionAssignPageObject aaapo = aapo.addAgendaPoint("Developer Updates", "Update on progress, challenges faced, resource requirements if any", "Front End Completed, Testing in progress");

            // ----TestCase 3  :  Add an action and assign it to a fictive user

            UpdateDateTimePageObject udtpo = aaapo.addActionAssignToUser("Develop Analysis Charts", "ramapriya.chakrapani@gmail.com");

            // ----TestCase 4   : Update meeting date 

            udtpo.updateMeetingDateTime("23-10-2019", "14:00");


        }


        [TearDown]
        public void cleanUp()
        {
            PropertyCollections.driver.Close();
        }



    }
}
