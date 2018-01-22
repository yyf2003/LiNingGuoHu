<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="WebUI_Promotion_RackInfo_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="../PromotionList.aspx" style="color: #c86000;">POP推广</a> &gt;&gt;
            <asp:Label ID="labTitle" runat="server" Text="道具基础信息"></asp:Label></div>
    </div>
    <br />
    <table class="table">
        <tr>
            <td style="width: 120px;">
                故事包：
            </td>
            <td style="width: 250px;">
                <asp:DropDownList ID="ddlStoryBag" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 120px;">
                位置：
            </td>
            <td>
                <asp:DropDownList ID="ddlSeat" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                道具名称：
            </td>
            <td style="width: 250px;">
                <asp:TextBox ID="txtName" runat="server" CssClass="txtwith" Style="width: 180px;"></asp:TextBox>
            </td>
            <td style="width: 120px;">
                状态：
            </td>
            <td>
                <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Selected="True" Value="">全部 </asp:ListItem>
                    <asp:ListItem Value="0">有效 </asp:ListItem>
                    <asp:ListItem Value="1">无效</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 120px;">
                道具类型：
            </td>
            <td style="width: 250px;">
                <asp:DropDownList ID="ddlPropType" runat="server">
                </asp:DropDownList>
            </td>
            <td style="width: 120px;">
            导出Excel：
            </td>
            <td>
                <asp:LinkButton ID="lbExport" runat="server" onclick="lbExport_Click">导 出</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Button ID="btnSearch" CssClass="qr0" runat="server" Text="查 询" OnClick="btnSearch_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAdd" CssClass="qr0" runat="server" Text="添 加" OnClick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnImport" CssClass="qr0" runat="server" Text="导 入" 
                    onclick="btnImport_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        故事包
                    </th>
                    <th>
                        位置
                    </th>
                    <th>
                        道具类型
                    </th>
                    <th>
                        道具名称
                    </th>
                    <th>
                        道具编码
                    </th>
                    <th>
                        尺寸
                    </th>
                    <th>
                        材质
                    </th>
                    <th>
                        规格
                    </th>
                    <th>
                        单位
                    </th>
                    <th>
                        类型
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Container.ItemIndex+1 %>
                </td>
                <td>
                    <%#Eval("StoryBagName")%>
                </td>
                <td>
                    <%#Eval("seat")%>
                </td>
                <td>
                    <%#Eval("RackType")%>
                </td>
                <td>
                    <%#Eval("RackName")%>
                </td>
                <td>
                    <%#Eval("RackCode")%>
                </td>
                <td>
                    <%#Eval("Size")%>
                </td>
                <td>
                    <%#Eval("Texture")%>
                </td>
                <td>
                    <%#Eval("Specification")%>
                </td>
                <td>
                    <%#Eval("Units")%>
                </td>
                <td>
                    <%#Eval("Category")%>
                </td>
                <td>
                    <%#Eval("IsDelete") != null && Eval("IsDelete").ToString() == "1" ? "<span style='color:red;'>无效</span>" : "有效"%>
                </td>
                <td>
                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="edit" CommandArgument='<%#Eval("Id")%>'>编辑</asp:LinkButton>
                    |
                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="dele" CommandArgument='<%#Eval("Id")%>'
                        OnClientClick="return confirm('确定删除吗？')">删除</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%if (Repeater1.Items.Count == 0)
              { %>
            <tr>
                <td colspan="13" style="text-align: center;">
                    --暂无信息--
                </td>
            </tr>
            <%} %>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <div style="text-align: center;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager" AlwaysShow="true"
            PageSize="10" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
            NumericButtonCount="7" OnPageChanged="AspNetPager1_PageChanged" LayoutType="Table"
            HorizontalAlign="Left" CustomInfoHTML="共%RecordCount%条记录" ShowCustomInfoSection="Left">
        </webdiyer:AspNetPager>
    </div>
    <br />
    <br />
    </form>
</body>
</html>
