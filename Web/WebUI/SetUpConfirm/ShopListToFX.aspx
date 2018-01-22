<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopListToFX.aspx.cs" Inherits="WebUI_SetUpConfirm_ShopListToFX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>店铺查询</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/pagination.css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery.min.js"> </script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.pagination.js"></script>
    <script type="text/javascript" language="javascript" src="./javascript/GetShopListByFXID.js"> </script>
    <style type="text/css">
 		*body{ 
 			  
 			font-size: 12px; 
 			background-position: center bottom; 
 			background-repeat: no-repeat;
 		} 
	</style>
	<script language="javascript" type="text/javascript">
		var FXID = "<%= FXID%>";
		var pageSize = 5;
        $(function(){
            InitData(0,pageSize);
        });

	</script>
</head>
<body>
<form id="form1" action="">
<div id="divload" style="top:50%; right:50%;position:absolute; padding:0px; margin:0px; z-index:999">
        <img alt="" src="../../images/spinner3-greenie.gif" /></div>
<div style="width:95%">
	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">直属客户确认店铺安装</div>
	<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width:15%;text-align:right">店铺编号：</td>
				<td style="width:30%;">&nbsp;<input id="txtShopID" name="txtDealerID" class="txtwith" type="text" /></td>
				<td style="width:15%;text-align:right">店铺名称：</td>
				<td>&nbsp;<input id="txtShopName" name="txtShopName" class="txtwith" type="text" /></td>
			</tr>
			<tr>
				<td style="text-align:center" colspan="4">
					<input name="btnSearch" type="button" value="搜   索" class="qr0" style="cursor:pointer" onclick="javascript:InitData(0,pageSize);" />
				</td>
			</tr>
	</table>
</div>
<div id="fillTable" style="margin-top:20px; margin-left:3%; float:left"></div>
<div id="Pagination" class="sabrosus" style=" width:100%; float:left;margin-top:20px;" ></div>
</form>
</body>
</html>
