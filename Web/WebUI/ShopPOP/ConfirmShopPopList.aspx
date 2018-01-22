<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmShopPopList.aspx.cs" Inherits="WebUI_ShopPOP_ExamShopPopList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>审批店铺POP信息</title>
    <link href="../../CSS/TableCss.css" type="text/css"  rel="stylesheet"/>
<script language="javascript" type="text/javascript">
 function checkall()
 {
   var all=document.getElementById('check_all');
   var shopidlist=document.getElementsByName('check_popid');

      for(var i=0;i<shopidlist.length;i++)
      {
          shopidlist[i].checked=all.checked;
      }

 }
</script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <div style="font-size:14px; color:#c86000">
        <strong>&nbsp;店铺季度新增POP审核</strong></div>

    <br/>
    	<table  class="table">
			<tr>
				<td style="width:15%">&nbsp;店铺名称：</td>
				<td style="width:35%">&nbsp;<%=Shopname %></td>
				<td style="width:15%">&nbsp;供应商：</td>
				<td>&nbsp;<%=SupplierName%></td>
			</tr>
		</table>
		<br/>
    <div style="width:110%" class="table">
        &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound" Font-Size="12px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                 <asp:BoundField HeaderText="POP位置" DataField="POPseat" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP编号" DataField="SeatNum" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="位置描述" DataField="SeatDesc" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="男女区域" DataField="Sexarea" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
              <asp:BoundField HeaderText="POP实际制作宽" DataField="realWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="PO实际制作高" DataField="realHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可是画面宽" DataField="POPWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面高" DataField="POPHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
              <asp:BoundField HeaderText="POP可是画面位置" DataField="POPplwz" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP画面偏离角度" DataField="POPpljd" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="POPArea" HeaderText="POP面积">
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP材质" DataField="POPMaterial" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP产品系列" DataField="ProductLine" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="是否为双面" DataField="TwoSided" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="是否粘于玻璃上" DataField="Glass" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗进深" DataField="PlatformLong" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗长" DataField="PlatformWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗面积" DataField="PlatformHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="ExamState" HeaderText="确认">
                <ItemStyle Width="60px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="确认">
                <ItemTemplate>
                    &nbsp;<asp:CheckBox  ID="DB_exam"  runat="server" />
                </ItemTemplate>
                <ItemStyle Width="70px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="ID" />
            <asp:BoundField DataField="ProductLineID" />
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:HyperLink ID="HyLinkShow" runat="server" Target="_blank">预览</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
		</div>
		<br />
  <div style="width:100%; text-align:center"><asp:Button id="Btn_Exam" runat="server" OnClientClick="return confirm('确认选择的POP信息都通过？');" CssClass="qr0" Text="通 过" OnClick="Btn_Exam_Click" />
      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
      <asp:Button ID="Btn_ExamNo" runat="server" CssClass="qr0" OnClientClick="return confirm('确认选择的POP信息都不允许通过？');" OnClick="Btn_ExamNo_Click" Text="未通过" /></div>
				

    </div>
    </form>
</body>
</html>
