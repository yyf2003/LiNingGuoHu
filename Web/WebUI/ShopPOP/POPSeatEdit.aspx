<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPSeatEdit.aspx.cs" Inherits="WebUI_ShopPOP_POPSeatEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>无标题页</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
    <script language="javascript" type="text/javascript">
    function changeseat(seatid,seat)
    {
     var seatvalue=document.getElementById("txt_seat");
     seatvalue.value=seat;
     document.getElementById("hf_seatid").value=seatid;
     document.getElementById("btn_add").style.display='none';
     document.getElementById("btn_update").style.display='';
    }
    function bodyload()
    {
          document.getElementById("btn_add").style.display='';
     document.getElementById("btn_update").style.display='none';
    }
    </script>
</head>
<body onload="bodyload()">
    <form id="form1" runat="server">
    <div style="margin-left:20px; margin-top:20px">
    <div style="font-size:14px; color:#c86000; font-weight:bold">POP位置项目维护</div>
    <br />
    	<table  class="table" style="width: 700px">
			<tr>
				<td style="width:15%">POP位置：</td>
				<td style="width:40%">
				<asp:TextBox id="txt_seat" runat="server" CssClass="txtwith"></asp:TextBox>
				&nbsp;</td>
				<td>
				<asp:Button id="btn_add" runat="server" Text="添 加" OnClick="btn_add_Click" />
				<asp:Button id="btn_update" runat="server" Text="更 改" OnClick="btn_update_Click"  />
				&nbsp;&nbsp;<asp:HiddenField ID="hf_seatid" runat="server" />
                </td>
			</tr>
		</table>
    <br/>

						<asp:Repeater id="Repeater1" runat="server">
						<HeaderTemplate>
						<table class="table" style="width: 700px">
						<tr>
						<th style="width:30px">编号</th><th style="width:300px">位置</th><th>更改</th><th>删除</th>
						</tr>
						</HeaderTemplate>
						<ItemTemplate>
						<tr>
						<td><%#Eval("SeatID") %></td><td><%#Eval("seat")%></td><td><a href="#" onclick="changeseat('<%#Eval("SeatID") %>','<%#Eval("seat")%>')">更改</a></td><td><a href="POPSeatEdit.aspx?id=<%#Eval("SeatID") %>" onclick="return confirm('确认要删除此数据？');">删除</a></td></tr>
						</ItemTemplate>
						<FooterTemplate>
						</table>
						</FooterTemplate>
						</asp:Repeater>
			
    </div>
    </form>
</body>
</html>
