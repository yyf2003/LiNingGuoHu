<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POPlaunchEdit.aspx.cs" Inherits="WebUI_POPLanuch_POPlaunchEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
 <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:20px">
    <div style="width:900px;font-size:14px; font-weight:bold; text-align:left; float:left; color: #c86000;">POP发起列表</div>
    <br />
    <br />

        <table class="table">
        <tr>
        <th style="width:120px">发起ID</th><th style="width:15%">主题</th><th style="width:60px">起始时间</th><th style="width:60px">结束时间</th><th  style="width:200px">产品系列</th><th style="width:50px">查 看</th><th style="width:50px">继续上传图片</th><th style="width:50px">更换范围变更</th><th style="width:50px">供应商供应区域</th></tr>

        <tr>
         <td><%=POPID %></td><td><%=POPTitle %></td><td><%=BeginDate %></td><td><%=EndDate%></td><td><%=ProductLineDatas%></td>
         <td><a href="POPDetail.aspx?POPID=<%=POPID %>&POPpro=<%=ProductUrl%>">查看详细</a></td>
         <td><a href="POPLaunchTwo.aspx?POPID=<%=POPID%>">继续上传</a></td>
         <td><a href="POPLaunchSetCiyt.aspx?POPID=<%=POPID%>">变更区域</a></td>
         <td><a href="../Supplier/SupplierListByVM.aspx">分配区域</a></td>
        </tr>

        </table>

    </div>
    </form>
</body>
</html>
