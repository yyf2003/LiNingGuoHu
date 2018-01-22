<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopRecordList.aspx.cs" Inherits="WebUI_DSRCheck_ShopRecordList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="stylesheet" href="../../CSS/TableCss.css"/>
    <title>店铺检查记录</title>
   <style type="text/css">
   </style>
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">店铺检查记录 &gt;&gt; <%=sname %></div>
    	<table  class="table" style="margin-top:20px;margin-left:5%">
			<tr>
				<td style="width:150px">检查时间：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_btime" CssClass="" runat="server"></asp:TextBox></td>
				<td align="center">到：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_etime" runat="server"></asp:TextBox></td>
				<td style="width:200px" align="center">&nbsp;<asp:Button ID="btn_Search" runat="server" Text="查 询" CssClass="qr0" /></td>
			</tr>
		</table>
	    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" style="margin-top:20px;margin-left:5%" CellPadding="4" ForeColor="#333333" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" PageSize="20" OnRowCommand="GridView1_RowCommand">
	        <Columns>
	            <asp:BoundField HeaderText="序号" >
	                <ItemStyle Width="30px" />
	            </asp:BoundField>
	            <asp:BoundField HeaderText="编号" DataField="PosID">
	                <ItemStyle HorizontalAlign="Center" Width="40px" />
	            </asp:BoundField>
	            <asp:BoundField HeaderText="店铺名称" DataField="ShopName" />
	            <asp:BoundField DataField="ProvinceName" HeaderText="省">
	                <ItemStyle Width="60px" />
	            </asp:BoundField>
	            <asp:BoundField DataField="CityName" HeaderText="市">
	                <ItemStyle Width="60px" />
	            </asp:BoundField>
	            <asp:BoundField HeaderText="所属供应商" DataField="SupplierName">
	                <ItemStyle HorizontalAlign="Left"  Width="200px"/>
	            </asp:BoundField>
	            <asp:BoundField HeaderText="检查人" DataField="UserName">
	                <ItemStyle HorizontalAlign="Center" Width="60px" />
	            </asp:BoundField>
	            <asp:BoundField HeaderText="检查结果" DataField="Y">
	                <ItemStyle HorizontalAlign="Center" Width="60px" />
	            </asp:BoundField>
	            <asp:TemplateField HeaderText="查看详情">
	                <EditItemTemplate>
	                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
	                </EditItemTemplate>
	                <ItemTemplate>
	                    &nbsp;<asp:LinkButton ID="LinkButton1" CommandName="look" CommandArgument='<%#Eval("DataID") %>' runat="server">查 看</asp:LinkButton>
	                </ItemTemplate>
	                <ItemStyle HorizontalAlign="Center" />
	            </asp:TemplateField>
	            <asp:BoundField DataField="DataID" ShowHeader="false">
	                <ItemStyle Width="0px" />
	                <HeaderStyle Width="0px" />
	            </asp:BoundField>
	        </Columns>
	            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
	            <RowStyle BackColor="#EFF3FB" />
	            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
	            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
	            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
	            <EditRowStyle BackColor="#2461BF" />
	            <AlternatingRowStyle BackColor="White" />
	    </asp:GridView>
    </div>
    </form>
		
</body>
</html>
