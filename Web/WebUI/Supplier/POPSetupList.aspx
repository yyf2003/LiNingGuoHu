<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPSetupList.aspx.cs" Inherits="WebUI_Supplier_POPSetupList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>POP安装图片</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/ShowImg.js"></script>
</head>
<body >

<form id="form1" runat="server">
<div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;"><a href="ShopPOPSetupList.aspx" title="已收货店铺列表" style="color: #c86000;">已收货店铺列表</a> &gt;&gt; 
        <asp:Label ID="lblShopName" runat="server" Text=""></asp:Label></div>
        
            <table class="table" style="margin-top:20px; color:navy; float:left; margin-left:20px">
	        <tr>
	    	    <th style="height: 24px; width:10%">流水号</th>
	            <th>POP位置</th>
	            <th>POP材料</th>
	            <th>所属店铺</th>
	            <th>上传安装照片</th>
	            <th>状态</th>
	            <th>查看</th>
	        </tr>
	        <asp:Repeater ID="RepPOPList" runat="server">
            <ItemTemplate>
            <tr>
	    	    <td>
	    	        <%# Container.ItemIndex + 1%>
	    	        <asp:Label ID="lblPOPID" runat="server" Text='<%# Eval("POPInfoID")%>' Visible="false"></asp:Label>
	    	        <asp:Label ID="lblShopID" runat="server" Text='<%# Eval("ShopID")%>' Visible="false"></asp:Label>
	    	        <asp:Label ID="lblIsUpLoad" runat="server" Text='<%# Eval("IsUpLoad")%>' Visible="false"></asp:Label>
	    	    </td>
	            <td><%# Eval("POPseat")%></td>
	            <td><%# Eval("POPMaterial")%></td>
	            <td><%# Eval("ShopName")%></td>
	            <td><asp:FileUpload ID="FileUploadImg" CssClass="txtwith" runat="server" /></td> 
	            <td><%# Eval("IsUpLoad").ToString().Trim() == "0" ? "未上传" : "已上传"%></td> 
	            <td><a href='<%# Eval("href")%>'>查看图片</a></td> 
	        </tr>
            </ItemTemplate>
            </asp:Repeater>  
            </table>
         
		
		<div style="margin-top:20px; color:navy; float:left; margin-left:20px; width:900px">
			<asp:Button ID="btnUpLoad" runat="server" Text="上  传" Visible="false" CssClass="qr0" OnClick="btnUpLoad_Click" />
		</div>
        <asp:HiddenField ID="HidSupplierID" runat="server" />
</div>
</form>
</body>
</html>
