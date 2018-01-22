<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DelShopPOP.aspx.cs" Inherits="WebUI_Shopmanage_DelShopPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>初始化店铺POP提交</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/GetShopInfoList_Del.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
    <script language="javascript" type="text/javascript">
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        }

        $(function () {
            $("table.datalist tr:nth-child(odd)").addClass("altrow");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 90%; position: relative;">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            初始化店铺POP提交</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td>
                    部门名称：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_department" runat="server" onchange="GetAreaName(this.value)"
                        CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    区域名称：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    省/市：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    地级城市：
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    一级客户：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="ddl_dealer" onchange="GetFxlist()" CssClass="txtwith"
                        runat="server">
                        <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    直属客户：
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="DDL_fx" runat="server">
                        <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺类型：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_Shoptype" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    零售分类：
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="SaleTypeID" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择零售分类</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺编号：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith" onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",Txt_PosID,Txt_ShopName,"shopdiv")'></asp:TextBox>
                </td>
                <td style="width: 15%; text-align: left">
                    店铺名称：
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox><div
                        id="shopdiv" class="ts">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺状态：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_shopstate" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="-1">请选择店铺状态</asp:ListItem>
                        <asp:ListItem Value="1">新开</asp:ListItem>
                        <asp:ListItem Value="2">整改</asp:ListItem>
                        <asp:ListItem Value="3">维持</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%">
                    &nbsp;是否公司支持安装：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_install" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="-1">请选择公司是否支持安装</asp:ListItem>
                        <asp:ListItem Value="1">支持</asp:ListItem>
                        <asp:ListItem Value="0">不支持</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <input id="Btn_search" type="button" class="qr0" value="查 询" onclick="Getshopinfolist(1,20)" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="fillTable" style="margin-top: 20px; margin-left: 5%">
    </div>
    <div id="HyperLinkPage" style="margin-top: 20px; text-align: center; padding-left: 10px;
        width: 900px; font-size: 14px; margin-left: 5%">
    </div>
    </form>
</body>
</html>
