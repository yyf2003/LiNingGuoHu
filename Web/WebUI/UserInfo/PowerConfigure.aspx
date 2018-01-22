<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PowerConfigure.aspx.cs" Inherits="WebUI_UserInfo_PowerConfigure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>权限分配设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/dtree.css" rel="StyleSheet" type="text/css" />
	<script type="text/javascript" language="javascript" src="../../js/dtree.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="./Javascript/GetRoleList.js"></script>
    <script type="text/javascript" language="javascript">
        var getList = new GetRoleListJS();
        $(function(){
            getList.GetList();
            getList.GetRolePageList(1);
        });
        
</script>
</head>
<body >
    <form id="form1">
    <div style="width:100%; height:auto; text-align:center">
        <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px;color: #c86000;">用户权限分配</div>
        <div id="roleList" style="border:2px solid #6d6060; width:17%; text-align:left; line-height:30px; float:left; margin-left:40px; margin-top:30px; padding-top:10px; padding-left:30px;">
            <img src="../../images/loading.gif" style=" border:0;" />&nbsp;&nbsp;正在加载权限，请稍后......
        </div>
	    <div id="FunctionList" style="border:2px solid #6d6060; text-align:left; width:45%; float:left; margin-left:20px; margin-top:30px; padding-top:20px; padding-left:20px;">
            <div id="showWait" style="text-align:left; display:none"><img src="../../images/loading.gif" style=" border:0;" />&nbsp;&nbsp;正在加载功能列表，请稍后.....</div>
        </div>
        <div id="operate" style=" width:50%; text-align:left; line-height:30px; padding-top:10px; margin-left:30%; float:left">
            <input id="btnSubmit" type="button" value="确 定" class="qr0" onclick="getList.SubmitRolePage()" />
        </div>
    </div>
    </form>
</body>
</html>
