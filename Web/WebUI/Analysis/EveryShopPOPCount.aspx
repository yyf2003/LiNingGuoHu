<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EveryShopPOPCount.aspx.cs" Inherits="WebUI_Analysis_Default" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />

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
    <div>
    <div style="margin-top:20px; margin-left:5%;">
	        <asp:Repeater ID="Repeater1" runat="server">
	        <HeaderTemplate>
	        	<div style="width:900px; font-size:14px; color:Olive">总面积：<%=area %>&nbsp; &nbsp; &nbsp; &nbsp; 总价格：<%=price %>&nbsp; &nbsp; &nbsp; &nbsp; 总数量:<%=num %></div>
		        <table class="table">
		        <tr>
		        <th style="width:50px">序号</th>  <th style="width:80px">店铺编号</th> <th>店铺名称</th><th style="width:15%">POP面积</th><th style="width:15%">POP总价</th><th style="width:15%">POP数量</th></tr>
	        </HeaderTemplate>
	        <ItemTemplate>
		        <tr>
		        <td><%#Eval("rowId")%></td>
		        <td><%#Eval("PosID")%></td>
		        <td><%#Eval("Shopname")%></td>
		        <td><%#Eval("totalArea")%></td>
		        <td><%#Eval("totalPrice")%></td>
		        <td><a href='SupplierEveryshoppoplist.aspx?shopid=<%#Eval("shopid")%>&POPID=<%=POPID%>&prolist=<%=prolines %>&cailiao=<%=Server.UrlEncode(cailiao) %>&year=<%=year %>'><%#Eval("totalnum")%></a></td>
		        </tr>
	        </ItemTemplate>
	        <FooterTemplate>
	        	</table>
	        </FooterTemplate>
	        </asp:Repeater>
	         <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="20" Width="900" OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>
    	</div>
    </div>
    </form>
</body>
</html>
