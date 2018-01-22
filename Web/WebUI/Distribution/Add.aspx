<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="WebUI_Distribution_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>添加直属客户信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>
	<script type="text/javascript" language="javascript" src="./javascript/ValidateFrom.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">
        <asp:Label ID="lblDealerName" runat="server" ForeColor="#c86000"></asp:Label>  &gt;&gt; 添加直属客户</div>
    <table class="table" style=" float:left; margin-top:20px; text-align:left;  margin-left:20px">
        <tr>
	        <td style="height:30px;width:15%;">直属客户编号：</td>
	        <td style="text-align:left;width:35%;">
	        	<asp:TextBox runat="server" id="txtFXID" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td><td style="width:15%; height:30px;">直属客户名称：</td>
	        <td style="text-align:left;width:35%; height: 30px;">
	        	<asp:TextBox runat="server" id="txtFXName" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>

	           <tr>
                <td>
                    部门名称：</td>
                <td>
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    区域名称：</td>
                <td>
                    <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        <asp:ListItem Value="-1">全国</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    省/市：</td>
                <td>
                    <asp:DropDownList ID="DDL_Province" runat="server" CssClass="DDlstyle" onchange="GetcityList()">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    地级城市名称：</td>
                <td>
                    <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择地级城市名称</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
	    <tr>
	        <td style="height:30px;">联&nbsp;&nbsp;&nbsp;系&nbsp;&nbsp;&nbsp;人：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtFXContactor" CssClass="txtwith"></asp:TextBox>

	        </td>
	        <td style="height:30px;">联系人电话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtFXPhone" CssClass="txtwith"></asp:TextBox>

	        </td>
	    </tr>

	    <tr>
	        <td style="height:30px;">直属客户电话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtFXtel" CssClass="txtwith"></asp:TextBox>

	        </td>
	        <td style="height:30px;">配送地址：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtFXAddress" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>

	    <tr>

	        <td colspan="4" align="center">
	        	<asp:Button runat="server" Text="添   加" id="btnAdd" CssClass="qr0" OnClientClick="return ValidateInput();" OnClick="btnAdd_Click" ></asp:Button>
	        </td>
	    </tr>
    </table>
    </div>
    </form>
</body>
</html>
