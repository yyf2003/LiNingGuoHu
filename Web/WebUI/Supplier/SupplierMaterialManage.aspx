<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierMaterialManage.aspx.cs" Inherits="WebUI_Supplier_SupplierMaterialManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>供应商材料管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/screen.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>
<%--    <script type="text/javascript" language="javascript" src="../../js/jquery.corner.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/jquery-impromptu.2.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../js/common.js"></script>--%>
    <script language="javascript" type="text/javascript" src="./javascript/SupplierMaterial.js"></script>
    <script language="javascript" type="text/javascript" src="./javascript/AddSupplierMaterial.js"></script>
	<script type="text/javascript" language="javascript">
        function showDIV(id,showID)
        {
            var spanID = $("#"+id);
            var tdID = $("#"+showID); 
            if(spanID.html() == "修改")
            {
                tdID.show();
                spanID.html("隐藏");
            }
            else
            {
                tdID.hide();
                spanID.html("修改");
            }
        }
        var id = '<%= UserID%>' ;
        var pagesize = 20;
        $(function(){
            getListMode(id,1,pagesize)
        });
        
        //分页显示材料列表
        function getListMode(ID,pageCurrent,pageSize)
        {
            var getListPage = new GetSupplierMaterial(id,pageCurrent,pageSize);
            getListPage.getList(pageCurrent,pageSize);
        }
        
        function FocusMaterialName(){$("#txtAddMaterial").focus();}
        
        //添加材料信息
        function AddMaterial(UserID,MaterialName,cltype)
        {
        
          
           if(MaterialName == "")
            {
                alert('请输入材料名称！！');
                 return false;
            }
          if(cltype=="-1")
            {
               alert('请选择材料支持类型！！');
                 return false;
            }
         
             $("#showPrompt").css("display","block");
             var getResult = new AddSupplierMaterial();
             getResult.Add(UserID,MaterialName,cltype);
        
        }
        
        //修改材料信息
        function UpdateMaterial(mID,MaterialName)
        {
            if(MaterialName != "")
            {
                $("#showPrompt").css("display","block");
                var getResult = new AddSupplierMaterial();
                getResult.Update(mID,MaterialName);
            }
            else
            {
                 alert('请输入材料名称！！');
                 return false;
            }
        }
        
        //修改材料状态
        function IsDelete(mID,IsDe)
        {
            if(window.confirm("是否修改其状态") == true)
            {
                $("#showPrompt").css("display","block");
                var getResult = new AddSupplierMaterial();
                getResult.IsDelete(mID,IsDe);
            }
        }
    </script>
</head>
<body >
<form id="form1" action="">
    <div style="width:100%; height:auto; text-align:center">
    <div style=" font-size:14px; font-weight:bold; text-align:left; padding-left:20px; width:50%;float:left; height:30px;color: #c86000;"><a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>  &gt;&gt; 材料管理</div>
    <div style="width:900px; text-align:left; float:left; margin-left:20px;font-size:12px;">
        添加供应材料：<input id="txtAddMaterial" type="text" style="width:20%" />材料支持类型：<select
            id="ddl_type" name="ddl_type" style="width: 170px">
            <option selected="selected" value="-1">请选择材料支持类型</option>
            <option value="0">不支持安装的店铺使用</option>
            <option value="1">支持安装店铺使用</option>
            <option value="2">通用材质</option>
        </select>
        <input id="btnAdd" type="button" value="添   加" onclick='AddMaterial(<%= UserID%>,$.trim($("#txtAddMaterial").val()),$.trim($("#ddl_type").val()))' />&nbsp;&nbsp;&nbsp;&nbsp;
        <span id="showPrompt" style=" display:none; margin-top:-20px; float:right">正在操作，请稍等。。。。。。</span><a href="../Analysis/daochu.aspx?dtname=MaterPro">导出材料数据</a>
    </div>
    <div id="showMaterialList" style="width:900px; float:left; margin-left:20px"></div>
	<div id="HyperLinkPage" style="width:900px; float:left;margin-top:10px; text-align:right; padding-right:10px; margin-left:20px"></div>
    </div>
</form>
</body>
</html>
