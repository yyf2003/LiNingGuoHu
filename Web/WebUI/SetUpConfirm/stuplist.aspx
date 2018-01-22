<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stuplist.aspx.cs" Inherits="WebUI_SetUpConfirm_stuplist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />

</head>

     <body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form2" runat="server">
        <div style="width: 90%;padding-left: 20px">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;color: #c86000;"><br /></div>
            <div  style=" padding-left: 20px;">
            <table class="table">
            <tr>
                <td style="color: black">店铺Poscode</td><td>
                    <asp:TextBox ID="txt_code" runat="server"></asp:TextBox></td><td>店铺名称</td><td>
                    <asp:TextBox ID="txt_shopname" runat="server"></asp:TextBox></td><td align="center">
                    <asp:Button ID="Btn_search" runat="server" Text="查 询" CssClass="qr0" OnClick="Btn_search_Click" /></td>
             </tr>
             </table>
             <br />
            <table class="table">
            <tr>
                <td style="color: black">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20">
                        <Columns>
                            <asp:BoundField DataField="posid" HeaderText="店铺Poscode" />
                            <asp:BoundField DataField="shopname" HeaderText="店铺名称" />
                            <asp:BoundField DataField="shopmaster" HeaderText="店铺负责人" />
                            <asp:BoundField DataField="shopmasterphone" HeaderText="负责人电话" />
                            <asp:BoundField DataField="dealername" HeaderText="所属一级客户" />
                            <asp:BoundField DataField="suppliername" HeaderText="所属供应商" />
                        </Columns>
                    </asp:GridView>
                </td>
             </tr>
             </table>
             </div>
        </div>
</form>
</body>
</html>
