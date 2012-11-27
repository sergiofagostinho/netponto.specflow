<%@ Page Title="Enviar email a amigo" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="NetPonto.Specflow.Site.SendEmail" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Enviar email a amigo
    </h2>
    <p>
        <label for="MainContent_name">
            O seu nome:</label>
        <asp:TextBox ID="name" runat="server" Columns="24"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator"
                            ControlToValidate="name" Display="Dynamic" 
                            ErrorMessage="2 a 24 letras, sem números nem símbolos" CssClass="error"
                            ValidationExpression="([A-Za-zàÀèÈéÉïÏîÎôÔêÊçÇ\s]){2,24}" runat="server" />
        <br />
        <label for="MainContent_emailAddress">
            O email do seu amigo:</label>
        <asp:TextBox ID="emailAddress" runat="server" Columns="24"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ControlToValidate="emailAddress" Display="Dynamic" 
                            ErrorMessage="o endereço de email não é válido" CssClass="error"
                            ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" runat="server" />
        <br />
        <asp:Button ID="send" runat="server" Text="Enviar" />
        <%--<asp:Button ID="send" runat="server" Text="Enviar" OnClientClick="if ($('#MainContent_name').val() === '' || $('#MainContent_emailAddress').val() === '') { $('#MainContent_result').val('Os campos são obrigatórios!'); return false; }"/>--%>

        <br />
        <asp:Label ID="result" runat="server" />
    </p>
</asp:Content>
