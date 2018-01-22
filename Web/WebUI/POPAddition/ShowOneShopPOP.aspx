<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowOneShopPOP.aspx.cs" Inherits="WebUI_POPAddition_ShowOneShopPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺发货信息</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>

    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js">
    </script>

    <script language="javascript" type="text/javascript" src="../../js/jquery.corner.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>

    <script language="javascript" type="text/javascript" src="../../js/common.js"></script>

    <script type="text/javascript">
        var IsAllCheck = 0;
        var checkval="";
        var shopid =<%=shopid%>;
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
	    
	    function GetCheckVal()
	    { 
	        var checkval="";
	         var chk =document.getElementsByTagName ("input");
	         for(var i =0;i<chk.length;i++)
	         { 
	             
	             if(chk[i].type=="checkbox")
	             {
	                if(chk[i].checked)
	                 {
	                      checkval +=chk[i].id+",";
	                 }
	             }
	         }
	        if(checkval!="")
	        {
	         checkval=checkval.substring(0,checkval.length-1);
	        }
	        else
	        {
	          $.prompt("请选择要增补的项！");
	          return false;
	        } 
	         window.location='AddPOPAddition.aspx?Shopid='+shopid+'&POPID='+checkval;
	      
	       
	    }
    </script>

    <script type="text/javascript" src="../../js/ShowDIV.js"></script>

</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat;">
    <form id="form1" runat="server">
        <div>
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <%=Shopname %>
                POP信息</div>
            <table class="table">
<tr>
				<td style="width: 15%">店铺编号：</td>
				<td style="width: 30%"><asp:TextBox id="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺零售属性：</td>
				<td style="width: 30%">
				<asp:TextBox id="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="width: 15%;">店铺名称：</td>
				<td colspan="3">
				<asp:TextBox id="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺简称：</td>
				<td colspan="3">
				<asp:TextBox id="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
            <tr>
                <td>
                    区域名称：</td>
                <td>
                    <asp:TextBox ID="txt_areaname" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td>
                    客户身份：</td>
                <td>
                    <asp:TextBox ID="txt_customerCard" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" text-align:left">店铺级别：</td>
				<td >
                    <asp:TextBox ID="DDL_shopLevel" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    店铺产权关系：</td>
				<td>
				<asp:TextBox id="txt_shopownership"  CssClass="txtwith" runat="server"></asp:TextBox>
				&nbsp;</td>
			</tr>
			<tr>
				<td style=" text-align:left">店铺类型：</td>
				<td >
                    <asp:TextBox ID="DDL_Shoptype" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    店铺形象属性：</td>
				<td>
                    <asp:TextBox ID="DDL_shopVI" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    省名称：</td>
				<td>&nbsp;<asp:TextBox id="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
				<td style="width: 15%">
                    地级城市名称：</td>
				<td>
				<asp:TextBox id="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
			</tr>
					<tr>
				<td style="width: 15%">
                    区县级城市名称：</td>
				<td>&nbsp;<asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺状态：</td>
				<td>
				<asp:TextBox ID="Txt_ShopState" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
            <tr>
                <td style="width: 15%">
                    上级客户集团编号：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txt_CustomerGroupID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    上级客户级别：</td>
                <td>
                    <asp:TextBox ID="txt_CustomerGroupName" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			
			<tr>
				<td style="width: 15%">
                    店长：</td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_LineMan" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    店长移动电话：</td>
				<td><asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺零售负责人：</td>
				<td>&nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    零售负责人电话：</td>
				<td><asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
                <td style=" text-align:left">
                    李宁省区VM负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁省区VM负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
			<tr>
				<td style=" text-align:left">
                    李宁DSR负责人：</td>
                <td >
                    <asp:TextBox ID="Txt_DSRMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style=" text-align:left">
                    李宁DSR负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_DSRMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    店铺Email：</td>
				<td><asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    店铺传真号码：</td>
				<td><asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">邮政编码：</td>
				<td><asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">
                    是否李宁公司统一支持安装：</td>
				<td>
				<asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">POP配送地址：</td>
				<td colspan="3"><asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    一级客户：</td>
				<td >
				<asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style=" text-align:left">
                    直属客户：</td>
				<td>
                    <asp:TextBox ID="txt_fx" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
			<tr>
			<td>
                店铺营业面积：</td><td>
                    <asp:TextBox ID="Txt_Shoparea" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox>㎡</td><td>
                        店铺固定电话：</td><td>
                        <asp:TextBox ID="txt_shopphone" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="width: 15%">
                    关店时间：</td>
				<td>
				<asp:TextBox ID="Txt_CloseTime" runat="server" CssClass="txtwith"></asp:TextBox></td>
				<td style="width: 15%">关店人：</td>
				<td><asp:TextBox ID="Txt_CloseUser" runat="server" CssClass="txtwith"></asp:TextBox></td>
			</tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="width: 15%">
                    </td>
                    <td>
                        &nbsp; <a href="#" onclick="history.back(-1)">返回上一页</a></td>
                </tr>
            </table>
            <br />
            <table class="table">
                <caption style="font-weight: bold">
                    POP信息列表：</caption>
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
                    <th>
                     
                        <span id="selectSpan" title="全选" onclick="AllCheck();" style="cursor: pointer;">选择</span></th>
                </tr>    <%=NoInfo %>
                <asp:Repeater runat="server" ID="RepPOPList">
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
                            <td align="center">
                                <input id="<%#Eval("ID") %>" type="checkbox" name="cb_pop" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table class="table" style="margin-top: 3px;">
                <tr>
                    <td align="center">
                        <input id="btn_ok" type="button" value="确   定" class="qr0" onclick="return GetCheckVal();" runat="server"  /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
