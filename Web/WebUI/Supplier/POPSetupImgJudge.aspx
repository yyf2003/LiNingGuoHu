<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPSetupImgJudge.aspx.cs" Inherits="WebUI_Supplier_POPSetupImgJudge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>POP安装图片审核</title>
    <meta content="zh-cn" http-equiv="Content-Language" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
	<link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
	<link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />

	<script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>

	<script language="javascript" type="text/javascript" src="../../js/ShowImg.js"></script>
	<script language="javascript" type="text/javascript">
		function Validate()
		{
			var txt_fk = $.trim($("#txt_fk").val());
			if(txt_fk == "")
			{
				$.prompt('请输入评价！！', {callback:FocusFK});
        		return false;
        	}
        	return true;
		}
		function FocusFK(){$("#txt_fk").focus();}
		
		function IsJudge()
		{
		    $.prompt('已经通过审核，不可重复审核！！');
        	return false;
		}

	</script>

</head>
<body >
<form id="form1" runat="server">
<div style="width:90%">
	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="POPSetupJudgeList.aspx" title="POP安装效果图店铺管理" style="color: #c86000;">POP安装效果图店铺管理</a> &gt;&gt; 
        <asp:Label ID="lblShopName" runat="server" Text=""></asp:Label></div>
		<table id="recevieGoods" class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px" >
		<tr>
			<td style="width: 10%; text-align:right">
			审核人：
			</td>
			<td colspan="3" style="text-align:left;">&nbsp;
			<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
		</tr>
		<tr>
			<td  style=" vertical-align:top; text-align:right">
			&nbsp;审核分数：</td>
			<td style="width:30%; vertical-align:top">
			<select id="fs" style="width: 138px" runat="server">
			<option value="1">1</option>
			<option selected="selected" value="3">3</option>
			<option value="5">5</option>
			</select>
			</td>
			<td  style="width:10%; vertical-align:top; text-align:right">
			评价：</td><td >
			<asp:TextBox ID="txt_fk" runat="server" CssClass="txtwith" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
		</tr>
		<tr>
			<td align="center" colspan="4">
			<asp:Button ID="btn_goods" runat="server" Text="提交审核" CssClass="qr0" Enabled="false" OnClick="btn_goods_Click" /></td>
		</tr>
		</table>
        <table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px">
	        <tr>
	    	    <th style="height: 24px; width:10%">流水号</th>
	            <th>POP位置</th>
	            <th>POP材料</th>
	            <th>宽</th>
	            <th>高</th>
	            <th>面积</th>
	            <th>所属店铺</th>
	            <th>上传人</th>
	            <th>查看</th>
	        </tr>
	        <asp:Repeater ID="RepPOPList" runat="server">
            <ItemTemplate>
            <tr>
	    	    <td>
	    	        <%# Container.ItemIndex + 1%>
	    	    </td>
	            <td><%# Eval("POPseat")%></td>
	            <td><%# Eval("POPMaterial")%></td>
	            <td><%# Eval("POPWith")%></td>
	            <td><%# Eval("POPHeight")%></td> 
	            <td><%# Eval("POPArea")%></td> 
	            <td><%# Eval("ShopName")%></td>
	            <td><%# Eval("OperatorName")%></td> 
	            
	            <td><a href='<%# Eval("href")%>'>查看图片</a></td> 
	        </tr>
            </ItemTemplate>
            </asp:Repeater>  
            </table>
</div>
</form>
</body>
</html>
