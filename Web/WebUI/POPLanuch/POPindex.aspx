<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPindex.aspx.cs" Inherits="WebUI_POPLanuch_POPindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
          <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div style="margin-left:20px">
         <div style=" width:100%; font-size:14px; font-weight:bold; text-align:left; float:left; color: #c86000;">POP发起未完成列表</div>
         <br />
         <br />
        
         <div style=" font-size:14px; font-weight:bold; text-align:left; float:left;"><a href ='POPLaunchOne.aspx'>重新发起</a></div>
         
         <div>
             <br />
             <br />
             <%=sb.ToString()%>
             &nbsp;</div>
      </div>
    </div>
    </form>
</body>
</html>
