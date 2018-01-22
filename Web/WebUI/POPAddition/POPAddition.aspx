<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPAddition.aspx.cs" Inherits="WebUI_POPAddition_POPAddition" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>POP增补</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

<%--    <script language="javascript" type="text/javascript" src="JavaScript/GetShopInfoList.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

    <script src="../../js/GetFxname.js" language="javascript" type="text/javascript"></script>--%>

    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>

    <script language="javascript" type="text/javascript">
//	function GetcityList()
//	{
//		var pro=$("#DDL_Province").val();
//		GetCityname(pro);
//	}
	
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
                POP破损补单</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%; text-align: left">
                        店铺编号：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; text-align: left">
                        店铺名称：</td>
                    <td style="width: 35%; text-align: left">
                        &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <%--<tr style="display:none">
                    <td style="width: 15%; text-align: left">
                        省：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: left">
                        市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>--%>
                <tr <%=dealerdispaly %>>
                    <td style="width: 15%; text-align: left">
                        一级客户：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server" >
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
               <%-- <tr style="display:none">
                    <td style="width: 15%; text-align: left">
                        安装支持：
                    </td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_install" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="-1">请选择供应商是否支持安装</asp:ListItem>
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
                </tr>--%>
               <%-- <tr  style="display:none">
                    <td style="width: 15%; text-align: left">
                        零售分类：
                    </td>
                    <td style="width: 30%;">
                        &nbsp;
                        <asp:DropDownList ID="SaleTypeID" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择零售分类</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="2" align="left">
                        &nbsp;
                    </td>
                </tr>--%>
                <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Btn_search" runat="server" CssClass="qr0" OnClick="Btn_search_Click"
                        Text="查 询" /></td>
                </tr>
            </table>
        </div>
        <br />
        <div id="fillTable" style="margin-top: 20px; margin-left: 5%">
            <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            <table class="table">
            <tr>
            <th>POSCode</th><th>店铺名称</th><th>POP数量</th><th>POP面积</th><th>查看POP</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
            <td><%#Eval("Posid") %></td><td><%#Eval("shopname") %></td><td><%#Eval("popcount") %></td><td><%#Eval("totalarea") %></td><td><a href='ShowOneShopPOP.aspx?shopid=<%#Eval("shopid") %>'>查看POP</a></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
             <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="100" Width="900px" OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>
        </div>
     
    </form>
</body>
</html>
