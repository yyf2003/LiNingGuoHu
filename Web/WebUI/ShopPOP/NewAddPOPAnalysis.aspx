<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewAddPOPAnalysis.aspx.cs"
    Inherits="WebUI_Analysis_NewAddPOPAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 90%">
            <div style="padding-left: 20px; font-weight: bold; font-size: 14px; color: #c86000;
                text-align: left">
                店铺新增POP数据分析</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        年份：
                    </td>
                    <td style="width: 35%">
                        <asp:DropDownList ID="DDL_year" runat="server">
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 15%">
                        供应商：
                    </td>
                    <td style="width: 35%">
                        &nbsp;<asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        一级客户：
                    </td>
                    <td>
                        <asp:DropDownList ID="DDL_Dealer" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        店铺编号：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        店铺名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td>
                        区域：
                    </td>
                    <td>
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="-1">全国</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfAreas" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        省：
                    </td>
                    <td>
                        <asp:DropDownList ID="DDL_Province" runat="server" CssClass="DDlstyle" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        地级城市：
                    </td>
                    <td>
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        产品大类：
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_ProductType" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择产品大类</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;产品系列：
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_proLine" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择产品系列</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 10px; margin-left: 5%; width: 45%; text-align: right">
                <asp:Button ID="Btn_Analysis" runat="server" CssClass="qr0" OnClick="Btn_Analysis_Click"
                    Text="分 析" /></div>
            <div style="padding-left: 5%;">
                <div style="font-size: 14px; color: Navy">
                    <a href="daochu.aspx?dtname=NewAddlist">导出数据</a>
                    <table class="table">
                        <tr>
                            <td>
                                共涉及到店铺数量：<%=shopcount %>
                            </td>
                            <td>
                                新增POP数量：<%=popcount %>
                            </td>
                            <td>
                                新增POP总面积：<%=areasum %>
                            </td>
                            <td>
                                总金额：<%=totalMoney %>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </div>
            <br />
            <div style="margin-top: 5px; margin-left: 5%">
                &nbsp;
            </div>
        </div>
    </div>
    </form>
</body>
</html>
