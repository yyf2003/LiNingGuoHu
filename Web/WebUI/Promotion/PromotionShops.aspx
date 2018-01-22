<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionShops.aspx.cs" Inherits="WebUI_Promotion_PromotionShops" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 订单发货确认 &gt;&gt; 店铺信息</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 170px; text-align: right">
                    推广ID:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; text-align: right">
                    推广主题:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="width: 170px; text-align: right">
                    
                </td>
                <td style="text-align: left">
                    
                    <asp:LinkButton ID="lbBack" runat="server" onclick="lbBack_Click">返 回</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <table class="table">
                    <tr>
                        <td style="width: 80px; text-align: right">
                            店铺编号:
                        </td>
                        <td style="width: 183px;">
                            <asp:TextBox ID="txtPOSCode" runat="server" MaxLength="5"></asp:TextBox>
                        </td>
                        <td style="width: 80px; text-align: right">
                            店铺名称:
                        </td>
                        <td style="width: 177px;">
                            <asp:TextBox ID="txtShopName" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                        <td style="text-align: left;">
                            <asp:Button ID="Button1" runat="server" Text="查 询" CssClass="qr0" OnClick="Button1_Click" />
                            
                        </td>
                    </tr>
                </table>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemdatabound="Repeater1_ItemDataBound" 
            onitemcommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table class="table" style="text-align: center;">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            POSCode
                        </th>
                        <th>
                            店铺名称
                        </th>
                        <th>
                            POP订单数量
                        </th>
                        <th>
                            发货状态
                        </th>
                        <th runat="server" id="receiveState">
                            收货状态
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
                            <%#Eval("PosID")%>
                        </td>
                        <td>
                            <%#Eval("Shopname")%>
                        </td>
                        <td >
                            <asp:Label ID="labOrderCount" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <%#!string.IsNullOrWhiteSpace(Eval("SentOrderDate").ToString()) ? "已发货" : "<span style='color:red;'>未发货</span>"%>
                        </td>
                        <td runat="server" id="receiveState">
                            <%#!string.IsNullOrWhiteSpace(Eval("ReceiveOrderDate").ToString()) ? "已收货" : "<span style='color:red;'>未收货</span>"%>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbSent" runat="server" CommandArgument='<%#Eval("Id") %>'>提交发货</asp:LinkButton>
                            
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%if (Repeater1.Items.Count == 0)
                  { %>
                   <tr>
                      <td colspan="11" style=" text-align:center;">
                         --暂无信息--
                      </td>
                   </tr>
                <%} %>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <div style=" text-align:center;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager" AlwaysShow="true"
                    PageSize="10" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
                    NumericButtonCount="7" OnPageChanged="AspNetPager1_PageChanged"
                    LayoutType="Table" HorizontalAlign="Left" CustomInfoHTML="共%RecordCount%条记录" ShowCustomInfoSection="Left">
            </webdiyer:AspNetPager>

        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
