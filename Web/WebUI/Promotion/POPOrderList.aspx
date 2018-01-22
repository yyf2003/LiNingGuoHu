<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPOrderList.aspx.cs" Inherits="WebUI_Promotion_POPOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        #maindiv td
        {
            padding-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 查看订单信息</div>
    </div>
    <br />
    <div id="maindiv">
        <table class="table">
            <tr>
                <td style="width: 15%">
                    POP推广ID:
                </td>
                <td style="width: 35%">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 15%">
                    推广主题：
                </td>
                <td style="width: 35%">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    起始时间：
                </td>
                <td>
                    <asp:Label ID="labStartDate" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    结束时间：
                </td>
                <td>
                    <asp:Label ID="labEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    描述：
                </td>
                <td colspan="3">
                    <asp:Label ID="labRemark" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    季度执行规范下载：
                </td>
                <td>
                    <asp:Label ID="labAttachment" runat="server" Text=""></asp:Label>
                </td>
                <td>
                订单收发信息：
                </td>
                <td>
                    <asp:LinkButton ID="lbCheck" runat="server" onclick="lbCheck_Click">查 看</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <a href="PromotionList.aspx">返回列表</a>
                </td>
                <td>
                </td>
                <td>
                    
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
                            <asp:Button ID="Button1" runat="server" Text="查询订单" CssClass="qr0" OnClick="Button1_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnLoadOut" runat="server" Text="导出订单" CssClass="qr0" OnClick="btnLoadOut_Click" />
                        </td>
                    </tr>
                </table>
        <div style="width: 900px; overflow: auto;">
            <div style="width: 2500px;">
                
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table class="table" style="width: 100%;">
                            <tr>
                                <th>
                                    序号
                                </th>
                                <th>
                                    确认状态
                                </th>
                                <th>
                                    店铺编号
                                </th>
                                <th>
                                    店铺名称
                                </th>
                                <th>
                                    POP位置
                                </th>
                                <th>
                                    位置描述
                                </th>
                                <th>
                                    男女区域
                                </th>
                                <th>
                                    POP实际制作宽(mm)
                                </th>
                                <th>
                                    POP实际制作高(mm)
                                </th>
                                <th>
                                    POP可视画面宽(mm)
                                </th>
                                <th>
                                    POP可视画面高(mm)
                                </th>
                                <th>
                                    POP可视画面位置
                                </th>
                                <th>
                                    POP可视画面偏离度
                                </th>
                                <th>
                                    POP材质
                                </th>
                                <th>
                                    POP材质备注
                                </th>
                                <th>
                                    产品大类
                                </th>
                                <th>
                                    POP产品系列
                                </th>
                                <th>
                                    是否粘于玻璃上
                                </th>
                                <th>
                                    是否为双面
                                </th>
                                <th>
                                    橱窗空间长度(mm)
                                </th>
                                <th>
                                    橱窗空间进深(mm)
                                </th>
                                <th>
                                    橱窗面积(平方米)
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("IsConfirm") != null && Eval("IsConfirm").ToString()=="1"?"已确认":"未确认"%>
                            </td>
                            <td>
                                <%#Eval("PosID")%>
                            </td>
                            <td>
                                <%#Eval("Shopname")%>
                            </td>
                            <td>
                                <%#Eval("seat")%>
                            </td>
                            <td>
                                <%#Eval("SeatDesc")%>
                            </td>
                            <td>
                                <%#Eval("Sexarea")%>
                            </td>
                            <td>
                                <%#Eval("RealWith")%>
                            </td>
                            <td>
                                <%#Eval("RealHeight")%>
                            </td>
                            <td>
                                <%#Eval("POPWith")%>
                            </td>
                            <td>
                                <%#Eval("POPHeight")%>
                            </td>
                            <td>
                                <%#Eval("POPPlwz")%>
                            </td>
                            <td>
                                <%#Eval("POPPljd")%>
                            </td>
                            <td>
                                <%#Eval("POPMaterial")%>
                            </td>
                            <td>
                                <%#Eval("POPMaterialRemark")%>
                            </td>
                            <td>
                                <%#Eval("ProductTypeName")%>
                            </td>
                            <td>
                                <%#Eval("ProductLine")%>
                            </td>
                            <td>
                                <%#Eval("Glass")%>
                            </td>
                            <td>
                                <%#Eval("TwoSided")%>
                            </td>
                            <td>
                                <%#Eval("PlatformWith")%>
                            </td>
                            <td>
                                <%#Eval("PlatformLong")%>
                            </td>
                            <td>
                                <%#Eval("PlatformHeight")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%if (Repeater1.Items.Count == 0)
                          { %>
                        <tr>
                            <td colspan="21" style="text-align: center; height: 30px;">
                                --暂无信息--
                            </td>
                        </tr>
                        <%} %>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            
        </div>
        <div style="text-align: left; width:900px;">
                <webdiyer:AspNetPager ID="AspNetPager1"  runat="server" CssClass="pager" AlwaysShow="true"
                    PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
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
