<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoadEffectImg.aspx.cs" Inherits="WebUI_Supplier_UpLoadEffectImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传安装效果图</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">
			供应商上传安装效果图  &gt;&gt; <asp:Label id="lblSupplierName" runat="server" Text=""></asp:Label>
		</div>
    	<table  class="table" style="margin-top:20px;">
    		<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File1" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File2" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File3" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File4" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File5" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr style="height:50px;">
				<td style="width:30%; text-align:right">上传图样：</td>
				<td >
				<input id="File6" type="file"  name="File1"  class="txtwith"/>
		        </td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center; height:40px;">
                    <asp:HiddenField ID="HidSupplierID" runat="server" />
                    <asp:HiddenField ID="HidPOPID" runat="server" />
					<asp:Button id="btnUpLoad" runat="server"  CssClass="qr0" Text="上  传" OnClick="btnUpLoad_Click" />
				</td>
			</tr>
    	</table>
    </form>
</body>
</html>
