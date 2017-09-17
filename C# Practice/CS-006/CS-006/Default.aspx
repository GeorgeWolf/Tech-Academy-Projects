<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS_006.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style2 {
            color: #CC0000;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            height: 31px;
        }
        .auto-style5 {
            height: 29px;
        }
        .auto-style6 {
            background-color: #FFFFCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>HeadLine 1</h1>
        <h2>HeadLine 2</h2>
        <h3>HeadLine 3</h3>
        <h4>HeadLine 4</h4>
        <h5>HeadLine 5</h5>
        <h6>HeadLine 6</h6>
        <p class="auto-style1">
            This is some text that I want to <span class="auto-style2">apply</span> a style to.</p>
        <div>

            <a href="http://www.blizzard.com">Add a hyperlink</a>
            <br />        
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.starcraft.com" Target="_blank">This is another hyperlink.</asp:HyperLink>
            <br />

        </div>
        <p class="auto-style1">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Zeratul.png" />
        </p>
        <table class="auto-style3">
            <tr>
                <td class="auto-style4">Player</td>
                <td class="auto-style4">Year</td>
                <td class="auto-style4">Home runs</td>
            </tr>
            <tr>
                <td class="auto-style5">Sammy Sosa</td>
                <td class="auto-style5">2005</td>
                <td class="auto-style5">100</td>
            </tr>
            <tr>
                <td>Mark MacGuire</td>
                <td>2005</td>
                <td>102</td>
            </tr>
        </table>
    </form>
    <p>
        &nbsp;</p>
    <ol>
        <li>First Item</li>
        <li>Second Item</li>
        <li>Third Item</li>
    </ol>
    <p>
        &nbsp;</p>
    <ul>
        <li class="auto-style6">This is an idea</li>
        <li class="auto-style6">This is an equally good idea</li>
        <li class="auto-style6">Yeat one more idea to consider</li>
    </ul>
</body>
</html>
