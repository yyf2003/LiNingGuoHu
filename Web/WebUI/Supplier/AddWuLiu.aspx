<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddWuLiu.aspx.cs" Inherits="WebUI_Supplier_AddWuLiu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加物流公司</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>
    <script type="text/javascript" language="javascript" src="./javascript/ValidateWuLiu.js"></script>
</head>
<body >
    <form id="form1" runat="server">
    <div ><br />
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="WuLiuList.aspx" title="物流管理" style="color: #c86000;">物流管理</a>  &gt;&gt; 添加物流公司</div>
    <table class="table" style=" float:left; margin-top:20px; width:50%; margin-left:20px">
	    <tr>
	        <td style="width:30%; height:30px;">物流公司名称：</td>
	        <td style="text-align:left; height: 30px;">
	        	<asp:TextBox runat="server" id="txtSupplierName" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">联&nbsp;&nbsp;&nbsp;系&nbsp;&nbsp;&nbsp;人：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtContacter" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">联 系 电 话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtContactPhone" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtRemarks" CssClass="txtwith" TextMode="MultiLine" Height="100px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;"></td>
	        <td style="text-align:left">
	        	<asp:Button runat="server" Text="添   加" id="btnAdd" CssClass="qr0" OnClientClick="return ValidateInput();" OnClick="btnAdd_Click" ></asp:Button>
	        </td>
	    </tr>
    </table>
    </div>
    </form>
</body>
</html>
