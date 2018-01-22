<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderSubmit.aspx.cs" EnableViewState="false" Inherits="WebUI_ShopPOP_OrderSubmit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>

        <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

</head>
<body >
<form id="form1" runat="server">
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;">
        所管辖店铺订单提交</div>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" Width="200%" BackColor="#E0E0E0" BorderColor="Silver" BorderStyle="Dotted" BorderWidth="1px" CellPadding="4" ForeColor="#333333">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <a href='ShopPOPListOpration.aspx?shopid=<%#Eval("系统编号") %>'>提交订单</a>
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
