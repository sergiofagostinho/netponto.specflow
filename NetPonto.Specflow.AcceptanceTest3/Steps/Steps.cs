using System;
using System.Threading;
using NetPonto.Specflow.AcceptanceTest3.Helpers;
using NetPonto.Specflow.AcceptanceTest3.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace NetPonto.Specflow.AcceptanceTest3.Steps
{
    [Binding]
    public class Steps
    {
        [Given(@"que estou no formulário ""enviar a amigo""")]
        public void GivenImInTheSendFriendForm()
        {
            var page = new SendEmailPage();
            page.Open();
        }

        [Given(@"preenchi os campos com o nome ""(.*)"" e endereço ""(.*)""")]
        public void GivenIFilledTheFields(string name, string emailAddress)
        {
            var page = new SendEmailPage();
            page.Name = name;
            page.EmailAddress = emailAddress;
        }

        [When(@"carrego no botão “enviar”")]
        public void WhenIClickSend()
        {
            ScenarioContext.Current["sendTime"] = DateTime.Now;

            var page = new SendEmailPage();
            page.ClickSendButton();
        }

        [Then(@"um email é enviado para o meu amigo")]
        [Then(@"um email é enviado para a minha amiga")]
        public void ThenAnEmailIsSentToMyFriend()
        {
            Thread.Sleep(2000);

            var page = new SendEmailPage();
            Assert.IsTrue(page.Result == "Email enviado com sucesso!");

            var sendTime = (DateTime)ScenarioContext.Current["sendTime"];
            var email = new Email();
            Assert.IsTrue(email.WasSent(sendTime));
        }

        [Then(@"é mostrada uma mensagem de erro com o texto ""(.*)""")]
        public void ThenAnErrorMessageIsShown(string message)
        {
            Thread.Sleep(2000);

            var page = new SendEmailPage();
            Assert.IsTrue(
                page.EmailAddressValidation == message || page.NameValidation == message || page.Result == message);
        }

        [Then(@"nenhum email é enviado para o meu amigo")]
        public void ThenNoEmailIsSentToMyFriend()
        {
            var sendTime = (DateTime)ScenarioContext.Current["sendTime"];
            var email = new Email();
            Assert.IsFalse(email.WasSent(sendTime));
        }

    }
}
