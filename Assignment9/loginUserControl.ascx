<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="loginUserControl.ascx.cs" Inherits="Project5.WebUserControl1" %>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="8">
                <tr> 
                     <td>User Name:</td>      
                     <td> <asp:TextBox ID="UserName" RunAt="server" /></td> 
                </tr>
                <tr>  
                     <td> Password: </td>
                     <td><asp:TextBox ID="Password" TextMode="password" RunAt="server" /> </td> 

                </tr>
                <tr>
                    <td>
                       <asp:Image ID ="ImageString" runat="server"> </asp:Image>
                    </td>
                    <td>
                        <asp:Button ID="refreshImage" runat="server" Text="Refresh" OnClick="refreshImage_Click" />
                    </td>
                    <td>
                        <asp:TextBox ID="captchaBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="Button1_Click" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <asp:Label ID="result" runat="server" Text=""></asp:Label><asp:Label ID="Captcha" runat="server" Visible="false" Text="test"></asp:Label>
</body>
</html>