<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShippingAnalysis.aspx.cs"
    Inherits="WebUI_Analysis_ShippingAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供应商发货分析</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
      <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; text-align:center;}
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
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; ">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                供应商发货进度查询</div>
            <table class="table" style="margin-top: 20px; ">
            <tr>
            <td>
                        POP发起ID：
                    </td><td><asp:DropDownList ID="ddl_popid" CssClass="DDlstyle" runat="server">
                        </asp:DropDownList></td>
                <td>
                </td><td></td>
            </tr>
                <tr>
                    <td style="width: 15%;">
                开始时间：</td>
                    <td style="width: 30%;">
                        <asp:TextBox ID="Txt_begindate"  onclick="setday(this,document.getElementById('Txt_begindate'))" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; ">
                        结束时间：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_enddate"  onclick="setday(this,document.getElementById('Txt_enddate'))" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; ">
                        部门名称：</td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="width: 15%; ">
                        区域：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_Area" CssClass="DDlstyle" runat="server" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%; ">
                        省/市：</td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; ">
                        地级市名称：</td>
                    <td style="">
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择地级市名称</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%; ">
                        一级客户：</td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="ddl_dealer" runat="server" CssClass="txtwith" onchange="GetFxlist()">
                        </asp:DropDownList></td>
                    <td style="width: 15%; ">
                        直属客户：</td>
                    <td style="">
                        &nbsp;<asp:DropDownList ID="DDL_fx" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td>
                        店铺编号：</td>
                <td>
                        <asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"  onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",Txt_PosID,Txt_ShopName,"shopdiv")'></asp:TextBox></td>
                <td>
                    店铺名称：</td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
                </tr>
                <tr>
                <td>
                        发货类型：</td><td><asp:DropDownList ID="ddl_shippingtype" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择发货类型</asp:ListItem>
                            <asp:ListItem Value="发货到一级客户">发货到一级客户</asp:ListItem>
                        <asp:ListItem>发货到直属客户</asp:ListItem>
                            <asp:ListItem Value="发货到店">发货到店</asp:ListItem>
                            <asp:ListItem Value="安装到店">安装到店</asp:ListItem>
                        </asp:DropDownList></td><td>
                        POP供应商：</td><td><asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" /></td>
                </tr>
            </table>
           <br />
           <br />
           <table class="table">
           <tr>
           <td>应发货:<%=AllNum %> </td><td>实际发货：<a href="daochu.aspx?dtname=FHOK" ><%=fhOKCount %></a></td><td>未发货：<a href="daochu.aspx?dtname=FHNO" ><%=fhNoCount %></a> </td> <td>发货进度：<%=(bili * 100).ToString("#0.00")%>% </td> 
           </tr>
           
           </table>
        </div>
        <asp:HiddenField ID="hidSupplierID" Value="0" runat="server" />
    </form>
</body>
</html>
