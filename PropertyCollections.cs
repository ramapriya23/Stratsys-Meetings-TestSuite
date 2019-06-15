using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace StratsysMeetingsTestSuite
{
    class PropertyCollections
    {
        public static IWebDriver driver { get; set; }
        public static WebDriverWait wait { get; set; }

        public static LoginPageObjects lpo { get; set; }

    }
}
