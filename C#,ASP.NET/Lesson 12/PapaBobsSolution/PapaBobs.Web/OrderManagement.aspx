<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PapaBobs.Web.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Order Management</h1>
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:ButtonField Text="Complete" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
