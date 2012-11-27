using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
                        var firefoxProfile = new FirefoxProfile
                        {
                            AcceptUntrustedCertificates = true,
                            EnableNativeEvents = true
                        };
                        driver = new FirefoxDriver(firefoxProfile);

                        break;
                    }
                case "Chrome":
                case "InternetExplorer":
                    // TODO
                    break;
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
