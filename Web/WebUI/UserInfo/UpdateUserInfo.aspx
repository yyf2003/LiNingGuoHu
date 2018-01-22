<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUserInfo.aspx.cs" Inherits="WebUI_UserInfo_UpdateUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改个人信息</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script type="text/javascript" language="javascript">
        function ValInput() {
            var DDL_department = $.trim($("#DDL_department").val());
            var DDL_Area = $.trim($("#DDL_Area").val());
            if (DDL_department == "0") {
                alert("请您选择部门名称");
                return false;
            }
            if (DDL_Area == "0") {
                alert("请您选择区域名称");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return CheckAdd();">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="UserList.aspx" title="人员信息管理" style="color: #c86000;">修改个人信息</a> &gt;&gt;
            修改员工信息</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td>
                    员工名称
                </td>
                <td align="left">
                    <%--<asp:TextBox ID="txt_UserName" runat="server" CssClass="txtwith" Enabled="False"></asp:TextBox>
                    <div id="msg" style="color: Red;">
                    </div>--%>
                    <asp:Label ID="labUserName" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 15%">
                    登录密码
                </td>
                <td align="left">
                    <%--<asp:TextBox ID="txt_Pwd" runat="server" CssClass="txtwith" Enabled="false"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td>
                    性别
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddl_Sex" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    角色类型
                </td>
                <td align="left">
                  
                    <asp:Label ID="labRole" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td>
                   
                    <asp:Label ID="labDepart" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    区域名称：
                </td>
                <td>
                   
                    <asp:Label ID="labAreas" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td>
                    电子邮件地址
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMail" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td>
                    所在地
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserAddress" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    家庭电话
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserPhone" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td>
                    移动电话
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_UserMobile" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 34px">
                    用户状态
                </td>
                <td align="left" style="height: 34px">
                    <asp:Label ID="lblUserState" runat="server"></asp:Label>
                </td>
                <td>
                    <div id="Div1" style="display: none;">
                        所属一级客户：</div>
                </td>
                <td>
                    <div id="Div2" style="display: none;">
                        <asp:DropDownList ID="DDL_dealerList" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr height="80px">
                <td>
                    描述
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txt_UserDesc" runat="server" TextMode="MultiLine" Height="80px"
                        Width="320px" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="确认修改" OnClick="Button1_Click" CssClass="qr0"
                        OnClientClick="return ValInput();" />
                    &nbsp;&nbsp;
                    <input id="Button2" type="button" value="返 回" class="qr0" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
