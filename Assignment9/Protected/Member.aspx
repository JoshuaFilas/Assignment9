<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment9.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Button to try login.<br />
    <asp:Button ID="toLogin" runat="server" Text="Login" OnClick="toLogin_Click" /><br />
    Button to try adding a member -> you can test this by then trying to login as the new member.<br />
    <asp:Button ID="toAddMember" runat="server" Text="Add Member" OnClick="toAddMember_Click" /><br />
    Button to Theater Service.<br />
    <asp:Button ID="toTheater" runat="server" Text="Theater" OnClick="toTheater_Click" /><br />
    The service that does the xml is explicitly testable by making a new user and trying to login. It is used for both of these tasks.<br />
        Demonstration of the DLL file <br />
        <asp:Button ID="DLLButton" runat="server" Text="DLL TryIt" OnClick="DLLButton_Click" />
    </p>
</asp:Content>
