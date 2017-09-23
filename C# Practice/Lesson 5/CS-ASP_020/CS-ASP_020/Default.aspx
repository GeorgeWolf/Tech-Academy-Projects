<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_020.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Type a value to add it to the string:<br />
            <br />
            Server Control:<br />
            <br />
            <asp:TextBox ID="valueTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Plain ol&#39; HTML Input Text field:<br />
            <br />
            <input id="Text1" type="text" /><br />
            <br />
            <asp:Button ID="addButton" runat="server" OnClick="addButton_Click" Text="Add" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
