<%@ Page Language="C#" AutoEventWireup="true" CodeFile="More.aspx.cs" Inherits="WebUI_Affiche_More" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告更多</title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />
   <style >
      a:link{TEXT-DECORATION: none;color: #000;}
                a:visited {TEXT-DECORATION: none;color: #000;}
                a:active{TEXT-DECORATION: none;color: blue;}
                a:hover{TEXT-DECORATION: none;color: blue;}
   </style> 
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" class="table">
            <tr>
                <td align="center">
                    <asp:Label ID="lblafficetypename" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="width: 900px; margin-top: 3px; " class="table">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="20" Width="900px">
                <Columns>
                    <asp:TemplateField HeaderText="标题" HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="60%"
                        ItemStyle-Width="60%">
                        <ItemTemplate>
                            <a href='ShowAffiche.aspx?ID=<%#Eval("ID") %>'>
                                <%#Eval("Title") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="点击率" ItemStyle-HorizontalAlign="center" DataField="Click" HeaderStyle-Width="10%"
                        ItemStyle-Width="10%" />
                    <asp:TemplateField HeaderText="发表时间" HeaderStyle-Width="20%"
                        ItemStyle-Width="20%">
                        <ItemTemplate>
                            <%#System.DateTime.Parse(Eval("Time").ToString()).ToString("yyyy-MM-dd") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
