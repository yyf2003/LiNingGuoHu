<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MateriaPriceManage.aspx.cs" Inherits="WebUI_Supplier_MateriaPriceManage" %>

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
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;">维护材料价格</div>
    <br />
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            <table class="table">
            <tr>
            <th>供应商名称</th><th>负责人</th><th>负责人电话</th><th>价格维护</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
            <td><%#Eval("Suppliername") %></td>  <td><%#Eval("Contacter") %></td>  <td><%#Eval("ContactPhone")%></td>  <td><a href="Supplier_MateriaPrice.aspx?sid=<%#Eval("SupplierID") %>&sname=<%#Server.UrlEncode(Eval("Suppliername").ToString()) %>">材料价格维护</a></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
            
            <br />
            
            <div style="font-size:14px; color:Red"><a href='Supplier_MateriaPrice.aspx?flag=all'>整体价格维护</a></div>
        </div>
    </div>
</div>
</form>
</body>
</html>
