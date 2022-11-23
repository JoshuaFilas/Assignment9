<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DLL.aspx.cs" Inherits="Member.DLL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DLL TryIt</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>DLL TryIt</h1>
            <asp:Button ID="DLLButton" runat="server" Text="submit" OnClick="DLLButton_Click" /><asp:Label ID="Label1" runat="server" Text="Input: "></asp:Label><asp:TextBox ID="inputBox" runat="server"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="result: "></asp:Label><asp:TextBox ID="resultBox" runat="server"></asp:TextBox>
        </div>
        <p>
            Encrypted passwords are never decrypted and validation during login is done against the hash of the input. So there is no need to decrypt.
        </p>
    </form>
</body>
</html>
