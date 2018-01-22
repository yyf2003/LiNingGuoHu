<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPImageList.aspx.cs" Inherits="WebUI_POPLanuch_POPImageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>POP图片设置</title>
            <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <div style="font-size:14px;color:Red">设置POP发起周期--》 <a href="POPLaunchTwo.aspx?POPID=<%=POPID %>" style="color:Red">POP产品系列图样上传</a>--》<a href="POPImgSet.aspx?POPID=<%=POPID %>" style="color:Red">图样设置</a></div>
    <br />
    
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
    <div style="font-size:14px; color:Red">请将不同比例的同一图样 设为相同的等级</div>
     <table class="table"><tr>
        <td style="width:300px;"> 图片描述
        </td><td>系列推广优先设置</td><td style="width:15%">图片优先级
        </td> <td>产品系列
        </td><td >图片
        </td></tr>
        <tr>
        <td style="width:300px;"> 
        </td><td>
            
           </td><td style="width:15%">
        </td> <td>
        </td><td >
        </td></tr>
      
        </HeaderTemplate>
        <ItemTemplate>
           <tr>
        <td style="height:200px; vertical-align:top">
            <asp:TextBox ID="imgRemark" runat="server" CssClass="txtwith" TextMode="MultiLine" Height="190px"></asp:TextBox>
        </td> 

        <td>
         <asp:DropDownList ID="DDL_ProLevel" runat="server"  DataSource ='<%#Getprolevel(Eval("productlevel")) %>' DataValueField="prolevel" Width="70%">
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="DDL_imgLevel"  DataSource ='<%#Getimglevel(Eval("imageLevel")) %>' DataValueField="imglevel"   runat="server" Width="70%">
             
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>0</asp:ListItem>
            </asp:DropDownList>
        </td> <td><%#Eval("ProductTypename")+"--"+Eval("ProductLinename") %>
            <asp:HiddenField ID="imgID" Value='<%#Eval("ImageID") %>' runat="server" />
        </td> <td><img alt='' style="height:200px; width:250px" src='<%#Eval("SmallImageUrl")%>' />
        </td></tr>
        </ItemTemplate>
        
        <FooterTemplate></table></FooterTemplate>
        
        </asp:Repeater>
        <br />
        <div style="width:900px; text-align:center">
            <input id="Button1" class="qr0" type="button"  value="继续上传图片" style="width: 96px" onserverclick="Button1_ServerClick" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btn_Save" CssClass="qr0" runat="server" Text="下一步" OnClick="Btn_Save_Click" /></div>
    </div>
    </form>
</body>
</html>
