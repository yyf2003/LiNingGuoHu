<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetupToShopList.aspx.cs"
    Inherits="WebUI_PhysicalDistribution_SetupToShopList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>安装到店铺列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

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

    <script language="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
	
	function GetDealerList()
	{
	    var cityID=$("#DDL_city").val();
	    GetdealerList(cityID);
	}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                安装到店铺</div>
            <table class="table" style="margin-top: 20px; float: left; margin-left: 20px; width: 100%">
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
                        所在省份：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="DDL_Province_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%;">
                        地级城市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="DDL_city_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%;">
                        一级客户：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddl_dealer_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%;">
                        直属客户：</td>
                    <td >
                        &nbsp;<asp:DropDownList ID="DDL_fx" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <table class="table" style="margin-top: 10px; float: left; margin-left: 20px; width: 100%">
                <tr>
                    <th style="height: 30px; width: 8%">
                        流水号</th>
                    <th style="width: 7%">
                        店铺编号</th>
                    <th style="width: 17%">
                        店铺名称</th>
                    <th style="width: 10%">
                        所属省市</th>
                    <th style="width: 20%">
                        所属一级客户</th>
                    <th style="width: 10%">
                        一级客户编号</th>
                    <th style="width: 8%">
                        直属客户编号</th>
                    <th style="width: 8%">
                        POP总数量</th>
                    <th style="width: 7%">
                        操作</th>
                </tr>
                <asp:Repeater runat="server" ID="RepShopList">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 25px;">
                                <%# Eval("SNumberID")%>
                                </th>
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
                                    <%# Eval("DealerID")%>
                                </td>
                                <td style="">
                                    <%# Eval("FXID")%>
                                </td>
                                <td style="">
                                    <%# Eval("POPSumNum")%>
                                </td>
                                <td style="">
                                    <a href='SetupToShop.aspx?id=<%# Eval("ShopID")%>&sid=<%= hidSupplierID.Value %>&did=<%# Eval("DealerID")%>&fxid=<%#Eval("FXID") %>'>
                                        安装发货</a></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb" ID="ListPages"
                runat="server" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"
                PageSize="20" Width="900" OnPageChanging="ListPages_PageChanging">
            </webdiyer:AspNetPager>
            <asp:HiddenField ID="hidSupplierID" runat="server" />
        </div>
    </form>
</body>
</html>
