<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneShopInfo.aspx.cs" Inherits="WebUI_Shopmanage_OneShopInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>查看店铺信息</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>
</head>

<body >

<form id="form1" runat="server">
	<div>
		<table class="table" style="width:100%">
			<tr>
				<td style="width: 15%">店铺编号：</td>
				<td style="width: 30%"><asp:TextBox id="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺零售属性：</td>
				<td style="width: 30%">
				<asp:TextBox id="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="width: 15%;">店铺名称：</td>
				<td colspan="3">
				<asp:TextBox id="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺简称：</td>
				<td colspan="3">
				<asp:TextBox id="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
            <tr>
                <td>
                    区域名称：</td>
                <td>
                    <asp:TextBox ID="txt_areaname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td>
                    客户身份：</td>
                <td>
                    <asp:TextBox ID="txt_customerCard" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" text-align:left">店铺级别：</td>
				<td >
                    <asp:TextBox ID="DDL_shopLevel" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    店铺产权关系：</td>
				<td>
				<asp:TextBox id="txt_shopownership"  CssClass="txtwith" runat="server"></asp:TextBox>
				&nbsp;</td>
			</tr>
			<tr>
				<td style=" text-align:left">店铺类型：</td>
				<td >
                    <asp:TextBox ID="DDL_Shoptype" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    店铺形象属性：</td>
				<td>
                    <asp:TextBox ID="DDL_shopVI" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    省名称：</td>
				<td>&nbsp;<asp:TextBox id="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
				<td style="width: 15%">
                    地级城市名称：</td>
				<td>
				<asp:TextBox id="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
			</tr>
					<tr>
				<td style="width: 15%">
                    区县级城市名称：</td>
				<td>&nbsp;<asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺状态：</td>
				<td>
				<asp:TextBox ID="Txt_ShopState" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
            <tr>
                <td style="width: 15%">
                    上级客户集团编号：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txt_CustomerGroupID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    上级客户级别：</td>
                <td>
                    <asp:TextBox ID="txt_CustomerGroupName" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			
			<tr>
				<td style="width: 15%">
                    店长：</td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_LineMan" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    店长移动电话：</td>
				<td><asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺零售负责人：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    零售负责人电话：</td>
				<td><asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
                <td style=" text-align:left">
                    李宁省区VM负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁省区VM负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" text-align:left">
                    李宁DSR负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_DSRMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁DSR负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_DSRMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺Email：</td>
				<td><asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺传真号码：</td>
				<td><asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">邮政编码：</td>
				<td><asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    是否李宁公司统一支持安装：</td>
				<td>
				<asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">POP配送地址：</td>
				<td colspan="3"><asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    一级客户：</td>
				<td >
				<asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    直属客户：</td>
				<td>
                    <asp:TextBox ID="txt_fx" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
			<td>
                店铺营业面积：</td><td>
                    <asp:TextBox ID="Txt_Shoparea" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox>㎡</td><td>
                        店铺固定电话：</td><td>
                        <asp:TextBox ID="txt_shopphone" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    关店时间：</td>
				<td>
				<asp:TextBox ID="Txt_CloseTime" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">关店人：</td>
				<td><asp:TextBox ID="Txt_CloseUser" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr style="font-weight:bold">
				<td style="width: 15%">大区VM审批：</td>
				<td>
                    <asp:Label ID="lblExamState" runat="server"></asp:Label>
				</td>
				<td style="width: 15%">省区VM审批：</td>
				<td>
				    <asp:Label ID="lblVMExamState" runat="server"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	<br />
	<div style=" text-align:center; width:100%">
        <asp:Button ID="Btn_Sure" runat="server" Text="店铺负责人确认" OnClick="Btn_Sure_Click" /></div>
</form>

</body>

</html>
