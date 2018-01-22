<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckShopList.aspx.cs" Inherits="WebUI_Shopmanage_ShopInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>店铺列表</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
<script language="javascript" type="text/javascript" src="javascript/CheckShopList.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
<script language ="javascript" type="text/javascript">
function GetcityList()
{
var pro=$("#DDL_Province").val();
//alert(pro);
   GetCityname(pro);
}

$(function(){
	$("table.datalist tr:nth-child(odd)").addClass("altrow");
});
</script>
<style type="text/css">
.datalist tr.altrow{
	background-color:#a5e5aa;	/* 隔行变色 */
}
</style>
</head>
<body >
<form id="form1" runat="server">
	<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">检查店铺</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width: 15%">店铺编号：</td>
				<td style="width: 250px">&nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">店铺名称：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">省：</td>
				<td style="width: 250px">&nbsp;<asp:DropDownList ID="DDL_Province" runat="server" onchange="GetcityList()">
                    <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">地级城市：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_city" runat="server">
                    <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width: 15%">一级客户：</td>
				<td style="width: 250px"><asp:DropDownList ID="ddl_dealer" runat="server">
                    <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">安装支持：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_install" runat="server">
                    <asp:ListItem Value="-1">是否李宁公司统一支持安装</asp:ListItem>
                    <asp:ListItem Value="1">支持</asp:ListItem>
                    <asp:ListItem Value="0">不支持</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width: 15%">店铺类型：</td>
				<td style="width: 250px">&nbsp;<asp:DropDownList id="DDL_Shoptype" runat="server">
                    <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
				</asp:DropDownList>
				</td>
				<td style="width: 15%">零售属性：</td>
				<td>&nbsp;
				<asp:DropDownList id="SaleTypeID"   runat="server">
                    <asp:ListItem Value="0">请选择零售属性</asp:ListItem>
				</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺状态：</td>
				<td style="width: 250px">&nbsp;<asp:DropDownList id="DDL_shopstate" runat="server">
                    <asp:ListItem Value="-1">请选择店铺状态</asp:ListItem>
                </asp:DropDownList></td>
				<td style="width: 15%">&nbsp;</td>
				<td align="center">&nbsp;<input id="Btn_search" type="button" value="查 询" class="qr0"  onclick="Getshopinfolist(1,20)"/></td>
			</tr>
		</table>
		<div id="fillTable" style="margin-top:10px; margin-left:5%"></div>
	 	<div id="HyperLinkPage" style="margin-top:10px; text-align:center; padding-right:10px; width:900px; font-size:14px; margin-left:5%"></div>
	 </div>
</form>

</body>

</html>
