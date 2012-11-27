using System;
using System.Net.Mail;
using System.Configuration;

namespace NetPonto.Specflow.Site
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(this.emailAddress.Text) || string.IsNullOrWhiteSpace(this.name.Text))
                    {
                        this.result.Text = "Os campos são obrigatórios!";
                        return;
                    }

                    const string from = "testes-specflow@netponto.pt";
                    var to = this.emailAddress.Text;
                    const string subject = "NetPonto Specflow Demo";
                    var body = string.Format(
                        @"Caro amigo/a,

Vi um site espetacular no NetPonto. Tens de ver! O design é brutal!

Abraços/Beijinhos,
{0}",
                        this.name.Text);

                    var smtpClient = new SmtpClient
                                         {
                                             Host = ConfigurationManager.AppSettings["SmtpServer"]
                                         };
                    smtpClient.Send(from, to, subject, body);

                    this.result.Text = "Email enviado com sucesso!";
                    return;
                }
                catch
                {
                    this.result.Text = "Erro a enviar email. Tente outra vez mais tarde.";
                    return;
                }
            }
        }
    }
}
