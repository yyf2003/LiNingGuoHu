<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveOrderManage.aspx.cs" Inherits="WebUI_Promotion_ReceiveOrderManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/calendar.js"></script>
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
                <asp:TextBox ID="txtBeginDate" runat="server" onclick="setday(this,document.getElementById('txtBeginDate'))"
                    CssClass="txtwith" Style="width: 180px;"></asp:TextBox>
            </td>
            <td style="width: 120px;">
                结束时间：
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server" onclick="setday(this,document.getElementById('txtEndDate'))"
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
    <asp:Repeater ID="Repeater1" runat="server" 
         onitemdatabound="Repeater1_ItemDataBound"
         
        >
            <HeaderTemplate>
                <table class="table">
                    <tr>
                        <th>
                            序号
                        </th>
                        <th>
                            发起ID
                        </th>
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
                            总店数
                        </th>
                        <th>
                            已发货店数
                        </th>
                        <th>
                            已收货店数
                        </th>
                        <th>
                            查看
                        </th>
                       
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("PromotionId")%>
                    </td>
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
                        <asp:Label ID="labTotalShops" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="labSnedShops" runat="server" Text=""></asp:Label>
                    </td>
                     <td>
                        <asp:Label ID="labReceiveShops" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <a href="PromotionShops.aspx?id=<%#Eval("Id") %>&isReceive=1">查看</a>
                    </td>
                    
                   
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%if (Repeater1.Items.Count == 0)
                  { %>
                   <tr>
                      <td colspan="12" style=" text-align:center;">
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
    </form>
</body>
</html>
