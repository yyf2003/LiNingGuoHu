<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmSetUp.aspx.cs" Inherits="WebUI_SetUpConfirm_ConfirmSetUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>确认安装</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" src="../../js/common.js"></script>
    <!--  end-->
	<style type="text/css">
 		*body{ 
 			  
 			font-size: 12px; 
 			background-position: center bottom; 
 			background-repeat: no-repeat;
 		} 
	</style>
	<script language="javascript" type="text/javascript">
	function isInt(str)
	{
		var result=str.match(/^(-|\+)?\d+$/);
		if(result==null) return false;
		return true;
	}
     function CheckAdd()
     {
		var txtSetupNum = $.trim($("#txtSetupNum").val());
		if(txtSetupNum == "")
		{
			$.prompt("安装数量不能为空，请添加内容",{callback:getfocus});
			return false;
		}
		else
		{
			if(!isInt(txtSetupNum))
			{
				$.prompt("安装数量必须是整数！！",{callback:getfocus});
				return false;
			}
		}
		
		var txtDesc = $.trim($("#txtDesc").val());
		if(txtDesc=="")
		{
			$.prompt("描述不能为空，请添加描述内容",{callback:getfocusdesc});
			return false; 
		}
     
     }
	function getfocus(){$("#txtSetupNum").focus();}
	function getfocusdesc(){$("#txtDesc").focus();}
      
    </script>

</head>
<body>
<form id="form1" runat="server">
<div style="width:95%">
	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:50px;color: #c86000;">确认安装 &gt;&gt; 
        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></div>
	<table class="table" style="margin-top:20px; margin-left:5%">
		<tr>
			<td style="width:15%;text-align:right">店铺名称：</td>
			<td style="width:30%;">&nbsp;<asp:Label runat="server" id="lblShopName"></asp:Label></td>
			<td style="width:15%;text-align:right">所属一级客户：</td>
			<td>&nbsp;<asp:Label runat="server" id="lblDealerName"></asp:Label></td>
		</tr>
		<tr>
			<td style="width:15%;text-align:right">所属供应商：</td>
			<td style="width:30%;">&nbsp;<asp:Label runat="server" id="lblSupplierName"></asp:Label></td>
			<td style="width:15%;text-align:right">POP发起标题：</td>
			<td>&nbsp;<asp:Label runat="server" id="lblPOPName"></asp:Label></td>
		</tr>
		<tr>
			<td style="text-align:right">安装数量：</td>
			<td style="text-align:left" colspan="3">&nbsp;<asp:TextBox runat="server" id="txtSetupNum" CssClass="txtwith" Width="100px"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="text-align:right">描述：</td>
			<td style="text-align:left" colspan="3">&nbsp;<asp:TextBox runat="server" id="txtDesc" TextMode="MultiLine" CssClass="txtwith" Height="100px"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="text-align:right">上传图片：</td>
			<td style="text-align:left" colspan="3"><asp:FileUpload ID="fuImg" runat="server" /><span style="color:red; font-weight:bold; margin-left:20px;">多幅图片，请上传RAR格式压缩文件</span></td>
		</tr>
		<tr>
			<td style="text-align:center; height:50px;" colspan="4">
				<asp:Button ID="btnSubmit" runat="server" Text="确定提交" CssClass="qr0" OnClientClick="return CheckAdd();" OnClick="btnSubmit_Click" />
			</td>
		</tr>
	</table>
</div>
</form>
</body>

</html>
