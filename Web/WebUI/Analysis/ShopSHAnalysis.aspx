<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopSHAnalysis.aspx.cs" Inherits="WebUI_Analysis_ShopSHAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺收货进度查询</title>
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
<body style=" font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                店铺收货进度查询</div>
            <table class="table" style="margin-top: 20px; text-align:left">
                <tr>
                    <td>
                        POP发起ID：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_popid" runat="server" CssClass="DDlstyle">
                        </asp:DropDownList></td>
                    <td>
                        开始时间：</td>
                    <td>
                        <asp:TextBox ID="Txt_begindate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_begindate'))"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        结束时间：</td>
                    <td style="width: 30%">
                        <asp:TextBox ID="Txt_enddate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_enddate'))"></asp:TextBox></td>
                    <td style="width: 15%">
                        部门名称：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        区域名称：</td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        省/市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_Province" runat="server" CssClass="txtwith" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        地级市名称：</td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择地级市名称</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        一级客户：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="ddl_dealer" runat="server" CssClass="txtwith" onchange="GetFxlist()">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        直属客户：</td>
                    <td style="width: 30%">
                        <asp:DropDownList ID="DDL_fx" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        店铺编号：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith" onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",Txt_PosID,Txt_ShopName,"shopdiv")'></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        店铺名称：</td>
                    <td>
                        <asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
                    <td>
                        发货类型：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="ddl_shippingtype" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择发货类型</asp:ListItem>
                            <asp:ListItem Value="发货到一级客户">发货到一级客户</asp:ListItem>
                            <asp:ListItem>发货到直属客户</asp:ListItem>
                            <asp:ListItem Value="发货到店">发货到店</asp:ListItem>
                            <asp:ListItem Value="安装到店">安装到店</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        POP供应商：</td>
                    <td>
                        <asp:DropDownList ID="ddl_supplier" runat="server" CssClass="txtwith">
                        </asp:DropDownList></td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSearch" runat="server" CssClass="qr0" OnClick="btnSearch_Click"
                            Text="查  询" /></td>
                </tr>
            </table>
           <br />
           <br />
           <table class="table">
           <tr>
           <td>共发货:<%=AllNum %> </td><td>实际收货：<a href="daochu.aspx?dtname=SHOK" ><%=fhOKCount %></a></td><td>未收货：<a href="daochu.aspx?dtname=SHNO" ><%=fhNoCount %></a> </td> <td>收货进度：<%=(bili * 100).ToString("#0.00")%>% </td> 
           </tr>
           
           </table>
        </div>
        <asp:HiddenField ID="hidSupplierID" Value="0" runat="server" />
    </form>
</body>
</html>
