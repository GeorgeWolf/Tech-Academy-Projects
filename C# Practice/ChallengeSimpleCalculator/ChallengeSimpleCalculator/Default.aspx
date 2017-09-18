<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeSimpleCalculator.Defaul" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style1"><strong>Simple Calculator</strong></h1>
            <br />
            <span class="newStyle1">First Value:</span>
            <asp:TextBox ID="firstValueTextBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            <span class="newStyle1">Second Value:</span>
            <asp:TextBox ID="secondValueTextBox" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="+" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="subtractButton" runat="server" OnClick="subtractButton_Click" Text="-" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="multiplyButton" runat="server" OnClick="multiplyButton_Click" Text="*" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="divideButton" runat="server" OnClick="divideButton_Click" Text="/" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server" BackColor="#99CCFF" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </div>
    </form>
</body>
</html>
