<%@ Page Title="Staff Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Staff._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Staff Page
    </h3>
    <br />
    <asp:Label ID="LabelGreeting" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Number of active sessions: "></asp:Label>
    <asp:Label ID="LabelSessions" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Link to TryIt page for Omar's components and services</asp:LinkButton>

</asp:Content>
