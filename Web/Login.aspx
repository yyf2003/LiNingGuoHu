<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>LI-NING 常规POP执行管理系统 </title>
    <style type="text/css">
		*{ margin:0; padding:0;}
		html, body, p, ul, ol, dl, li, dt, dd, h1, h2, h3, h4, h5, h6,tr,td{margin: 0;padding: 0;position: static;}
		html {background-color: #080808; color: #080808;}
		img{border:none;}
		a{color:#ffffff; text-decoration:none;}
		a:hover{}
		ul, ol,li {list-style: none;}
		.mag{ font-size:11px;}
		body{ font-family: Arial, Helvetica, sans-serif,"宋体" ; color:#FFF; font-size:12px; line-height:18px; }
	</style>

</head>
<body bgcolor="#080808">
<form id="form1" runat="server">
<!-- Save for Web Slices (未命名.psd - Slices: 03, 06, bottom, denglu, lefttu, lining, rightu, top) -->
<div style="margin:0 auto; width:1186px;">
<table id="__01" width="1186" border="0" cellpadding="0" cellspacing="0" align="center" style=" vertical-align:top; ">
	<tr>
		<td colspan="4" style="background:url(images/lining.jpg) no-repeat; width:1186px; height:70px;">
			</td>
	</tr>
	<tr>
		<td colspan="4" style="background:url(images/top.jpg) no-repeat; width:1186px; height:37px;">
			</td>
	</tr>
	<tr>
		<td style="background: url(images/pop_03.jpg) no-repeat; width:68px; height:353px;">
			</td>
		<td>
			<img id="lefttu" src="images/Login/20111011/lefttu.jpg" width="483" height="353" alt="" /></td>
		<td>
			<img id="rightu" src="images/Login/20111011/rightu.jpg" width="510" height="353" alt="" /></td>
		<td style="background:url(images/pop_06.jpg) no-repeat; width:125px; height:353px;">
			</td>
	</tr>
	<tr>
		<td colspan="4" style="background:url(images/denglu.jpg) no-repeat; width:1186px; height:84px;">
        <div style="width:278px; height:52px; margin:23px 0 0 430px; vertical-align:top;">
        <table width="100%" border="0" cellpadding="0" cellspacing="5">
  <tr>
    <td align="right" style="width:70px;">ID/用户名</td>
    <td >
    	<input name="idname" type="text" id="idname" runat="server" style="background:#012c3a; line-height:12px; color:#FFFFFF; font-size:12px; width:120px" autocomplete="off" />

    </td>
  </tr>
  <tr>
    <td align="right">DWP/密码</td>
    <td>
    	<input name="password" type="password" id="password" runat="server" style="background:#012c3a; line-height:12px; color:#FFFFFF; font-size:12px; width:120px" onkeydown="javascript: if(event.keyCode==13) {__doPostBack('lbtnUserLogin','')};" />

    </td>
  </tr>
</table>

        
        </div>
        
			</td>
	</tr>
	<tr>
		<td colspan="4" style="background:url(images/bottom.jpg) no-repeat; width:1186px; height:145px; vertical-align:top;">
        <div style="margin:35px 0 0 523px; font-size:14px; font-weight:bold;">
        <asp:LinkButton runat="server" id="lbtnUserLogin" OnClick="lbtnUserLogin_Click">点击进入</asp:LinkButton>
        </div>
        
			</td>
	</tr>
</table>
</div>

<!-- End Save for Web Slices -->
</form>
</body>
</html>
