<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeEpicSpiesAssignment.Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="spyImage" runat="server" Height="190px" ImageUrl="~/epic-spies-logo.jpg" />
            <br />
            <h2 class="auto-style1"><strong>Spy New Assignment Form</strong></h2>
            <br />
            Spy Code Name: <asp:TextBox ID="spyTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            New Assignment Name:
            <asp:TextBox ID="assignmentTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            End Date of Previous Assignment:<br />
            <asp:Calendar ID="previousDateCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            Start Date of New Assignment:<br />
            <asp:Calendar ID="startDateCalendar" runat="server"></asp:Calendar>
            <br />
            <br />
            Project End Date of New Assignment:<br />
            <asp:Calendar ID="endDateCalendar" runat="server"></asp:Calendar>
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
