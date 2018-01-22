<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddReceiveGoods.aspx.cs"
    Inherits="WebUI_PhysicalDistribution_AddReceiveGoods" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>增补收货查询</title>

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script src="../../js/GetFxname.js" language="javascript" type="text/javascript"></script>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto;">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                店铺增补POP收货</div>
            <div style="margin-top: 20px; float: left; margin-left: 20px; width: 100%">
                <table class="table" style="width: 100%">
                    <tr>
                        <td style="width: 15%;">
                            店铺编号：</td>
                        <td style="width: 30%;">
                            &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                        <td style="width: 15%;">
                            店铺名称：</td>
                        <td>
                            &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            发货单号：</td>
                        <td style="width: 30%;">
                            &nbsp;<asp:TextBox ID="txt_FHID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                        <td style="width: 15%;">
                            一级客户：</td>
                        <td>
                            &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="DDlstyle" runat="server" Width="80%" onchange="GetFxlist();">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            直属客户：</td>
                        <td style="width: 30%;">
                            &nbsp;<asp:DropDownList ID="DDL_fx" CssClass="txtwith" runat="server">
                                <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                            </asp:DropDownList></td>
                        <td colspan="2" align="left">
                            <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" /></td>
                    </tr>
                </table>
                <br />
                <table class="table" style="width: 100%">
                    <tr>
                        <th style="height: 30px; width: 7%">
                            流水号</th>
                        <th>
                            店铺编号</th>
                        <th style="width: 23%">
                            店铺名称</th>
                        <th style="">
                            所属省市</th>
                        <th style="width: 23%">
                            所属一级客户</th>
                        <th style="">
                            POP总数量</th>
                    </tr>
                    <asp:Repeater runat="server" ID="RepShopList">
                        <ItemTemplate>
                            <tr>
                                <td style="height: 25px;">
                                    <asp:HiddenField ID="hf1" Value='<%# Eval("ShopID")%>' runat="server" />
                                    <%# Eval("rowId")%>
                                </td>
                                <td style="">
                                    <%# Eval("PosID")%>
                                </td>
                                <td style="">
                                    <%# Eval("Shopname")%>
                                </td>
                                <td style="">
                                    <%# Eval("ProvinceName")%>
                                    ，<%# Eval("CityName")%></td>
                                <td style="">
                                    <%# Eval("DealerName")%>
                                </td>
                                <td style="">
                                    <a href='shouhuo.aspx?shopid=<%#Eval("ShopID") %>&POPID=<%=NewPOPID %>'>
                                        <%# Eval("POPCount")%>
                                    </a>
                                </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb" ID="ListPages"
                    runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                    PageSize="100" Width="900" OnPageChanging="ListPages_PageChanging">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
