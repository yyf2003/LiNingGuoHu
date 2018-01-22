<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supplier_POPOderList.aspx.cs"
    Inherits="WebUI_Supplier_Supplier_POPOderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/LinkageClass.js"></script>
    <script language="javascript" type="text/javascript" src="./javascript/GetSrarchTimeByPOPID.js"></script>
    <script language="javascript" type="text/javascript">
        function GetListObj(areaid) {
            var obj = new LinkageClass();
            obj.GetDealerByAreaID(areaid);
            obj.GetProvinceName(areaid);
        }

        function GetFXObj(DealerID) {
            var obj = new LinkageClass();
            obj.GetFxbyDealerid(DealerID);
        }

        function ValidateDateTime() {
            var txtBeginDate = $.trim($("#txtBeginDate").val());      //起始时间
            if (txtBeginDate == "") {
                alert("请您输入起始时间！！");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="padding-left: 20px;">
            <div style="font-size: 14px; font-weight: bold; text-align: left; width: 50%; height: 30px;
                color: #c86000;">
                季度订单数据导出</div>
            <br />
            <div>
                <table class="table">
                    <tr>
                        <td style="width: 20%; text-align: right;">
                            POP发起ID：
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DDL_poplist" Width="250px" runat="server" onchange="GetSrarchTimeByPOPIDJS(this.value);">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; text-align: right;">
                            订单生成起始时间：
                        </td>
                        <td colspan="2" style="">
                            <asp:TextBox runat="server" ID="txtBeginDate" Width="250px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; text-align: right;">
                            所属区域：
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DDL_Area" Width="250px" runat="server" onchange="GetListObj(this.value);">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfAreas" runat="server" />
                        </td>
                        <td style="width: 20%; text-align: right;">
                            所属省份：
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DDL_Province" Width="250px" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%; text-align: right;">
                            一级客户：
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DDL_DealerInfo" Width="250px" runat="server" onchange="GetFXObj(this.value);">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%; text-align: right;">
                            直属客户：
                        </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="DDL_Dis" Width="250px" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btn_search" CssClass="qr0" runat="server" Text="查 询" OnClick="btn_search_Click"
                                OnClientClick=" return ValidateDateTime();" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <tr>
                                <th>
                                    供应商名称
                                </th>
                                <th>
                                    负责人
                                </th>
                                <th>
                                    负责人电话
                                </th>
                                <th>
                                    分画面订单数量
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("Suppliername") %>
                            </td>
                            <td>
                                <%#Eval("Contacter") %>
                            </td>
                            <td>
                                <%#Eval("ContactPhone")%>
                            </td>
                            <td>
                                <a href="Supplier_OrderListImg.aspx?sid=<%#Eval("SupplierID") %>&sname=<%#Server.UrlEncode(Eval("Suppliername").ToString()) %>&POPID=<%=POPID %>">
                                    <%#Eval("popcount") %></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <%=daochuAllurl %>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=daochuurl %>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=nosubmiturl %>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
