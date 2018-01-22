<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shouhuo.aspx.cs" Inherits="WebUI_ShopPOP_ShopPOPList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
      <script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
    <script language="javascript" type="text/javascript" src="../../js/calendar.js" ></script>
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>
<script language="javascript" type="text/javascript">
function submitdata()
{
 var chkBoxlist = $("input[type='checkbox']");      //复选框集合
 var checkshopid='';
 var IsCheck=0;
    for(var i = 0; i < chkBoxlist.length; i++)
    {
        if(chkBoxlist[i].checked)
        {
            IsCheck ++;
           // checkshopid=checkshopid+chkBox[i].attr("value")+',';
           //alert(chkBoxlist[i].attr('value'));
        }
    }
    if(IsCheck=0)
    {
      alert('请选择店铺');
      return false;
    }
    
    return confirm("确认提交此收货数据");
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                <td style="width: 15%">
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
        </table>
		<br />
		<table class="table" style="width: 100%">
			<tr>
				<td style="height: 54px">
				<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
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
            <asp:BoundField HeaderText="POP可是画面宽" DataField="POPWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="POP可视画面高" DataField="POPHeight" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
              <asp:BoundField HeaderText="POP可是画面位置" DataField="POPplwz" >
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
            <asp:BoundField HeaderText="橱窗进深" DataField="PlatformLong" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗长" DataField="PlatformWith" >
                <ItemStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="橱窗面积" DataField="PlatformHeight" >
                <ItemStyle Width="80px" />
                 </asp:BoundField>
            <asp:TemplateField HeaderText="收货">
                <ItemStyle Width="60px" />
                <ItemTemplate>
                    <asp:CheckBox ID="CB_choose"  runat="server" />
                    <asp:HiddenField ID="HF1" Value ='<%#Eval("addid") %>' runat="server" />
                
                </ItemTemplate>
            </asp:TemplateField>
  
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
		<br />
        <table id="recevieGoods" class="table" >
            <tr>
                <td style="width: 70px">
                    操作人：
                </td>
                <td style="width: 300px">
                    <%=Username %>
                </td>
                <td style="width: 70px">
                    收货时间：
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txt_time" runat="server"  onclick="setday(this,document.getElementById('txt_time'))" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;客户评分：</td>
                <td valign="top">
                    <select id="fs" runat="server" style="width: 138px">
                        <option selected="selected" value="3">3</option>
                        <option value="5">5</option>
                        <option value="1">1</option>
                    </select>
                </td>
                <td>
                    客户反馈：</td>
                <td>
                    <asp:TextBox ID="txt_fk" runat="server"  TextMode="MultiLine" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="btn_goods" runat="server" CssClass="qr0" OnClick="btn_goods_Click"
                        OnClientClick="return submitdata();" Text="确认收货" /></td>
            </tr>
        </table>
		
    </div>
    </form>
</body>
</html>
