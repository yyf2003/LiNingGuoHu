<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchAddPOP.aspx.cs" Inherits="WebUI_POPAddition_SearchAddPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/calendar.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetFxname.js"></script>
    <script language="javascript" type="text/javascript">
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        }
    </script>
</head>
<body style="font-size: 12px; background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
    <div style="width: 97%; padding-left: 20px">
        <div style="font-size: 14px; font-weight: bold; text-align: left; color: #c86000;">
            原损加单审批结果查询</div>
        <table class="table" style="margin-top: 20px;">
            <tr>
                <td style="width: 15%;">
                    店铺编号：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td style="width: 15%;">
                    区域：
                </td>
                <td>
                    &nbsp;
                    <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr <%=dealerdispaly %>>
                <td style="width: 15%; text-align: left">
                    省名称：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    地级城市：
                </td>
                <td>
                    &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr <%=dealerdispaly %>>
                <td style="width: 15%; text-align: left">
                    一级客户：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="ddl_dealer" onchange="GetFxlist()" CssClass="txtwith"
                        runat="server">
                        <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%">
                    供应商：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择店铺的供应商</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr <%=dealerdispaly %>>
                <td style="width: 15%; text-align: left">
                    直属客户：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_fx" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择直属客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    发起POP的ID：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="ddl_poplaunch" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择发起POP的ID</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 15%; text-align: left">
                    审核状态：
                </td>
                <td style="width: 30%;">
                    &nbsp;<asp:DropDownList ID="DDL_examstate" CssClass="txtwith" Enabled="false" runat="server">
                        <asp:ListItem Value="-1">请选择审核状态</asp:ListItem>
                        <asp:ListItem Value="1">通过</asp:ListItem>
                        <asp:ListItem Value="0">未通过</asp:ListItem>
                        <asp:ListItem Value="-2">未审核</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 15%; text-align: left">
                    加单时间：
                </td>
                <td style="width: 30%;">
                    <asp:TextBox runat="server" ID="txtBeginDate" onclick="setday(this,document.getElementById(this.id))"
                        Width="80px"></asp:TextBox>&nbsp;&nbsp;至&nbsp;&nbsp;
                    <asp:TextBox runat="server" ID="txtEndDate" onclick="setday(this,document.getElementById(this.id))"
                        Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    &nbsp;<input id="Btn_search" type="button" class="qr0" value="查 询" onserverclick="Btn_search_ServerClick"
                        runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <div style="margin-top: 20px; font-size: 12px;">
            <table class="table" style="margin-top: 3px; font-weight: bold;">
                <tr>
                    <td align="left">
                        增补数量：&nbsp;&nbsp;&nbsp;&nbsp;<a href="../Analysis/daochu.aspx?dtname=addPOPps"><%=POPAddtionCount%></a>
                        &nbsp;&nbsp;&nbsp;&nbsp; 张
                    </td>
                    <td align="left">
                        增补面积：<%=POPAddtitionArea %>
                    </td>
                    <td align="left">
                    </td>
                </tr>
            </table>
            <table class="table" style="width: 100%">
                <caption style="font-weight: bold; font-size: 12px">
                </caption>
                <tr>
                    <th>
                        店铺名称
                    </th>
                    <th style="width: 8%">
                        位置
                    </th>
                    <th>
                        POP编号
                    </th>
                    <th style="width: 7%">
                        高度
                    </th>
                    <th style="width: 5%">
                        宽度
                    </th>
                    <th style="width: 5%">
                        面积
                    </th>
                    <th>
                        图片
                    </th>
                    <th style="width: 20%">
                        备注
                    </th>
                    <th style="width: 7%">
                        状态
                    </th>
                    <th style="width: 20%">
                        审核结果
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="gv_popaddition">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("shopname")%>
                            </td>
                            <td align="left">
                                <%# Eval("POPseat")%>
                            </td>
                            <td align="left">
                                <%# Eval("seatnum")%>
                            </td>
                            <td align="left">
                                <%# Eval("POPHeight")%>
                            </td>
                            <td align="left">
                                <%# Eval("POPWith")%>
                            </td>
                            <td align="left">
                                <%# Eval("POPArea")%>
                            </td>
                            <td align="left">
                                <img src='../../<%# Eval("PhotoUrl")%>' height="28px" width="45px" style="cursor: pointer;"
                                    alt='<%#Eval("Des") %>' onclick="javascript:ShowDIV('30%','30%','700px','50px','500px',this.alt,this.src)" />
                            </td>
                            <td>
                                <%# Eval("Des")%>
                            </td>
                            <td align="left">
                                <%#Eval("ExamState").ToString() == "0" ? "未审核" :Eval ("ExamState").ToString ()=="1"? "<font color=red>通过</font>":"<font color=red>未通过</font>"%>
                            </td>
                            <td>
                                <%#Eval("UnDes").ToString() == "" ? "无" : Eval("UnDes").ToString ()%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div id="HyperLinkPage" style="margin-top: 20px; text-align: center; padding-left: 10px;
            width: 900px; font-size: 14px; margin-left: 5%">
        </div>
    </div>
    </form>
</body>
</html>
