<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDADSR.aspx.cs" Inherits="PDADSR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta content="zh-cn" http-equiv="Content-Language" />
    <title>DSR检查单</title>
<link href="../../CSS/TableCss.css" type="text/css" rel="stylesheet"/>


<script language="javascript" type="text/javascript">

</script>
</head>
<body style="font-size:12px; background-position:center bottom; background-repeat:no-repeat">
    <form id="form1" runat="server">
    <div style="width:90%">
    	<div style=" font-size:12px; font-weight:bold; text-align:left; padding-left:20px;">
    	<table id="dtinfo" class="table" style="margin-top:20px; margin-left:5%; width:100%">
			<tr>
				<td style="width:15%">店铺编号：</td>
				<td>&nbsp;<asp:TextBox ID="PosID"  CssClass="txtwith"  runat="server"></asp:TextBox></td>
				<td>
                    <asp:Button ID="btn_find" runat="server" Text="查询" OnClick="btn_find_Click" /></td>
			</tr>
		</table>
        <asp:HiddenField ID="HF_cityID" runat="server" /><asp:HiddenField ID="HF_ProvinceID" runat="server" />
        <asp:HiddenField ID="HF_supplierID" runat="server" />
            <asp:HiddenField ID="HF_shopid" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table"  style="margin-top:20px; margin-left:5%" 
                	ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound" Width="100%">
                   <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
					<RowStyle BackColor="#EFF3FB" />
					<PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
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
        	<asp:Button ID="btn_save" Text="保 存"  OnClick="btn_save_Click"  runat="server" Enabled="False" /></div>
	</div>
	</div>
    </form>
	
</body>
</html>
