<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEveryShopPOP.aspx.cs" Inherits="WebUI_Analysis_AddEveryShopPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../GetBaseInfo/autoComplete.js"></script>
    <style type="text/css">
.txtwith{
	
	width:95%;

	border-width:0px;
	border-color:black;
    readonly:expression(this.readOnly=true);
}
td{background-color:white;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table">
            <tr>
				<td style="width: 15%">店铺编号：</td>
				<td style="width: 30%"><asp:TextBox id="PosID" runat="server" CssClass="txtwith" ></asp:TextBox></td>
				<td style="width: 15%">
                    店铺零售属性：</td>
				<td style="width: 30%">
				<asp:TextBox id="Txt_Saletype" runat="server" CssClass="txtwith"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="width: 15%;">店铺名称：</td>
				<td colspan="3">
				<asp:TextBox id="Txt_Shopname" runat="server" CssClass="txtwith"></asp:TextBox></div></td>
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
                    &nbsp;<asp:TextBox ID="txt_CustomerGroupID" runat="server" CssClass="txtwith" ></asp:TextBox></td>
                <td style="width: 15%">
                    上级客户级别：</td>
                <td>
                    <asp:TextBox ID="txt_CustomerGroupName" runat="server" CssClass="txtwith"></asp:TextBox></div></td>
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
				</td>
				<td style="width: 15%"></td>
				<td><a href="#" onclick="history.back(-1)">返回上一页</a>
		</td>
		</tr>
        </table>
		<br />
		<table class="table" style="width: 110%">
			<tr>
				<td style="height: 54px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333">
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
                            <asp:TemplateField HeaderText="价格">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("totalprice")%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="POPMaterial" HeaderText="POP材质">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductLine" HeaderText="POP故事包">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="收发货">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" Text='<%#Eval("state").ToString()=="2"?"已收货":"未收货"%>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                                <asp:BoundField HeaderText="是否为双面" DataField="TwoSided" >
                <ItemStyle Width="50px" />
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
