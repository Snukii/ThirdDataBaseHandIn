<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Exterminator.aspx.cs" Inherits="Pests.Exterminator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewPests" runat="server" OnSelectedIndexChanged="GridViewPests_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
<br />
<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Name<br />
<asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Price<br />
<asp:TextBox ID="TextBoxPicture" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Picture<br />
<br />
<asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
<br />
<br />
<asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" />
<br />
<br />
<asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
<br />
<br />
Appointments:<br />
<asp:GridView ID="GridViewAppointments" runat="server" OnSelectedIndexChanged="GridViewPests_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
<br />
<asp:Button ID="ButtonAll" runat="server" OnClick="ButtonAll_Click" Text="Show all appointments " />
<br />
<br />
<asp:TextBox ID="TextBoxCustomerID" runat="server"></asp:TextBox>
&nbsp;CustomerID<br />
<asp:Button ID="ButtonID" runat="server" OnClick="ButtonID_Click" Text="Show appointments from id" />
<br />
<br />
<asp:TextBox ID="TextBoxDay" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;Appointment day<br />
<asp:Button ID="ButtonDay" runat="server" OnClick="ButtonDay_Click" Text="Show appointments from day" />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
