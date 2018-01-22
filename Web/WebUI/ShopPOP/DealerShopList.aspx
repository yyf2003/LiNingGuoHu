<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerShopList.aspx.cs" EnableViewState="false" Inherits="WebUI_ShopPOP_DealerShopList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>店铺信息列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

</head>
<body>
<form id="form1" runat="server">
<div style="margin-left:20px">
	<div style="font-size:14px;color:#c86000; font-weight:bold">&nbsp;店铺POP画面信息修改</div><br/>
	<asp:GridView ID="GridView1" runat="server" Width="200%" BackColor="#E0E0E0" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" CellPadding="4" ForeColor="#333333">
            <Columns>
                <asp:TemplateField HeaderText="查看POP">
                    <ItemTemplate>
                        <a href='ShopPOPEditList.aspx?shopid=<%#Eval("系统编号") %>' target="_blank">查看</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
	
</div>
</form>
</body>
</html>
