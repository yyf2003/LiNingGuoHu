<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultInfo.aspx.cs" Inherits="WebUI_DSRCheck_ResultInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>DSR检查单</title>
<link href="../../CSS/TableCss.css" type="text/css" rel="stylesheet"/>
<script language="javascript" type="text/javascript" src="javascript/DSRCheckShop.js"></script>
<script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
   <style type="text/css">

.td{TEXT-ALIGN: right;}
.noline{
	border:0px;
	 readonly:expression(this.readOnly=true);
}
  .nochoose{
	border:1px;
	border-color:red;
	font-color:red;
}
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
   </style>
   <script language="javascript" src="../../js/Validate.js" type="text/javascript"></script>

</head>
<body >
<form id="form1" onsubmit="return Checkall();" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">DSR检查单</div>
    	<table id="dtinfo" class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td  style="width:150px" rowspan="4"><img alt="a" src="../../images/icon.gif" /></td>
				<td style="width:15%">店铺名称：</td>
				<td style="width:250px">&nbsp;<asp:TextBox ID="Txt_Shopname" CssClass="txtwith" runat="server"></asp:TextBox></td>
				<td style="width:15%">店铺编号：</td>
				<td>&nbsp;<asp:TextBox ID="PosID"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>一级客户：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_Dealer"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td>地级城市：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_City"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>检查人：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_checkman"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td>检查日期：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_CheckDate"  CssClass="txtwith" runat="server" Width="95%"></asp:TextBox></td>
			</tr>
			<tr>
				<td> 所属供应商：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_gyx"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td>
                    检查结果：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_result"  CssClass="txtwith"  runat="server" ></asp:TextBox></td>
			</tr>
		</table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table"  style="margin-top:20px; margin-left:5%"
             ForeColor="#333300" OnRowDataBound="GridView1_RowDataBound">
           <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
			<RowStyle BackColor="#EFF3FB" />
			<PagerStyle HorizontalAlign="Center" BackColor="#CFFFB9" ForeColor="White" />
			<SelectedRowStyle BackColor="#D6DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CF1" ForeColor="White" Font-Bold="True" />
            <Columns>
                <asp:BoundField HeaderText="序号">
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="检查分类" DataField="DSRCheckType" >
                    <ItemStyle  Width="100px" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="分类项目" DataField="DSRRules" >
                    <ItemStyle Width="350px" />
                </asp:BoundField>
                <asp:BoundField DataField="CheckResults" HeaderText="结果" />
                <asp:BoundField DataField="remarks" HeaderText="备注" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
	</div>
</form>	
</body>
</html>
