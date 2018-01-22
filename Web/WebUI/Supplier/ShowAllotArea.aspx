<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAllotArea.aspx.cs" Inherits="WebUI_Supplier_ShowAllotArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>显示供应商所负责区域</title>
        <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                width: 50%; float: left; height: 30px; color: #c86000;">
                <a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>
                <%= " &gt;&gt; " + SupplierName%>
            </div>
            <div style="float: left; font-size:12px; width: 30%; height: 30px; text-align: right">
             </div>
            
        </div>
    <div style="margin-left:20px">
<table class="table" style="color: navy;">
                <tr>
                    <td style="height: 30px; width: 20%; font-weight: bold">
                        供应商名称:</td>
                    <td style="width: 40%">
                        <%= SupplierName%>
                    </td>
                    <td style="width: 20%; font-weight: bold">
                        负责人:</td>
                    <td>
                        <%= Contacter%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; font-weight: bold">
                        邮政地址:</td>
                    <td style="height: 30px;">
                        <%= PostAddress%>
                    </td>
                    <td style="height: 30px; font-weight: bold">
                        邮政编码:</td>
                    <td style="height: 30px;">
                        <%= PostCode%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; font-weight: bold">
                        联系电话:</td>
                    <td style="height: 30px;">
                        <%= ContactPhone%>
                    </td>
                    <td style="height: 30px; font-weight: bold">
                        联系人职位:</td>
                    <td style="height: 30px;">
                        <%= ContacterRole%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; width: 20%; font-weight: bold">
                        备注：</td>
                    <td style="height: 30px; text-align: left" colspan="3">
                        <%= Remarks%>
                    </td>
                </tr>
            </table>

            <br />
            <table class="table">
                <tr>
                    <td>
                        &nbsp;省&nbsp;区：</td>
                </tr>
            </table>
            <table class="table">
                <tr>
                    <td>
                        <asp:Literal ID="Lit_Area" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
        <table class="table"  style="margin-left:20px">
            <tr>
                <td>
                    &nbsp; 省&nbsp; 份：</td>
            </tr>
        </table>
        <table id="pro" class="table"  style="margin-left:20px">
            <tr>
                <td>
                    <asp:Literal ID="Lit_province" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" border="0" class="table" style="margin-top: 3px; margin-left:20px">
            <tr>
                <td colspan="2" align="center">
                    <input id="Button1" type="button" value="返回" class="qr0" style="margin-right: 20px;"
                        onclick="history.back(-1)" />
                    <asp:HyperLink ID="hyLink" runat="server" Width="120px">重新分配区域</asp:HyperLink>
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
