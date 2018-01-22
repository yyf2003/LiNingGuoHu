<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSRlogin.aspx.cs" Inherits="DSRlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
	<table style="width:100%; height:100%">
	<tr>
	   <td  align="center" valign="middle">
	   <strong style="font-size:14"> LI-NING 常规POP执行管理系统<br />
       </strong><br />
	   <div style="width:25%;text-align:left; font-size:12px ">
	   <table style="width:100%;text-align:left; ">
	   <tr><td style="height: 31px"> 用户名：</td><td > 
           <asp:TextBox ID="username" runat="server"></asp:TextBox></td></tr>
	   <tr><td style="height: 33px"> 密 &nbsp; 码：</td><td>
           <asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td></tr>
           <tr>
           <td colspan="2" align="center">
               <asp:Button ID="Btn_login" runat="server" Text="登 陆" OnClick="Btn_login_Click" /></td>
           </tr>
	   </table>
	   </div></td>
	</tr>
	</table>
	</div>
    </form>
</body>
</html>
