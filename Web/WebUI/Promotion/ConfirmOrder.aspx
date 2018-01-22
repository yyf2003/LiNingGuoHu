<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="WebUI_Promotion_ConfirmOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function AlertMsg(msg) {
            alert(msg);
        }
        $(function () {
            //            $("input[type='checkbox'][name$='cbAll']").on("click", function () {
            //                var check = this.checked;
            //                $("input[type='checkbox'][name$='cbOne']").each(function () {
            //                    $(this).attr("checked", check);
            //                })
            //            })
        })

        function check() {
            var count = $(".data").length;
            //            count = $("input[type='checkbox'][name$='cbOne']:checked").length;
            //            if (count == 0) {
            //                alert("请选择要确认的订单！");
            //                return false;
            //            }
            if (count == 0) {
                alert("没有可提交的数据");
                return false;
            }
            return confirm("确定提交吗？");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="PromotionList.aspx" title="POP推广信息" style="color: #c86000;">POP推广信息</a>
            &gt;&gt; 订单确认</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 150px; text-align: right">
                    推广ID:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    推广主题:
                </td>
                <td style="text-align: left">
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="table">
            <tr>
                <td style="width: 80px; text-align: right">
                    店铺编号:
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtPOSCode" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                <td style="width: 60px; text-align: right">
                    店铺名称:
                </td>
                <td style="width: 150px;">
                    <asp:TextBox ID="txtShopName" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                <td style="width: 60px; text-align: right">
                    确认状态:
                </td>
                <td style="width: 150px;">
                    <asp:RadioButtonList ID="rblConfirmState" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">未确认 </asp:ListItem>
                        <asp:ListItem Value="1">已确认 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="text-align: left;">
                    <asp:Button ID="Button1" runat="server" Text="查询订单" CssClass="qr0" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server">
            <div style="width: 900px; overflow: auto;">
                <div style="width: 2500px;">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <HeaderTemplate>
                            <table id="table1" class="table" style="width: 100%;">
                                <tr>
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        确认状态
                                    </td>
                                    <td>
                                        店铺编号
                                    </td>
                                    <td>
                                        店铺名称
                                    </td>
                                    <td>
                                        POP位置
                                    </td>
                                    <td>
                                        位置描述
                                    </td>
                                    <td>
                                        男女区域
                                    </td>
                                    <td>
                                        POP实际制作宽(mm)
                                    </td>
                                    <td>
                                        POP实际制作高(mm)
                                    </td>
                                    <td>
                                        POP可视画面宽(mm)
                                    </td>
                                    <td>
                                        POP可视画面高(mm)
                                    </td>
                                    <td>
                                        POP可视画面位置
                                    </td>
                                    <td>
                                        POP可视画面偏离度
                                    </td>
                                    <td>
                                        POP材质
                                    </td>
                                    <td>
                                        POP材质备注
                                    </td>
                                    <td>
                                        产品大类
                                    </td>
                                    <td>
                                        POP产品系列
                                    </td>
                                    <td>
                                        是否粘于玻璃上
                                    </td>
                                    <td>
                                        是否为双面
                                    </td>
                                    <td>
                                        橱窗空间长度(mm)
                                    </td>
                                    <td>
                                        橱窗空间进深(mm)
                                    </td>
                                    <td>
                                        橱窗面积(平方米)
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="data">
                                <td>
                                    <%#Container.ItemIndex+1 %>
                                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("ID")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="labState" runat="server" Text=""></asp:Label>
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
                                <td colspan="22" style="text-align: left; padding-left: 50px; height: 30px;">
                                    --无符合条件的信息--
                                </td>
                            </tr>
                            <%} %>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>
        <div style="text-align: left; padding-left: 50px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager" AlwaysShow="true"
                    PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
                    NumericButtonCount="7" 
                    LayoutType="Table" HorizontalAlign="Left" 
                CustomInfoHTML="共%RecordCount%条记录" ShowCustomInfoSection="Left" 
                onpagechanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
        <br />
        <br />
        <div style="text-align: center; width: 900px;">
            <asp:Button ID="BtnConfirm" CssClass="qr0" runat="server" Text="确 认" OnClientClick="return check()"
                OnClick="BtnConfirm_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" CssClass="qr0" runat="server" Text="返 回" OnClick="Button2_Click" />
        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
