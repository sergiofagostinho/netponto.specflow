using System;
using System.Threading;
using NetPonto.Specflow.AcceptanceTest2.Helpers;
using NetPonto.Specflow.AcceptanceTest2.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NetPonto.Specflow.AcceptanceTest2.Steps
{
    [Binding]
    public class Steps
    {
        [Given(@"que estou no formulário ""enviar email a amigo""")]
        public void GivenImInTheSendFriendForm()
        {
            var page = new SendEmailPage();
            page.Open();
        }

        [Given(@"preenchi os campos")]
        public void GivenIFilledTheFields()
        {
            var page = new SendEmailPage();

            page.Name = "Sérgio Agostinho";
            page.EmailAddress = "caio@netponto.org";
        }

        [When(@"carrego no botão “enviar”")]
        public void WhenIClickSend()
        {
            ScenarioContext.Current["sendTime"] = DateTime.Now;

            var page = new SendEmailPage();
            page.ClickSendButton();
        }

        [Then(@"um email é enviado para o meu amigo")]
        public void ThenAnEmailIsSentToMyFriend()
        {
            Thread.Sleep(2000);

            var page = new SendEmailPage();
            Assert.IsTrue(page.Result == "Email enviado com sucesso!");

            var sendTime = (DateTime) ScenarioContext.Current["sendTime"];
            var email = new EmailHelper();
            Assert.IsTrue(email.WasSent(sendTime));
        }

    }
}
