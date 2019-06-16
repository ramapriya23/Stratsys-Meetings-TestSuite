# Stratsys Meetings TestSuite

### Description
Test Suite written for the Stratsys Meetings Website to written in C#.Net with Selenium to check specific functionalities.

### Project Walk-through
Below is a short descripton of each file in the repo

- #### StartUp.cs
  
This is the entry point into the TestSuite. The test method invokes all the test cases to be performed. The page and specific objects are initialized before the calls to the test cases are made.

- #### LoginPageObjects.cs
  
This class file implements the test case required to Login to an account to perform test cases.

- #### AddMeetingPageObjects.cs
 
This class file implements the test case required to create a new meeting. Here details of the meeting such as location, date, time and duration.

- #### AddAgendaPageObjects.cs
  
This class file implements the test case required to add a new agenda to the meeting created. Feilds like title, description for the agenda and notes section are filled.

- #### AddActionAssignPageObejects.cs
  
This class file implements the test case required to add an action for the agenda and assign the action to the name of the user passed as a parameter.

- #### UpdateDateTimePageObjects.cs
  
This class file implements the test case required to Update the Date and Time of the meeting.

- #### SetDateTime.cs
  
This consists of common objects required to set Date and time of a meeting. It is implemented by the objects of *AddMeetingPageObjects.cs* and *UpdateDateTimePageObjects.cs*.

- #### CheckDate.cs
  
This checks if the date passed as a parameter is valid. Returns the appropriate action to be taken.

- #### PropertyCollections.cs
  
This class consists of common objects used through out the project.

#### Deployment

- Miscrosoft Visual Studio (any latest version should do)
- Selenium : Install from NuGet package manager
- Importing the project code from this GITHub repo
- Hit run!

