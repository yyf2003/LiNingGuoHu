<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewAddPOPOrderList.aspx.cs" Inherits="WebUI_Supplier_NewAddPOPOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/calendar.js" ></script>
</head>
<body >
<form id="form1" runat="server">
<div>
<div style=" padding-left:20px; ">
    <div style=" font-size:14px; font-weight:bold; text-align:left;width:50%; height:30px;color: #c86000;">季度新增POP订单导出</div>
    <br />
        <div>
             <table class="table">
             <tr>
               <td style="width:15%">POP发起ID</td>
               <td style="width:30%">
                   <asp:DropDownList ID="DDL_POPID" Width="95%" runat="server">
                   </asp:DropDownList>
               </td>
               <td  style="width:15%">
                       供应商：
               </td>
               <td>
                    <asp:DropDownList ID="DDL_Supplier" Width="95%" runat="server">
                    <asp:ListItem Value="0">请选择供应商</asp:ListItem>
                    </asp:DropDownList>
               </td>
             </tr>
             <tr>
               <td style="width:15%">新增时间：</td>
               <td style="width:30%">
                   <asp:TextBox runat="server" id="txtBeginDate" onclick="setday(this,document.getElementById(this.id))" Width="80px"  ></asp:TextBox>&nbsp;&nbsp;至&nbsp;&nbsp;
				   <asp:TextBox runat="server" id="txtEndDate" onclick="setday(this,document.getElementById(this.id))" Width="80px"  ></asp:TextBox>
			    </td>
                 <td colspan="2" style="text-align:center">
                     <asp:Button ID="btn_search" CssClass="qr0" runat="server" Text="查 询" OnClick="btn_search_Click" /></td>
             </tr>
             </table>
             <br />
             
           <span style="font-size:14px"> 季度新增POP订单数量为 &nbsp;&nbsp;&nbsp;&nbsp;<a href="../Analysis/daochu.aspx?dtname=NewOrderlist"><%=TotalCount %></a>&nbsp;&nbsp;&nbsp;&nbsp;(点击数字导出excel)</span> 
             <br />
            <asp:GridView ID="GridView1" CssClass="table" Width="130%" runat="server">
            </asp:GridView>
            <br />

        </div>
    </div>
</div>
    </form>
</body>
</html>
