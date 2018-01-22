<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allotArea.aspx.cs" Inherits="WebUI_Supplier_allotArea" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title>分配供应商供应区域</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../../js/jquery.min.js" type="text/javascript"></script>
<script language="javascript" src="javascript/allotArea.js" type="text/javascript"></script>
<script type="text/javascript">

</script>
<style type="text/css">
    .divcss{
        font-family:Arial;font-size:12px;width:85%; border:1px solid #6d6060;background-color:#fdf6f6; padding-left:20px; padding-top:10px; margin-top:10px;
    }
</style>
</head>

<body>

<form id="form1" method="post" onsubmit="return checkData();" action="allotarea_do.aspx?id=<%=id %>&name=<%=Server.UrlEncode(name)%>">
	<div>
	    <div style=" font-size:14px; height:30px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>  &gt;&gt; <a href='SupplierArea.aspx?id=<%=id %>' title="<%=name %>" style="color: #c86000;"><%=name %></a>  &gt;&gt; 分配供应区域</div>
		<div id="deptdiv" class="divcss"><span style="font-weight:bold">部门名称：</span><asp:Literal ID="Lit_dept" runat="server"></asp:Literal></div>
		<div id="areadiv" class="divcss"><span style="font-weight:bold">区域：</span><asp:Literal ID="Lit_Area" runat="server"></asp:Literal></div>
		<div id="pro" class="divcss" style="display:none"><span style="font-weight:bold">省&nbsp;&nbsp;份：</span><br /><asp:Literal ID="Lit_province" runat="server"></asp:Literal><br /><br /></div>
<%--		<div id="citytable" class="divcss" style="display:none"><span style="font-weight:bold">城&nbsp;&nbsp;市：</span><br /><asp:Literal ID="Lit_city" runat="server"></asp:Literal><br /><br /></div>
		<div id="towntable" class="divcss" style="display:none"><span style="font-weight:bold">区级市：</span><br /><asp:Literal ID="Lit_town" runat="server"></asp:Literal><br />
	</div>--%>
	<div id="Div1" class="divcss" ><span style="text-align:right; font-size: 14px; color: #0033ff; text-decoration: underline; cursor:hand; float:right" >
            <input type="text" name="HF_shopid"  style="display:none" id="HF_shopid" />
        <input id="btn_getshop"  onclick="GetselctShop(<%=id %>);" type="button" value="调整区域店铺" /></span>
            <br />
	</div>
	
	</div>
		<div class="divcss" style=" text-align:center; height:30px;"><input onclick="return confirm('确认重新划分，以前划分的数据将删除。');" type="submit" value="保 存" class="qr0"/></div>
	<br/>
</form>

</body>

</html>
