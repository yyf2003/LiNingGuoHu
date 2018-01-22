<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendToPOPAddition.aspx.cs" Inherits="WebUI_POPAddition_SendToPOPAddition" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>发货到店铺</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/Validate.js"></script>
	<script type="text/javascript" language="javascript">
	 
	    function ValidateInput()
	    {
	       var goodsno =$("#txtGoodsOrderNO").val();
	       if(goodsno=="")
	       {
	           $.prompt("发货单号不能为空！");
	           return false;
	       }
	       var company =$("#ddlCompanyName").val();
	         if(company=="0")
	       {
	           $.prompt("请选择物流公司！");
	           return false;
	       }
	       var senddes =$("#txtRemarks").val();
	        if(senddes=="")
	       {
	           $.prompt("请添加货物明细信息！");
	           return false;
	       }
	       if(senddes.length>200)
	       {
	          $.prompt("明细信息不能超过200个字！");
	           return false;
	       }
	    }
	</script>
</head>
<body>
<form id="form1" runat="server">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;"><a href="SendToPOPAdditionList.aspx" title="POP增补发货" style="color: #c86000;">POP增补发货</a>  &gt;&gt;  <%= ShopName%></div>
    <table class="table" style="margin-top:20px; float:left; margin-left:20px; width:90%">
		<caption style="font-weight:bold">POP信息列表：</caption>
		<tr>
			 <th>
                        POP编号</th>
                    <th>
                        POP位置</th>
                    <th>
                        材料</th>
                    <th>
                        POP实际制作高</th>
                    <th>
                        POP实际制作宽</th>
 
                    <th>
                        POP可视画面高</th>
                    <th>
                        POP可视画面宽</th>
                    <th>
                        POP面积</th>
                        <th>
                        POP可视画面位置</th>
                    <th>
                        POP可视画面偏离角度</th>

		</tr>
		<asp:Repeater runat="server" id="RepPOPList">
		<ItemTemplate>
		<tr>
			         <td>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("seatnum")%>'></asp:Label></td>
                            <td>
                                <%# Eval("POPseat")%>
                            </td>
                            <td>
                                <%# Eval("POPMaterial") %>
                            </td>
                            <td align="center">
                                <%# Eval("realHeight")%>
                            </td>
                            <td align="center">
                                <%# Eval("realWith")%>
                            </td> <td align="center">
                                <%# Eval("POPHeight")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPWith")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPArea")%>
                            </td>
                             <td align="center">
                                <%# Eval("POPplwz")%>
                            </td>
                            <td align="center">
                                <%# Eval("POPpljd")%>
                            </td>
			 
		</tr>
		</ItemTemplate>
	   	</asp:Repeater>
	</table>
	<table class="table" style="margin-top:10px; float:left; margin-left:20px; width:90%">
	    <tr>
	        <td style="width:30%; height:30px;">POP发起ID：</td>
	        <td style="text-align:left; height: 30px;">
	        	<asp:TextBox runat="server" id="txtPOPID" CssClass="txtwith"  ReadOnly="true"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="width:30%; height:30px;">发 货 单 号：</td>
	        <td style="text-align:left; height: 30px;">
	        	<asp:TextBox runat="server" id="txtGoodsOrderNO" CssClass="txtwith"></asp:TextBox><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">物 流 公 司：</td>
	        <td style="text-align:left">
	        	<asp:DropDownList runat="server" id="ddlCompanyName"  CssClass="txtwith"></asp:DropDownList><span style=" margin-left:5px;color:red">*</span>

	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<br />
	        	<span style="color:red">主要填写发货单中所包括的货物明细</span></td>
	        <td style="text-align:left">
	        	<asp:TextBox runat="server" id="txtRemarks" CssClass="txtwith" TextMode="MultiLine" Height="100px"></asp:TextBox>
	        </td>
	    </tr>
	    <tr>
	        <td style="height:30px;"></td>
	        <td style="text-align:left">
	        	<asp:Button runat="server" Text="确认发货" id="btnAdd" CssClass="qr0" OnClientClick="return ValidateInput();" OnClick="btnAdd_Click"></asp:Button>
	        </td>
	    </tr>
    </table>
    </div>
</form>
</body>
</html>
