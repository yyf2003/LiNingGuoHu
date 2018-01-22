<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePwd.aspx.cs" Inherits="WebUI_UserInfo_UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
</head>
<body>
<form id="form1" runat="server">
<div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">修改人员密码</div>
    <table class="table" style="margin-top: 20px; margin-left: 5%">
        <tr>
            <td style="width: 15%">
            员工名称：
            </td>
            <td style="width: 35%">
            <asp:TextBox ID="txt_UserName" runat="server" CssClass="txtwith"></asp:TextBox>
            </td>
            <td style="text-align:left">&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="查询" Width="75px" OnClientClick="javascript: return Validate();" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
        
	    <asp:Repeater runat="server" id="RepUserList">
	    <HeaderTemplate>
	        <table class="table" style="margin-top:20px; margin-left: 5%">
	        <tr>
	            <th style="height:30px; width:40%">用户编号</th>
	            <th style="height: 30px;">用户名</th>
	            <th style="height: 30px;">密码</th>
	            <th style="height: 30px;">操作</th>	        
	        </tr>
	    </HeaderTemplate>
		<ItemTemplate>
		    <tr>
	            <td style="height: 25px;"><%# Eval("UserID")%></td>
	            <td style="height: 25px;"><%# Eval("Username")%></td>
	            <td style="height: 25px;"><%# Eval("UserPassword")%></td>
	            <td style="height: 25px;"><a href='SubmitUserPwd.aspx?id=<%# Eval("UserID")%>'>恢复</a></td>	        
	        </tr>
		</ItemTemplate>	   
		<FooterTemplate>
		    </table>
		</FooterTemplate>	
	   	</asp:Repeater>
   
    </div>
</form>
<script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
<script language="javascript" type="text/javascript">
    function Validate()
    {
    	 var txt_UserName = $.trim($("#txt_UserName").val());      //用户名称
         if(txt_UserName=="")
         {
           alert("请输入搜索员工姓名！！");
           return false;
         } 
         
         return true;
    }
</script>
</body>
</html>
