<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckSelectShops.aspx.cs"
    Inherits="WebUI_Promotion_CheckSelectShops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table" style="text-align: center;width:85%;">
            <tr>
                <td colspan="4" style="text-align: left; padding-left: 15px;">
                    总共记录：<asp:Label ID="labTotalNum" runat="server" Text=""></asp:Label>
                    &nbsp;条
                </td>
            </tr>
            <tr>
                <td style="width: 50px;">
                    序号
                </td>
                <td>
                    店铺名称
                </td>
                <td style="width: 200px;">
                    PosCode
                </td>
                <td style="width: 180px;">
                    省市
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="width: 50px;">
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td>
                            <%#Eval("Shopname") %>
                        </td>
                        <td style="width: 200px;">
                            <%#Eval("PosID") %>
                        </td>
                        <td style="width: 180px;">
                            <%#Eval("ProvinceName")%>，<%#Eval("CityName")%>
                        </td>
                    </tr>
                </ItemTemplate>
                
            </asp:Repeater>
            </table>
    </div>
    </form>
</body>
</html>
