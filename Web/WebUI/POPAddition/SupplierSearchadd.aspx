<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierSearchadd.aspx.cs" Inherits="WebUI_POPAddition_SupplierSearchadd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>审核-POP增补</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="JavaScript/GetShopInfoList.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>
    <script language="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
	
	$(function(){
		$("table.datalist tr:nth-child(odd)").addClass("altrow");
	});
    </script>
 
    <style type="text/css">
	.datalist tr.altrow{background-color:#a5e5aa;	/* 隔行变色 */}
	td{background-color:white;}
</style>
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                POP增补查询</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%; text-align: left">
                        店铺编号：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; text-align: left">
                        店铺名称：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        省：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: left">
                        地级城市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        一级客户：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺的一级客户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%">
                        供应商：</td>
                    <td>
                        <asp:DropDownList ID="ddl_supplier" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择店铺的供应商</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: left">
                        POP主题 ：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:DropDownList ID="ddl_poplaunch" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择发起POP的ID</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: left">
                    </td>
                    <td style="width: 30%;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        &nbsp;<input id="Btn_search" type="button" class="qr0" value="查 询" onserverclick="Btn_search_ServerClick"
                            runat="server" /></td>
                </tr>
            </table>
        </div>
        <br />
        <div style="margin-top: 20px; margin-left: 5%; font-size: 12px;">
           <table class="table" style="margin-top: 3px; font-weight: bold;">
                <tr>
                    <td align="left" style="color:Red">
                        增补数量<%=POPAddtionCount %>个，增补面积<%=POPAddtitionArea %>
                    </td>
                </tr>
            </table>
            <table class="table" style="width:100%">
                <caption style="font-weight: bold; font-size:12px">
                    </caption>
                <tr><th>店铺名称</th><th style="width:8%">位置</th><th>POP编号</th><th style="width:7%">高度</th><th style="width:5%">宽度</th><th style="width:5%">面积</th><th>图片</th><th style="width:20%">备注</th><th style="width:7%">状态</th><th style="width:20%">审核结果</th></tr>
                <asp:Repeater runat="server" ID="gv_popaddition">
                    <ItemTemplate>
                        <tr>
                           <td><a href='#' onclick= 'javascript:ShowDIV("30%","30%","900px","50px","500px","[店铺详情]","../ShopPOP/ShopPOPList.aspx?shopid=<%#Eval("shopid")%>")'><%# Eval("shopname")%></a></td>
                            <td align ="left" >
                                <%# Eval("POPseat")%>
                            </td>
                            <td align ="left" >
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
                                <font color="red">已审核通过</font>
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
    </form>
</body>
</html>
