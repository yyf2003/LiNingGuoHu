<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="WebUI_Promotion_Supprier_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" 
            onitemcommand="Repeater1_ItemCommand" >
            <HeaderTemplate>
                <table class="table" style="text-align: center;">
                    <tr>
                        <th style="width: 80px;">
                            序号
                        </th>
                        <th>
                            供应商名称
                        </th>
                        <th>
                            简称
                        </th>
                        <th>
                            联系人
                        </th>
                        <th>
                            联系电话
                        </th>
                        <th>
                            负责区域
                        </th>
                        
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <%#Eval("SupplierName")%>
                    </td>
                    <td>
                        <%#Eval("ShortName")%>
                    </td>
                    <td>
                        <%#Eval("Contacter")%>
                    </td>
                    <td>
                        <%#Eval("ContactPhone")%>
                    </td>
                    <td>
                        <a href="SupplierArea.aspx?id=<%#Eval("SupplierID") %>">查看</a>
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%if (Repeater1.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="12" style="text-align: center;">
                        --暂无信息--
                    </td>
                </tr>
                <%} %>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
