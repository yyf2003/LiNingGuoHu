<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OneDealerInfo.aspx.cs" Inherits="WebUI_DealerInfo_OneDealerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看一级客户信息 </title>
    <link rel="stylesheet" media="all" type="text/css" href="../../css/screen.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/examples.css" />
    <link rel="stylesheet" media="all" type="text/css" href="../../css/TableCss.css" />


</head>
<body style="  font-size: 12px;
    background-position: center bottom; background-repeat: no-repeat">
    <form id="form1" runat="server">
        <div style="width: 90%">
            <div style="font-size: 14px; font-weight: bold; text-align: left; padding-left: 20px;
                color: #c86000;">
                <a href="DealerList.aspx" title="一级客户管理" style="color: #c86000;">一级客户管理</a> &gt;&gt;
                查看一级客户信息</div>
            <table class="table" style="margin-top: 20px; margin-left: 5%">
                <tr>
                    <td style="width: 15%">
                        一级客户编号：</td>
                    <td style="width: 35%; text-align: left">
                        <%#DealerID %>
                    </td>
                    <td>
                        一级客户名称：</td>
                    <td style="text-align: left">
                        <%#DealerName %>
                    </td>
                </tr>
                <tr>
                    <td>所属部门：
                        </td>
                    <td align="left">
                       <%#Department%>
                    </td>
                    <td>所在省区：
                        </td>
                    <td align="left">
                         <%#Areaname%>
                    </td>
                </tr>
                <tr>
                    <td>所在省市：
                        </td>
                    <td align="left">
                        <%#Provincename%>
                    </td>
                    <td>所在市区：
                       </td>
                    <td align="left">
                       <%#Cityname%>
                    </td>
                </tr>
                <tr>
                    <td> 联系人：
                        </td>
                    <td align="left">
                        <%#Contactor %>
                    </td>
                    <td>
                        联系电话：</td>
                    <td align="left">
                        <%#ContactorPhone %>
                    </td>
                </tr>
                <tr>
                    <td>
                        邮政地址：</td>
                    <td align="left">
                        <%#PostAddress %>
                    </td>
                    <td>
                        </td>
                    <td align="left">
                       
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input id="Button2" type="button" value="返回" class="qr0" onclick="javascript:if(window.history.length==0) window.close();else window.history.back();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
