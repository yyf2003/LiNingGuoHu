<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPDataFromExcel.aspx.cs" Inherits="WebUI_ExcelToDB_DataFromExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="../../CSS/TableCss.css" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="margin-left:20px">
			<div style="font-size: 14px; color: #c86000">
                execl导入POP信息</div>
				<br />
				<table class="table">
				<tr>
				<td style="width:15%">
                    导入的excel文件：</td><td style="width:50%">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" /></td><td align="center">
                    <asp:Button ID="Btn_show" runat="server" Text="导入Excel表中数据" OnClientClick="this.enabled=false;" OnClick="Btn_show_Click" /></td>
				</tr>
				</table>
				<table class="table">
				<tr>
				<td>
				<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
                    <asp:Label ID="labUpdate" runat="server" Text=""></asp:Label>
                    <asp:Label ID="labNew" runat="server" Text=""></asp:Label>
                    <asp:Label ID="labStateMsg" runat="server" Text=""></asp:Label>
				</td>
				</tr>
				</table>
				</div>
				
    </div>
    </form>
</body>
</html>
