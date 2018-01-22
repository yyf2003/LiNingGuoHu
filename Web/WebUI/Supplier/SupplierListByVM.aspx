<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SupplierListByVM.aspx.cs" Inherits="WebUI_Supplier_SupplierListByVM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../js/GetCityByProvince.js"></script>

    <title>供应商信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;">供应商负责区域管理</div>    
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" style="float:left"
                        ForeColor="#333333" Width="100%" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField HeaderText="序号">
                                <ItemStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="供应商名称" DataField="SupplierName" />
                            <asp:BoundField HeaderText="联系人" DataField="Contacter">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="电话" DataField="ContactPhone">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="供应区域">
                                <EditItemTemplate>
                                    &nbsp;
                                </EditItemTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="L_allotArea" runat="server" CommandName="allotArea"  CommandArgument='<%#Eval("SupplierID") %>'>供应区域</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="放弃">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="L_GiveUp" runat="server" CommandName="GiveUp"  CommandArgument='<%#Eval("SupplierID") %>'>放 弃</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>    
    </div>
    </form>
</body>
</html>
