<%@ Page Title="Theater" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Theater.aspx.cs" Inherits="TryIt.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>
        This service is for finding theater information in you area. You can either put in a zipCode, Longitude and Latitude, or nothing at all.
        You can specify if the theater has to have showtimes avaiable or not as well. You are also able to input distance, if no distance is entered
        it will default to 10 miles. In the table below things inside the curly brackets {} are were you can input parameters - be sure to also remove the curly brackets.
    </p>
    <br />
    <a href="http://webstrar63.fulton.asu.edu/page1/">Url to the service.</a>
    <p>
        <asp:Table ID="Method" runat="server" GridLines="Both" CellPadding="10" CellSpacing="15" Width="750">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>EndPoint Number</asp:TableHeaderCell>
                <asp:TableHeaderCell>End Point</asp:TableHeaderCell>
                <asp:TableHeaderCell>Inputs</asp:TableHeaderCell>
                <asp:TableHeaderCell>Outputs</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>http://webstrar63.fulton.asu.edu/page1/api/Theater</asp:TableCell>
            <asp:TableCell>No Input needed</asp:TableCell>
            <asp:TableCell>Json reponse of a list of theaters</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell>http://webstrar63.fulton.asu.edu/page1/api/Theater?zipCode={zipCode}&showTimes={showTimes}&distance={distance}</asp:TableCell>
            <asp:TableCell>Integer zipCode, String showTimes, Integer distance</asp:TableCell>
            <asp:TableCell>Json reponse of a list of theaters around designated zipCode, with or without showtimes</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>http://webstrar63.fulton.asu.edu/page1/api/Theater?longitude={longitude}&latitude={latitude}&showTimes={showTimes}&distance={distance}</asp:TableCell>
            <asp:TableCell>Decimal longitude, Decimal latitude, String showTimes, Integer distance</asp:TableCell>
            <asp:TableCell>Json reponse of a list of theaters around designated long and lat, with or without showtimes</asp:TableCell>
        </asp:TableRow>
        </asp:Table>
    </p>    
    <br /> 
    <p>
        <asp:Table ID="TheaterTable1" runat="server" HorizontalAlign="Left" Width="800" GridLines="Both">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="6">http://webstrar63.fulton.asu.edu/page1/api/Theater</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>1</asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="submit" runat="server" Text="Click for example results" OnClick="TheaterSub" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="6">http://webstrar63.fulton.asu.edu/page1/api/Theater?zipCode={zipCode}&showTimes={showTimes}&distance={distance}</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>2</asp:TableCell>
            <asp:TableCell >
                <asp:Button ID="submit2" runat="server" Text="Search" OnClick="theaterSub1" />
            </asp:TableCell>
            <asp:TableCell >zipCode Here<asp:TextBox ID="TextBox1" runat="server">55304</asp:TextBox></asp:TableCell>
            <asp:TableCell >true or false<asp:TextBox ID="TextBox2" runat="server">true</asp:TextBox></asp:TableCell>
            <asp:TableCell >distance<asp:TextBox ID="TextBox3" runat="server">10</asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="6">http://webstrar63.fulton.asu.edu/page1/api/Theater?longitude={longitude}&latitude={latitude}&showTimes={showTimes}&distance={distance}</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell>3</asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="submit3" runat="server" Text="Search" OnClick="theaterSub2" />
            </asp:TableCell>
            <asp:TableCell>longitude here<asp:TextBox ID="longbox" runat="server">-105</asp:TextBox></asp:TableCell>
            <asp:TableCell>latitude here<asp:TextBox ID="latbox" runat="server">35</asp:TextBox></asp:TableCell>
            <asp:TableCell>true or false<asp:TextBox ID="showtimebox" runat="server">true</asp:TextBox></asp:TableCell>
            <asp:TableCell>distance<asp:TextBox ID="distancebox" runat="server">10</asp:TextBox></asp:TableCell>   
        </asp:TableRow>
    </asp:Table>   
    </p>
    <p>
        <asp:Table ID="TheaterTable" runat="server" GridLines="Both">
        </asp:Table>
    </p>
</asp:Content>
