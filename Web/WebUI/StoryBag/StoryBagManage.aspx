<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoryBagManage.aspx.cs" Inherits="WebUI_StoryBag_StoryBagManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>故事包管理</title>
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
       
    </script>
    <style type="text/css">
        a{ text-decoration:none; }
	    .datalist tr.altrow{background-color:#a5e5aa;	/* 隔行变色 */}
	    td{background-color:white;}
    </style>
</head>
<body >
<div style="width:90%">
		<div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">产品系列管理</div>
		<table class="table" style="margin-top:20px; margin-left:5%">
			<tr>
				<td style="width:15%;text-align:right">产品系列名称：</td>
				<td style="width:30%;">&nbsp;<input id="txtPName" type="text" class="txtwith" /></td>
				<td style="width:15%;text-align:right">所属产品大类：</td>
				<td>&nbsp;
				    <select id="ddlTypeName" class="txtwith">
				        <option value="0">请选择产品大类</option>
				    </select>
				</td>
			</tr>

			<tr>
				<td style="text-align:center; height:40px;" colspan="4">
					<input id="Btn_search" type="button"  class="qr0" value="查 询"  onclick="getListMode(1,20)"/>
				</td>
			</tr>
		</table>
	</div>
	<br />
	<div id="fillTable" style="margin-top:20px; margin-left:5%;width:85%"></div>
	 <div id="HyperLinkPage" style="margin-top:20px; text-align:right; padding-left:10px; width:75%; font-size:12px; margin-left:5%"></div>
</body>
</html>
