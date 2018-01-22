<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignArea.aspx.cs" Inherits="WebUI_UserManage_AssignArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>区域管理信息</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" /> 
  
</head>
<body>
    <form id="form1" runat="server">
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
                        &nbsp;大区域：</td>
                </tr>
            </table>
            <table class="table">
                <tr>
                    <td>
                        <asp:Literal ID="Lit_Area" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <table class="table"  style="margin-left:20px">
            <tr>
                <td>
                    &nbsp; 省&nbsp; 份：</td>
            </tr>
        </table>
        <table id="pro" class="table"  style="margin-left:20px">
            <tr>
                <td>
                    <asp:Literal ID="Lit_province" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <table class="table"  style="margin-left:20px">
            <tr>
                <td>
                    &nbsp; 地级城市：</td>
            </tr>
        </table>
        <table id="citytable" class="table"  style="margin-left:20px">
            <tr>
                <td>
                     <asp:Literal ID="Lit_city" runat="server"></asp:Literal></td>
            </tr>
        </table>
           <table class="table"  style="margin-left:20px">
            <tr>
                <td>
                    &nbsp; 区县级城市：</td>
            </tr>
        </table>
        <table id="Table1" class="table"  style="margin-left:20px">
            <tr>
                <td >
                    <asp:Literal ID="Lit_town" runat="server"></asp:Literal></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px; margin-left:20px">
            <tr>
                <td colspan="2" align="center">
                    <input id="Button1" type="button" value="返回" class="qr0" style="margin-right: 20px;"
                        onclick="window.location='UserList.aspx'" />
                    <input id="Button2" type="button" value="重新分配" class="qr0" onclick =" if(confirm('确定重新分配吗？如果确定，该用户以前分配的区域将会全部删除')) window.location='AddAssginAreat.aspx?UserID=<%#UserID %>';" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
