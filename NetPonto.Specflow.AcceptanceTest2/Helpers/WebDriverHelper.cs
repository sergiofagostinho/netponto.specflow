using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace NetPonto.Specflow.AcceptanceTest2.Helpers
{
    public class WebDriverHelper
    {
        private static IWebDriver _instance;

        private static IWebDriver CreateWebDriver()
        {
            IWebDriver driver = null;

            var type = ConfigurationManager.AppSettings["WebDriver"];
            switch (type)
            {
                case "Firefox":
                    {
                        var profile = new FirefoxProfile
                        {
                            AcceptUntrustedCertificates = true,
                            EnableNativeEvents = true
                        };
                        driver = new FirefoxDriver(profile);

                        break;
                    }
                case "InternetExplorer":
                    {
                        // Currently not working
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true
                        };
                        driver = new InternetExplorerDriver(options);

                        break;
                    }                    
                case "Chrome":
                default:
                    throw new NotSupportedException();
            }
            return driver;
        }

        public static IWebDriver CurrentInstance
        {
            get { return _instance ?? (_instance = CreateWebDriver()); }
        }
    }
}
