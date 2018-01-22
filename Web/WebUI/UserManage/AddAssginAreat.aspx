<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAssginAreat.aspx.cs" Inherits="WebUI_UserManage_AddAssginAreat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>区域管理信息</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <!-- Can't miss  begin -->

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" src="../../js/common.js"></script>

    <script language="javascript" src="javascript/allotArea.js" type="text/javascript"></script>
<style type="text/css">
    .divcss{
        font-family:Arial;font-size:12px;width:99%; border:1px solid #6d6060;background-color:#fdf6f6; padding-left:20px; padding-top:10px; margin-top:10px;
    }
</style>
    <script type="text/javascript" language="javascript">
   var userid=<%#UserID %> ; 
    function CheckPost()
   { 
var alist=""; 
var plist="";
var clist="";   
var area =document.getElementsByTagName ("input");
for(var i=0;i<area.length;i++)
{
var a =area[i];
if(a.name=="area")
{
if(a.checked)
alist +=a.value+",";
} 
if(a.name=="province")
{
if(a.checked)
plist +=a.value+",";
} 
if(a.name=="city")
{
if(a.checked)
clist +=a.value+",";
} 
}  
if(alist=="")
{
$.prompt("请选择区域");
return false; 
} 
else
{
alist=alist.substring(0,alist.length-1); 
} 
if(plist=="")
{
$.prompt("请选择省份");
return false; 
}
else
{
plist=plist.substring(0,plist.length-1);
}   
if(clist=="")
{
$.prompt("请选择市区");
return false; 
}
else
{
clist=clist.substring(0,clist.length-1);
}  
  }
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1"  onsubmit="return CheckPost();" method ="post" action ="AddAssginArea_do.aspx?UserID=<%=UserID %>" >
        <div style="margin-left:20px">
            <table class="table">
                <tr>
                    <td style="height: 32px; font-size:14px; color:#c86000;">
                        &nbsp;为<%=UserName%>分配管理区域</td>
                </tr>
            </table>
            <br />
            <table class="table">
            <tr>
            <td>
           
        <div id="areadiv" class="divcss" style="height:25px;"><span style="font-weight:bold">区域：</span><asp:Literal ID="Lit_Area" runat="server"></asp:Literal></div>
		<div id="pro" class="divcss"><span style="font-weight:bold">省&nbsp;&nbsp;份：</span><br /><asp:Literal ID="Lit_province" runat="server"></asp:Literal><br /><br /></div>
		<div id="citytable" class="divcss"><span style="font-weight:bold">地级城市：</span><br /><asp:Literal ID="Lit_city" runat="server"></asp:Literal><br /><br /></div>
		<div id="towntable" class="divcss"><span style="font-weight:bold">区县级城市：</span><br /><asp:Literal ID="Lit_town" runat="server"></asp:Literal><br /><br /></div>
		 </td>
        </tr>
		 </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px;">
            <tr>
                <td colspan="2" align="center">
                    <input id="Button1" type="button" value="返回" class="qr0" style="margin-right: 20px;"
                        onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />&nbsp;
                    <input id="Submit1" type="submit" value="确定提交" class="qr0" /></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
