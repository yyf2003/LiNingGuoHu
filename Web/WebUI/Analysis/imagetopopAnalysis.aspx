<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imagetopopAnalysis.aspx.cs" Inherits="WebUI_Analysis_imagetopopAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetAreaBydept.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
<script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 90%">
            <div style="padding-left: 20px; font-weight: bold; font-size: 14px; color: #c86000;
                text-align: left">
                店铺季度提交POP数据分析</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width:15%">
                        POP发起ID：</td>
                    <td style="width:35%">
                        <asp:DropDownList ID="DDL_POPID" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style ="width:15%">
                        POP供应商：</td>
                    <td  style="width:35%">
                        <asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td>
                    开始时间：</td><td>
                    <asp:TextBox ID="Txt_begindate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_begindate'))"></asp:TextBox></td><td>
                    结束时间：</td><td>
                    <asp:TextBox ID="Txt_enddate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_enddate'))"></asp:TextBox></td>
                </tr>
          
                <tr>
                    <td>
                    部门名称：</td>
                    <td>
                    <asp:DropDownList ID="DDL_department" runat="server" onchange="GetAreaName(this.value)"  CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                        <asp:ListItem Value="东区">东区</asp:ListItem>
                        <asp:ListItem>南区</asp:ListItem>
                        <asp:ListItem>北区</asp:ListItem>
                    </asp:DropDownList></td>
                    <td>
                        区域名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                            <asp:ListItem Value="-1">全国</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        省/市：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Province" runat="server" CssClass="DDlstyle" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        地级城市名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择地级城市名称</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
      
                <tr>
                <td>
                        一级客户：</td><td>
                        <asp:DropDownList ID="ddl_dealer" runat="server" CssClass="DDlstyle"  onchange="GetFxlist()">
                            <asp:ListItem Value="0">请选择 一级客户</asp:ListItem>
                        </asp:DropDownList></td><td>
                            直属客户：</td><td>
                            <asp:DropDownList ID="DDL_fx" runat="server" CssClass="txtwith">
                                <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                            </asp:DropDownList></td>
                </tr>
               <tr>
                <td>
                        店铺编号：</td><td>
                        <asp:TextBox ID="txt_PosID" runat="server" CssClass="txtwith"   onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",txt_PosID,txt_shopname,"shopdiv")' ></asp:TextBox></td><td>
                        店铺名称：</td><td>
                        <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
                </tr>
            </table>
            <div style="margin-top: 10px; margin-left: 5%; width: 45%; text-align: right">
                <asp:Button ID="Btn_Analysis" runat="server" CssClass="qr0" OnClick="Btn_Analysis_Click"
                    Text="分 析" /></div>
                    <div style="padding-left: 20px; font-weight: bold; font-size: 14px; 
                text-align: center"><%=showpage %></div>
    </div>
    </div>
    </form>
</body>
</html>
