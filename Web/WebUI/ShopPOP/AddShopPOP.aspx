<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddShopPOP.aspx.cs" Inherits="WebUI_ShopPOP_AddShopPOP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta content="zh-cn" http-equiv="Content-Language" />
<title>店铺POP信息添加</title>
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
<script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
<script language="javascript" src="../../js/jquery-impromptu.2.5.min.js" type="text/javascript"></script>
<script language="javascript" src="../../js/common.js" type="text/javascript"></script>
<script language="javascript" src="../../js/jquery.corner.js" type="text/javascript"></script>
<script language="javascript" src="../../js/Validate.js" type="text/javascript"></script>
<script language="javascript" src="./javascript/addpop.js" type="text/javascript"></script>
<script language="javascript" src="./javascript/GetFOS.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function check()
{
  return checkdata(<%=shopid%>);
}
function checknum()
{
   var seatnum=$.trim($('#txt_seatNum').val());
   $.post('ashx/GetOnlyNum.ashx?shopid='+<%=shopid%>+'&snum='+seatnum,function(data)
   {
       if(data>0)
       {
         $.prompt("此POP编号已经存在，请重新按照规定填写！");
       }
    })
}

function choiseSeat()
{
   $.post('ashx/GetSeat.ashx?seat='+encodeURIComponent($('#DDL_Popseat').val()),function(data)
   {
      $("#sel_seat").empty();
      $(data).appendTo("#sel_seat")//    
    })
}
function setData()
{
    var str=$('#sel_seat option:selected').text();
    var arr=str.split('|');
    if(arr.length>0)
    {
        $('#txt_POPMaterialRemark').val(arr[1]);
        $('#txt_realwidth').val(arr[2]);    
        $('#txt_realheight').val(arr[3]);
        $('#txt_POPWith').val(arr[4]);
        $('#txt_POPHeight').val(arr[5]);
    }
}
</script>
</head>
<body >
<form id="form1" runat="server" onsubmit="return check();">
	<div style="margin-left:20px">
		<div style="font-size:14px;color:#c86000; font-weight:bold">
				&nbsp;增加店铺POP 
       </div>
		<br />
		<table class="table">
			<tr>
				<td style="width: 5%">POP位置：</td>
				<td style="width: 30% ; " align="left">
				    <asp:DropDownList ID="DDL_Popseat" runat="server" onchange="choiseSeat()" CssClass="DDlstyle">
                       <asp:ListItem Value="0">请选择POP位置</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                      <div style="display:none;"><select id="sel_seat" onchange="setData()" ><option>请选择</option></select></div> 
				</td>
				<td style="width: 15%">图片编号：</td>
				<td  style="width: 30%">&nbsp;<asp:TextBox ID="txt_seatNum" runat="server" CssClass="txtwith" onblur="checknum();" TabIndex="1" Enabled="false"></asp:TextBox></td>
			</tr>
			<tr>
				<td>位置描述：</td>
				<td align="left">&nbsp;<asp:TextBox ID="txt_SeatDesc" runat="server" CssClass="txtwith" TabIndex="2"></asp:TextBox></td>
				<td style="width: 15%">男女区域：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_sexarea" runat="server" CssClass="DDlstyle" TabIndex="3">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                    <asp:ListItem>男子</asp:ListItem>
                    <asp:ListItem>女子</asp:ListItem>
                    <asp:ListItem>公共区</asp:ListItem>
                </asp:DropDownList></td>
			</tr>
			<tr>
				<td style="width: 15%">POP实际制作宽：</td>
				<td align="left">&nbsp;<asp:TextBox ID="txt_realwidth" runat="server" CssClass="txtwith" TabIndex="5"></asp:TextBox>毫米</td>
				<td style="width: 15%">POP实际制作高：</td>
				<td>&nbsp;<asp:TextBox ID="txt_realheight" runat="server" CssClass="txtwith"></asp:TextBox>毫米</td>
			</tr>

			<tr>
				<td>POP可视画面宽：</td>
				<td align="left">&nbsp;<asp:TextBox ID="txt_POPWith" runat="server" CssClass="txtwith" TabIndex="5"></asp:TextBox>毫米</td>
				<td style="width: 15%">POP可视画面高：</td>
				<td>&nbsp;<asp:TextBox ID="txt_POPHeight" runat="server" CssClass="txtwith"></asp:TextBox>毫米</td>
			</tr>
			<tr>
				<td>POP可视画面位置：</td>
				<td align="left">&nbsp;<asp:DropDownList ID="DDL_plwz" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                    <asp:ListItem>偏上</asp:ListItem>
                    <asp:ListItem>偏下</asp:ListItem>
                    <asp:ListItem>偏左</asp:ListItem>
                    <asp:ListItem>偏右</asp:ListItem>
                    <asp:ListItem>居中</asp:ListItem>
                    <asp:ListItem>左上</asp:ListItem>
                    <asp:ListItem>左下</asp:ListItem>
                    <asp:ListItem>右上</asp:ListItem>
                    <asp:ListItem>右下</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">POP可视画面偏离度：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_pljd" runat="server" CssClass="DDlstyle">
                    <asp:ListItem Value="-1">请选择偏离角度</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td>POP材质：</td>
				<td align="left">&nbsp;<asp:DropDownList ID="DDL_POPMaterial" runat="server" CssClass="DDlstyle" TabIndex="6">
                    <asp:ListItem Value="0">请选择POP材质</asp:ListItem>
                    </asp:DropDownList></td>
				<td style="width: 15%">
                    产品大类：</td>
				<td>&nbsp;<asp:DropDownList ID="DDL_ProductType" onchange="getProductLine()" runat="server" CssClass="DDlstyle">
                        <asp:ListItem Value="0">请选择POP的产品大类</asp:ListItem>
                    </asp:DropDownList></td>
			</tr>
			<tr>
				<td>POP材质备注：</td>
				<td align="left">
					&nbsp;<asp:TextBox ID="txt_POPMaterialRemark" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
				<td style="width: 15%">POP产品系列：</td>
				<td>
					&nbsp;<asp:DropDownList ID="DDL_ProductLine" runat="server" CssClass="DDlstyle" TabIndex="7">
		                    <asp:ListItem Value="0">请选择POP产品系列</asp:ListItem>
		                  </asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>是否粘于玻璃上：</td>
				<td align="left">
					<asp:RadioButtonList ID="CB_Glass" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
				</td>
				<td style="width: 15%">是否为双面：</td>
				<td>
                    <asp:RadioButtonList ID="CB_TwoSided" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                    </asp:RadioButtonList></td>
			</tr>
			<tr>
				<td>橱窗空间长度：</td>
				<td align="left">
                	&nbsp;<asp:TextBox ID="txt_PlatformWith" runat="server" CssClass="txtwith" TabIndex="12"></asp:TextBox>毫米
                </td>
				<td style="width: 15%">
                    橱窗空间进深：</td>
				<td>&nbsp;<asp:TextBox ID="txt_PlatformLong" runat="server" CssClass="txtwith" TabIndex="10"></asp:TextBox>毫米</td>
			</tr>
			<tr>
				<td>橱窗面积：</td>
				<td align="left">
					&nbsp;<asp:TextBox ID="txt_PlatformHeight" runat="server" CssClass="txtwith" TabIndex="13"></asp:TextBox>平方米
				</td>
				<td colspan="2">
                    </td>
			</tr>
			<tr>
				<td>图片上传：</td>
				<td>
					<asp:FileUpload runat="server" id="FupPOPImg1" Width="100%" Height="20px" style="margin-top:10px;"></asp:FileUpload><br />
					<asp:FileUpload runat="server" id="FupPOPImg2" Width="100%" Height="20px" style="margin-top:10px;"></asp:FileUpload><br />
					<asp:FileUpload runat="server" id="FupPOPImg3" Width="100%" Height="20px" style="margin-top:10px;"></asp:FileUpload>
				</td>
				<td colspan="2">
					<asp:TextBox ID="txtImgDescribe1" runat="server" CssClass="txtwith" Width="100%" Height="20px"  style="margin-top:5px;"></asp:TextBox><br />
					<asp:TextBox ID="txtImgDescribe2" runat="server" CssClass="txtwith" Width="100%" Height="20px" style="margin-top:7px;"></asp:TextBox><br />
					<asp:TextBox ID="txtImgDescribe3" runat="server" CssClass="txtwith" Width="100%" Height="20px" style="margin-top:7px;"></asp:TextBox>
				</td>
			</tr>
		</table>
		<br />
		<table border="1px" cellpadding="1" cellspacing="1;" class="table">
			<tr>
				<td align="center">&nbsp;<asp:Button id="btn_save" runat="server" cssclass="qr0" onclick="btn_save_Click" tabindex="14" text="保 存" /></td>
			</tr>
		</table>
		<br />
		<table class="table" style="width: 2000px;">
			<tr>
				<td style="height: 54px">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField HeaderText="POP位置" DataField="POPseat" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="图片编号" DataField="SeatNum" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="位置描述" DataField="SeatDesc" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="男女区域" DataField="Sexarea" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
               <asp:BoundField HeaderText="POP实际制作宽" DataField="realwith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP实际制作高" DataField="realheight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面宽" DataField="POPWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面高" DataField="POPHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
             <asp:BoundField HeaderText="POP可视画面位置" DataField="POPPlwz" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面偏离角度" DataField="POPPljd" >
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
            <asp:BoundField HeaderText="双面" DataField="TwoSided" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="玻璃" DataField="Glass" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗长" DataField="PlatformLong" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗宽" DataField="PlatformWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗高" DataField="PlatformHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
             <asp:BoundField DataField="SysTime" HeaderText="添加时间">
                <ItemStyle Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="ExamState" HeaderText="确认">
                <ItemStyle Width="60px" />
            </asp:BoundField>
  
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    			</asp:GridView>
				</td>
			</tr>
		</table>
	</div>
</form>

</body>

</html>
