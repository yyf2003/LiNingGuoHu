<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="WebUI_UserInfo_UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户列表</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <style>
        *body
        {
            font-size: 12px;
        }
        a:link
        {
            text-decoration: none;
            color: #424242;
        }
        a:active
        {
            text-decoration: underline;
            color: #424242;
        }
        a:visited
        {
            text-decoration: none;
            color: #424242;
        }
        a:hover
        {
            text-decoration: underline;
            color: #000000;
        }
    </style>
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"> </script>
    <script type="text/javascript">
        function rehab(key) {
            if (key != "") {
                if (confirm('确定执行复职操作吗？')) {
                    $.get("CallBack/RehabOneUser.ashx?Date=" + new Date(), { UserID: key }, function (data) {
                        if (data.length > 0) {
                            window.location = window.location;
                        }
                    });
                }
            }
        }


        $(function () {
            $("#GV_UserList").find("input[name$='cbAll']").click(function () {
                var check = this.checked;
                $("#GV_UserList").find("input[name$='cbOne']").each(function () {
                    this.checked = check;
                })
            })
        })


        function checkDelete() {
            var selectCount = 0;
            selectCount = $("#GV_UserList").find("input[name$='cbOne']:checked").length;
            if (selectCount > 0) {
                return confirm("确定删除吗？");
            }
            else {
                alert("请先选择要删除的数据");
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            人员信息管理</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style="width: 15%">
                    员工名称
                </td>
                <td style="width: 35%">
                    <asp:TextBox ID="txt_UserName" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td style="width: 15%">
                    性别
                </td>
                <td>
                    <asp:DropDownList ID="ddl_Sex" runat="server">
                        <asp:ListItem Value="0" Text="0">请选择性别</asp:ListItem>
                        <asp:ListItem Text="男">男</asp:ListItem>
                        <asp:ListItem Text="女">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    角色类型
                </td>
                <td>
                    <asp:DropDownList ID="ddl_UserType" runat="server">
                        <asp:ListItem Value="0">请选择角色类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    用户状态
                </td>
                <td>
                    <asp:DropDownList ID="ddl_UserStation" runat="server">
                        <asp:ListItem Value="1">在职</asp:ListItem>
                        <asp:ListItem Value="0">离职</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <input id="Button1" type="button" value="查询" class="qr0" onserverclick="Button1_ServerClick"
                        runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <div style="margin-left: 5%">
            <asp:Button ID="btnDelete" runat="server" Text="删除所选" class="qr0" 
                OnClientClick="return checkDelete()" onclick="btnDelete_Click"/>
        </div>
        <asp:GridView ID="GV_UserList" runat="server" AutoGenerateColumns="false" CssClass="table"
            Style="margin-top: 10px; margin-left: 5%" OnRowCommand="GV_UserList_RowCommand"
            OnRowDataBound="GV_UserList_RowDataBound" AllowPaging="True" OnPageIndexChanging="GV_UserList_PageIndexChanging"
            PageSize="20">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbAll" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbOne" runat="server"/>
                        <asp:HiddenField ID="hfUserId" runat="server" Value='<%#Eval("ID") %>'/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="4%" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="Rid" HeaderText="编号">
                    <ItemStyle Height="22px" HorizontalAlign="Center" Width="8%" />
                    <HeaderStyle Height="22px" Width="8%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="用户名">
                    <ItemTemplate>
                        <%#Eval("UserName") %>
                    </ItemTemplate>
                    <HeaderStyle Width="8%" />
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Sex" HeaderText="性别">
                    <ItemStyle Height="22px" HorizontalAlign="Center" Width="6%" />
                    <HeaderStyle Height="22px" Width="6%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="人员角色">
                    <ItemTemplate>
                        <asp:Label ID="labRole" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部门">
                    <ItemTemplate>
                        <asp:Label ID="labDepart" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>
                <asp:BoundField DataField="UserEmail" HeaderText="电子邮件">
                    <ItemStyle Height="22px" HorizontalAlign="Center" Width="14%" />
                    <HeaderStyle Height="22px" Width="14%" />
                </asp:BoundField>
                <asp:BoundField DataField="UserPhone" HeaderText="联系电话">
                    <ItemStyle Height="22px" HorizontalAlign="Center" Width="8%" />
                    <HeaderStyle Height="22px" Width="8%" />
                </asp:BoundField>
                <asp:BoundField DataField="UserMobel" HeaderText="手机">
                    <ItemStyle Height="22px" HorizontalAlign="Center" Width="8%" />
                    <HeaderStyle Height="22px" Width="8%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#Eval("UserState").ToString() == "1" ? "在职" : "离职&nbsp;&nbsp;<span onclick=\"rehab(" + Eval("ID") + ");\" style=\"cursor:hand;\">复职</span>"%>
                        <asp:LinkButton ID="LK_UserStation" runat="server" CommandName="SetStation" OnClientClick="return confirm('确定设置职位状态吗?');"
                            CommandArgument='<%#Eval("ID") %>' Visible=' <%#Eval("UserState").ToString ()=="0"?false:true%>'>操作</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="8%" />
                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="详细">
                    <ItemTemplate>
                        <a href='OneUserInfo.aspx?ID=<%#Eval("ID") %>'>详细 </a>
                    </ItemTemplate>
                    <HeaderStyle Width="6%" />
                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbEdit" CommandArgument='<%#Eval("ID") %>' CommandName="mdf" runat="server">修改</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="6%" />
                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
