<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSupplier.aspx.cs" Inherits="WebUI_Supplier_AddSupplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加供应商信息</title>
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
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>  &gt;&gt; 添加供应商</div>
    <table class="table" style=" float:left; margin-top:20px; width:50%; margin-left:20px">
	    <tr>
	        <td style="width:30%; height:30px;">供应商名称：</td>
	        <td style="text-align:left; height: 30px;">
	        	<asp:TextBox runat="server" id="txtSupplierName" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">负&nbsp;&nbsp;&nbsp;责&nbsp;&nbsp;&nbsp;人：</td>
	        <td style="text-align:left">
	        	<asp:DropDownList runat="server" id="ddlContacter" CssClass="txtwith"></asp:DropDownList><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">移 动 电  话：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtContactPhone" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">负责人职位：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtContacterRole" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">邮 政 编 码：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtPostCode" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
		<tr>
	        <td style="height:30px;">邮 政 地 址：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtPostAddress" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">员 工 数 量：</td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtStaffNum" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">营 业 执 照：</td>
	        <td style="text-align:left">
	        	<asp:FileUpload runat="server" id="fudLicensePath" CssClass="txtwith"></asp:FileUpload>
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
