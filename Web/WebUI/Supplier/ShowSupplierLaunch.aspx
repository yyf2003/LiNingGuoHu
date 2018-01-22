<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowSupplierLaunch.aspx.cs" Inherits="WebUI_Supplier_ShowSupplierLaunch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>POP 发起 列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <style type="text/css">
        .cailiao{
            width:200px;border:1px solid #6d6060; height:25px; margin-top:10px; float:left; margin-left:4%; text-align:center; padding-top:3px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function showDIV(id,showID)
        {
            var spanID = $("#"+id);
            var tdID = $("#"+showID); 
            if(spanID.html() == "查看")
            {
                tdID.show();
                spanID.html("隐藏");
            }
            else
            {
                tdID.hide();
                spanID.html("查看");
            }
        }
    </script>
</head>
<body >
<form id="form1" runat="server">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;"><a href="LaunchPOPListMessage.aspx" title="POP发起活动列表" style="color: #c86000;">POP发起活动列表</a>  &gt;&gt; 供应商材料报价</div>
    <table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px">
	    <tr>
	        <th style="height:30px; width:40%">供应商名称</th>
	        <th style="height: 30px;">联系人</th>
	        <th style="height: 30px;">联系电话</th>
	        <th style="height: 30px;">联系人职位</th>
	        <th style="height: 30px;">查看报价</th>	        
	    </tr>
        <asp:Repeater ID="RepSupplierList" runat="server">
        <ItemTemplate>
        <tr>
	    	 <td style="height: 25px;"><%# Eval("SupplierName")%></td>
	        <td style="height: 25px;"><%# Eval("Contacter")%></td>
	        <td style="height: 25px;"><%# Eval("ContactPhone")%></td>
	        <td style="height: 25px;"><%# Eval("ContacterRole")%></td>
	        <td><span id='show<%# Eval("SupplierID") %>' style="cursor:pointer" onclick='javascript:showDIV(this.id,<%# Eval("SupplierID") %>)'>查看</span></td>   
	    </tr>
	    <tr id='<%# Eval("SupplierID") %>' style="display:none">
	        <td colspan="6" style="text-align:center">
	            <asp:Repeater ID="RepBindPrice" DataSource='<%# BindPrice(Eval("SupplierID").ToString()) %>' runat="server">
	                <ItemTemplate>
	                    <div class="cailiao"><%# Eval("POPMaterialName")%>：<%# Eval("POPprice")%></div>
	                </ItemTemplate>
	            </asp:Repeater>
	            <br /><br />
	        </td>
	    </tr>
        </ItemTemplate>
        </asp:Repeater>   
	</table>
    </div>
</form>
</body>
</html>

