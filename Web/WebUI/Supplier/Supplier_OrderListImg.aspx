<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supplier_OrderListImg.aspx.cs" Inherits="WebUI_Supplier_Supplier_OrderListImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body >
<form id="form1" runat="server">
<div>
<div style=" padding-left:20px; ">
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;"><%=suppliername %>&gt;&gt;<%=POPID %> 季度订单</div>
    <br />
    <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table class="table" style="width:60%">
    <tr>
    <th>图片小样</th><th>数量</th><th>图片编号</th><th>查看原图</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><img alt="samllimage" src='<%#Eval("smallimageurl")%>' /></td><td><a href='POPOrderdaochu.aspx?sid=<%=supplierid %>&imgid=<%#Eval("imageID") %>&POPID=<%=POPID %>'><%#Eval("popcount") %></a></td><td><%#Eval("ImageLevel")%></td> <td><a href='<%#Eval("ImageUrl") %>' target="_blank">查看原图</a></td>
    </tr>
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    </asp:Repeater>
        </div>
    </div>
    </form>
</body>
</html>
