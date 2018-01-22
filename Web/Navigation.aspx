<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Navigation.aspx.cs" Inherits="Navigation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>李宁POP管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <style type="text/css">

*{ margin:0; padding:0;}
html, body, p, ul, ol, dl, li, dt, dd, h1, h2, h3, h4, h5, h6,tr,td{margin: 0;padding: 0;position: static;}
html {background-color: #080808; color: #080808;}
img{border:none;}
a{color:#ffffff; text-decoration:none;}
a:hover{}
ul, ol,li {list-style: none;}
.mag{ font-size:11px;}
body{ font-family: Arial, Helvetica, sans-serif,"宋体" ; color:#FFF; font-size:12px; line-height:18px; }


</style>
    <link href="CSS/pop.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.1.min.js"></script>

    <script src="js/jquery.d.imagechange.min.js"></script>

    <script type="text/javascript" language="javascript">
    function OpenLoginWindow(ConnStr)
    { 
        
        $.get("./WebUI/ashx/SetConnStr.ashx",{ConnStrName:ConnStr,num: Math.random()},function(data){
            if(data !="")
            {            
                window.location = "Login.aspx";
            }
        }); 
    }
    </script>

</head>
<body bgcolor="#080808">
    <!-- Save for Web Slices (未命名.psd - Slices: 03, 06, bottom, denglu, lefttu, lining, rightu, top) -->
    <div style="margin: 0 auto; width: 1186px;">
        <table id="__01" width="1186" border="0" cellpadding="0" cellspacing="0" align="center"
            style="vertical-align: top;">
            <tr>
                <td colspan="4" style="background: url(images/lining.jpg) no-repeat; width: 1186px;
                    height: 70px;">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background: url(images/top.jpg) no-repeat; width: 1186px;
                    height: 37px;">
                </td>
            </tr>
            <tr>
                <td style="background: url(images/pop_03.jpg) no-repeat; width: 68px; height: 353px;">
                </td>
                <td style="width: 993px; height: 353px;">
                    <img alt="" class="pic" id="oDIV1" style="width:993px; height:353px;BORDER-RIGHT: white 1px solid; BORDER-TOP: white 1px solid; BORDER-LEFT: white 1px solid; BORDER-BOTTOM: white 1px solid" src="images/navigation.jpg" border="0" />
                    <%--<div id="pic1" style="width: 993px; height: 353px; border-right: white 1px solid;
                        border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
                    </div>--%>
                </td>
                <td style="background: url(images/pop_06.jpg) no-repeat; width: 125px; height: 353px;">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background: url(images/denglu.jpg) no-repeat; width: 1186px;
                    height: 84px;  ">
                    <ul class="nav_1" >
                        <li style="margin-left:310px;"><a href="javascript:OpenLoginWindow('ConnectionString');">常规店</a></li>
                        <li><a href="javascript:OpenLoginWindow('FOS_ConnectionString');">FOS</a></li>
                        <%--<li><a href="javascript:OpenLoginWindow('NewRebate_ConnectionString');">新折扣店</a></li>
                        <li><a href="javascript:OpenLoginWindow('Rebate_ConnectionString');">折扣店</a></li>
                        <li><a href="javascript:OpenLoginWindow('Fashion_ConnectionString');">时尚店</a></li>
                        <li><a href="javascript:OpenLoginWindow('MiniShoe_ConnectionString');">迷你鞋店</a></li>--%>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background: url(images/bottom.jpg) no-repeat; width: 1186px;
                    height: 145px; vertical-align: top;">
                    <div style="margin: 35px 0 0 523px; font-size: 14px; font-weight: bold;">
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">

// 需要你写的数据
var data = [
	{title:'',desc:'',src:'images/Login/2011926/banner.jpg'},
	{title:'',desc:'',src:'images/Login/2011926/Z-1.jpg'},
	{title:'',desc:'',src:'images/Login/2011926/ZT-1.jpg'}
];
	
$(document).ready(function(){
	$('#pic1').d_imagechange({
		data:data,
		playTime:3000,
		animateStyle:'show-y',//默认值'o',可以不写	
		width:993,
		height:353,
		bg:false, 
		title:false, 
		desc:false, 
		btn:false, 
		btnText:false  
	});
	
});



    </script>

    <!-- End Save for Web Slices -->
</body>
</html>
