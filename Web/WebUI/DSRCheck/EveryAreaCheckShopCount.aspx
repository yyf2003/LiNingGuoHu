<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EveryAreaCheckShopCount.aspx.cs" Inherits="WebUI_DSRCheck_EveryAreaCheckShopCount" %>
<%@ Register TagPrefix="dotnet" Namespace="dotnetCHARTING" Assembly="dotnetCHARTING"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DSR 整体分析</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../js/Validate.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
<script language="javascript" type="text/javascript">
  function checkdata()
  {
    if(!isdate($("#txt_btime").val()))
    {
      alert('请正确填写检查日期');
      $("#txt_btime").focus();
      return false;
    }
    if(!isdate($("#txt_endtime").val()))
    {
      alert('请正确填写检查日期');
      $("#txt_endtime").focus();
      return false;
    }
  }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">DSR 整体分析</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
		  	<tr>
				<td style="width: 15%">
                    POP发起ID：</td>
				<td style="width: 30%">
                    &nbsp;<asp:DropDownList ID="DDL_POPID" runat="server">
                        <asp:ListItem Value="0">请选择POP发起ID</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">&nbsp;部门名称：</td>
				<td  style="width: 30%">
                    &nbsp;<asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle" AutoPostBack="True" OnSelectedIndexChanged="DDL_department_SelectedIndexChanged">
                        <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
				<tr>
				<td style="width: 15%">
                    检查时间：</td>
				<td  style="width: 30%">
                    &nbsp;<asp:TextBox ID="txt_btime" runat="server" onclick="setday(this,document.getElementById('txt_btime'))" Width="95%"></asp:TextBox></td>
				<td align="center"  style="width: 15%">到</td>
				<td  style="width: 30%" align="center">
						<asp:TextBox ID="txt_endtime" runat="server" onclick="setday(this,document.getElementById('txt_endtime'))" Width="95%"></asp:TextBox>&nbsp;</td>
			</tr>
			<tr>
			<td>
                区域：</td><td colspan="3">
                <asp:CheckBoxList ID="CBlist_Area" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                </asp:CheckBoxList></td>
			</tr>
			<tr>
			  <td colspan="4" align="center">
                  <asp:Button ID="btn_search" runat="server" Text="分 析" CssClass="qr0" OnClick="btn_search_Click"  OnClientClick="return checkdata();"/></td>
			</tr>
		</table>
		<br />
		<table class="table" style="margin-top:20px; margin-left:5%">
		<tr>
		<td align="center">
		各个省区检查店铺数据

            <asp:GridView ID="GridView1" runat="server" Width="98%">
            </asp:GridView>
            <br />
        各个省区检查数据表
            <asp:GridView ID="GridView2" runat="server" Width="98%">
            </asp:GridView>
              <br />
        安装和非安装区域检查数据表
            <asp:GridView ID="GridView3" runat="server" Width="98%">
            </asp:GridView>
            <dotnet:Chart ID="Chart1" Type="Combo" runat="server">
            <TitleBox Position="Left">
            </TitleBox>
            <SmartLabelLine Color="Transparent" />
            <DefaultLegendBox CornerBottomRight="Cut" Visible="True">
                <HeaderEntry Name="Name" SortOrder="-1" Value="Value" Visible="False">
                    <DividerLine Color="Gray" />
                    <LabelStyle Font="Arial, 8pt, style=Bold" />
                </HeaderEntry>
            </DefaultLegendBox>
            <DefaultElement>
                <DefaultSubValue>
                    <Line Length="4" />
                </DefaultSubValue>
                <SmartLabel>
                    <Line Color="Transparent" />
                </SmartLabel>
            </DefaultElement>
		  </dotnet:Chart>
		</td>
		</tr>
		</table>
    </div>
    </form>
</body>
</html>
