<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_019.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Loan Application Form<br />
            <br />
            Name:
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone Number:
            <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Social Security Number: <asp:TextBox ID="ssTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Loan Origination Date:<br />
            <asp:Calendar ID="loanCalendar" runat="server"></asp:Calendar>
            <br />
            Salary:
            <asp:TextBox ID="salaryTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
