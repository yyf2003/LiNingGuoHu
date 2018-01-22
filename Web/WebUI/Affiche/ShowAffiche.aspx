<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAffiche.aspx.cs" Inherits="WebUI_Affiche_ShowAffiche" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=gb2312" />
    <title><%#AfficheTitle %>---公告</title>
    <link href="http://js1.pp.sohu.com.cn/ppp/blog/themes_ppp/def/style.css" type="text/css"
        rel="stylesheet">
    <link href="../../CSS/ModelStyle.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
window.isIE = document.all?true:false;
//	window.isIE7 = (navigator.userAgent.indexOf("MSIE 7")>-1);
window.isIE7 = (window.isIE && window.XMLHttpRequest);
    </script>

 

    <script>
 
 
   window.onload = function() { 
  
    for (var index = 0; index < document.images.length; index++) { 
  
        var widthRestriction = 720; //定义缩放的宽
        var heightRestriction = 500; 
        var rate = document.images[index].width / document.images[index].height; 
  
        if (document.images[index].width > widthRestriction) { 
            document.images[index].width = widthRestriction; 
            document.images[index].height = widthRestriction / rate; 
              document.images[index].onclick = function() {window.open(this.src)}; 
              document.images[index].title = document.images[index].title + ' 点击在新窗口中查看原图'; 
        } else if (document.images[index].height > heightRestriction) { 
            document.images[index].height = heightRestriction; 
            document.images[index].width = heightRestriction * rate; 
              document.images[index].onclick = function() {window.open(this.src)}; 
        document.images[index].title = document.images[index].title + ' 点击在新窗口中查看原图'; 
        } 
  
      
    } 
}
   
 
    </script>

    <style>
.previewStyle {
	width:720px;
	border-left:1px solid #ccc;
	border-right:1px solid #ccc;
	border-bottom:1px solid #ccc;
	padding:20px;
	background-color:#fff;
}

.PreviewTitleStyle {
	background-image:url(../image/affiche/bg.png);
	width:100%;
	height:30px;
	text-align:center;
}

.PreviewTitleLeft {
	width:150px;
	float:left;
	font-size:14px;
	font-weight:bold;
	text-align:center;
	padding-top:4px;
}

.PreviewTitleRight {
	width:150px;
	float:right;
	text-align:center;
	padding-top:4px;
}

input.button-submit {
	color: white;
	height: 20px;
	line-height: 18px;
	padding: 0px 5px 0px;
	background-color: #F03309;
	border: 1px solid #cecece;
	cursor: pointer;
}

</style>
<script >
 function Zoom(size)
{
  document.getElementById ("contentEle").style .fontSize =size+"px";
} 
</script>
</head>
<body>
    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolor="#D6D6D6"
        style="border-collapse: collapse">
        <tr class="DgHead">
            <td align="left" style="font-weight: bold; font-size: 14px">
                <img src="../../Images/func_arrowDown.gif" style="width: 22px; height: 11px" />查看公告&nbsp;
            </td>
        </tr>
    </table>
    <div class="PreviewTitleStyle">
        <div class="PreviewTitleLeft">
        </div>
        <div class="PreviewTitleRight">
            <input name="Submit" type="button" value="打印公告" onclick="window.print();" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="previewStyle">
        <div class="item-title">
            <h3 id="titleEle" style="width: 500px">
                <%#AfficheTitle %>
            </h3>
            <div style="width: 520px; text-align: right;">
                发布人：<%#AfficheUser %>
                &nbsp;发布时间：<%#AfficheTime  %>&nbsp;字体：【<a href ="#" onclick ="Zoom('16')">大</a>&nbsp;<a href ="#" onclick ="Zoom('14')">中</a>&nbsp;<a href ="#" onclick ="Zoom('10')">小</a>】&nbsp;<a href='#' onclick="javascript:window.location='index.aspx';"
                    title='点击返回' style="color: Red; padding-left: 12px; font-weight: bold;">返回</a>
            </div>
        </div>
        <br />
        <div class="item-content" id="contentEle">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <br />
            <%#Maintxt %>
        </div>
    </div>
</body>
</html>