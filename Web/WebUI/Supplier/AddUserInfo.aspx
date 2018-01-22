<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserInfo.aspx.cs" Inherits="WebUI_Supplier_AddUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加供应商人员</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>
    <script type="text/javascript" language="javascript" src="./javascript/ValidateUserFrom.js"></script>
</head>
<body >
<form id="form1" runat="server">
<div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="SupplierList.aspx" title="供应商人员管理" style="color: #c86000;">供应商人员管理</a>  &gt;&gt; 添加人员</div>
    <table class="table" style="margin-top:20px; width:50%">
	    <tr>
	        <td style="width:30%; height:30px; text-align:right">员工名称(用户名)：</td>
	        <td style="text-align:left; height: 30px;">
	        	<asp:TextBox runat="server" id="txtUserName" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">登录密码：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtPassWord" CssClass="txtwith" Width="45%" TextMode="Password"></asp:TextBox><span style=" margin-left:5px;color:red">若为空，设置为默认密码：000000</span>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
	        <td style="text-align:left">
	        	<asp:DropDownList ID="ddlSex" runat="server" Width="50%">
                    <asp:ListItem Value="男">先生</asp:ListItem>
                    <asp:ListItem Value="女">女士</asp:ListItem> 
                 </asp:DropDownList><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">用户权限：</td>
	        <td style="text-align:left">
	        	<asp:DropDownList ID="ddlUserType" runat="server" Width="50%">
                    <asp:ListItem Value="1">可修改</asp:ListItem>
                    <asp:ListItem Value="0">只查询</asp:ListItem> 
                 </asp:DropDownList><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">电子邮件地址：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtEmail" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">移 动 电 话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtMob" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">固 定 电 话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtPhone" CssClass="txtwith"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">联 系 地 址：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txttAddress" CssClass="txtwith"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px; text-align:right">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtRemarks" CssClass="txtwith" TextMode="MultiLine" Height="100px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;"></td>
	        <td style="text-align:left">
	        	<asp:Button runat="server" Text="添   加" id="btnAdd" CssClass="qr0" OnClientClick="return ValidateInput();" OnClick="btnAdd_Click"></asp:Button>
	        </td>
	    </tr>
    </table>
    </div>
    <asp:HiddenField ID="hidSupplierID" runat="server" />
</form>
</body>
</html>
