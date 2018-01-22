<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamPrice.aspx.cs" Inherits="WebUI_Supplier_ExamPrice" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>价格审批</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function showprice()
{

   if(document.getElementById('ExamYes').style.display=='none')
     {
       document.getElementById('ExamYes').style.display='';
     }else
     {
        document.getElementById('ExamYes').style.display='none';
     }
}
</script>
</head>

<body>

<form id="form1" runat="server">
	<div>
		<div style=" font-size:14px; height:30px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="SupplierListByVM.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>  &gt;&gt; <%=sName%>  &gt;&gt; 报价审核</div>
	</div>
	<table class="table" style="margin-left:5%">
		<tr>
			<td style="width: 15%">供应商：</td>
			<td>&nbsp; <%=sName%></td>
		<td>&nbsp; </td>
			<td>&nbsp;</td>
		</tr>
	</table>
			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table" style="margin-top:20px; font-size:12px;margin-left:5%" ForeColor="#333333"  OnRowDataBound="GridView1_RowDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField HeaderText="序号">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SupplierName" HeaderText="供应商">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="POPMaterialName" HeaderText="材料">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="价格">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("POPPrice") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="通过">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Check_in" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PriceID">
                                <HeaderStyle Width="1px" />
                                <ItemStyle Width="1px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
	<table class="table" style="margin-left:5%; margin-top:20px;">
		<tr>
			<td align="center">
                <asp:Button ID="btn_Exam" runat="server" OnClientClick="return confirm('没有选中的视为未通过价格，供应商修改后再审批，是否要提交？');" OnClick="btn_Exam_Click" Text="审 批" CssClass="qr0" />&nbsp;</td>
		</tr>
	</table>
	<div style="font-size:12px;font-weight:bold;margin-left:5%; margin-top:20px;"><font style="cursor:crosshair; font-size:14px" onclick="showprice()">查看本期已通过价格(点击查看)</font></div>
	<div id="ExamYes" style="margin-left:5%; margin-top:20px; display:none">
	
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
              <table class="table" style="margin-top:20px;width:50%" ><tr>
              <th>材料</th><th>价格</th>
              </tr>
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
            <td><%#Eval("POPMaterialName")%></td>
            <td><%#Eval("POPPrice") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>   
        </FooterTemplate>
        </asp:Repeater>
    </div>
</form>

</body>

</html>
