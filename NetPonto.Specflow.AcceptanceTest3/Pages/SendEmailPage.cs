using System.Configuration;
using NetPonto.Specflow.AcceptanceTest3.Helpers;
using OpenQA.Selenium;

namespace NetPonto.Specflow.AcceptanceTest3.Pages
{
    public class SendEmailPage
    {
        public void Open()
        {
            var webDriver = WebDriverFactory.CurrentInstance;
            webDriver.Url = ConfigurationManager.AppSettings["WebAppRoot"] + "/SendEmail.aspx";
            webDriver.Navigate();
        }

        public string Name
        {
            set
            {
                var webDriver = WebDriverFactory.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_name"));
                element.SendKeys(value);
            }
        }

        public string NameValidation
        {
            get 
            { 
                var webDriver = WebDriverFactory.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_RegularExpressionValidator"));
                return element.Text;
            }
        }

        public string EmailAddress
        {
            set
            {
                var webDriver = WebDriverFactory.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_emailAddress"));
                element.SendKeys(value);
            }
        }

        public string EmailAddressValidation
        {
            get
            {
                var webDriver = WebDriverFactory.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_RegularExpressionValidator1"));
                return element.Text;
            }
        }

        public string Result
        {
            get
            {
                var webDriver = WebDriverFactory.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_result"));
                return element.Text;
            }
        }

        public void ClickSendButton()
        {
            var webDriver = WebDriverFactory.CurrentInstance;
            var element = webDriver.FindElement(By.Id("MainContent_send"));
            element.Click();
        }
    }
}
