<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditInfo.aspx.cs" Inherits="WebUI_Distribution_EditInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
        <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
            <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>
	<script type="text/javascript" language="javascript" src="./javascript/ValidateFrom.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetCityByProvince.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetProvinceName.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">更改直属客户所属一级客户</div>
       	<table class="table" style="margin-top:20px; text-align:left; margin-left:5%">
		         <tr>
                    <td>
                        部门名称：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle"  onchange=" GetAreaName(this.value);">
                    <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                </asp:DropDownList></td>
                    <td>
                        区域名称：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_Area"  onchange="GetprovinceList()"  CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        所在省份：</td>
                    <td align="left">
                        <asp:DropDownList ID="DDL_Province" CssClass="txtwith" onchange="GetcityList()" runat="server">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        所在市区：</td>
                        <td>
                        <asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
			<tr>
				<td style="width:15%;text-align:left">直属客户编号：</td>
				<td style="width:30%;"><input id="txtFXID" type="text" class="txtwith" runat="server" disabled="disabled" /></td>
				<td style="width:15%;text-align:left">直属客户名称：</td>
				<td><input id="txtFXName" type="text" class="txtwith" runat="server" /></td>
			</tr>
			<tr>
				<td style="width:15%;">所属一级客户编号：</td>
				<td style="width:30%;"><input id="txtdealerID" type="text" class="txtwith"   onkeyup='showGs(event,"../GetBaseInfo/Base_DealerInfo.aspx",txtdealerID,txtDealerName,"dealerdiv")' runat="server"/></td>
				<td>
					一级客户名称：
				</td>
				<td><input id="txtDealerName" type="text" class="txtwith" runat="server" /><br />
				<div id="dealerdiv" class="ts"></div>
				</td>
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
	        <td style="height:30px;">配送地址：</td>
            <td colspan="3" style="text-align: left">
	        	<asp:TextBox runat="server" id="txtFXAddress" CssClass="txtwith"></asp:TextBox><span
                    style="color: #ff0000"></span><span style=" margin-left:5px;color:red"></span></td>
	    </tr>
	    <tr>
	    <td colspan="4" align="center">
            <asp:Button ID="Btn_update" runat="server" CssClass="qr0" Text="更新"  OnClientClick="if(confirm('是否确认更新此直属客户信息？')){return ValidateInput();}else{return false;}"  OnClick="Btn_update_Click" /></td>
	    </tr>
		    </table>
        <asp:HiddenField ID="HF1" runat="server" />
    </div>
    </form>
</body>
</html>
