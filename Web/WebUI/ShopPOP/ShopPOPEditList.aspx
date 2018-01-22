<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopPOPEditList.aspx.cs" EnableViewState="false" Inherits="WebUI_ShopPOP_ShopPOPEditList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>店铺POP信息修改</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
	<script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div style="margin-left:20px">
	<div style="font-size:14px;color:#c86000; font-weight:bold">&nbsp;店铺POP画面信息</div>
	<table class="table" style="margin-top:20px; width:95%">
		<tr>
			<th>图片编号</th>
			<th>POP位置</th>	
			<th>位置描述</th>
			<th>男女区域</th>
			<th>POP实际制作宽</th>
			<th>POP实际制作高</th>
			<th>POP可视画面宽</th>
			<th>POP可视画面高</th>
			<th>POP可视画面位置</th>
			<th>POP画面偏离角度</th>
			<th>POP面积</th>
			<th>POP材质</th>
			<th>男女区域</th>
			<th>是否粘于玻璃上</th>
			<th>省区VM审批</th>
			<th>大区VM审批</th>
			<th>确认修改</th>
			<th>确认删除</th>
			
		</tr>
		<asp:Repeater ID="RepPOPList" runat="server">
		<ItemTemplate>
		<tr>
			<td><%#Eval("SeatNum")%></td>
			<td><%#Eval("POPseat")%></td>
			<td><%#Eval("SeatDesc")%></td>
			<td><%#Eval("Sexarea")%></td>
			<td><%#Eval("realWith")%></td>
			<td><%#Eval("realHeight")%></td>
			<td><%#Eval("POPWith")%></td>
			<td><%#Eval("POPHeight")%></td>
			<td><%#Eval("POPplwz")%></td>
			<td><%#Eval("POPpljd")%></td>
			<td><%#Eval("POPArea")%></td>
			<td><%#Eval("POPMaterial")%></td>
			<td><%#Eval("Sexarea")%></td>
			<td><%#Eval("Glass").ToString()=="0"?"否":"是"%></td>
			<td>
			    <%--<%#Eval("VMExamState").ToString() == "1" ? "已通过" : "未通过"%>--%>
			    <%#Eval("VMExamState").ToString() == "1" ? "已通过" : (Eval("VMExamState").ToString() == "0" ? "未审核" : "未通过") %>
			</td>
			<td>
			  <%-- <%#Eval("ExamState").ToString() == "1" ? "已通过" : "未通过"%>--%>
			   <%#Eval("ExamState").ToString() == "1" ? "已通过" : (Eval("ExamState").ToString() == "0" ? "未审核" : "未通过") %>
			</td>
			<td>
				<asp:Label runat="server" id="lblID" Text='<%#Eval("ID")%>' Visible="false"></asp:Label>
				<asp:Label runat="server" id="lblIsSubmit" Text='<%#Eval("IsSubmit")%>' Visible="false"></asp:Label>
				<asp:HyperLink runat="server" id="HLinkUrl"></asp:HyperLink>
			</td>
			<td>
			    <asp:HyperLink runat="server" id="HLinkDelete"></asp:HyperLink>
			</td>
			
		</tr>
		</ItemTemplate>
		</asp:Repeater>
	</table>
</div>
</form>
</body>
</html>
