<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerInfoList.aspx.cs" Inherits="WebUI_PhysicalDistribution_DealerInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发货到一级客户</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/calendar.js"> </script>

    <script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

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
	            IsAllCheck = 1;
	            selectSpan.html("取消");
	            selectSpan.attr("title","全部取消");
	        }
	        else
	        {
	            chk.removeAttr("checked");//取消
	            IsAllCheck = 0;
	            selectSpan.html("全选");
	            selectSpan.attr("title","全部选择");
	        }
	    }
	    
	    
	    function GetDealerList()
	    {
	        var cityID=$("#DDL_city").val();
	        GetdealerList(cityID);
	        GetdealerIDList(cityID);
    	}
    	
	    function SetChange(obj)
	    {
	        
	        var selectedValue = obj.value;
	        $("#ddl_dealers").val(selectedValue);
	    }
	    function SetChanges(obj)
	    {
            var selectedValue = obj.value;
	        $("#ddl_dealer").val(selectedValue);
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
                <tr>
                    <td style="width: 15%;">
                        所在省份：</td>
                    <td style="width: 30%;" align="left">
                        &nbsp;<asp:DropDownList ID="DDL_Province" CssClass="txtwith" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="DDL_Province_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择省</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="width: 15%;">
                        地级城市：</td>
                    <td align="left">
                        &nbsp;<asp:DropDownList ID="DDL_city" CssClass="txtwith" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="DDL_city_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择地级城市</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%;">
                        &nbsp;一级客户编号：
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_dealers" runat="server" CssClass="txtwith" onchange="SetChanges(this)">
                            <asp:ListItem Value="0">请选择一级客户编号</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                    <td style="width: 15%;">
                        一级客户：</td>
                    <td style="width: 30%;" align="left">
                        <asp:DropDownList ID="ddl_dealer" runat="server" CssClass="txtwith" onchange="SetChange(this)">
                            <asp:ListItem Value="0">请选择一级客户</asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
                </tr>
                <%--<tr>
                    <td style="width: 15%; text-align: right">
                        店铺编号：</td>
                    <td style="width: 30%;">
                        &nbsp;<asp:TextBox runat="server" ID="txtShopID" CssClass="txtwith"></asp:TextBox></td>
                    <td style="width: 15%; text-align: right">
                        店铺名称：
                    </td>
                    <td>
                        &nbsp;<asp:TextBox runat="server" ID="txtShopName" CssClass="txtwith"></asp:TextBox></td>
                </tr>--%>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
            <table class="table" id="ShopList" style="margin-top: 10px; float: left; margin-left: 20px;
                width: 100%">
                <tr>
                    <th style="height: 30px; width: 10%">
                        流水号</th>
                    <th style="width: 30%">
                        一级客户名称</th>
                    <th style="width: 15%">
                        联系人名称</th>
                    <th style="width: 15%">
                        联系人电话</th>
                    <th style="width: 20%">
                        联系地址</th>
                    <th style="width: 10%">
                        查看</th>
                </tr>
                <asp:Repeater runat="server" ID="RepShopList">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 25px;">
                                <%# Eval("SNumberID")%>
                            </td>
                            <td style="height: 25px;">
                                <%# Eval("DealerName")%>
                            </td>
                            <td style="height: 25px;">
                                <%# Eval("Contactor")%>
                            </td>
                            <td style="height: 25px;">
                                <%# Eval("ContactorPhone")%>
                            </td>
                            <td style="height: 25px;">
                                <%# Eval("Address")%>
                            </td>
                            <td style="height: 25px;">
                                <a href="DistributorsInfoList.aspx?DealerId=<%#Eval("DealerId")%>">查看从属客户</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <asp:HiddenField ID="hidSupplierID" runat="server" />
        </div>
    </form>
</body>
</html>
