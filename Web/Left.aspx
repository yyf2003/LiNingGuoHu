<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="./css/defalut.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="./js/jquery-1.3.2.min.js"></script>
    <style type="text/css">
<!--
body {
	background-color: #fff;
	
}
-->
</style>
    <script language="javascript" type="text/javascript">
        function showhide(id)
        {
            var m = $(".Content");
            m.hide();
            $(id).fadeIn(1000);
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
<div id="left"  style ="text-align :left ; float :left ; height:100%; ">
    <div id="Div1" class="AquaAccordion">
        <%=strOutput %>       
    </div>
</div>
</form>
</body>
</html>
