<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendRecShopList.aspx.cs" Inherits="WebUI_Analysis_SendRecShopList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供应商收发货差异数据</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
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
<body style="font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto;">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                供应商发货收货差异</div>
            <table class="table" style="margin-top: 20px; float: left; margin-left: 20px; width: 100%">
              <tr>
                    <td style="width: 15%;  ">
                        POP发起ID：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_popid" CssClass="txtwith" runat="server">
                        </asp:DropDownList></td>
                    <td style="width: 15%;  ">
                        </td>
                    <td style="">
                        &nbsp;
                    </td>
                </tr>
               <tr>
                <td>
                    开始时间：</td><td>
                    <asp:TextBox ID="Txt_begindate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_begindate'))"></asp:TextBox></td><td>
                    结束时间：</td><td>
                    <asp:TextBox ID="Txt_enddate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_enddate'))"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;  ">
                        部门名称：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
                    <td style="width: 15%;  ">
                        区域名称：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%;  ">
                        省/市：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%;  ">
                        所在地级城市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td>
                        一级客户：</td><td><asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server"  onchange="GetFxlist()">
                        <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList></td><td>
                            直属客户：</td><td>
                            <asp:DropDownList ID="DDL_fx" runat="server" CssClass="DDlstyle">
                                <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%;  ">
                        发货类型：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_shippingtype" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择发货类型</asp:ListItem>
                            <asp:ListItem Value="发货到一级客户">发货到一级客户</asp:ListItem>
                            <asp:ListItem Value="发货到直属客户">发货到直属客户</asp:ListItem>
                            <asp:ListItem Value="发货到店">发货到店</asp:ListItem>
                            <asp:ListItem Value="安装到店">安装到店</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%;  ">
                        &nbsp;供应商：</td>
                    <td style="">
                        &nbsp;
                        <asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
       
    
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" /></td>
                </tr>
            </table>
            <br /><br /><br />
    <div style="font-size: 14px; font-weight: bold; text-align: center; padding-left: 20px;
               ">供应商已发货但店铺仍未确认收货的店铺数量为：<a href='daochu.aspx?dtname=sendRec'><%=NorecCount %></a>家</div>
    </div>
    </form>
</body>
</html>
