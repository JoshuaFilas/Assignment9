<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Member.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <body>
      <h1>Please Log In</h1>
      <hr>
      <form runat="server">
         <table cellpadding="8">
            <tr>
               <td>User Name:</td>
               <td>
                  <asp:TextBox ID="UserName" RunAt="server" />
               </td>
            </tr>
            <tr>
               <td> Password: </td>
               <td>
                  <asp:TextBox ID="Password" TextMode="password" 
                     RunAt="server" />
               </td>
            </tr>
            <tr>
               <td>
                  <asp:Button Text="Log In" OnClick="LoginFunc" RunAt="server" />
               </td>
                <td>
                    <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" /></td>
            </tr>
         </table>
      </form>
      <hr>
      <h3>
         <asp:Label ID="Output" RunAt="server" />
      </h3>
   </body>
</html>
