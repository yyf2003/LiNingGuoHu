<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allotarea_getShopByarea.aspx.cs" Inherits="WebUI_Supplier_allotarea_getShopByarea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
      <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
      <script language="javascript" type="text/javascript" src="../../js/SearchInPage.js"></script>
            <script language="javascript" type="text/javascript" src="../../js/ReturnTop.js"></script>
      <script language="javascript" type="text/javascript">
		function exit() {
		var s =document.getElementsByName("shopcheck");
		var s2="";
		//alert(s.length);
		for( var i = 0; i < s.length; i++ )
			{
			if ( s[i].checked ){
			 s2 += s[i].value+',';
			}
			}
			s2 = s2.substr(0,s2.length-1);

		window.returnValue = s2;
		window.close();
}
</script> 
 <style type="text/css">
  
  body           {font-size: 9pt;}
  table          {font-size: 9pt; cursor: default; margin: 0;}
  tr             {height: 20;}
  tr.over        {font-size: 9pt; color: #ffffff; background-color: #66aadd; cursor: default;}
  tr.out         {font-size: 9pt; color: #ffffff; background-color: #004477; cursor: default;}
  div.rm_div     {position: absolute; filter: Alpha(Opacity='95'); display: none; border: 2px outset #3377aa; background-color: #004477; width: 0; height: 0;}
  hr.sperator    {border: 1px inset #3377aa;}
  
  </style>
<script language="javascript"  type="text/javascript">

  var menu = new RightMenu();
  menu.AddItem("Top","返回顶端","rbpm",null);
   document.writeln(menu.GetMenu());
  </script>
  

</head>
<body onunload="javascript:exit();"  oncontextmenu="self.event.returnValue=false">
    <form id="form1" runat="server">
    <div>
        <div style="font-size:14px"> 
            <span style="font-weight:bold">搜 索：&nbsp;&nbsp;&nbsp;&nbsp;</span><input id="searchstr" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;<input id="Button1"  onclick="javascript:findIt();" type="button" value="查 找" /></div>
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table class="table" style="width:100%">
        <tr>
        <th>选择</th><th>店铺店号</th><th>店铺名称</th><th>店铺地址</th><th>店铺电话</th><th>直属客户</th>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
        <td>
            <input name="shopcheck" checked="checked" type="checkbox" value='<%#Eval("ShopID") %>' /></td><td><%#Eval("PosID")%></td><td><%#Eval("Shopname")%></td><td><%#Eval("PostAddress") %></td><td><%#Eval("shopPhone")%></td><td><%#Eval("FXName")%></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="width:100%; text-align:center">
        <input id="btn_close" type="button" onclick="exit();"; value="关 闭" /></div>
    </form>
</body>
</html>

