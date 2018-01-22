<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneUserInfo.aspx.cs" Inherits="WebUI_UserInfo_OneUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人员详细信息</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/screen.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/Validate.js"></script>

    <script language="javascript" type="text/javascript" src="Javascript/AddUser.js"> </script>

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server" onsubmit="return CheckAdd();">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <a href="UserList.aspx" title="人员信息管理" style="color: #c86000;">人员信息管理</a> &gt;&gt;
                员工详细信息</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td width ="100px">
                        员工名称
                    </td>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text='<%#UserName %>'></asp:Label>
                        <div id="msg" style="color: Red;">
                        </div>
                    </td>
                    <td style="width: 15%">
                           用户状态
                    </td>
                    <td align="left">
                       <asp:Label ID="Label9" runat="server" Text='<%#UserState.ToString ()=="1"?"在职":"离职" %> '></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td width ="100px">
                        性别
                    </td>
                    <td align="left">
                        <asp:Label ID="Label3" runat="server" Text='<%#Sex %>'></asp:Label>
                    </td>
                    <td>
                        角色类型
                    </td>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Text='<%#GetUserType(UserType.ToString()) %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td width ="100px">
                        电子邮件地址
                    </td>
                    <td align="left">
                        <asp:Label ID="Label5" runat="server" Text='<%#UserEmail %>'></asp:Label>
                    </td>
                    <td>
                        所在地
                    </td>
                    <td align="left">
                        <asp:Label ID="Label6" runat="server" Text='<%#UserAddress %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                      <td width ="100px">
                        家庭电话
                    </td>
                    <td align="left">
                        <asp:Label ID="Label7" runat="server" Text='<%#UserPhone %>'></asp:Label>
                    </td>
                    <td>
                        移动电话
                    </td>
                    <td align="left">
                        <asp:Label ID="Label8" runat="server" Text='<%#UserMobel %>'></asp:Label>
                    </td>
                </tr>
            
                <tr height="80px">
                    <td>
                        描述
                    </td>
                    <td colspan="3" align="left">
                        <asp:Literal ID="Literal1" runat="server" Text='<%#UserDesc %>'></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <input id="Button2" type="button" value="返 回" class="qr0" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
