<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaterialInfo.aspx.cs" Inherits="WebUI_Supplier_MaterialInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>材料明细</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script language="javascript" type="text/javascript" src="./javascript/MaterialInfo.js"></script>
    <script type="text/javascript" language="javascript">
        var id = '<%= UserID%>' ;
        var pagesize = 20;
        $(function(){
            getListMode(id,1,pagesize)
        });
        
         //分页显示材料列表
        function getListMode(ID,pageCurrent,pageSize)
        {
            var getListPage = new MaterialInfo(id,pageCurrent,pageSize);
            getListPage.getList(pageCurrent,pageSize);
        }
    </script>
</head>
<body >
<form id="form1">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;">材料明细</div>

    <div id="showMaterialList" style="width:900px; float:left; margin-left:20px"></div>
	<div id="HyperLinkPage" style="width:900px; float:left;margin-top:10px; text-align:right; padding-right:10px; margin-left:20px"></div>
    </div>
</form>
</body>
</html>
