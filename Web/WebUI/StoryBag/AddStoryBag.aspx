<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddStoryBag.aspx.cs" Inherits="WebUI_StoryBag_AddStoryBag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>添加产品系列</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.min.js" ></script>
    <script language="javascript" type="text/javascript" src="./javascript/SearchStoryBagList.js"></script>
    <script language ="javascript" type="text/javascript">
        var pagesize = 20;
	    $(function(){
	        getTypeName();
		    getListMode(1,pagesize);
	    });
        
        //分页显示材料列表
        function getListMode(pageCurrent,pageSize)
        {
            var getListPage = new GetStoryBagList();
            getListPage.getList(pageCurrent,pageSize);
        }
        
        //绑定故事包品类
        function getTypeName()
        {
            var getListPage = new GetStoryBagList();
            getListPage.GetTypeList();
        }
        
        //添加故事包品类
        function AddTypeName()
        {
            var getListPage = new GetStoryBagList();
            getListPage.AddTypeName();
        }
        
        //添加故事包信息
        function AddProductLine()
        {
            var getListPage = new GetStoryBagList();
            getListPage.AddProductLine();
        }
       
    </script>
    <style type="text/css">
        a{ text-decoration:none; }
	    .datalist tr.altrow{background-color:#a5e5aa;	/* 隔行变色 */}
	    td{background-color:white;}
    </style>
</head>
<body >
<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;"><a href="StoryBagManage.aspx" title="直属客户查询管理" style="color: #c86000;">产品系列管理</a>  &gt;&gt; 添加产品系列 </div>
		<table class="table" style="margin-top:20px; margin-left:5%; width: 85%;">
			<tr>
				<td style="width:15%; text-align:right">所属品类：</td>
				<td>
					<div style="float:left; width:30%;height: 26px;">
						<select id="ddlTypeName" class="txtwith" style=" width:100%;">
					        <option value="0">请选择产品大类</option>
					    </select>
				    </div>
				    <div style="float:left; width:65%; margin-left:20px; height: 26px;">
				    	<div style="float:left; "><a href="#" onclick="javascript: document.getElementById('ShowAdd').style.display='block'">添加产品大类</a></div>
				    	<div id="ShowAdd" style="float:left; width:60%; margin-left:20px; display:none">
				    		<input id="txtTypeName" type="text"  class="txtwith"  style=" width:50%;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				    		<input id="btnAdd" type="button" value="添加产品大类" class="qr0" onclick="AddTypeName();" />
				    	</div>
				    	<div id="showMessage" style="float:right;"></div>
				    </div>
				</td>
			</tr>
			<tr>
				<td style="text-align:right; width: 11%;">产品系列名称：</td>
				<td>&nbsp;<input id="txtPName" type="text" class="txtwith"  style=" width:30%"/></td>
			</tr>
            
			<tr>
				<td style="text-align:center; height:40px;" colspan="2">
					<input id="Btn_search" type="button"  class="qr0" value="添    加"  onclick="AddProductLine();"/>
				</td>
			</tr>
		</table>
	</div>
	<br />
	<div id="fillTable" style="margin-top:20px; margin-left:5%;width:85%"></div>
	 <div id="HyperLinkPage" style="margin-top:20px; text-align:right; padding-left:10px; width:75%; font-size:12px; margin-left:5%"></div>
</body>
</html>
