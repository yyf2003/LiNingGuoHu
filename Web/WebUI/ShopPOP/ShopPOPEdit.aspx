<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopPOPEdit.aspx.cs" Inherits="WebUI_ShopPOP_ShopPOPEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>店铺POP信息修改</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
	<script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
	<script language="javascript" src="../../js/Validate.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div style="margin-left:20px">
	<div style="font-size:14px;color:#c86000; font-weight:bold">&nbsp;店铺POP画面信息修改</div>
	<table class="table" style="margin-top:20px; width:95%">
			<tr>
				<td style="width: 15%">POP位置：</td>
				<td align="left" style="width: 30%">
				    &nbsp;<%--<asp:TextBox id="txtPOPSeat" runat="server" ReadOnly="true" Width="90%"></asp:TextBox>--%>
				    
				    <asp:DropDownList ID="DDL_Popseat" runat="server" onchange="choiseSeat()" CssClass="DDlstyle">
                       <asp:ListItem Value="0">请选择POP位置</asp:ListItem>
                    </asp:DropDownList>
				</td>
				<td style="width: 15%">图片编号：</td>
				<td style="width: 30%">&nbsp;<asp:TextBox id="txtSeatNum" runat="server" ReadOnly="true" Width="90%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">位置描述：</td>
				<td>&nbsp;<asp:TextBox id="txtSeatDesc" runat="server" Width="90%"></asp:TextBox></td>
				<td style="width: 15%">男女区域：</td>
				<td>&nbsp;<asp:TextBox id="txtSexarea" runat="server" Width="90%"></asp:TextBox></td>
			</tr>
            <tr>
                <td style="width: 15%">
                    POP实际制作宽(mm)：</td>
                <td align="left">&nbsp;<asp:TextBox id="txtrealWith" runat="server" Width="90%"></asp:TextBox></td>
                <td style="width: 15%">
                    POP实际制作高(mm)：</td>
                <td>&nbsp;<asp:TextBox id="txtRealHeight" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
			<tr>
				<td style="width: 15%">
                    POP可视画面宽(mm)：</td>
                <td>&nbsp;<asp:TextBox id="txtPOPWith" runat="server" Width="90%"></asp:TextBox></td>
                <td style="width: 15%">
                    POP可视画面高(mm)：</td>
				<td>&nbsp;<asp:TextBox id="txtPOPHeight" runat="server" Width="90%"></asp:TextBox></td>
			</tr>
            <tr>
                <td style="width: 15%">
                    POP可视画面位置：</td>
                <td>&nbsp;<asp:TextBox id="txtPOPplwz" runat="server" Width="90%"></asp:TextBox></td>
                <td style="width: 15%">
                    POP可视画面偏离度：</td>
                <td>&nbsp;<asp:TextBox id="txtPOPpljd" runat="server" Width="90%"></asp:TextBox></td>
            </tr>
			<tr>
				<td style="width: 15%">POP材质：</td>
				<td align="left">&nbsp;
					<asp:DropDownList ID="DDL_material" runat="server" CssClass="DDlstyle">
						<asp:ListItem Value="0">请选择POP材质</asp:ListItem>
					</asp:DropDownList>
				</td>
				<td style="width: 15%">
                    是否为双面：</td>
				<td>&nbsp;<asp:TextBox ID="txtTwoSided"  runat="server" Width="90%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">POP材质备注：</td>
				<td align="left">&nbsp;<asp:TextBox ID="txtPOPMaterialRemark"  runat="server" Width="90%"></asp:TextBox></td>
				<td style="width: 15%">是否粘于玻璃上：</td>
				<td>&nbsp;<asp:TextBox ID="txtGlass" runat="server" Width="90%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">橱窗进深(mm)：</td>
				<td>&nbsp;<asp:TextBox id="txtPlatformLong" runat="server" Width="90%"></asp:TextBox></td>
				<td style="width: 15%">橱窗进深长度(mm)：</td>
				<td>&nbsp;<asp:TextBox id="txtPlatformWith" runat="server" Width="90%"></asp:TextBox></td>
				
			</tr>
			<tr>
				<td style="width: 15%">橱窗进深面积(㎡)：</td>
				<td>&nbsp;<asp:TextBox id="txtPlatformHeight" runat="server" Width="90%"></asp:TextBox></td>
				<td colspan="2"></td>
				
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
		<table class="table" style="margin-top:20px; width:95%">
			<tr>
				<td align="center">
				<asp:Button id="btn_save" runat="server" OnClientClick="return ValidateInput();" cssclass="qr0" text="修 改" OnClick="btn_save_Click" /></td>
			</tr>
		</table>
</div>
<script language="javascript" type="text/javascript">
	function ValidateInput()
	{
		var DDL_material = $('#DDL_material').val();	//POP材质
		var txtPOPMaterialRemark = $.trim($('#txtPOPMaterialRemark').val());	//POP材质备注
		var txtSeatDesc = $('#txtSeatDesc').val();		//位置描述
		var txtSexarea= $('#txtSexarea').val();			//男女区域
		var txtrealWith= $('#txtrealWith').val();		//POP实际制作宽
		var txtRealHeight= $('#txtRealHeight').val();	//POP实际制作高
		var txtPOPWith= $('#txtPOPWith').val();			//POP可视画面宽
		var txtPOPHeight= $('#txtPOPHeight').val();		//POP可视画面高
		var txtPOPplwz= $('#txtPOPplwz').val();			//POP可视画面位置
		var txtPOPpljd= $('#txtPOPpljd').val();			//POP可视画面偏离度
		var txtTwoSided= $('#txtTwoSided').val();		//是否为双面
		var txtGlass= $('#txtGlass').val();				//是否粘于玻璃上
		
		if(DDL_material=="0"){
	        alert("请您选择POP材质");
	        $('#DDL_material').focus();
	        return false;
	    }
	    else if(DDL_material=="其他")
	    {
	    	if(txtPOPMaterialRemark == "")
	    	{
	    		alert("请您输入POP材质备注");
	        	$('#txtPOPMaterialRemark').focus();
	        	return false;
	    	}
	    }
	    
	    if(txtSeatDesc == ""){
	        alert("请您填写位置描述");
	        $('#txtSeatDesc').focus();
	        return false;
	    }
	    
	    if(txtSexarea== ""){
	        alert("请您填写男女区域");
	        $('#txtSexarea').focus();
	        return false;
	    }
	    
	    if(txtrealWith == ""){
	        alert("请您填写POP实际制作宽");
	        $('#txtrealWith').focus();
	        return false;
	    }
	    else{
	    	if(!isnumber(txtrealWith)){
	    		alert("POP实际制作宽必须是数字");
		        $('#txtrealWith').focus();
		        return false;
	    	}
	    }

		if(txtRealHeight == ""){
	        alert("请您填写POP实际制作高");
	        $('#txtRealHeight').focus();
	        return false;
	    }
	    else{
	    	if(!isnumber(txtRealHeight)){
	    		alert("POP实际制作高必须是数字");
		        $('#txtRealHeight').focus();
		        return false;
	    	}
	    }

		if(txtPOPWith == ""){
	        alert("请您填写POP可视画面宽");
	        $('#txtPOPWith').focus();
	        return false;
	    }
	    else{
	    	if(!isnumber(txtPOPWith)){
	    		alert("POP可视画面宽必须是数字");
		        $('#txtPOPWith').focus();
		        return false;
	    	}
	    }

		if(txtPOPHeight == ""){
	        alert("请您填写POP可视画面高");
	        $('#txtPOPHeight').focus();
	        return false;
	    }
	    else{
	    	if(!isnumber(txtPOPHeight)){
	    		alert("POP可视画面高必须是数字");
		        $('#txtPOPHeight').focus();
		        return false;
	    	}
	    }

		if(txtPOPplwz== ""){
	        alert("请您填写POP可视画面位置");
	        $('#txtPOPplwz').focus();
	        return false;
	    }
	    
	    if(txtPOPpljd != ""){
	        if(!isint(txtPOPpljd)){
	    		alert("POP可视画面偏离度必须是整数");
		        $('#txtPOPpljd').focus();
		        return false;
	    	}
	    }


	    if(txtTwoSided== ""){
	        alert("请您填写是否为双面");
	        $('#txtTwoSided').focus();
	        return false;
	    }
	    
	    if(txtGlass== ""){
	        alert("请您填写是否粘于玻璃上");
	        $('#txtGlass').focus();
	        return false;
	    }
	    
	    return true;

	}
</script>
</form>
</body>
</html>
