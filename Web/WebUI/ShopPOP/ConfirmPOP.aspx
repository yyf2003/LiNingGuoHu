<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmPOP.aspx.cs" Inherits="WebUI_ShopPOP_ExamPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>审核店铺POP信息</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script  src="../../js/jquery-impromptu.2.5.min.js" type="text/javascript"></script>
<script  src="../../js/common.js" type="text/javascript"></script>
<script  src="../../js/jquery.corner.js" type="text/javascript"></script>
<script  src="../../js/Validate.js" type="text/javascript"></script>
<script type="text/javascript" src="../../js/GetAreaBydept.js"></script>
<script  type="text/javascript" src="../../js/GetProvinceName.js"></script>
<script  type="text/javascript"  src="../../js/GetCityByProvince.js"></script>
<script  src="../../js/calendar.js" type="text/javascript""></script>
    <script type="text/javascript">
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        }
        function GetbtimeFocus() { $('#Txt_btime').focus(); }
        function GetetimeFocus() { $('#Txt_etime').focus(); }
        function check() {
            if ($('#Txt_btime').val().length > 0) {
                if (!isdate($('#Txt_btime').val())) {
                    $.prompt('起始时间格式不正确；请正确选择填写', { callback: GetbtimeFocus });
                    return false;
                }
            }
            if ($('#Txt_etime').val().length > 0) {
                if (!isdate($('#Txt_etime').val())) {
                    $.prompt('结束时间格式不正确；请正确选择填写', { callback: GetetimeFocus });
                    return false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table">
            <tr>
                <td style="font-size: 14px; color: #c86000; font-weight: bold">
                    店铺季度新增POP审核
                </td>
            </tr>
        </table>
        <br />
        <table class="table">
            <tr>
                <td style="width: 15%">
                    店铺编号：
                </td>
                <td>
                    <asp:TextBox ID="txt_POSID" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td style="width: 15%">
                    店铺名称：
                </td>
                <td>
                    <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td>
                    <%--<asp:DropDownList ID="DDL_department" runat="server" onchange=" GetAreaName(this.value);"
                        CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>--%>
                    <asp:DropDownList ID="DDL_department" runat="server"
                        CssClass="DDlstyle" 
                        onselectedindexchanged="DDL_department_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    区域名称：
                </td>
                <td>
                    <%--<asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" onchange="GetprovinceList()">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        <asp:ListItem Value="-1">全国</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreaId" runat="server" />--%>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                    
                    <asp:DropDownList ID="DDL_Area" runat="server" CssClass="DDlstyle" 
                        onselectedindexchanged="DDL_Area_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                        <asp:ListItem Value="-1">全国</asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td>
                    省：
                </td>
                <td>
                <%--onchange="GetcityList()"--%>
                    <asp:DropDownList ID="DDL_Province" runat="server"  CssClass="DDlstyle" 
                        AutoPostBack="true" onselectedindexchanged="DDL_Province_SelectedIndexChanged">
                        <asp:ListItem Value="0">请选择省份</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    地级城市：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    供应商：
                </td>
                <td colspan="3">
                    &nbsp;<asp:DropDownList ID="DDL_supplier" runat="server">
                        <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    申请时间：
                </td>
                <td style="width: 35%">
                    &nbsp;<asp:TextBox ID="Txt_btime" onclick="setday(this,document.getElementById('Txt_btime'))"
                        runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td align="center">
                    到
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_etime" onclick="setday(this,document.getElementById('Txt_etime'))"
                        runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 900px; text-align: center">
            <asp:Button ID="btn_search" runat="server" Text="查 询" OnClientClick="return check();"
                CssClass="qr0" OnClick="btn_search_Click" />
        </div>
        <br />
        <table class="table">
            <tr>
                <td align="center">
                    <%=NOrecord %>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AllowPaging="True"
                        AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="rowId" HeaderText="序号">
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="店编号" DataField="PosID">
                                <ItemStyle Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="店铺名称" DataField="ShopName">
                                <ItemStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProvinceName" HeaderText="省">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CityName" HeaderText="市">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="一级客户" DataField="DealerName">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="供应商" DataField="SupplierName">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="未审批">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("ShopID") %>' CommandName="exam"
                                        Text='<%# Bind("noExam") %>' runat="server"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
