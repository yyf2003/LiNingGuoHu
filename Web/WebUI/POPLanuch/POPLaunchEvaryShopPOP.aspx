<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPLaunchEvaryShopPOP.aspx.cs" Inherits="WebUI_POPLanuch_POPLaunchEvaryShopPOP" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
            <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:20px;font-size:14px;color:Purple"><%=POPID %>期<%=suppliername%>所提供POP数据</div>
    <br />
    <div style=" margin-left:20px; font-size:12px ">
    
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table class="table">
        <tr><th>序号</th><th>店铺编号</th><th>店铺名称</th><th>POP数量</th><th>POP总面积</th></tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td><%#Eval("rowId") %></td>  <td><%#Eval("PosID") %></td> <td><%#Eval("Shopname") %></td> <td><a href='SupplierEveryshoppoplist.aspx?POPID=<%=POPID %>&shopid=<%#Eval("Shopid")%>&prolist=<%=prolist%>'><%#Eval("totalnum")%></a></td> <td><%#Eval("totalarea")%></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate></table>
        </FooterTemplate>
        </asp:Repeater>
    
    </div> <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="20"  OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>
    </form>
</body>
</html>
