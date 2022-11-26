<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Member._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Default Page</h3>
    <asp:Button ID="ButtonMemberPage" runat="server" Text="Member Page" OnClick="ButtonMemberPage_Click" />
    <br />
    <asp:Button ID="ButtonStaffPage" runat="server" Text="Staff Page" OnClick="ButtonStaffPage_Click" />
</asp:Content>
