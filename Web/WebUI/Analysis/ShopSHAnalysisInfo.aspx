<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopSHAnalysisInfo.aspx.cs" Inherits="WebUI_Analysis_ShopSHAnalysisInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收货分析</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>
</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div>
            <table class="table">
                <tr>
                    <td style="width: 15%">
                        店铺编号：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:TextBox ID="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        零售分类：</td>
                    <td style="width: 35%">
                        &nbsp;<asp:TextBox ID="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">
                        店铺名称：</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺地址</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Address" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        店铺类型：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_shoplevel" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        开店时间：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopOpenDate" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        省：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        地级市：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        区级市：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        店铺状态：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopState" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        联系人：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_LineMan" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        联系电话：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        负责人：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        负责人电话：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        Email：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        传真号码：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        邮政编码：</td>
                    <td>
                        &nbsp;<asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%">
                        POP安装：</td>
                    <td>
                        &nbsp;
                        <asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        POP配送地址：</td>
                    <td colspan="3">
                        &nbsp;<asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                        一级客户：</td>
                    <td colspan="3">
                        &nbsp;
                        <asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp; <a href="#" onclick="history.back(-1)">返回上一页</a></td>
                </tr>
            </table>
            <br />
            <table class="table">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
                <tr>
                    <th>
                        POP编号</th>
                    <th>
                        POP位置</th>
                    <th>
                        材料</th>
                    <th>
                        POP高度</th>
                    <th>
                        POP宽度</th>
                    <th>
                        POP面积</th>
                </tr>
                <asp:Repeater runat="server" ID="RepPOPList" >
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label></td>
                            <td>
                                <%# Eval("POPseat")%>
                            </td>
                            <td>
                                <%# Eval("POPMaterial") %>
                            </td>
                            <td>
                                <%# Eval("POPHeight")%>
                            </td>
                            <td>
                                <%# Eval("POPWith")%>
                            </td>
                            <td>
                                <%# Eval("POPArea")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
          
        </div>
    </form>
</body>
</html>
