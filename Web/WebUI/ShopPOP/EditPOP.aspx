<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPOP.aspx.cs" Inherits="WebUI_ShopPOP_EditPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server"><base target="_self">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>店铺POP信息添加</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
function checkdate()
{
//modify by mhj 2012.11.30
//    if($('#DDL_material').val()=="0")
//    {
//        alert("请正确选择POP的材质");
//        $('#DDL_material').focus();
//        return false;
//    }

//    if($('#DDL_ProductLine').val()=="0")
//    {
//        alert("请正确选择POP产品系列");
//        $('#DDL_ProductLine').focus();
//        return false;
//    }
    return confirm("是否已确定画面选择？");
}
</script>
</head>
<body >
<form id="form1" runat="server" >
	<div style="margin-left:20px">
		<div style="font-size:14px;color:#c86000; font-weight:bold">
				&nbsp;店铺POP确认画面订单
       </div>
		<br />
		<table class="table">
			<tr>
				<td style="width: 15%">POP位置：</td>
				<td align="left" style="width: 30%"><%=POPSeat%>
                    &nbsp;</td>
				<td style="width: 15%">图片编号：</td>
				<td style="width: 30%"><%=SeatNum %>&nbsp;</td>
			</tr>
			<tr>
				<td style="width: 15%">位置描述：</td>
				<td align="left"><%=SeatDesc %>&nbsp;</td>
				<td style="width: 15%">男女区域：</td>
				<td>&nbsp;</td>
			</tr>
            <tr>
                <td style="width: 15%">
                    POP实际制作宽：</td>
                <td align="left">
                    <%=realWith %>
                    &nbsp;</td>
                <td style="width: 15%">
                    POP实际制作高：</td>
                <td>
                    <%=RealHeight%>
                    &nbsp;</td>
            </tr>
			<tr>
				<td style="width: 15%">
                    POP可视画面宽：</td>
                <td align="left">
                    <%=POPWith %>
                    &nbsp;</td>
                <td style="width: 15%">
                    POP可视画面高：</td>
				<td><%=POPHeight %>&nbsp;</td>
			</tr>
            <tr>
                <td style="width: 15%">
                    POP可视画面位置：</td>
                <td align="left">
                    <%=POPplwz %>
                    &nbsp;</td>
                <td style="width: 15%">
                    POP可视画面偏离度：</td>
                <td>
                    <%=POPpljd %>
                    &nbsp;</td>
            </tr>
			<tr style="display:none;">
				
				<td style="width: 15%">
                    POP产品大类：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_ProductType" runat="server" AutoPostBack="True" CssClass="DDlstyle"
                        OnSelectedIndexChanged="DDL_ProductType_SelectedIndexChanged">
                        <asp:ListItem Value="0">请选择POP产品大类</asp:ListItem>
                    </asp:DropDownList></td>
                    
                    
                    <td style="width: 15%">POP产品系列：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_ProductLine" runat="server" CssClass="DDlstyle" TabIndex="7" AutoPostBack="True" OnSelectedIndexChanged="DDL_ProductLine_SelectedIndexChanged">
                    <asp:ListItem Value="0">请选择POP产品系列</asp:ListItem>
                     
                    </asp:DropDownList>
                    <%--<asp:ListItem Value="19">Core系列sss</asp:ListItem>--%>
                </td>
			</tr>
			<tr>			
			   
                
                <td style="width: 15%">POP材质：</td>
				<td align="left">&nbsp;<asp:DropDownList ID="DDL_material" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择POP材质</asp:ListItem>
                </asp:DropDownList></td>
                
				<td style="width: 15%">是否为双面：</td>
				<td align="left">&nbsp;<asp:TextBox ID="twoside" runat="server"  Text="<%=TwoSided %>" ReadOnly="true"></asp:TextBox></td>
				
			</tr>
			<tr><td style="width: 15%">是否粘于玻璃上：</td>
				<td>&nbsp;<asp:TextBox ID="txt_Glass" runat="server" Text="<%=Glass %>" ReadOnly="true"></asp:TextBox></td>
				<td style="width: 15%">
                    橱窗进深(mm)：</td>
				<td align="left"><%= PlatformLong%>&nbsp;</td>
				
			</tr>
			<tr><td style="width: 15%">
                橱窗进深长度(mm)：</td>
				<td><%=PlatformWith%>&nbsp;</td>
				<td style="width: 15%">
                    橱窗进深面积(㎡)：</td>
				<td align="left"><%=PlatformHeight %>&nbsp;</td>
				
			</tr>
		</table>
		<asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table class="table">
        <tr>
        <th style="width:80px">产品大类</th><th>产品系列</th><th>图片</th><th style="width:250px">位置描述</th><th>确认使用画面</th>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td style="width:30px"><%#Eval("ProductTypeName").ToString()%></td>
        <td><%#Eval("ProductLineName").ToString()%></td>
        <td><img alt='<%#Eval("ProductLine")%>' src="<%#Eval("SmallImageUrl")%>"></td>
        <td><asp:Label id="lblPOPSeatID" runat="server" Text='<%#Eval("ImageDesc")%>' Visible="false"></asp:Label><asp:Label id="lblPOPSeatName" runat="server"></asp:Label></td>
        <td style="text-align:center;"><input id="Radio1" name="chooseimage" value="<%#Eval("ImageID") %>" type="radio" /></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
         </table>
        </FooterTemplate>
        </asp:Repeater>
		<br />
		<table border="1px" cellpadding="1" cellspacing="1;" class="table">
			<tr>
				<td align="center">&nbsp;<asp:Button id="btn_save" runat="server" OnClientClick="return checkdate();" cssclass="qr0" onclick="btn_save_Click" tabindex="14" text="保 存" /></td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
