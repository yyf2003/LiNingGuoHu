<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RackList.aspx.cs" Inherits="WebUI_Promotion_Shops_RackList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.7.2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 95%">
        <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
            color: #c86000;"> &gt;&gt; <asp:Label ID="labTitle" runat="server" Text="店铺道具信息"></asp:Label>
          </div>
            
           
    </div>
    <br />
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
          <HeaderTemplate>
             <table class="table" style=" text-align:center;width:100%;">
               <tr>
                  <th>
                     序号
                  </th>
                  <th>
                     所属位置
                  </th>
                  
                  <th>
                     道具名称
                  </th>
                  <th>
                     道具类型
                  </th>
                  
                  <th>
                     数量
                  </th>
               </tr>
             
          </HeaderTemplate>
          <ItemTemplate>
             <tr>
                <td>
                  <%#Container.ItemIndex+1 %>
                </td>
                <td id="seat" runat="server">
                   <%#Eval("Seat")%>
                </td>
                <td>
                <%#Eval("RackName")%>
                </td>
                <td>
                <%#Eval("RackType")%>
                </td>
                <td>
                <%#Eval("RackCount")%>
                </td>
                
             </tr>
          </ItemTemplate>
          <FooterTemplate>
             <%if (Repeater1.Items.Count == 0)
               { %>
                 <tr>
                    <td colspan="5">--无信息--</td>
                 </tr>
             <%} %>
             </table>
          </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
