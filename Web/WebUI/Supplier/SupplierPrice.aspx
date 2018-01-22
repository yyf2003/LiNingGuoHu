<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierPrice.aspx.cs" Inherits="WebUI_Supplier_SupplierPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>供应商 材料报价</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body >
<form id="form1" runat="server">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;"><a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>  <%= " &gt;&gt; " + SupplierName%></div>
    <table class="table" style="margin-top:20px; color:navy">
	    <tr>
	    	<td style="height: 30px; width:20%; font-weight:bold">供应商名称:</td>
	        <td style="width:40%; text-align:left"><%= SupplierName%></td>
	        <td style="width:20%; font-weight:bold">负责人:</td>
	        <td style="text-align:left"><%= Contacter%></td>        
	    </tr>
		<tr>
	    	<td style="height: 30px; font-weight:bold">邮政地址:</td>
	        <td style="height:30px; text-align:left"><%= PostAddress%></td>
	        <td style="height: 30px; font-weight:bold">邮政编码:</td>
	        <td style="height: 30px; text-align:left"><%= PostCode%></td>        
	    </tr>
	    <tr>
	    	<td style="height: 30px; font-weight:bold">联系电话:</td>
	        <td style="height:30px; text-align:left"><%= ContactPhone%></td>
	        <td style="height: 30px; font-weight:bold">负责人职位:</td>
	        <td style="height: 30px; text-align:left"><%= ContacterRole%></td>        
	    </tr>
		<tr>
	    	<td style="height: 30px; width:20%; font-weight:bold">备注：</td>
	        <td style="height:30px; text-align:left " colspan="3"><%= Remarks%></td>
	    </tr>
	</table>
	<table class="table" style="margin-top:20px; color:navy; width:50%">
	    <caption style="font-weight:bold"><%= SupplierName%> &nbsp;&nbsp;&nbsp; 材料报价</caption>
	    <tr>
	    	<td style="height: 30px; width:20%; font-weight:bold">供应商名称:</td>
	        <td style="width:40%; text-align:left"></td>    
	    </tr>
		<tr>
	    	<td style="height: 30px; font-weight:bold">邮政地址:</td>
	        <td style="height:30px; text-align:left"></td>    
	    </tr>
	    <tr>
	    	<td style="height: 30px; font-weight:bold">联系电话:</td>
	        <td style="height:30px; text-align:left"></td>    
	    </tr>
		<tr>
	    	<td style="height: 30px; width:20%; font-weight:bold">备注：</td>
	        <td style="height:30px; text-align:left "></td>
	    </tr>
	</table>
    </div>
</form>
</body>
</html>
