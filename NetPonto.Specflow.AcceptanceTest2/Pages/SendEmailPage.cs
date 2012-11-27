using System.Configuration;
using NetPonto.Specflow.AcceptanceTest2.Helpers;
using OpenQA.Selenium;

namespace NetPonto.Specflow.AcceptanceTest2.Pages
{
    public class SendEmailPage
    {
        protected IWebDriver WebDriver
        {
            get { return WebDriverHelper.CurrentInstance; }
        }

        public void Open()
        {
            var webDriver = WebDriverHelper.CurrentInstance;
            webDriver.Url = ConfigurationManager.AppSettings["WebAppRoot"] + "/SendEmail.aspx";
            webDriver.Navigate();
        }

        public string Name
        {
            set
            {
                var webDriver = WebDriverHelper.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_name"));
                element.SendKeys(value);
            }
        }

        public string EmailAddress
        {
            set
            {
                var webDriver = WebDriverHelper.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_emailAddress"));
                element.SendKeys(value);
            }
        }

        public string Result
        {
            get
            {
                var webDriver = WebDriverHelper.CurrentInstance;
                var element = webDriver.FindElement(By.Id("MainContent_result"));
                return element.Text;
            }
        }

        public void ClickSendButton()
        {
            var webDriver = WebDriverHelper.CurrentInstance;
            var element = webDriver.FindElement(By.Id("MainContent_send"));
            element.Click();
        }

    }
}
