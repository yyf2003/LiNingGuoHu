<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSRCheckShop.aspx.cs" Inherits="WebUI_DSRCheck_DSRCheckShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>DSR检查单</title>
<link href="../../CSS/TableCss.css" type="text/css" rel="stylesheet"/>
<script language="javascript" src="../../js/Validate.js" type="text/javascript"></script>
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
   </style>
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
  function checkdata()
  {
    if(!isdate($("#Txt_CheckDate").val()))
    {
      alert('请正确填写检查日期');
      return false;
    }
  }
</script>
</head>
<body >
    <form id="form1" onsubmit="return Checkall();" runat="server">
    <div style="width:90%">
    	<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="CheckShopList.aspx" title="店铺检查列表" style="color: #c86000;">店铺检查列表</a>  &gt;&gt; 检查店铺</div>
    	<table id="dtinfo" class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td  style="width:150px" rowspan="4"><img alt="a" src="../../images/icon.gif" /></td>
				<td style="width:15%">店铺名称：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_Shopname" CssClass="txtwith" runat="server"></asp:TextBox></td>
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
				<td style="height: 33px">检查人：</td>
				<td style="height: 33px">&nbsp;<asp:TextBox ID="Txt_checkman"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td style="height: 33px">检查日期：</td>
				<td style="height: 33px">&nbsp;<asp:TextBox ID="Txt_CheckDate"  onclick="setday(this,document.getElementById('Txt_CheckDate'))" runat="server" Width="95%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="height: 33px">所属供应商：</td>
				<td style="height: 33px">&nbsp;<asp:TextBox ID="Txt_gyx"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td style="height: 33px">
                    检查结果：</td>
				<td style="height: 33px">&nbsp;<asp:TextBox ID="Txt_result"  CssClass="txtwith"  runat="server" ></asp:TextBox></td>
			</tr>
		</table>
        <asp:HiddenField ID="HF_cityID" runat="server" /><asp:HiddenField ID="HF_ProvinceID" runat="server" />
        <asp:HiddenField ID="HF_supplierID" runat="server" />
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
                        <asp:TemplateField HeaderText="是">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="Check_Yes" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="否">
                                                      <ItemTemplate>
                                <asp:CheckBox ID="Check_NO" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="结果">
                                     <ItemTemplate>
                                &nbsp;<asp:TextBox ID="Label_result" CssClass="noline" runat="server" BorderStyle="None" Style="border-top-style: none;
                                    border-right-style: none; border-left-style: none; border-bottom-style: none"
                                    Width="90%" ></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                                 <ItemTemplate>
                                <asp:TextBox ID="txt_remarks" runat="server" TextMode="MultiLine" Width="99%"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RulesID" ShowHeader="False">
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" />
                            <ItemStyle Width="1px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <div style="margin-top:20px; height:30px; padding-top:10px; margin-left:5%; text-align:center">
        	<asp:Button ID="btn_save" Text="保 存" CssClass="qr0" OnClientClick="return  checkdata();" OnClick="btn_save_Click"  runat="server" /></div>
	</div>
    </form>
	
</body>
</html>
