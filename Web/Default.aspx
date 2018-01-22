<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs"  Inherits="_Default" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>李宁管理系统</title>
</head>


<frameset  rows="100,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="top.aspx" name="topFrame"  style="DISPLAY:block; background-color:#e7e7e7" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="196,9,*" frameborder="no" border="0" framespacing="0" id="attachucp">
   
    <frame src="left.aspx" name="leftFrame"  style="DISPLAY:block; background-color:#e7e7e7;zoom:1;" scrolling="Yes" noresize="noresize" id="leftFrame" title="leftFrame" />
    <frame src="MainSwith.htm" name="bar"  style="DISPLAY:block; background-color:#e7e7e7;zoom:1;" scrolling="no" noresize="noresize" id="bar" />
    <frame src="WebUI/Affiche/Index.aspx" name="main"  style="DISPLAY:block; background-color:#e7e7e7;zoom:1;" id="main" title="main" />
  </frameset>
</frameset>
<body>

</body>
</html>

