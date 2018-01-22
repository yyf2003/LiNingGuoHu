<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewAddPOPAnalysis.aspx.cs" Inherits="WebUI_Analysis_NewAddPOPAnalysis" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>季度新增POP数据分析</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
     <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetAreaBydept.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
     <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
     <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
     <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width: 90%">
            <div style="padding-left: 20px; font-weight: bold; font-size: 14px; color: #c86000;
                text-align: left">
                季度新增POP数据分析</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        POP发起ID：</td>
                    <td style="width: 35%">
                        <asp:DropDownList ID="DDL_POPID" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择POP发起的ID</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        开始时间：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:TextBox ID="Txt_begindate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_begindate'))"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        结束时间：</td>
                    <td>
                        <asp:TextBox ID="Txt_enddate" runat="server" CssClass="txtwith" onclick="setday(this,document.getElementById('Txt_enddate'))"></asp:TextBox></td>
                    <td>
                        部门名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_department" runat="server" onchange="GetAreaName(this.value)"  CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        区域名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                            <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        省/市：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Province" runat="server" CssClass="DDlstyle" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        地级城市名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择地级城市名称</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        一级客户：</td>
                    <td>
                        <asp:DropDownList ID="ddl_dealer" runat="server" CssClass="DDlstyle" onchange="GetFxlist()">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        直属客户：</td>
                    <td>
                        <asp:DropDownList ID="DDL_fx" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
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
                        <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith" ></asp:TextBox><br /><div id="shopdiv" class="ts"></div></td>
                    <td>
                        供应商名称：</td>
                    <td>
                        <asp:DropDownList ID="DDL_Supplier" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        产品大类：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_proType" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择大类</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        产品系列：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_proLine" runat="server" CssClass="DDlstyle">
                            <asp:ListItem Value="0">请选择产品系列</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr style="display: none">
                    <td>
                        年份：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_year" runat="server">
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
            <div style="padding-left: 5%;">
            
             <div style="font-size:14px; color:Navy">
             <a href="daochu.aspx?dtname=NewAddlist">导出数据</a> 
             <table class="table"><tr><td>共涉及到店铺数量：<%=shopcount %> </td><td>新增POP数量：<%=popcount %></td><td>新增POP总面积：<%=areasum %></td><td>总金额：<%=totalMoney %></td></tr></table></div>
             <br />
             <div  style="font-size:14px; color:red">根据产品大类与产品系列统计数据</div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <tr>
                            <th>
                                产品大类</th>
                            <th>
                                产品系列</th>
                            <th>
                                新增数量</th>
                            <th>
                                新增面积</th>
                                <th>总金额</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("产品大类")%>
                        </td>
                        <td >
                            <%#Eval("产品系列")%>
                        </td>
                        <td>
                            <%#Eval("数量")%>
                        </td>
                        <td >
                            <%#Eval("总面积") %>
                        </td>
                       <td> <%#Eval("总金额") %>
                       </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <div  style="font-size:14px; color:red">根据POP制作材料统计数据</div>

                <asp:Repeater ID="Repeater2" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <tr>
                                <th>
                                    材料名称</th>
                                
                                <th>
                                    新增数量</th>
                                <th>
                                    新增面积</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("材料名称")%>
                            </td>
                            
                            <td>
                                <%#Eval("数量")%>
                            </td>
                            <td >
                                <%#Eval("总面积") %>
                            </td>
                  
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                       <br />
            <div  style="font-size:14px; color:red">根据店铺统计数据</div>

            <asp:Repeater ID="RepShopList" runat="server">
            <HeaderTemplate>
            <table class="table">
            <tr>
              <th>店铺编号</th><th>店铺名称</th><th>新增数量</th><th>新增面积</th>
            </tr>
           
            </HeaderTemplate>
            <ItemTemplate>
            <tr>
           <td><%#Eval("店铺编号") %></td><td ><%#Eval("店铺名称") %></td><td><%#Eval("数量")%></td><td ><%#Eval("总面积") %></td>
            </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
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
