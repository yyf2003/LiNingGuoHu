<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchShop.aspx.cs" Inherits="WebUI_SetUpConfirm_SearchShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺查询</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <style>
 *body{ font-size:12px;} 
 

 </style>

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"> </script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                店铺查询</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        店铺编号
                    </td>
                    <td style="width: 35%">
                        <asp:TextBox ID="txt_posid" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                    <td style="width: 15%">
                        店铺名称
                    </td>
                    <td>
                        <asp:TextBox ID="txt_shopname" runat="server" CssClass="txtwith"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <input id="Button1" type="button" value="查询" class="qr0" onserverclick="Button1_ServerClick"
                            runat="server" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GV_UserList" runat="server" AutoGenerateColumns="false" CssClass="table"
                Style="margin-top: 10px; margin-left: 5%" AllowPaging="True" OnPageIndexChanging="GV_UserList_PageIndexChanging"
                PageSize="20">
                <Columns>
                    <asp:BoundField DataField="Rid" HeaderText="编号">
                        <ItemStyle Height="22px" HorizontalAlign="Center" />
                        <HeaderStyle Height="22px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="PosID">
                        <ItemTemplate>
                            <%#Eval("PosID")%>
                        </ItemTemplate>
                        <HeaderStyle />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Shopname" HeaderText="店铺名称">
                        <ItemStyle Height="22px" HorizontalAlign="Center" />
                        <HeaderStyle Height="22px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="安装确认" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <a href='AddOne.aspx?ID=<%#Eval("AssignShopID") %>'>安装确认</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hidSupplierID" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
