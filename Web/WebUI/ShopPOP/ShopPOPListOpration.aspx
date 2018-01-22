<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShopPOPListOpration.aspx.cs" Inherits="WebUI_ShopPOP_ShopPOPListOpration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <base target="_self">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>

    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>
<script type="text/javascript">
   function openWin(id,shopid,popid)
   {
       var returnValue = showModalDialog('EditPOP.aspx?id='+id+'&shopid='+shopid+'&popid='+popid+'','example04','dialogWidth:950px;dialogHeight:750px;dialogLeft:200px;dialogTop:100px;center:yes;help:yes;resizable:yes;status:yes');

       if(returnValue=="ok")
       {
           window.location.href=window.location.href;
       
       }     
   }   
   function setEnable()
   {
       // $("#btn_save").attr('disabled',true);
       //document.getElementById("btn_save").disabled=true;
       $("#td_btn").css("display","none");       
       return true;
   }
</script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
        <div style="color:Red; font-weight:bold; margin:0px auto 8px 50px;"><a href="ShopPOPEditList.aspx">查看订单审核情况</a></div>
        <table class="table">
            <tr>
                <td style="width: 15%">
                    店铺编号：</td>
                <td style="width: 30%">
                    <asp:TextBox ID="PosID" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    店铺零售属性：</td>
                <td style="width: 30%">
                    <asp:TextBox ID="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    店铺名称：</td>
                <td colspan="3">
                    <asp:TextBox ID="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    店铺简称：</td>
                <td colspan="3">
                    <asp:TextBox ID="txt_samplename" runat="server" CssClass="txtwith"></asp:TextBox></td>
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
                <td style="text-align: left">
                    店铺级别：</td>
                <td>
                    <asp:TextBox ID="DDL_shopLevel" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="text-align: left">
                    店铺产权关系：</td>
                <td>
                    <asp:TextBox ID="txt_shopownership" runat="server" CssClass="txtwith"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">
                    店铺类型：</td>
                <td>
                    <asp:TextBox ID="DDL_Shoptype" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="text-align: left">
                    店铺形象属性：</td>
                <td>
                    <asp:TextBox ID="DDL_shopVI" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    省名称：</td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_Pro" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
                <td style="width: 15%">
                    地级城市名称：</td>
                <td>
                    <asp:TextBox ID="Txt_City" runat="server" CssClass="txtwith"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15%">
                    区县级城市名称：</td>
                <td>
                    &nbsp;<asp:TextBox ID="txt_town" runat="server" CssClass="txtwith"></asp:TextBox></td>
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
                <td>
                    <asp:TextBox ID="Txt_LinkPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%;">
                    店铺零售负责人：</td>
                <td>
                    &nbsp;<asp:TextBox ID="Txt_ShopMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    零售负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_ShopMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    李宁省区VM负责人：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="text-align: left">
                    李宁省区VM负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_VMMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    李宁DSR负责人：</td>
                <td>
                    <asp:TextBox ID="Txt_DSRMaster" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="text-align: left">
                    李宁DSR负责人电话：</td>
                <td>
                    <asp:TextBox ID="Txt_DSRMasterPhone" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    店铺Email：</td>
                <td>
                    <asp:TextBox ID="Txt_Email" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    店铺传真号码：</td>
                <td>
                    <asp:TextBox ID="Txt_FixNumber" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    邮政编码：</td>
                <td>
                    <asp:TextBox ID="Txt_PostCode" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    是否李宁公司统一支持安装：</td>
                <td>
                    <asp:TextBox ID="Txt_install" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    POP配送地址：</td>
                <td colspan="3">
                    <asp:TextBox ID="Txt_PostAddress" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    一级客户：</td>
                <td>
                    <asp:TextBox ID="Txt_Dealer" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="text-align: left">
                    直属客户：</td>
                <td>
                    <asp:TextBox ID="txt_fx" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    店铺营业面积：</td>
                <td>
                    <asp:TextBox ID="Txt_Shoparea" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox>㎡</td>
                <td>
                    店铺固定电话：</td>
                <td>
                    <asp:TextBox ID="txt_shopphone" runat="server" CssClass="txtwith" Width="60%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 15%">
                    关店时间：</td>
                <td>
                    <asp:TextBox ID="Txt_CloseTime" runat="server" CssClass="txtwith"></asp:TextBox></td>
                <td style="width: 15%">
                    关店人：</td>
                <td>
                    <asp:TextBox ID="Txt_CloseUser" runat="server" CssClass="txtwith"></asp:TextBox></td>
            </tr>
        </table>
		<br />		
		<table class="table" style="width: 110%">
			<tr>
				<td style="height: 54px">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:BoundField HeaderText="POP位置" DataField="POPseat" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="图片编号" DataField="SeatNum" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="位置描述" DataField="SeatDesc" >
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="男女区域" DataField="Sexarea" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
              <asp:BoundField HeaderText="POP实际制作宽" DataField="realWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="PO实际制作高" DataField="realHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面宽" DataField="POPWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面高" DataField="POPHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
              <asp:BoundField HeaderText="POP可视画面位置" DataField="POPplwz" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP画面偏离角度" DataField="POPpljd" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="POPArea" HeaderText="POP面积">
                <ItemStyle Width="80px" />
            </asp:BoundField>

            <asp:BoundField HeaderText="POP材质" DataField="POPMaterial" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="男女区域" DataField="Sexarea" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="图片编号" DataField="SeatNum" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
                 <asp:BoundField HeaderText="是否粘于玻璃上" DataField="Glass" >
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="确认画面订单">
                <ItemTemplate>
                    <%--<a href="#" onclick='openWin(<%#Eval("ID") %>,<%=shopid %>,<%=POPID %>)'>确认画面订单</a>--%>
                    <asp:HiddenField ID="h_IsHide" Value='<%#Eval("IsHide") %>' runat="server" />
                    <asp:HiddenField ID="h_id" Value='<%#Eval("id") %>' runat="server" />                    
                    <%--<a href ="EditPOP.aspx?id=<%#Eval("ID") %>&shopid=<%=shopid %>&popid=<%=POPID %>">确认画面订单</a>--%>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="是否提交订单" DataField="IsSubmit" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="画面">
                <ItemTemplate>                   
                    <asp:HiddenField ID="h_popInfoId" runat="server" Value='<%#Eval("ID") %>' />
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    			</asp:GridView>
				</td>
			</tr>
			<tr>
				<td id="td_btn" style="text-align:center; height:60px;"><%--OnClick="btn_save_Click"--%>
					<asp:Button id="btn_save" runat="server" cssclass="qr0" text="生成订单"  OnClientClick="return setEnable()" OnClick="btn_save_Click"/>
				</td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
