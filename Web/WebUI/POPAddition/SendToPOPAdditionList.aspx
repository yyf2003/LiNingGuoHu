<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendToPOPAdditionList.aspx.cs"
    Inherits="WebUI_POPAddition_SendToPOPAdditionList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>发货-POP增补</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="JavaScript/GetShopInfoList.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

    <script src="../../js/GetFxname.js" language="javascript" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>

    <script language="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
	
	$(function(){
		$("table.datalist tr:nth-child(odd)").addClass("altrow");
	});
    </script>

    <style type="text/css">
	.datalist tr.altrow{background-color:#a5e5aa;	/* 隔行变色 */}
	td{background-color:white;}
</style>
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                POP增补</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%; text-align: left">
                        店铺编号：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; text-align: left">
                        店铺名称：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        省名称：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: left">
                        地级城市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        一级客户：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server" onchange="GetFxlist();">
                            <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: left">
                        直属客户：
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_fx" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        是否李宁公司统一支持安装：
                    </td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_install" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="-1">请选择是否李宁公司统一支持安装</asp:ListItem>
                            <asp:ListItem Value="1">支持</asp:ListItem>
                            <asp:ListItem Value="0">不支持</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 15%; text-align: left">
                        店铺类型：
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_Shoptype" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        零售属性：
                    </td>
                    <td style="width: 30%;">
                        &nbsp;
                        <asp:DropDownList ID="SaleTypeID" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择零售属性</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 15%; text-align: left">
                        审批状态：
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_examstate" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="1">已审批</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        供应商：
                    </td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺的供应商</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="center" colspan="2">
                        &nbsp;<input id="Btn_search" type="button" class="qr0" value="查 询" onserverclick="Btn_search_ServerClick"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="margin-top: 20px; margin-left: 5%; font-size: 12px;" class="table">
            <asp:GridView ID="gv_popaddition" runat="server" AutoGenerateColumns="false" Font-Size="12px"
                Width="100%">
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="NO" />
                    <asp:BoundField DataField="PosID" HeaderText="店铺编号" />
                    <asp:BoundField DataField="Shopname" HeaderText="店铺名称" />
                    <asp:TemplateField HeaderText="店铺一级客户">
                        <ItemTemplate>
                            <%#GetDealerName(Eval("DealerID").ToString ())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺城市">
                        <ItemTemplate>
                            <%#GetProviceName(Eval("ProvinceID").ToString ())%>
                            <%#GetCityName(Eval("CityID").ToString ())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发货" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <a href='SendToPOPAddition.aspx?id=<%#Eval("Shopid") %>&Addid=<%#Eval("Addid") %>&sid=<%#Eval("SupplierID") %>'>
                                发货</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="HyperLinkPage" style="margin-top: 20px; text-align: center; padding-left: 10px;
            width: 900px; font-size: 14px; margin-left: 5%">
        </div>
    </form>
</body>
</html>
