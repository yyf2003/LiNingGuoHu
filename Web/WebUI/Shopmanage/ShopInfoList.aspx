<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopInfoList.aspx.cs" Inherits="WebUI_Shopmanage_ShopInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>店铺列表</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetTownByCity.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/getshop_pop_info.js"></script>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
    <script language="javascript" type="text/javascript">
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        }

        function GetTownList() {
            var cityid = $("#DDL_city").val();
            GetTownname(cityid);
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
            店铺筛选</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺编号：
                </td>
                <td style="width: 30%;">
                    <asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith" onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",Txt_PosID,Txt_ShopName,"shopdiv")'></asp:TextBox>
                </td>
                <td style="width: 15%; text-align: left">
                    店铺简称：
                </td>
                <td>
                    <asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox><br />
                    <div id="shopdiv" class="ts">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_DepartMent" CssClass="txtwith" runat="server" onchange="GetAreaName(this.value)">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    区域名称：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Area" CssClass="txtwith" runat="server" onchange="GetprovinceList()">
                        <asp:ListItem Value="0">请选择区域名称</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    省：
                </td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    地级城市：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server" onchange="GetTownList()">
                        <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    区县级城市名称：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_town" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择区县级城市名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    地市级城市级别：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Citylevel" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择地市级城市级别</asp:ListItem>
                        <asp:ListItem>超大</asp:ListItem>
                        <asp:ListItem>一线</asp:ListItem>
                        <asp:ListItem>二线</asp:ListItem>
                        <asp:ListItem>三线</asp:ListItem>
                        <asp:ListItem>三线一下</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    区县级城市级别：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_TownLevel" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择区县级城市级别</asp:ListItem>
                        <asp:ListItem>超大</asp:ListItem>
                        <asp:ListItem>一线</asp:ListItem>
                        <asp:ListItem>二线</asp:ListItem>
                        <asp:ListItem>三线</asp:ListItem>
                        <asp:ListItem>三线一下</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    客户身份：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_CoustomerCard" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择客户身份</asp:ListItem>
                        <asp:ListItem>子公司</asp:ListItem>
                        <asp:ListItem>经销商</asp:ListItem>
                        <asp:ListItem>分销商</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    上级客户编号：
                </td>
                <td>
                    <asp:TextBox ID="txt_CusID" runat="server" CssClass="txtwith" onkeyup='showGs(event,"../GetBaseInfo/Base_CustomerInfo.aspx",txt_CusID,txt_CusName,"Cusdiv")'></asp:TextBox>
                </td>
                <td>
                    上级客户级别：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txt_CusName" CssClass="txtwith"></asp:TextBox><br />
                    <div id="Cusdiv" class="ts">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    店铺产权关系：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_CustomerShip" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺产权关系</asp:ListItem>
                        <asp:ListItem>直营店</asp:ListItem>
                        <asp:ListItem>分销店</asp:ListItem>
                        <asp:ListItem>经销店</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    店铺级别：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_ShopLevel" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺级别</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    一级客户：
                </td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="ddl_dealer" onchange="GetFxlist()" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    直属客户：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_fx" runat="server" CssClass="txtwith">
                        <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺类型：
                </td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="DDL_Shoptype" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    零售属性：
                </td>
                <td>
                    <asp:DropDownList ID="SaleTypeID" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择零售分类</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    店铺状态：
                </td>
                <td style="width: 30%;">
                    <asp:DropDownList ID="DDL_shopstate" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="-1">请选择店铺状态</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%">
                    营业面积：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_shopArea" runat="server" CssClass="txtwith"></asp:TextBox>㎡
                </td>
            </tr>
            <tr>
                <td>
                    POP类型：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_Popseat" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择POP类型</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    故事包大类：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_ProductType" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择故事包大类</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    POP故事包：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_POPline" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择POP故事包</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    POP面积：
                </td>
                <td>
                    <asp:TextBox ID="txt_POParea" runat="server" CssClass="txtwith"></asp:TextBox>㎡
                </td>
            </tr>
            <tr>
                <td>
                    橱窗空间进深mm：
                </td>
                <td>
                    <asp:TextBox ID="txt_PfJS" runat="server" CssClass="txtwith"></asp:TextBox>mm
                </td>
                <td>
                    橱窗空间长度mm：
                </td>
                <td>
                    <asp:TextBox ID="txt_Pfcd" runat="server" CssClass="txtwith"></asp:TextBox>mm
                </td>
            </tr>
            <tr>
                <td>
                    橱窗空间面积：
                </td>
                <td>
                    <asp:TextBox ID="txt_Pfmj" runat="server" CssClass="txtwith"></asp:TextBox>㎡
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <input id="Button2" type="button" class="qr0" style="width: 80px" value="导出店铺信息"
                        onclick="gotoShophref()" />&nbsp;&nbsp;&nbsp;
                    <input id="Button1" type="button" class="qr0" style="width: 120px" value="导出店铺及POP信息"
                        onclick="gotohref()" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HidSupplierID" runat="server" Value="0" />
    <br />
    <div id="fillTable" style="margin-top: 20px; margin-left: 5%">
    </div>
    <div id="HyperLinkPage" style="margin-top: 20px; text-align: center; padding-left: 10px;
        width: 900px; font-size: 14px; margin-left: 5%">
    </div>
    </form>
</body>
</html>
