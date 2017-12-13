<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GlobalExceptionHandling.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Whatever you do, DO NOT click these button:
            <br />
            <br />
            <asp:Button ID="okButton" runat="server" Text="DO NOT click me" OnClick="okButton_Click" />
            <br />
            <br />
            <asp:Button ID="argumentOutOfRangeButton" runat="server" OnClick="argumentOutOfRangeButton_Click" Text="Arguement Out of Range" />
        </div>
    </form>
</body>
</html>
