<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FormsAuthWithDatabase.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Already Registered?
        <asp:HyperLink ID="LoginLink" runat="server">Go to Login</asp:HyperLink>
    
        <br />
        <br />
        <span class="auto-style1"><strong>Registration Page:</strong></span><br />
        <br />
        Choose Username:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        Choose Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Confirm Password:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LblMatch" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="CreateAccount" runat="server" OnClick="CreateAccount_Click" Text="Create Account" />
    
    </div>
    </form>
</body>
</html>
