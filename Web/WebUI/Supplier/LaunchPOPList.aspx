<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeFile="LaunchPOPList.aspx.cs" Inherits="WebUI_Supplier_LaunchPOPList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�ޱ���ҳ</title>
        <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body >
<form id="form1" runat="server">
<div>
<div style=" padding-left:20px; ">
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;"> ���ϼ۸�</div>
    <br />
    <div class="table" style="width:51%; text-align:center">
        <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField HeaderText="��������" DataField="MateriaPro" />
                <asp:BoundField DataField="POPprice" HeaderText="�۸�" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    </div>
</div>
</form>
</body>
</html>
