<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Pests.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Welcome, these are the pests we offer to take care of:"></asp:Label>
    <br />
    <asp:Repeater ID="RepeaterWelcome" runat="server">
        <HeaderTemplate>
            <table class="mytable">
                        <tr>
                            <td class="myheader">ID</td>
                            <td class="myheader">Name</td>
                            <td class="myheader">Price</td>
                            <td class="myheader">Picture</td>
                        </tr>
                </HeaderTemplate>
                        <ItemTemplate>
                    <tr>
                        <td class="myitem"><%# Eval("ID") %></td>
                        <td class="myitem"><%# Eval("Name") %></td>
                        <td class="myitem"><%# Eval("Price") %></td>
                        <td class="myitem pestpic"><img src="Pictures/<%# Eval("Picture") %>" alt="pest"</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
    </asp:Repeater>
    <br />
<br />
Sign up:<br />
<br />
<asp:TextBox ID="TextBoxFirst" runat="server"></asp:TextBox>
&nbsp;First Name
<br />
<asp:TextBox ID="TextBoxlast" runat="server"></asp:TextBox>
&nbsp;Last Name<br />
<asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
&nbsp;Address<br />
<asp:TextBox ID="TextBoxZip" runat="server"></asp:TextBox>
&nbsp;Zip code<br />
<asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
&nbsp;City<br />
<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
&nbsp;Password<br />
<asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
&nbsp;Email<br />
<asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
&nbsp;Phone<br />
<br />
<asp:Button ID="ButtonSignUp" runat="server" OnClick="ButtonSignUp_Click" Text="Sign up" />
<br />
<br />
<asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
</asp:Content>
