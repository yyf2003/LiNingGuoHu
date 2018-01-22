<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendToDealers.aspx.cs" Inherits="WebUI_PhysicalDistribution_SendToDealers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发货到一级客户</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/calendar.js"> </script>

    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

    <script type="text/javascript" language="javascript" src="./javascript/SaveSessionIDList.js"></script>

    <script src="../../js/GetFxname.js" language="javascript" type="text/javascript"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>

    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>

    <script language="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
	function CheckSub()
	{
	 	var DName = $.trim($("#ddl_dealer").val());
		var DId = $.trim($("#txtDealerID").val());
//		if(DName == "0" && DId == "")
//		{
//			$.prompt("请选择要发货的一级客户!");
//            return false;   
//		}
	}
	function dealerChange()
	{
	    var DName = $.trim($("#ddl_dealer").val());
	    if(DName!="0")
	       $("#txtDealerID").val(DName);
	    else
	      $("#txtDealerID").val("");
	}
	function CheckAddInfo()
	{
	   var sendcode =$("#txtGoodsOrderNO").val();
	   if(sendcode=="")
	   {
	      $.prompt("发货单号不能为空！",{callback:gettxtGoodsOrderNOfocs});
	               return false;
	   }
	}
	 function gettxtGoodsOrderNOfocs(){$("#txtGoodsOrderNO").focus();}
    </script>

    <script type="text/javascript" language="javascript">
	    var IsAllCheck = 0;
	    function AllCheck()
	    {
	        var selectSpan = $("#selectSpan");
	        var chk = $("input[type='checkbox']");
	        if(IsAllCheck == 0)
	        {
	            chk.attr("checked",'true');//全选
	            for(var i=0;i<chk.length;i++)
	            {
	                AddOrDeleteIDsBy(chk[i],"add");
	            }
	            IsAllCheck = 1;
	            selectSpan.html("取消");
	            selectSpan.attr("title","全部取消");
	        }
	        else
	        {
	            chk.removeAttr("checked");//取消
	            for(var i=0;i<chk.length;i++)
	            {
	                AddOrDeleteIDsBy(chk[i],"del");
	            }
	            IsAllCheck = 0;
	            selectSpan.html("全选");
	            selectSpan.attr("title","全部选择");
	        }
	    }
    </script>

</head>
<body>
    <form id="form1" runat="server" onsubmit="return CheckSub();">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                发货到一级客户</div>
            <table class="table" style="margin-top: 20px; float: left; margin-left: 20px; width: 100%">
               <%-- <tr>
                    <td style="width: 15%; text-align: right">
                        所在省份：</td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" onchange="GetcityList()">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%; text-align: right">
                        地级城市：</td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server">
                            <asp:ListItem Value="0">请选择市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align: right">
                        &nbsp;一级客户编号：
                    </td>
                    <td>
                        &nbsp;<asp:TextBox runat="server" ID="txtDealerID" CssClass="txtwith"></asp:TextBox>&nbsp;</td>
                    <td style="width: 15%; text-align: right">
                        一级客户：</td>
                    <td style="width: 30%;">
                        <asp:DropDownList ID="ddl_dealer" onchange="dealerChange()" runat="server" CssClass="txtwith">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>--%>
                <tr>
                    <td style="width: 15%; text-align: right">
                        店铺编号：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:TextBox runat="server" ID="txtShopID" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; text-align: right">
                        店铺名称：
                    </td>
                    <td>
                        &nbsp;<asp:TextBox runat="server" ID="txtShopName" CssClass="txtwith"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <table class="table" id="ShopList" style="margin-top: 10px; float: left; margin-left: 20px;
                width: 100%">
                <tr>
                    <th style="height: 30px; width: 7%">
                        流水号</th>
                    <th>
                        店铺编号</th>
                    <th style="width: 23%">
                        店铺名称</th>
                    <th style="">
                        所属省市</th>
                    <th style="width: 23%">
                        一级客户</th>
                    <th style="">
                        POP总数量</th>
                    <th style="">
                        <span id="selectSpan" style="cursor: pointer" onclick="javascript:AllCheck();" title="全部选择">
                            全选</span></th>
                </tr>
                <asp:Repeater runat="server" ID="RepShopList" OnItemDataBound="RepShopList_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 25px;">
                                <%# Eval("SNumberID")%>
                                <%--<asp:Label ID="lblID" runat="server" Text='<%# Eval("ShopID")%>' Visible="false"></asp:Label>--%>
                                <asp:HiddenField ID="lblID" runat="server" Value='<%# Eval("ShopID")%>'></asp:HiddenField>
                                </th>
                                <td style="">
                                    <%# Eval("PosID")%>
                                </td>
                                <td style="">
                                    <%# Eval("Shopname")%>
                                </td>
                                <td style="">
                                    <%# Eval("ProvinceName")%>
                                    ，<%# Eval("CityName")%></td>
                                <td style="">
                                    <%# Eval("DealerName")%>
                                    <%--<asp:Label ID="lblDealerID" runat="server" Text='<%# Eval("DealerID")%>' Visible="false"></asp:Label>--%>
                                    <asp:HiddenField ID="lblDealerID" runat="server" Value='<%# Eval("DealerID")%>'></asp:HiddenField>
                                </td>
                                <td style="">
                                    <asp:HiddenField ID="lbl_popnum" runat="server" Value='<%# Eval("POPSumNum")%>'></asp:HiddenField>
                                    <a href='SendToDealerInfo.aspx?id=<%# Eval("ShopID")%>&sid=<%= hidSupplierID.Value %>&did=<%# Eval("DealerID")%>'>
                                        <%# Eval("POPSumNum")%>
                                    </a>
                                </td>
                                <td style="">
                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="AddOrDeleteIDsBy(this,'')"/></td>
                                <td style="display: none">
                                    <%--<asp:Label ID="lbfx" runat="server" Text='<%# Eval("FXID")%>'></asp:Label>--%>
                                    <asp:HiddenField ID="lbfx" runat="server" Value='<%# Eval("FXID")%>'></asp:HiddenField>
                                </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" id="ArriveInfo" style="margin-top: 10px; float: left; margin-left: 20px;
                width: 90%">
                <tr>
                    <td style="width: 30%; height: 30px;">
                        POP发起ID：</td>
                    <td style="text-align: left; height: 30px;">
                        <asp:DropDownList ID="ddlPOPID" runat="server" CssClass="txtwith">
                        </asp:DropDownList><span style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 30px;">
                        发 货 单 号：</td>
                    <td style="text-align: left; height: 30px;">
                        <asp:TextBox runat="server" ID="txtGoodsOrderNO" CssClass="txtwith"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;预计收货时间： &nbsp;&nbsp;
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_YJSHDate" CssClass="txtwith" onfocus="setday(this)" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        物 流 公 司：</td>
                    <td style="text-align: left">
                        <asp:DropDownList runat="server" ID="ddlCompanyName" CssClass="txtwith">
                        </asp:DropDownList><span style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        发货地址：</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_SendAddress" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        收货人：</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_Consignee" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        收货人移动电话：</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_ConsigneeMobile" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        收货固定电话：</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_ConsigneePhone" CssClass="txtwith" runat="server"></asp:TextBox><span
                            style="margin-left: 5px; color: red">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                        备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<br />
                        <span style="color: red">主要填写发货单中所包括的货物明细</span></td>
                    <td style="text-align: left">
                        <asp:TextBox runat="server" ID="txtRemarks" CssClass="txtwith" TextMode="MultiLine"
                            Height="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;">
                    </td>
                    <td style="text-align: left">
                        <asp:Button runat="server" Text="发   货" ID="btnAdd" CssClass="qr0" OnClientClick="return CheckAddInfo();"
                            OnClick="btnAdd_Click"></asp:Button>
                            
                            
                       <%--<asp:Button runat="server" Text="选择直属客户" ID="btnReSelect" CssClass="qr0" OnClick="btnReSelect_Click"
                           ></asp:Button>--%>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidSupplierID" runat="server" />
        </div>
    </form>
</body>
</html>

