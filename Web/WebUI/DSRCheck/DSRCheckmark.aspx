<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSRCheckmark.aspx.cs" Inherits="WebUI_DSRCheck_DSRCheckmark" %>
<%@ Register TagPrefix="dotnet" Namespace="dotnetCHARTING" Assembly="dotnetCHARTING"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title>DSR 数据统计</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>
      <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>
         <script language="javascript" type="text/javascript" src="../../js/GetProvinceName.js"></script>
          <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>
</head>
<body >
<form id="form1" runat="server">
	<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">DSR数据分析</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width: 15%">
                    部门名称：</td>
				<td style="width: 250px">&nbsp;<asp:DropDownList ID="DDL_department" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择部门名称</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">
                    区域名称：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_Area" runat="server" onchange="GetprovinceList()"  CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择区域</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
			<td>
                省/市：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_Province" runat="server" onchange="GetcityList()" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择省</asp:ListItem>
                    </asp:DropDownList></td>
				<td>地级城市名称：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_city" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择地级城市名称</asp:ListItem>
                    </asp:DropDownList></td>
				
			</tr>
			<tr>
				<td style="width: 15%">
                    检查时间：</td>
				<td style="width: 250px">
                    &nbsp;<asp:TextBox ID="txt_btime" runat="server" onclick="setday(this,document.getElementById('txt_btime'))" Width="95%"></asp:TextBox></td>
				<td align="center"  style="width: 15%">到</td>
				<td align="center">
						<asp:TextBox ID="txt_endtime" runat="server" onclick="setday(this,document.getElementById('txt_endtime'))" Width="95%"></asp:TextBox>&nbsp;</td>
			</tr>
				<tr>
				<td style="width: 15%">
                    POP发起ID：</td>
				<td style="width: 250px">
                    &nbsp;<asp:DropDownList ID="DDL_POPID" runat="server">
                        <asp:ListItem Value="">请选择POP发起ID</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">&nbsp;DSR检查人：</td>
				<td >
                    &nbsp;<asp:DropDownList ID="txt_DsrName" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
			<td>
                        POP供应商：</td><td>
                <asp:DropDownList ID="ddl_supplier" runat="server">
                    <asp:ListItem Value="0">请选择POP供应商</asp:ListItem>
                    </asp:DropDownList></td><td>
                        是否李宁公司统一支持安装：</td><td>
                <asp:DropDownList ID="DDL_stall" runat="server">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem Value="1">支持</asp:ListItem>
                    <asp:ListItem Value="0">不支持</asp:ListItem>
                </asp:DropDownList></td>
			</tr>
			<tr>
			<td colspan="4" align="center">
                    <asp:Button ID="Btn_search" runat="server" OnClick="Btn_search_Click" Text="分 析" CssClass="qr0" />
                &nbsp;&nbsp;</td>
			</tr>
		</table>
      <br />
      <div style="font-size:14px; color:#c86000;padding-left:40px;"><%=resultstr %></div>
		<br />
		<div id="showimage">
		<div id="charting"><dotnet:Chart ID="Chart1" Type="Combo" runat="server">
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
		  <br />
		  <dotnet:Chart ID="Chart2" Type="Combo" runat="server">
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
</div>
		</div>
		<%=Bigtable.ToString()%>
                    </div>
</form>
</body>
</html>
