<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneDsrCheckshop.aspx.cs" Inherits="WebUI_DSRCheck_OneDsrCheckshop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../CSS/TableCss.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:20px">
      <div style="margin-left:20px;font-size:14px;color:#c86000"><%=POPID %>期<%=checkname%>检查店铺列表</div>
      <br />
      <div style="margin-left:40px">
          <table class="table" style="width:100%">
              <tr>
                  <td>
                      <asp:Repeater ID="Repeater1" runat="server">
                      <HeaderTemplate>
                      <table class="table">
                      <tr>
                     <th>序号</th> <th> 编号</th> <th>店铺名称 </th><th>级别</th> <th> 省市</th> <th>供应商 </th> <th>一级客户 </th> <th>查看 </th> 
                      </tr>
                      </HeaderTemplate>
                      <ItemTemplate>
                      <tr>
                      <td></td> <td><%#Eval("PosID") %></td> <td><%#Eval("Shopname") %></td> <td><%#Eval("ShopLevel")%></td> <td><%#Eval("ProvinceName")%>,<%#Eval("CityName")%></td><td><%#Eval("SupplierName")%></td> <td><%#Eval("DealerName")%></td> <td><a href ='ResultInfo.aspx?shopid=<%#Eval("shopid")%>&Did=<%#Eval("DataID")%>'>查看</a></td>
                      </tr>
                      </ItemTemplate>
                      <FooterTemplate>
                      </table>
                      </FooterTemplate>
                      </asp:Repeater>
                  </td>
                  
              </tr>
              
          </table>
      </div>
    </div>
    </form>
</body>
</html>
