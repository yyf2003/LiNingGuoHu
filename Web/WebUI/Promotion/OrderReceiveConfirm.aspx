<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderReceiveConfirm.aspx.cs" Inherits="WebUI_Promotion_OrderReceiveConfirm" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register src="../../FileUploadUC/UpLoadContraol.ascx" tagname="UpLoadContraol" tagprefix="uc1" %>

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
            &gt;&gt; 订单收货确认 &gt;&gt; 提交收货信息</div>
        <br />
        <table class="table">
            <tr>
                <td style="width: 100px;">
                    POP推广ID:
                </td>
                <td style="width: 250px;">
                    <asp:Label ID="labPromotionId" runat="server" Text=""></asp:Label>
                </td>
                <td style="width: 100px;">
                    推广主题：
                </td>
                <td>
                    <asp:Label ID="labTitle" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    店铺POSCode：
                </td>
                <td>
                    <asp:Label ID="labPosCode" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    店铺名称：
                </td>
                <td>
                    <asp:Label ID="labShopName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <asp:LinkButton ID="lbBack" runat="server" onclick="lbBack_Click">返 回</asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
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
        <div style="text-align: left; width: 900px;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pager" AlwaysShow="true"
                PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PrevPageText="前页"
                NumericButtonCount="7" OnPageChanged="AspNetPager1_PageChanged" LayoutType="Table"
                HorizontalAlign="Left" CustomInfoHTML="共%RecordCount%条记录" ShowCustomInfoSection="Left">
            </webdiyer:AspNetPager>
        </div>
        <br />
        <br />
        <table class="table">
            <tr>
                <td style="width: 100px;">
                    收货时间:
                </td>
                <td>
                    <asp:TextBox ID="txtReceiveDate" MaxLength="10" runat="server" ContentEditable="false" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        CssClass="txtwith" style=" width:180px;"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    上传签收单：
                </td>
                <td>
                    <div id="show1" class="ShowFileInfo"></div>
                    <uc1:UpLoadContraol ID="UpLoadContraol1" runat="server" Code="1"/>
                    
                </td>
                
            </tr>
            <tr>
                <td>
                    备注：
                </td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="150" CssClass="txtwith" style=" width:500px;"></asp:TextBox>
                </td>
                
            </tr>
        </table>
        <br />
        <div style="text-align: center; width: 900px;">
            <asp:Button ID="BtnSubmit" CssClass="qr0" runat="server" Text="提 交" 
                OnClientClick="return check()" onclick="BtnSubmit_Click"
                 />
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button1" CssClass="qr0" runat="server" Text="返 回" onclick="lbBack_Click" 
                
                 />
        </div>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function check() {
        if ($.trim($("#txtReceiveDate").val()) == "") {
            alert("请选择收货时间");
            return false;
        }
        if ($.trim($("#show1").html()) == "") {
            alert("请上传签收单");
            return false;
        }
        return confirm("确定提交吗？");
    }
</script>

