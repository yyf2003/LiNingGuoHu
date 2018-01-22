<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="SupplierList.aspx.cs" Inherits="WebUI_Supplier_SupplierList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>供应商列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">供应商管理</div>
    <table class="table" style="margin-top:20px;">
	    <tr>
	        <th style="height:30px; width:40%">供应商名称</th>
	        <th style="height: 30px;">联系人</th>
	        <th style="height: 30px;">联系电话</th>
	       <%-- <th style="height: 30px;">联系人职位</th>--%>
	        <th style="height: 30px;">供应区域</th>	 
	        <th style="height: 30px;">供应的店铺</th>       
	    </tr>
	    <asp:Repeater runat="server" id="RepSupplierList">
		<ItemTemplate>
		<tr>
	        <td style="height: 25px;"><%# Eval("SupplierName")%></td>
	        <td style="height: 25px;"><%# Eval("Contacter")%></td>
	        <td style="height: 25px;"><%# Eval("ContactPhone")%></td>
	       <%-- <td style="height: 25px;"><%# Eval("ContacterRole")%></td>--%>
	        <td style="height: 25px;"><a href='ShowAllotArea.aspx?id=<%# Eval("SupplierID")%>&show=0'>查看</a></td>	
	        <td style="height: 25px;"><a href='SupplierArea.aspx?id=<%# Eval("SupplierID")%>&show=0'>查看</a></td>	        
	    </tr>
		
		</ItemTemplate>	   	
	   	</asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
