<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupplierArea.aspx.cs" Inherits="WebUI_Supplier_SupplierArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>指定供应商详细信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/TableCss.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/showDIV.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../../js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="./javascript/GetSupplierAssignRecord.js"></script>

    <script type="text/javascript" language="javascript" src="../../js/ShowDIV.js"></script>

    <script type="text/javascript" language="javascript">
        var id = '<%= SupplierID%>' ;
        var pagesize = 15;
        $(function(){
            getListMode(id,1,pagesize)
        });
        
        function getListMode(ID,pageCurrent,pageSize)
        {
            var getListPage = new GetSupplierAssignRecord(id,pageCurrent,pageSize);
            getListPage.getList(pageCurrent,pageSize);
        }
    </script>

</head>
<body style=" font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; text-align: center">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                width: 50%; float: left; height: 30px; color: #c86000;">
                <a href="SupplierList.aspx" title="供应商管理" style="color: #c86000;">供应商管理</a>
                <%= " &gt;&gt; " + SupplierName%>
            </div>
            <div style="float: left; width: 30%; height: 30px; text-align: right">
                <asp:HyperLink ID="hyLink" Visible="false" runat="server">重新分配区域</asp:HyperLink></div>
            <table class="table" style="margin-top: 20px; color: navy; float: left; margin-left: 5%">
                <tr>
                    <td style="height: 30px; width: 20%; font-weight: bold">
                        供应商名称:</td>
                    <td style="width: 40%">
                        <%= SupplierName%>
                    </td>
                    <td style="width: 20%; font-weight: bold">
                        负责人:</td>
                    <td>
                        <%= Contacter%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; font-weight: bold">
                        邮政地址:</td>
                    <td style="height: 30px;">
                        <%= PostAddress%>
                    </td>
                    <td style="height: 30px; font-weight: bold">
                        邮政编码:</td>
                    <td style="height: 30px;">
                        <%= PostCode%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; font-weight: bold">
                        联系电话:</td>
                    <td style="height: 30px;">
                        <%= ContactPhone%>
                    </td>
                    <td style="height: 30px; font-weight: bold">
                        联系人职位:</td>
                    <td style="height: 30px;">
                        <%= ContacterRole%>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px; width: 20%; font-weight: bold">
                        备注：</td>
                    <td style="height: 30px; text-align: left" colspan="3">
                        <%= Remarks%>
                    </td>
                </tr>
            </table>
            <div id="showOrderList" style="width: 900px; float: left; margin-left: 5%; margin-top: 20px;">
            </div>
            <div id="HyperLinkPage" style="width: 900px; margin-top: 10px; text-align: right;
                padding-right: 10px; float: left; margin-left: 5%;">
            </div>
        </div>
    </form>
</body>
</html>
