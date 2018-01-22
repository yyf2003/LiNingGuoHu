<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPImgSet.aspx.cs" Inherits="WebUI_POPLanuch_POPImgSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>POP图片设置</title>
            <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

            <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
            <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />
            <script language="javascript" src="../../js/jquery.min.js" type="text/javascript"></script>    
            <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>   
            <script type="text/javascript">
              // 判断输入是否是一个整数
                function isint(str)
                {
	                var result=str.match(/^(-|\+)?\d+$/);
	                if(result==null) return false;
	                return true;
                }
                //校验文本是否为空
                function checknull(field)
                {
	                if (field.value =="")
  	                {
    	                return false;
  	                }
  	                return true;
  	            }

  	            function openWin(ImageID) {
  	                var returnValue = showModalDialog('POPPhotoSetCity.aspx?ImageID=' + ImageID + '', 'example04', 'dialogWidth:950px;dialogHeight:750px;dialogLeft:200px;dialogTop:100px;center:yes;help:yes;resizable:yes;status:yes');
  	                if (returnValue == "ok") {
  	                    window.location.href = window.location.href;
  	                }
  	            } 
            </script>


</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <div style="font-size:14px;color:Red">设置POP发起周期--》 <a href="POPLaunchTwo.aspx?POPID=<%=POPID %>" style="color:Red">POP产品系列图样上传</a>--》<a href="POPImgSet.aspx?POPID=<%=POPID %>" style="color:Red">图样设置</a></div>
    <br />
    
       
    <div style="font-size:14px; color:Red">请将不同比例的同一图样 设为相同的等级</div>
     <table class="table"><tr>
        <td style="width:300px;"> 画面可用位置
        </td><td>同系列画面优先级</td><td style="width:15%">
            图片编号</td> <td>产品系列
        </td><td >图片
        </td></tr>
        <tr>
        <td style="width:300px;"> 
        </td><td>
            <asp:DropDownList ID="first_prolevel" runat="server"  AutoPostBack="true"  Width="70%" OnSelectedIndexChanged="first_prolevel_SelectedIndexChanged">
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
           </td><td style="width:15%">
               &nbsp;</td> <td>
        </td><td >
        </td></tr>
       <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
           <tr>
        <td style=" vertical-align:top">
            <asp:CheckBoxList ID="chkSetPOPList" runat="server" DataSource="<%#GetPOPSeat()%>" DataTextField="seat" DataValueField="SeatID" RepeatColumns="2">
            </asp:CheckBoxList>
        </td> 

        <td>
         <asp:DropDownList ID="DDL_ProLevel" runat="server"  Width="70%">
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
         <asp:TextBox ID="txt_imgLevel" runat="server" CssClass="txtwith" Text='<%#Eval("ImageLevel") %>'></asp:TextBox>
        </td> 
        <td>
           <a href='#' onclick='openWin(<%#Eval("ImageID")%>)'>
            <%#Eval("ProductTypename")+"--"+Eval("ProductLinename") %></a>
            <asp:HiddenField ID="imgID" Value='<%#Eval("ImageID") %>' runat="server" />
        </td> <td><img alt='' style="height:200px; width:250px" src='<%#Eval("SmallImageUrl")%>' />
        </td></tr>
        </ItemTemplate>
        
        <FooterTemplate></FooterTemplate>
        
        </asp:Repeater></table>
        <br />
        <div style="width:900px; text-align:center">
            <input id="Button1" class="qr0" type="button"  value="继续上传图片" style="width: 96px" onserverclick="Button1_ServerClick" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btn_Save" CssClass="qr0" runat="server" Text="下一步" OnClick="Btn_Save_Click" /></div>
    </div>
    </form>
</body>
</html>
