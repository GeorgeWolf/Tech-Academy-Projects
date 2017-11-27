<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_028.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Convert to Cups<br />
            <br />
            <asp:TextBox ID="quantityTextBox" runat="server" AutoPostBack="True" OnTextChanged="quantityTextBox_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:RadioButton ID="fromCupsRadio" runat="server" AutoPostBack="True" GroupName="FromGroup" OnCheckedChanged="fromCupsRadio_CheckedChanged" Text="Cups" />
            <br />
            <asp:RadioButton ID="fromPintsRadio" runat="server" AutoPostBack="True" GroupName="FromGroup" OnCheckedChanged="fromPintsRadio_CheckedChanged" Text="Pints" />
            <br />
            <asp:RadioButton ID="fromQuartsRadio" runat="server" AutoPostBack="True" GroupName="FromGroup" OnCheckedChanged="fromQuartsRadio_CheckedChanged" Text="Quarts" />
            <br />
            <asp:RadioButton ID="fromGallonsRadio" runat="server" AutoPostBack="True" GroupName="FromGroup" OnCheckedChanged="fromGallonsRadio_CheckedChanged" Text="Gallons" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
