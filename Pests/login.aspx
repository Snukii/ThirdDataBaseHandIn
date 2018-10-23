<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Pests.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
&nbsp;Email<br />
<br />
<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
&nbsp;Password<br />
<br />
<asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" />
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
<br />
<br />
<asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
