<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamFx.aspx.cs" Inherits="WebUI_Distribution_ExamFx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script language="javascript" type="text/javascript">
        function checkall() {
            var all = document.getElementById('check_all');
            var shopidlist = document.getElementsByName('check_shopid');

            for (var i = 0; i < shopidlist.length; i++) {
                shopidlist[i].checked = all.checked;
            }

        }
    </script>
</head>
<body style="font-size: 12px; background-position: center bottom; background-repeat: no-repeat;
    border-width: 1px; border-color: #ffccff">
    <form id="form1" runat="server">
    <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
        color: #c86000;">
        直属客户从属关系审核</div>
    <br />
    <div style="margin-top: 20px; margin-left: 20px">
        <table class="table">
            <tr>
                <td style="width: 15%">
                    部门名称：
                </td>
                <td align="left" style="width: 35%">
                    <%--onchange=" GetAreaName(this.value);"--%>
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" 
                        AutoPostBack="true" 
                        onselectedindexchanged="DDL_department_SelectedIndexChanged">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%">
                    区域名称：
                </td>
                <td align="left" style="width: 35%">
                    <asp:DropDownList ID="DDL_Area" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btn_search" runat="server" CssClass="qr0" Text="查 询" OnClick="btn_search_Click" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table" style="width: 150%">
                    <tr>
                        <th>
                            全选
                            <input id="check_all" onclick="checkall()" type="checkbox" />
                        </th>
                        <th>
                            直属客户编号
                        </th>
                        <th>
                            直属客户
                        </th>
                        <th>
                            联系人
                        </th>
                        <th>
                            联系电话
                        </th>
                        <th>
                            前一级客户
                        </th>
                        <th>
                            现一级客户
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <input name="check_shopid" id="Checkbox1" value="<%#Eval("ID") %>" type="checkbox" />
                    </td>
                    <td>
                        <%#Eval("FXID") %>
                    </td>
                    <td>
                        <%#Eval("FXName")%>
                    </td>
                    <td>
                        <%#Eval("FxContactor") %>
                    </td>
                    <td>
                        <%#Eval("FxPhone") %>
                    </td>
                    <td>
                        <%#Eval("dealername") %>
                    </td>
                    <td>
                        <%#Eval("newdealername") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        <br />
        <div class="table">
            <asp:Button ID="btn_ok" runat="server" OnClientClick="return confirm('确认选择的信息都通过？');"
                CssClass="qr0" Text="通 过" OnClick="btn_ok_Click" Enabled="False" />&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;
            <asp:Button ID="Btn_no" runat="server" CssClass="qr0" OnClientClick="return confirm('确认选择的信息都不能通过审核？');"
                Text="未通过" OnClick="Btn_no_Click" Enabled="False" /></div>
    </div>
    </form>
</body>
</html>
