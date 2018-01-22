<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VmSetMPrice.aspx.cs" Inherits="WebUI_Supplier_VmSetMPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>设置材料报价</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <style type="text/css">
        .show{
            font-size:12px;width:27%; height:35px; float:left;text-align:right; margin-left:4%; margin-top:5px; padding-top:5px; padding-right:10px; border:1px solid #6d6060;background-color:#fdf6f6;
        }
    </style>
    <script language="javascript" type="text/javascript">
       // 判断输入是否是一个数字--(数字包含小数)--
        function isnumber(str)
        {
            return !isNaN(str);
        }
        
        function Validate()
        {
            var obj = $("#showMateriaList :input[type='text']");
            for(var i = 0; i < obj.length; i++)
            {
                if($.trim(obj[i].value) == "")
                {
                    alert("所有材料必须报价");
                    return false;
                    break;
                }
                else
                {
                    if(!isnumber($.trim(obj[i].value)))
                    {
                        alert("价格必须是数字");
                        return false;
                        break;
                    }
                }
            }
            return true;
        }
    </script>
</head>
<body >
<form id="form1" runat="server">
<div style="width:90%; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;">设置材料报价</div>
    <table class="table" style="margin-top:10px; float:left; margin-left:5%">
     <caption style="font-weight:bold">最新发起的POP</caption>
	    <tr style="height: 30px;">
	    	<td style="width:20%;">发起POPID：</td>
	        <td style="width:40%; text-align:left"><%= POPID%></td>
	        <td>开始时间：</td>
	        <td style="width:20%; text-align:left"><%= BeginDate%></td>
	    </tr>
		<tr style="height: 30px;">
		    <td>POP主题：</td>
	        <td style=" text-align:left"><%= POPTitle%></td>
	        <td>结束时间：</td>
	        <td style="text-align:left"><%= EndDate%></td>
	    </tr>
	    <tr style="height: 30px;">
	    	<td>发起人：</td>
	        <td style="text-align:left"><%= OrganigerName%></td>
	        <td>发起时间：</td>
	        <td style="text-align:left"><%= InputDate%></td>
	    </tr>
	</table>
	<div id="showMateriaList" style="width:900px; border:1px solid #6d6060; margin-top:20px; float:left; margin-left:5%">
	    <div style="width:100%; height:30px; font-size:12px; text-align:left; font-weight:bold; margin-top:10px; margin-left:10px;">材料报价</div>
	    <asp:Repeater id="RepMateriaPrice" runat="server">
	    <ItemTemplate>
	    <div class="show">
	        <asp:Label id="lblID" Text='<%# Eval("MateriaID") %>' runat="server" Visible="false"></asp:Label>
	        <%# Eval("MateriaPro") %>：<asp:TextBox ID="txtPrice" Width="20%" runat="server" ></asp:TextBox>
	    </div>
	    </ItemTemplate>
	    </asp:Repeater>
	    <br /><br /><br />
	    <div style="width:100%; height:50px; text-align:left; margin-top:30px; padding-left:100px;">
	    <asp:Button ID="btnSubmit" Text="提交报价" CssClass="qr0" runat="server" OnClientClick="return Validate();" OnClick="btnSubmit_Click" > </asp:Button></div>
	</div>
</div>
    <asp:HiddenField ID="hidPOPID" runat="server" />
</form>
</body>
</html>