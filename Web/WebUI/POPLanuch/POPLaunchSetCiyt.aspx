<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPLaunchSetCiyt.aspx.cs" Inherits="WebUI_POPLanuch_POPLaunchSetCiyt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>无标题页</title>
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />

    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../js/jquery.min.js" type="text/javascript"></script>        
    <script language="javascript" src="JavaScript/allotArea.js" type="text/javascript"></script>
    <script language="javascript"  src="JavaScript/POPSetCity.js"  type="text/javascript"></script>

    <script language="javascript" type="text/javascript" src="../../js/ShowDIV.js"></script>
    <style type="text/css">
        .divcss{
            font-family:Arial;font-size:12px;width:97%; border:1px solid #6d6060;background-color:#fdf6f6; padding-left:20px; padding-top:10px; margin-top:10px;
        }
         .divstype{ width:100%; font-weight:bold; background-color:InactiveCaption;font-size:13px}
        .style1
        {
            height: 34px;
        }
    </style>

    <script type="text/javascript" language="javascript">
    function check()
    {
    if(!checkdata())
       {
          return false;
       }

     return confirm('确认提交?');
    }
    </script>
    

</head>
<body>
    <form method="post" action="POPLaunchSetCiyt_do.aspx?POPID=<%=POPID %>" id="form1" name="form1">
    <div>
        <div style="font-size: 14px; color: Red">
        设置POP发起周期--》 <a href="POPLaunchTwo.aspx?POPID=<%=POPID %>" style="color: Red">POP产品系列图样上传</a>--》<a
            href="POPImgSet.aspx?POPID=<%=POPID %>" style="color: Red">图样设置</a></div>
        <br />
        <div style="width: 100%; text-align: left; font-size: 14px">
            设置POP更换城市（方式一：<a href='#' onclick="javascript:ShowDIV('30%','30%','700px','50px','500px','[导入店铺]','ShopsImport.aspx?POPID=<%=POPID %>')">导入店铺）</a></div>
        <br />

        <div style="width: 100%; text-align: left; font-size: 14px">
            设置POP更换城市（方式二：限定方式）</div>
        <br />
        
    	<table class="table">
			<tr>
				<td style="width:20%; text-align:right">POP发起ID：</td>
				<td style="width:800px">&nbsp;<%=POPID %></td>

			</tr>

			<tr>
				<td style="text-align:right">店铺零售属性：</td>
				<td><div id="saname"><asp:Literal ID="Literal_ShopSA" runat="server"></asp:Literal></div></td>

			</tr>
			<tr>
				<td style="text-align:right" class="style1">店铺级别：</td>
				<td class="style1"><div id="levelname"><asp:Literal ID="Literal_Shoplevel" runat="server"></asp:Literal></div></td>

			</tr>
			<tr>
			  <td style="text-align:right">店铺类型：</td>
			  <td><div id="div_shoptype">
                  <asp:Literal ID="Lit_shoptype" runat="server"></asp:Literal></div></td>
			</tr>
			<tr>
			  <td style="text-align:right">店铺形象属性：</td>
			  <td><div id="div_shopVI">
                  <asp:Literal ID="Lit_shopVI" runat="server"></asp:Literal></div></td>
			</tr>
			<tr>
			  <td style="text-align:right">地市级城市级别-市场定义：</td>
			  <td><div id="div_shopTCL">
                  <asp:Literal ID="Lit_TCL" runat="server"></asp:Literal></div></td>
			</tr>
			<tr>
			  <td style="text-align:right">区县级城市级别-市场定义：</td>
			  <td><div id="div_shopACL">
                  <asp:Literal ID="Lit_ACL" runat="server"></asp:Literal></div></td>
			</tr>
			<tr>
			  <td style="text-align:right">历史POP发起名称：</td>
			  <td>
                  <asp:Literal ID="Lit_POPID" runat="server"></asp:Literal></td>
			</tr>
			<tr>
			  <td style="text-align:right">所包含的画面编号：</td>
			  <td><div id="imgDIV" style="font-family:Arial;font-size:12px;width:97%; padding-left:10px; padding-top:10px;">
                  <asp:Literal ID="Lit_POPImageData" runat="server"></asp:Literal></div></td>
			</tr>


			
			<tr>
			<td colspan="2">
			
			<div>
		<div id="areadiv" class="divcss"><span style="font-weight:bold"><input value="全选" name="AllArea" id="AllArea" onclick="" type="checkbox" />区域：</span><asp:Literal ID="Lit_Area" runat="server"></asp:Literal></div>
		<div id="pro" class="divcss" style="display:none"><span style="font-weight:bold"><input value="全选" name="AllProvince" id="AllProvince" type="checkbox" />省&nbsp;&nbsp;份：</span><br /><asp:Literal ID="Lit_province" runat="server"></asp:Literal>
            <br /><br /></div>
		<!--<div id="citytable" class="divcss" style="display:none"><span style="font-weight:bold">地级城市：<input id="Checkall" name="Checkall"
                type="checkbox" />全选</span><br /><asp:Literal ID="Lit_city" runat="server"></asp:Literal><br /><br /></div>-->
		<!--<div id="towntable" class="divcss" style="display:none"><span style="font-weight:bold">区县级城市：</span><br /><asp:Literal ID="Lit_town" runat="server"></asp:Literal><br />
		
		<br /></div>-->
		<span style="text-align:right; font-size: 14px; color: #0033ff; text-decoration: underline; cursor:hand; float:right"  onclick="GetselctShop();">
            <input type="text"  name="HF_shopid"  style="display:none" id="HF_shopid" />
            查看所选择的店铺</span>
		<div class="divcss" style=" text-align:center; height:30px;"><input onclick="return check();" type="submit" value="保 存" class="qr0" id="Submit1"/>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<input onclick="if(confirm('确认发起完成')){location.href='POPlaunchEdit.aspx'}" type="button" value="发起完成" class="qr0"/></div>
	</div>
			
			</td>
			</tr>

		</table>
        
    </div>
</form>
<script language="javascript" type="text/javascript">
	<!--    
$(function() {    
    $("#AllArea").click(function() {    
	    if ($(this).attr("checked") == true) { // 全选    
		    //$(":checkbox").each( function() { //可以对.net服务器控件有效    
		    $("input[@name='area']").each(function() {    
			    $(this).attr("checked", true);
			    $('#pro')[0].style.display='';
			    var divlist= $("#pro div").get();
			    for(var i=0;i<divlist.length;i++)
			    {
				    divlist[i].style.display='';
			    }
		    });
	    } 
	    else { // 取消全选    
		    //$(":checkbox").each( function() { //可以对.net服务器控件有效    
		    $("input[@name='area']").each(function() {    
			    $(this).attr("checked", false);
			    $('#pro')[0].style.display='none';
			    var divlist= $("#pro div").get();
			    for(var i=0;i<divlist.length;i++)
			    {
				    divlist[i].style.display='none';
			    }

		    });    
	    }
	     $("#AllProvince").attr("checked",false);
	     $("input[@name='province']").each(function() {    
			    $(this).attr("checked", false);
		 });

    }); 

    $("#AllProvince").click(function(){
        if ($(this).attr("checked") == true) { // 全选    
		    //$(":checkbox").each( function() { //可以对.net服务器控件有效
		    var divlist= $("#pro div").get();
		    for(var i=0;i<divlist.length;i++)
		    {
		        if(divlist[i].style.display=='' || divlist[i].style.display=='block')
		        {
		            var showid = "#"+divlist[i].id+ " input[@name='province']";
		            $(showid).each(function(){
		                $(this).attr("checked", true);
		            });
		        }
		    }
	    }
	    else
	    {
	         $("input[@name='province']").each(function() {    
			    $(this).attr("checked", false);
		     });
	    }
    
    });
});    
//-->  
</script>
</body>
</html>
