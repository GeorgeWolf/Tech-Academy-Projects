<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpiesAssignmentSolution.Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 190px;
            height: 235px;
        }
        .auto-style2 {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img alt="" class="auto-style1" src="epic-spies-logo.jpg" /><br />
            <h2 class="auto-style2">Spy New Assignment Form</h2>
            Spy Code Name:
            <asp:TextBox ID="codeNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:
            <asp:TextBox ID="newAssignmentTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment<br />
            <asp:Calendar ID="previousCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            Start Date of New Assignment<br />
            <asp:Calendar ID="newCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            Project End Date of New Assignment<br />
            <asp:Calendar ID="endCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="assignButton" runat="server" OnClick="assignButton_Click" Text="Assign Spy" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
