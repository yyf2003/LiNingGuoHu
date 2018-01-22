<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="WebUI_SetUpConfirm_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>安装进度查询列表</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <style type="text/css">
 *body{ font-size:12px;} 

 </style>

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"> </script>

    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
          <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
         <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
     <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
    <script  type="text/javascript">
       	function GetcityList()
		{
			var pro=$("#DDL_Province").val();
			GetCityname(pro);
		}
    </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                店铺安装进度查询</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        POP时间段：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:DropDownList ID="DDL_POPID" runat="server" CssClass="DDlstyle">
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                    </td>
                    <td style="width: 35%">
                        &nbsp;</td>
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
                        <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
                    <td>
                        区域名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
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
                        &nbsp;地级城市：</td>
                    <td>
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        一级客户：</td>
                    <td>
                        <asp:DropDownList ID="ddl_dealer" runat="server" CssClass="DDlstyle" onchange="GetFxlist()">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        直属客户：</td>
                    <td>
                        <asp:DropDownList ID="DDL_fx" runat="server">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
          

                <tr>
                <td>供应商：</td><td><asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList></td><td>
                            是否为供应商支持安装：</td><td>
                                <asp:DropDownList ID="DDL_install" runat="server">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList></td>
                </tr>
            </table>
            <br />
            <div style="width:900px; text-align:center; margin-left: 5%">  <asp:Button ID="Button1" runat="server" Text="查询" CssClass="qr0" OnClick="Button1_Click" /></div>

                <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                   <table class="table" style=" margin-left: 5%">
                <tr>
                <th>供应商</th><th>店铺数量</th><th>已安装</th><th>未安装</th><th>安装百分比</th>
                </tr>
                </HeaderTemplate>
                <ItemTemplate>
                <tr>
                <td><%#Eval("suppliername") %></td><td><%#Eval("totalsetup")%></td><td><a href='stuplist.aspx?flag=1&sid=<%#Eval("supplierid") %><%=pageUrl %>'><%#Eval("setupcount") %></a></td><td><a href='stuplist.aspx?flag=0&sid=<%#Eval("supplierid") %><%=pageUrl %>'><%#Eval("nosetupcount") %></a></td><td><%#Eval("bfb")%>%</td>
                </tr>
                </ItemTemplate>
                <FooterTemplate>
                <tr>
                <td>总 计</td> <td><%=totalcount %></td> <td><%=setupcount %></td> <td><%=unsetupcount %></td> <td><%= bfb.ToString("#0.000") %>%</td>
                </tr>
                </table>
                </FooterTemplate>
                </asp:Repeater>
            
        </div>
        <asp:HiddenField ID="hiddenPOPID" runat="server" />
    </form>
</body>
</html>
