<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="./css/defalut.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    <!--
    body {
	    background-color: #fff;
    	
    }
    .qr0{
        height:23px; 
        width:62px;
	    font-size:12px;
	    cursor:hand;
	    color:#fff;
	    background-color: #ffffff;   
	    background-image:url(./images/login-1_12.gif);
	    background-repeat: repeat;
	    background-attachment:scroll;
	    background-position:center;
	    border:   0   solid   #000000;
	    text-align:   center;
	    padding-top:   3px;}  

    -->
    </style>
    <script language="javaScript" type="text/javascript">
    function showTimeDate(){
        var showTime = document.getElementById("showTime");
        var now = new Date();
        var hour = now.getHours();
        if(hour < 6){showTime.innerText = "凌晨好！"} 
        else if (hour < 9){showTime.innerHTML = "早上好！"} 
        else if (hour < 12){showTime.innerHTML = "上午好！"} 
        else if (hour < 14){showTime.innerHTML = "中午好！"} 
        else if (hour < 17){showTime.innerHTML = "下午好！"} 
        else if (hour < 19){showTime.innerHTML = "傍晚好！"} 
        else if (hour < 22){showTime.innerHTML = "晚上好！"} 
        else {showTime.innerText = "夜里好！"}
    }
    
    function tick() {
       var today = new Date();
       document.getElementById("showTick").innerHTML = today.toLocaleString();
        window.setTimeout("tick()", 1000);
    }
    </script>
</head>
<body onload="showTimeDate(); tick();">
    <form id="form1" runat="server">
 <div id="header" style="z-index: 1">
<div id="siteNav">
<img alt="" src="images/inde-logo.jpg" width="150" height="69" /></div>
<div id="siteNav1">
<img  alt="" src="images/inde-logo1.gif" width="100%" height="69" /></div>
</div>
<div id="header1">
<div id="headertext">
    <span id="showTime"></span>  <%=UserName %>&nbsp; |&nbsp; 当前时间：<span id="showTick"></span> &nbsp; |&nbsp; <a title="安全退出" style="color:#fff; font-weight:bold" href="exit.aspx">安全退出</a></div>
</div>
</form>
</body>
</html>
