<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Pests.Appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="GridViewPests" runat="server" OnSelectedIndexChanged="GridViewPests_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
<br />
<asp:TextBox ID="TextBoxTime" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Time<br />
<asp:TextBox ID="TextBoxPest" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Pest ID<br />
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
<br />
<br />
<br />
<br />
<br />
<asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
