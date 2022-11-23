<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Member._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Button ID="ButtonMemberPage" runat="server" Text="Member Page" />
    <br />
    <br />
    <asp:Button ID="ButtonStaffPage" runat="server" Text="Staff Page" OnClick="ButtonStaffPage_Click" />
    <br />
    <br />
    <asp:Button ID="toLogin" runat="server" Text="Login" OnClick="toLogin_Click" />
    <asp:Button ID="toAddMember" runat="server" Text="Add Member" OnClick="toAddMember_Click" />
    <asp:Button ID="toTheater" runat="server" Text="Theater" OnClick="toTheater_Click" />

    <p>
        Demonstration of the DLL file <br />
        <asp:Button ID="DLLButton" runat="server" Text="DLL TryIt" OnClick="DLLButton_Click" />
    </p>
</asp:Content>
