<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisList.aspx.cs" Inherits="WebUI_Distribution_DisList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>直属客户列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script language="javascript" type="text/javascript" src="./javascript/SearchDisList.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetCityByProvince.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetProvinceName.js"></script>
    <%--<script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>--%>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
    <script language="javascript" type="text/javascript">
        var pagesize = 20;
        $(function () {
            getListMode(1, pagesize)
        });

        //分页显示材料列表
        function getListMode(pageCurrent, pageSize) {
            var getListPage = new GetDistributorsInfo();
            getListPage.getList(pageCurrent, pageSize);
        }

        function DelMode(FID) {
            var getListPage = new GetDistributorsInfo();
            getListPage.DeleteInfo(FID);
        }
    </script>
    <style type="text/css">
        a
        {
            text-decoration: none;
        }
        .datalist tr.altrow
        {
            background-color: #a5e5aa; /* 隔行变色 */
        }
        td
        {
            background-color: white;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            查看直属客户</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td>
                    部门名称：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" onchange=" GetAreaName(this.value);">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    区域名称：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_Area" onchange="GetprovinceList()" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    所在省份：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_Province" CssClass="txtwith" onchange="GetcityList()" runat="server">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    所在市区：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server" Width="200px">
                        <asp:ListItem Value="0">请选择市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    直属客户编号：
                </td>
                <td style="width: 30%;">
                    <input id="txtFXID" type="text" class="txtwith" />
                </td>
                <td style="width: 15%; text-align: left">
                    直属客户名称：
                </td>
                <td>
                    <input id="txtFXName" type="text" class="txtwith" />
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    所属一级客户编号：
                </td>
                <td style="width: 30%;">
                    <input id="txtdealerID" type="text" class="txtwith" onkeyup='showGs(event,"../GetBaseInfo/Base_DealerInfo.aspx",txtdealerID,txtDealerName,"dealerdiv")' />
                </td>
                <td style="text-align: center">
                    一级客户名称：
                </td>
                <td>
                    <input id="txtDealerName" type="text" class="txtwith" /><br />
                    <div id="dealerdiv" class="ts">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <input id="Btn_search" type="button" class="qr0" value="查 询" onclick="getListMode(1,20)" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="fillTable" style="margin-top: 20px; margin-left: 5%">
    </div>
    <div id="HyperLinkPage" style="margin-top: 20px; text-align: right; padding-left: 10px;
        width: 900px; font-size: 12px; margin-left: 5%">
    </div>
    </form>
</body>
</html>
