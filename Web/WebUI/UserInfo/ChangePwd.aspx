<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="WebUI_UserInfo_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/screen.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Validate.js"></script>
    <script language="javascript" type="text/javascript">
    function CheckPwd()
   {
      var oldpwd=$("#txtOlePwd").val();
     if(oldpwd=="")
     {
       $.prompt("请输入旧密码",{callback:getfocusold});
       return false;
     } 
       var pwd1=$("#txtPwd1").val();
     if(pwd1=="")
     {
       $.prompt("请输入新密码",{callback:getfocuspwd1});
       return false;
     } 
     if(!isalphanumber(pwd1))
     {
       alert('新密码只能输入数字和字母！');
       $("#txtPwd1").focus();
       return false;
     }
       var pwd2=$("#txtPwd2").val();
     if(pwd2=="")
     {
       $.prompt("请再次输入新密码",{callback:getfocuspwd2});
       return false;
     } 
     if(pwd1!=pwd2)
     {
       $.prompt("两次输入密码不一致！",{callback:getfocuspwd2});
       return false;
     }
   } 
  
  
   function getfocusold()
  {
   $("#txtOlePwd").focus();
  } 
       function getfocuspwd1()
  {
   $("#txtPwd1").focus();
  }    function getfocuspwd2()
  {
   $("#txtPwd2").focus();
  } 
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">修改个人密码</div>
        <table class="table" style="margin-top:20px; margin-left:5%">
            <tr>
                <td style="width:15%; text-align:right">请输入原密码：</td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtOlePwd"  runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">请输入新密码：</td>
                <td style="text-align:left" >
                    <asp:TextBox ID="txtPwd1"  runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">请再次输入新密码</td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtPwd2"  runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
            	<td></td>
                <td style="text-align:left">
                	<asp:Button ID="Button1" runat="server" Text="确定" CssClass="qr0" OnClientClick="return CheckPwd();" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="取消" OnClientClick="javascript:window.location=window.location;" CssClass="qr0" style="margin-left:50px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
