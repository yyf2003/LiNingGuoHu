<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamNewShopList.aspx.cs"
    Inherits="WebUI_Shopmanage_ExamNewShopList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>省区VM审核新开店</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
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
<body>
    <form id="form1" runat="server">
    <div>
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            <a href="ShopInfoList.aspx" title="店铺信息" style="color: #c86000;">店铺信息</a> &gt;&gt;
            审核新增店铺信息</div>
        <br />
        <div style="margin-top: 20px; margin-left: 20px">
            <table class="table">
                <tr>
                    <td>
                        部门名称：
                    </td>
                    <td>
                   <%-- onchange=" GetAreaName(this.value);"--%>
                        <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" 
                            onselectedindexchanged="DDL_department_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        省区：
                    </td>
                    <td style="width: 30%">
                        <%--onchange="GetprovinceList()"--%>
                        <asp:DropDownList ID="DDL_Area" CssClass="txtwith" runat="server" 
                            onselectedindexchanged="DDL_Area_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">请选择区域名称</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfAreas" runat="server" />
                    </td>
                    <td style="width: 15%">
                        省：
                    </td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择省份</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center">
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
                                店铺编号
                            </th>
                            <th>
                                店铺名称
                            </th>
                            <th>
                                集团客户
                            </th>
                            <th>
                                一级客户
                            </th>
                            <th>
                                直属客户
                            </th>
                            <th>
                                店铺地址
                            </th>
                            <th>
                                店长
                            </th>
                            <th>
                                店长电话
                            </th>
                            <th>
                                VM负责人
                            </th>
                            <th>
                                VM负责人电话
                            </th>
                            <th>
                                DSR负责人电话
                            </th>
                            <th>
                                店铺电话
                            </th>
                            <th>
                                店铺级别
                            </th>
                            <th>
                                店铺类型
                            </th>
                            <th>
                                店铺VI形象
                            </th>
                            <th>
                                店铺面积
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <input name="check_shopid" id="Checkbox1" value="<%#Eval("shopid") %>" type="checkbox" />
                        </td>
                        <td>
                            <%#Eval("Posid") %>
                        </td>
                        <td>
                            <%#Eval("ShopName") %>
                        </td>
                        <td>
                            <%#Eval("CustomerGroupName") %>
                        </td>
                        <td>
                            <%#Eval("DealerName") %>
                        </td>
                        <td>
                            <%#Eval("FXName") %>
                        </td>
                        <td>
                            <%#Eval("ShopAddress") %>
                        </td>
                        <td>
                            <%#Eval("LinkMan") %>
                        </td>
                        <td>
                            <%#Eval("LinkPhone") %>
                        </td>
                        <td>
                            <%#Eval("VMMaster") %>
                        </td>
                        <td>
                            <%#Eval("VMMasterPhone") %>
                        </td>
                        <td>
                            <%#Eval("DSRMaster") %>
                        </td>
                        <td>
                            <%#Eval("ShopPhone") %>
                        </td>
                        <td>
                            <%#Eval("ShopLevel") %>
                        </td>
                        <td>
                            <%#Eval("ShopType") %>
                        </td>
                        <td>
                            <%#Eval("ShopVI") %>
                        </td>
                        <td>
                            <%#Eval("Shoparea") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table></FooterTemplate>
            </asp:Repeater>
            <br />
            <div class="table">
                <asp:Button ID="btn_ok" runat="server" OnClientClick="return confirm('确认选择的店铺都通过？');"
                    CssClass="qr0" Text="通 过" OnClick="btn_ok_Click" Enabled="False" />&nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp;
                <asp:Button ID="Btn_no" runat="server" CssClass="qr0" OnClientClick="return confirm('确认选择的店铺都不能通过审核？');"
                    Text="未通过" OnClick="Btn_no_Click" Enabled="False" /></div>
        </div>
    </div>
    </form>
</body>
</html>
