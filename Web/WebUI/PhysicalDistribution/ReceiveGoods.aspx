<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReceiveGoods.aspx.cs" Inherits="WebUI_PhysicalDistribution_ReceiveGoods" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>收货查询</title>
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
    <script language="javascript" type="text/javascript" src="javascript/ReceiveGoods.js" ></script>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*分页样式风格*/
        .paginator { font: 11px Arial, Helvetica, sans-serif;padding:10px 10px 10px 0; margin: 0px; float:right;}
        .paginator a {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
        .paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
        .paginator .cpb {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
        .paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;} 
    </style>
    <script language ="javascript" type="text/javascript">
	function GetcityList()
	{
		var pro=$("#DDL_Province").val();
		GetCityname(pro);
	}
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
function btn_goods_onclick() {
    submitdata('<%=UserID %>','<%=NewPOPID %>');
}

    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:100%; height:auto;">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">
        一级客户收货</div>
        <div style="margin-top:20px; float:left; margin-left:20px; width:100%">
    <table class="table">
			<tr style="display:none">
				<td style="width:15%;">店铺编号：</td>
				<td style="width:30%;">&nbsp;<asp:TextBox ID="Txt_PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width:15%;">店铺名称：</td>
				<td style="width:30%;">&nbsp;<asp:TextBox ID="Txt_ShopName" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width:15%;">
                    发货单号：</td>
				<td style="width:30%;">&nbsp;<asp:TextBox ID="txt_FHID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width:15%;">一级客户：</td>
				<td>&nbsp;<asp:DropDownList ID="ddl_dealer" CssClass="txtwith" onchange="GetFxlist()" runat="server"></asp:DropDownList></td>
			</tr>
			<tr style="display:none">
			<td>直属客户：</td><td><asp:DropDownList ID="DDL_fx" runat="server">
                            <asp:ListItem Value="0">请选择店铺的直属客户</asp:ListItem>
                        </asp:DropDownList></td><td></td><td></td>
			</tr>
			<tr>
                <td align="center" colspan="4" style="padding-left: 2%;">
                   <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="qr0" OnClick="btnSearch_Click" /></td>
			</tr>
	</table>
	<br />
	  <span style="FONT-WEIGHT: bold; FONT-SIZE: 14px; CURSOR: hand; COLOR: #cc3333; TEXT-DECORATION: underline" onclick="$('#recevieGoods').fadeIn(200);"> 点击填写收货反馈单</span>
        <table id="recevieGoods" style="display:none" class="table" >
            <tr>
                <td style="width: 70px">
                  操作人：
                </td>
                <td style="width: 300px">
                   <%=Username %></td>
                <td style="width:70px">收货时间：
                </td>
                 <td style="width: 300px">
                     <asp:TextBox ID="txt_time" runat="server" onclick="setday(this,document.getElementById('txt_time'))" CssClass="txtwith"></asp:TextBox></td>

            </tr>

            <tr>
                 <td  valign="top">
                     &nbsp;客户评分：</td>
                <td valign="top">
                    <select id="fs" style="width: 138px" runat="server">
                        <option selected="selected" value="3">3</option>
                        <option value="5">5</option>
                        <option value="1">1</option>
                    </select>
                </td>
                 <td >
                客户反馈：</td><td >
                    <asp:TextBox ID="txt_fk" runat="server" CssClass="txtwith" TextMode="MultiLine" Height="52px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btn_goods" OnClientClick="return btn_goods_onclick();" runat="server" Text="确认收货" CssClass="qr0" OnClick="btn_goods_Click" /></td>

            </tr>
        </table>
	<br />
     <table class="table">
	    <tr>
	        
	        <th>
                订单号</th>
	        <th style="width:23%">
                发货日期</th>
	        <th style="">
                备注</th>
                <th style="">
                店铺数量</th>
	        <th style="width:23%">
                发货供应商</th>
	 
	        <th style=""><span id="selectSpan" onclick="AllCheck();">全选</span></th>
	    </tr>
	    <asp:Repeater runat="server" id="RepShopList">
		<ItemTemplate>
		<tr>
		    <td style="height:25px;">
                <asp:HiddenField ID="hf1" Value='<%# Eval("goodsorderno")%>' runat="server" />
                <%# Eval("goodsorderno")%></td>
	        <td style=""><%# Eval("FHDate")%></td>
	        <td style=""><%# Eval("Remars")%></td> 
	         <td style=""><%# Eval("ShopCount")%></td>
	        <td style=""><%# Eval("SupplierName")%></td>
	      
	        <td style="">
                <asp:CheckBox ID="cb" runat="server" /></td>	        
	    </tr>
		
		</ItemTemplate>	   	
	   	</asp:Repeater>
    </table>
    <webdiyer:AspNetPager CssClass="paginator" CurrentPageButtonClass="cpb"  ID="ListPages" runat="server" 
        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页"  PageSize="100" Width="900px" OnPageChanging="ListPages_PageChanging" ></webdiyer:AspNetPager>
    </div>
    </div>
    </form>
</body>
</html>
