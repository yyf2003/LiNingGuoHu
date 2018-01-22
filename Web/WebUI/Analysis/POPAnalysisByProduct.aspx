﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPAnalysisByProduct.aspx.cs" Inherits="WebUI_Analysis_POPAnalysisByProduct" %>
<%--<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>POP成本--产品大类与系列</title>
        <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
        <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
        <script language="javascript" type="text/javascript" src="../../js/GetAreaBydept.js"></script>
         <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
          <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
         <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
              <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">POP成本--产品大类与产品系列</div>
        <table class="table" style="margin-top: 20px; margin-left: 5%">
            <tr>
                <td style="width: 15%">
                    POP发起ID</td>
                <td style="width: 35%">
                    <asp:DropDownList ID="DDL_POPID" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 15%">
                    &nbsp;年份：</td>
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
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    部门名称：</td>
                <td>
                    <asp:DropDownList ID="DDL_department" runat="server" onchange="GetAreaName(this.value)" CssClass="DDlstyle">
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
                    地级城市名称：</td>
                <td>
                    <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择地级城市名称</asp:ListItem>
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
                    <asp:DropDownList ID="DDL_fx" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    店铺编号：</td>
                <td>
                    <asp:TextBox ID="txt_PosID" runat="server" CssClass="txtwith"  onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",txt_PosID,txt_shopname,"shopdiv")'></asp:TextBox></td>
                <td>
                    店铺名称：</td>
                <td>
                    <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
            </tr>
            <tr>
                <td>
                    &nbsp;供应商：</td>
                <td>
                    <asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    产品大类：</td>
                <td>
                    <asp:DropDownList ID="DDL_ProductType" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择产品大类</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
            <td>&nbsp;产品系列：</td>
            <td><asp:DropDownList ID="DDL_proLine" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择产品系列</asp:ListItem>
                    </asp:DropDownList></td>
            <td></td>
            <td></td>
            </tr>
        </table>
		<div style="margin-top:10px; width:45%; margin-left:5%; text-align:right;">
            <asp:Button ID="Btn_Analysis" runat="server" CssClass="qr0" Text="分 析" OnClick="Btn_Analysis_Click" /></div>
		<br />
    <div style="margin-top:5px; margin-left:5%;">
        <table class="table">
        <tr>
        <td style="font-weight:bold">合计:</td><td>总面积：<%=area %></td><td>材料费用：<%=price %></td><td>总数量:<%=num %></td><td>安装费用：<%=setupprice%></td><td>总费用：<%=price+setupprice %></td>
        </tr>
        </table>
        <asp:GridView CssClass="table" ID="GridView1" runat="server">
        </asp:GridView>
        <asp:GridView CssClass="table"  ID="GridView2" runat="server">
        </asp:GridView>
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
<%--         <div style="width:900px; font-size:14px; color:Olive">总面积：<%=area %>&nbsp; &nbsp; &nbsp; &nbsp; 总价格：<%=price %>&nbsp; &nbsp; &nbsp; &nbsp; 总数量:<%=num %></div>--%>  
     
           
      <table class="table">
        <tr>
        <%--<th style="width:50px">序号</th>--%><th>产品大类</th>  <th>产品系列</th><th style="width:15%">POP面积</th><th style="width:15%">POP材料费用</th><th style="width:15%">涉及POP数量</th><th>安装费用</th><th>总费用</th></tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
       <%-- <td><%#Eval("rowId")%></td>--%><td><%#Eval("ProductTypeName")%></td><td><%#Eval("ProductLine")%></td><td><%#Eval("TotalArea")%></td><td><%#Eval("totalPrice")%></td><td><a href='EveryShopPOPCount.aspx?pro=<%#Eval("CatenaProID").ToString()%>&<%=cxstr %>'><%#Eval("totalnum")%></a></td><td><%#Eval("setupMoney")%></td><td><%#Eval("allprice")%></td></tr>
        </ItemTemplate>
        <FooterTemplate></table>
        </FooterTemplate>
        </asp:Repeater>
        <%-- <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="100" Width="900" OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>--%>
    </div>
    </div>
    </form>
</body>
</html>