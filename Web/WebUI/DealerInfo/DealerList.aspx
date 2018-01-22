<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerList.aspx.cs" Inherits="WebUI_DealerInfo_DealerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>一级客户信息列表</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetCityByProvince.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/GetProvinceName.js"></script>
    <%--<script type="text/javascript" language="javascript" src="../../js/GetAreaBydept.js"></script>--%>
    <style type="text/css">
        *body
        {
            font-size: 12px;
        }
        a:link
        {
            text-decoration: none;
            color: #424242;
        }
        a:active
        {
            text-decoration: underline;
            color: #424242;
        }
        a:visited
        {
            text-decoration: none;
            color: #424242;
        }
        a:hover
        {
            text-decoration: underline;
            color: #000000;
        }
        #alertName
        {
            border: solid 1px #ffffff;
            display: none;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ReLoadPage() {
            location.reload();
        }

        function CheckDel(ID) {
            $.prompt('确认删除该一级客户吗？<input type ="text" name="alertName" id ="alertName" value="' + ID + '"  />', { callback: DelOneUser, buttons: { 确定: 'true', 取消: 'false'} });
            return false;
        }

        function DelOneUser(v, m, f) {
            if (v == "true") {
                var id = f.alertName;
                $.get("../ashx/DelOneDealerInfo.ashx?Data=" + new Date(), { ID: id }, function (data) {
                    if (data.length > 0) {
                        $.prompt('删除成功', { callback: ReLoadPage });
                    }
                });
            }
        }
        function GetcityList() {
            var pro = $("#DDL_Province").val();
            GetCityname(pro);
        } 
    </script>
</head>
<body style="font-size: 12px; background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
    <div style="width: 90%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;">
            查看一级客户</div>
        <table class="table" style="margin-top: 20px; margin-left: 20px">
            <tr>
                <td width="15%">
                    一级客户编号：
                </td>
                <td align="left" width="35%">
                    <asp:TextBox ID="txt_DealerID" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td width="100px">
                    一级客户名称：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt_DealerName" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    部门名称：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" onchange=" GetAreaName(this.value);">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    区域名称：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_Area" onchange="GetprovinceList()" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfAreas" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    所在省份：
                </td>
                <td align="left">
                    <asp:DropDownList ID="DDL_Province" CssClass="txtwith" onchange="GetcityList()" runat="server">
                        <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    所在市区：
                </td>
                <td>
                    <asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                        <asp:ListItem Value="0">请选择市</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnSearch" runat="server" Text="查询" class="qr0" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table"
            Style="margin-left: 20px; margin-top: 20px;" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
            <Columns>
                <asp:BoundField HeaderText="编号" DataField="Nid">
                    <HeaderStyle Height="22px" />
                    <ItemStyle Height="22px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="一级客户编号" DataField="DealerID">
                    <HeaderStyle Height="22px" />
                    <ItemStyle Height="22px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="一级客户名称" DataField="DealerName">
                    <HeaderStyle Height="22px" />
                    <ItemStyle Height="22px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="所属部门">
                    <ItemTemplate>
                        <%#Eval("department").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所在省区">
                    <ItemTemplate>
                        <%#Eval("areaname").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所在省份">
                    <ItemTemplate>
                        <%#Eval("ProvinceName").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所在市区">
                    <ItemTemplate>
                        <%#Eval("cityname").ToString()%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="联系人" DataField="Contactor">
                    <HeaderStyle Height="22px" />
                    <ItemStyle Height="22px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="联系电话" DataField="ContactorPhone">
                    <HeaderStyle Height="22px" />
                    <ItemStyle Height="22px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <a href="#" onclick="return CheckDel(<%#Eval("ID") %>); ">删除</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="详细">
                    <ItemTemplate>
                        <a href='OneDealerInfo.aspx?ID=<%#Eval("ID") %>'>详细 </a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="修改">
                    <ItemTemplate>
                        <a href='UpdateOneDealerInfo.aspx?ID=<%#Eval("ID") %>'>修改 </a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="直属客户" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href='../Distribution/Add.aspx?id=<%#Eval("DealerID") %>'>添加 </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
