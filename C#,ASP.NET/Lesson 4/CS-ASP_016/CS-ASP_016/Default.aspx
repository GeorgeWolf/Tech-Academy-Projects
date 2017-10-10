<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_ASP_016.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Working with the Calendar Server Control<br />
            <br />
            <asp:Calendar ID="myCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="350px" OnSelectionChanged="myCalendar_SelectionChanged" ShowGridLines="True" Width="350px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <br />
            <br />
            <br />
            <asp:Button ID="getDateButton" runat="server" OnClick="getDateButton_Click" Text="Get Date" />
&nbsp;<asp:Button ID="setDateButton" runat="server" OnClick="setDateButton_Click" Text="Set Date" />
&nbsp;<asp:Button ID="showDateButton" runat="server" OnClick="showDateButton_Click" Text="Show Date" />
&nbsp;<asp:Button ID="selectedWeekButton" runat="server" OnClick="selectedWeekButton_Click" Text="Selected Week" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
