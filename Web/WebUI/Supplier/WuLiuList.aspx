<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="WuLiuList.aspx.cs" Inherits="WebUI_Supplier_WuLiuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>物流设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="./javascript/UpdateWuLiu.js"></script>
    <script type="text/javascript" language="javascript">
        function showDIV(id)
        {
            var spanID = $("#"+id);
            var tdID = $("#item"+id); 
            if(spanID.html() == "修改")
            {
                //tdID.show();
                tdID.css("display","block");
                spanID.html("隐藏");
            }
            else
            {
                tdID.css("display","none");
                spanID.html("修改");
            }
        }
        
        //更新指定id的物流公司信息
        function UpDate(id)
        {
        	var obj = new UpdateWuLiuJS(id);
        	if(obj.Validate() == true)
        	{
        		$("#wait"+id).css("display","block");
        		obj.updateMethod();
        	}
        }
    </script>
</head>
<body style="background-image:url('../../images/tabe-bg2.gif');font-size:12px; background-position:center bottom; background-repeat:no-repeat; text-align:center; left:auto;right:auto;">
    <form id="form1" runat="server">
    <div style="width:100%; ">
    <div style=" font-size:14px;width:50%; font-weight:bold; text-align:left; float:left; margin-top:10px; margin-left:20px; padding-left:20px;color: #c86000;">供应商物流设置</div>
    <div style="float:left;width:22%; height:20px; text-align:right;padding-top:10px;"><asp:HyperLink ID="hyLink" Visible="false" ForeColor="#000" runat="server">添加物流公司</asp:HyperLink></div>
    <table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px">
	    <tr style="height: 24px">
	    	<th style=" width:10%">公司编号</th>
	        <th style="width:40%">公司名称</th>
	        <th>联系人</th>
	        <th>联系电话</th>
	        <th>操作</th>
	    </tr>
        <asp:Repeater ID="RepWuLiu" runat="server">
        <ItemTemplate>
        <tr>
	    	<td><%# Eval("CompanyID") %></td>
	        <td><%# Eval("CompanyName")%></td>
	        <td><%# Eval("Contactor")%></td>
	        <td><%# Eval("ContactorPhone")%></td>
	        <td><span id='Show<%# Eval("CompanyID") %>' style="cursor:pointer" onclick='javascript:<%# TypeID=="0" ? "$.prompt(\"抱歉，您没有修改权限！！\")" : "showDIV(this.id)"%>'>修改</span></td>   
	    </tr>
	    <tr>
	        <td colspan="5">
	       		<div id='itemShow<%# Eval("CompanyID") %>' style="width:100%; display:none">
	       			<table style="margin-top:10px; margin-bottom:10px; color:navy; width:50%; float:left; margin-left:20px">
	            	<tr>
	            		<td style=" text-align:right">联系人：</td>
	            		<td style="text-align:left; padding-left:10px;"><input id='txtContactor<%# Eval("CompanyID") %>' type="text" class="txtwith" value='<%# Eval("Contactor")%>' /></td>
	            	</tr>
	            	<tr>
	            		<td style="text-align:right">联系电话：</td>
	            		<td style="text-align:left; padding-left:10px;"><input id="txtContactorPhone<%# Eval("CompanyID") %>" type="text" class="txtwith" value='<%# Eval("ContactorPhone")%>' /></td>
	            	</tr>
	            	<tr>
	            		<td style="text-align:right">操作：</td>
	            		<td style="text-align:left; padding-left:10px;"><input name="btnUpdate" type="button" class="qr0" onclick='javascript:UpDate(<%# Eval("CompanyID") %>);' value="更 新" /></td>
	            	</tr>
	            	<tr>
	            		<td colspan="2" style="line-height:20px; color:#000">
	            		<span id='wait<%# Eval("CompanyID") %>' style="display:none"><img alt="" src="../../images/loading.gif" style=" border:0;" />&nbsp;&nbsp;正在操作中，请稍后。。。。。。</span></td>
	            	</tr>
					</table>
	       		</div>
	        </td>
	    </tr>
        </ItemTemplate>
        </asp:Repeater>   
	</table>
    </div>
    </form>
</body>
</html>
