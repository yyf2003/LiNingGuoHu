<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPOPAnalysis.aspx.cs" Inherits="WebUI_Analysis_AddPOPAnalysis" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
     <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
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
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 90%">
            <div style="padding-left: 20px; font-weight: bold; font-size: 14px; color: #c86000;
                text-align: left">
                POP原损补单分析</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        POP发起ID</td>
                    <td style="width: 35%">
                        <asp:DropDownList ID="DDL_POPID" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择POP发起的ID</asp:ListItem>
                           
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        年份：</td>
                    <td style="width: 35%"> <asp:DropDownList ID="DDL_year" runat="server">
                       
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
                </tr>
                <tr>
                    <td>
                        一级客户：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Dealer" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        店铺编号：</td>
                    <td>
                        <asp:TextBox ID="txt_PosID" runat="server" CssClass="txtwith"   onkeyup='showGs(event,"../GetBaseInfo/Base_shopInfo.aspx",txt_PosID,txt_shopname,"shopdiv")' ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        店铺名称：</td>
                    <td>
                        <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
                    <td>
                        区域：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                            <asp:ListItem Value="-1">全国</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        省名称：</td>
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
                        收发货：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_send" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="-1">请选择</asp:ListItem>
                            <asp:ListItem Value="2">已收货</asp:ListItem>
                            <asp:ListItem Value="1">已发货</asp:ListItem>
                            <asp:ListItem Value="0">未发</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        供应商：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="display:none">
                    <td>
                        </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        是否通过：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_OK" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="1">已通过</asp:ListItem>
                            <asp:ListItem Value="-1">请选择</asp:ListItem>
                            <asp:ListItem Value="0">未审批</asp:ListItem>
                            <asp:ListItem Value="2">未通过</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
            <div style="margin-top: 10px; margin-left: 5%; width: 45%; text-align: right">
                <asp:Button ID="Btn_Analysis" runat="server" CssClass="qr0" OnClick="Btn_Analysis_Click"
                    Text="分 析" /></div>
            <div style="padding-left: 5%;"><br />
            <div style="font-size:14px; color:Navy">增补共涉及店铺<%=shopcount %>家 ,共<%=popcount %>张POP, POP总面积<%=areasum %>,成本共<%=pricesum %></div>
            <asp:Repeater ID="RepShopList" runat="server">
            <HeaderTemplate>
            <table class="table">
            <tr>
            <th>序号</th><th>编号</th><th>店铺名称</th><th>省市</th><th>供应商</th><th>增补数量</th><th>增补面积</th><th>成本</th>
            </tr>
           
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
            <td ><%#Eval("rowId") %></td><td><%#Eval("Posid") %></td><td ><%#Eval("Shopname") %></td><td ><%#Eval("provincename") %>,<%#Eval("cityname") %></td><td ><%#Eval("Suppliername")%></td><td ><a href='AddEveryShopPOP.aspx?shopid=<%#Eval("shopid") %>&POPID=<%=POPID %>'><%#Eval("POPCount")%></a></td><td ><%#Eval("Totalarea") %></td><td ><%#Eval("totalPrice") %></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
            </div>
            <br />
            <div style="margin-top: 5px; margin-left: 5%">
                &nbsp;<webdiyer:aspnetpager id="ListPages" runat="server" cssclass="paginator" currentpagebuttonclass="cpb"
                    firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" onpagechanging="ListPages_PageChanging"
                    pagesize="20" prevpagetext="上一页" width="900"></webdiyer:aspnetpager>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
