<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionList.aspx.cs" Inherits="WebUI_Promotion_PromotionList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../../My97DatePicker/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt;
            <asp:Label ID="labTitle" runat="server" Text="推广信息提交记录"></asp:Label></div>
    </div>
    <br />
    <table class="table">
        <tr>
            <td style="width: 120px;">
                推广主题:
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="txtwith" Style="width: 180px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                起始时间：
            </td>
            <td style="width: 250px;">
                <asp:TextBox ID="txtBeginDate" runat="server" ContentEditable="false" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    CssClass="txtwith" Style="width: 180px;"></asp:TextBox>
            </td>
            <td style="width: 120px;">
                结束时间：
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" ContentEditable="false" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    CssClass="txtwith" Style="width: 180px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Button ID="btnSearch" CssClass="qr0" runat="server" Text="查 询" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
        OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>
                        序号
                    </th>
                    <%--<th>
                            发起ID
                        </th>--%>
                    <th>
                        主题
                    </th>
                    <th>
                        起始时间
                    </th>
                    <th>
                        结束时间
                    </th>
                    <th>
                        故事包
                    </th>
                    <th runat="server" id="submitState">
                        提交状态
                    </th>
                    <th runat="server" id="confirmState">
                        订单确认状态
                    </th>
                    <th runat="server" id="caozuo">
                        操 作
                    </th>
                    <th runat="server">
                        更新订单
                    </th>
                    <th runat="server" id="check">
                        导出订单
                    </th>
                    <th runat="server" id="editOrder">
                        修改订单
                    </th>
                    <th runat="server" id="confirm">
                        确认订单
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#Container.ItemIndex+1 %>
                </td>
                <%--<td>
                        <%#Eval("PromotionId")%>
                    </td>--%>
                <td>
                    <%#Eval("PromotionName")%>
                </td>
                <td>
                    <%#DateTime.Parse(Eval("BeginDate").ToString()).ToShortDateString() %>
                </td>
                <td>
                    <%#DateTime.Parse(Eval("EndDate").ToString()).ToShortDateString()%>
                </td>
                <td>
                    <asp:Label ID="labStoryBag" runat="server" Text=""></asp:Label>
                </td>
                <td runat="server" id="submitState">
                    <asp:Label ID="labSubmitState" runat="server" Text=""></asp:Label>
                </td>
                <td runat="server" id="confirmState">
                    <asp:Label ID="labConfirmState" runat="server" Text=""></asp:Label>
                </td>
                <td runat="server" id="caozuo" style="text-align: left;">
                    <asp:LinkButton ID="lbSubmit" runat="server" Visible="false" CommandArgument='<%#Eval("Id")%>'
                        CommandName="Submit" Style="color: Red; margin-right: 10px;">继续提交</asp:LinkButton>
                    <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Edit"
                        Style="margin-right: 10px;">编辑</asp:LinkButton>
                    <asp:LinkButton ID="lbDelete" runat="server" Visible="false" CommandArgument='<%#Eval("Id")%>'
                        CommandName="Delete" OnClientClick="return confirm('确定删除吗？')" Style="margin-right: 10px;
                        color: Red;">删除</asp:LinkButton>
                    <asp:LinkButton ID="lbCheck" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Check">查看</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="lbUpdateOrder" runat="server" CommandArgument='<%#Eval("Id")%>'
                        CommandName="Update">更新订单</asp:LinkButton>
                </td>
                <td runat="server" id="check">
                    <asp:LinkButton ID="lbExport" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="Export">导出原始订单</asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="lbFinalExport" runat="server" CommandArgument='<%#Eval("Id")%>'
                        CommandName="FinalExport">汇总导出</asp:LinkButton>
                </td>
                <td runat="server" id="editOrder">
                    <a href="PromotionFive.aspx?id=<%#Eval("Id") %>&edit=1">修改</a>
                </td>
                <td runat="server" id="confirm">
                    <a href="ConfirmOrder.aspx?id=<%#Eval("Id") %>&edit=1">确认</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%if (Repeater1.Items.Count == 0)
              { %>
            <tr>
                <td colspan="11" style="text-align: center;">
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
