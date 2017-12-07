<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_022.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            From:<br />
            <br />
            <asp:RadioButton ID="fromChicagoRadio" runat="server" GroupName="FromGroup" Text="Chicago" />
            <br />
            <asp:RadioButton ID="fromNewYorkRadio" runat="server" GroupName="FromGroup" Text="New York" />
            <br />
            <asp:RadioButton ID="fromLondonRadio" runat="server" GroupName="FromGroup" Text="London" />
            <br />
            <br />
            To:<br />
            <br />
            <asp:RadioButton ID="toChicagoRadio" runat="server" GroupName="ToGroup" Text="Chicago" />
            <br />
            <asp:RadioButton ID="toNewYorkRadio" runat="server" GroupName="ToGroup" Text="New York" />
            <br />
            <asp:RadioButton ID="toLondonRadio" runat="server" GroupName="ToGroup" Text="London" />
            <br />
            <br />
            <asp:Button ID="okButton" runat="server" OnClick="okButton_Click" Text="OK" />
            <br />
            <br />
            Ticket Price: <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
